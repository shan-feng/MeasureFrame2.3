using AcqDevice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Drawing;

namespace Measure
{
    [Serializable]
    public class CRoteCenterCalib : CMeasureCell
    {
        public CRoteCenterCalib()
            : base()
        {
            DTCoord = BuidTable();
        }

        public CRoteCenterCalib(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
            DTCoord = BuidTable();
        }

        public int AcqUnitID { get; set; }

        /// <summary>
        /// 采集设备ID
        /// </summary>
        private string _DeviceID;
        [NonSerialized]
        public AcqAreaDeviceBase AcqDevice;

        public string DeviceID
        {
            set
            {
                _DeviceID = value;
                AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
            }
            get { return _DeviceID; }
        }
        /// <summary>
        /// 机械坐标系转换关系参考单元
        /// </summary>
        public int iCalibCoordID = -1;

        /// <summary>
        /// 拟合旋转点坐标列表，拟合旋转中心
        /// </summary>
        public DataTable DTCoord
        { get; set; }

        /// <summary>
        /// 是否表定过
        /// </summary>
        [NonSerialized]
        public bool Calibrated;
        /// <summary>
        /// 机械旋转中心
        /// </summary>
        public PointF MachinePoint { get; set; }
        /// <summary>
        /// 旋转中心世界坐标
        /// </summary>
        public PointF WorldPoint { get; set; }

        private DataTable BuidTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("相机行坐标", Type.GetType("System.Double"));
            dt.Columns.Add("相机列坐标", Type.GetType("System.Double"));
            return dt;
        }
        public override void Execute(bool blnByHand = false)
        {
            if (Calibrated)
            {
                Calibrated = true;
                return;
            }
            try
            {
                double[] row = DTCoord.AsEnumerable().Select(r => r.Field<double>("相机行坐标")).ToArray();
                double[] col = DTCoord.AsEnumerable().Select(r => r.Field<double>("相机列坐标")).ToArray();
                HXLDCont xld = new HXLDCont(new HTuple(row), new HTuple(col));
                double Row, Column, Radius, StartPhi, EndPhi;
                String PointOrder;
                xld.FitCircleContourXld("algebraic", -1, 0, 0, 3, 2, out Row, out Column, out Radius, out StartPhi, out EndPhi, out PointOrder);

                F_DATA_CELL data = m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == iCalibCoordID && c.m_Data_Name == ConstVavriable.outHomMat2D);
                HHomMat2D homMat2D = ((List<HHomMat2D>)data.m_Data_Value)[0];
                double x, y;
                x = homMat2D.AffineTransPoint2d(Column,Row,  out y);
                WorldPoint = new PointF((float)x, (float)y);
                homMat2D = new HHomMat2D();
                homMat2D.VectorAngleToRigid(MachinePoint.X, MachinePoint.Y, 0.0, WorldPoint.X, WorldPoint.Y, 0f);
                F_DATA_CELL dataMat2D = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.位置转换2D, ConstVavriable.outHomMat2D
                    , "机械坐标到世界坐标转换", "0", 1, new List<HHomMat2D>() { homMat2D }, DataAtrribution.全局变量);
                m_Owner.UpdateVariableValue(dataMat2D);
                Calibrated = true;
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                Calibrated = false;
                blnSuccessed = false;
            }
        }
        //[OnDeserialized()]
        //internal void OnDeSerializedMethod(StreamingContext context)
        //{
        //    AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
        //    if (AcqDevice == null)
        //        MessageBox.Show("单元U " + m_CellID + "中采集设备" + DeviceID + "不存在，请重新绑定");
        //}
    }
}
