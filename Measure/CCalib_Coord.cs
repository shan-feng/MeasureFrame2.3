using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Data;
using AcqDevice;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Measure
{
    /// <summary>
    /// 坐标标定，机械坐标和相机坐标统一
    /// </summary>
    [Serializable]
    public class CCalib_Coord : CMeasureCell
    {
        public CCalib_Coord()
            : base()
        {
            m_DTCoord = BuidTable();
            m_DTCoordSingle = BuidSingleTable();
        }
        public CCalib_Coord(CellCatagory _CellCatagory, int _CellID)
            : base(_CellCatagory, _CellID)
        {
            m_DTCoord = BuidTable();
            m_DTCoordSingle = BuidSingleTable();
        }

        /// <summary>
        /// 轴个数=CaliAxisCount+1
        /// </summary>
        private int iCaliAxisCount = 0;
        public int CaliAxisCount
        {
            get { return iCaliAxisCount; }
            set { iCaliAxisCount = value; }
        }
        /// <summary>
        /// 采集设备ID
        /// </summary>
        private string _DeviceID;
        [NonSerialized]
        public AcqAreaDeviceBase AcqDevice;


        public int AcqUnitID { get; set; }
        public string DeviceID
        {
            set
            {
                _DeviceID = value;
                AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == _DeviceID);
            }
            get { return _DeviceID; }
        }
        public DataTable m_DTCoordSingle
        { get; set; }
        public DataTable m_DTCoord
        { get; set; }

        /// <summary>
        /// 坐标变换
        /// </summary>
        public HHomMat2D m_homMat2D = new HHomMat2D();
        /// <summary>
        ///单轴标定时相机和X轴的夹角
        /// </summary>
        public double PhiSingle = 0.0;

        /// <summary>
        /// 单轴标定，是否移动x轴 true 为x轴移动，false y轴移动
        /// </summary>
        public bool blnXSingle = false;

        public bool blnRbootMode = false;
        /// <summary>
        /// 是否标定过
        /// </summary>
        [NonSerialized]
        public bool m_Calibrated = false;

        private DataTable BuidSingleTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("相机行坐标", Type.GetType("System.Double"));
            dt.Columns.Add("相机列坐标", Type.GetType("System.Double"));
            return dt;
        }

        private DataTable BuidTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("机械X坐标", Type.GetType("System.Double"));
            dt.Columns.Add("机械Y坐标", Type.GetType("System.Double"));
            dt.Columns.Add("相机行坐标", Type.GetType("System.Double"));
            dt.Columns.Add("相机列坐标", Type.GetType("System.Double"));
            return dt;
        }

        /// <summary>
        /// 位置标定
        /// </summary>
        public override void Execute(bool blnByHand = false)
        {
            if (m_Calibrated)
            {
                m_Calibrated = true;
                return;
            }
            try
            {
                if (CaliAxisCount == 0)
                {
                    UserDefine.Line_INFO Line = new UserDefine.Line_INFO();
                    double[] rowY = m_DTCoordSingle.AsEnumerable().Select(r => r.Field<double>("相机行坐标")).ToArray();
                    double[] colX = m_DTCoordSingle.AsEnumerable().Select(r => r.Field<double>("相机列坐标")).ToArray();
                    VBA_Function.fitLineByH(rowY.ToList(), colX.ToList(), out Line);
                    //计算直线角度  -90-90度 yoga 2017-9-3 19:10:57
                    HTuple angle = 0;
                    HalconDotNet.HOperatorSet.LineOrientation(Line.StartY, Line.StartX, Line.EndY, Line.EndX, out angle);
                    if (!blnXSingle)
                    {

                        if (angle>0)
                        {
                            angle = angle - Math.PI / 2;
                        }
                        else
                        {

                            angle = angle + Math.PI / 2;
                        }
                    }
                    //使用halcon算法算出的角度与tan算出的角度正负相反  yoga 2017-9-4 8:39:55
                    angle = angle.D * (-1.0);
                    PhiSingle = angle.D;
                    m_homMat2D = new HHomMat2D();
                    m_homMat2D = m_homMat2D.HomMat2dRotateLocal(angle);
                    //废弃  使用halcon角度算法 yoga 2017-9-3 19:19:37
                    //double tan = (Line.StartY - Line.EndY) / (Line.StartX - Line.EndX);
                    //PhiSingle = Math.Atan(tan);
                    //if (!blnXSingle)
                    //    PhiSingle = PhiSingle - Math.PI / 2;
                    //m_homMat2D = new HHomMat2D();
                    //m_homMat2D = m_homMat2D.HomMat2dRotateLocal(PhiSingle);
                }
                else if (CaliAxisCount == 1)
                {

                    //若为机械手标定 行列要交换   图像直接标定与x夹角不需要交换行列 yoga 2018-9-3 08:51:49
                    if (blnRbootMode == false)
                    {
                        double[] X = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械X坐标") * (-1)).ToArray();
                        double[] Y = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械Y坐标") * (-1)).ToArray();
                        double[] row = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机行坐标")).ToArray();
                        double[] col = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机列坐标")).ToArray();
                        m_homMat2D = new HHomMat2D();
                        //m_homMat2D.VectorToHomMat2d(new HTuple(col), new HTuple(row), new HTuple(X), new HTuple(Y));
                        m_homMat2D.VectorToHomMat2d(new HTuple(row), new HTuple(col), new HTuple(Y), new HTuple(X));
                    }
                    else
                    {
                        double[] X = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械X坐标")).ToArray();
                        double[] Y = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械Y坐标")).ToArray();
                        double[] row = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机行坐标")).ToArray();
                        double[] col = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机列坐标")).ToArray();
                        m_homMat2D = new HHomMat2D();
                        m_homMat2D.VectorToHomMat2d(new HTuple(col), new HTuple(row), new HTuple(X), new HTuple(Y));
                    }

                    //double[] X = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械X坐标")).ToArray();
                    //double[] Y = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("机械Y坐标")).ToArray();
                    //double[] rowY = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机行坐标")).ToArray();
                    //double[] colX = m_DTCoord.AsEnumerable().Select(r => r.Field<double>("相机列坐标")).ToArray();

                    //m_homMat2D = new HHomMat2D();
                    //m_homMat2D.VectorToHomMat2d(new HTuple(colX), new HTuple(rowY), new HTuple(X), new HTuple(Y));

                }
                F_DATA_CELL dataMat2D = new F_DATA_CELL(m_CellID, DataGroup.单量, DataType.位置转换2D, ConstVavriable.outHomMat2D
            , "相机和机械转换", "0", 1, new List<HHomMat2D>() { m_homMat2D }, DataAtrribution.全局变量);

                m_Owner.UpdateVariableValue(dataMat2D);
                m_Calibrated = true;
                blnSuccessed = true;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(this._CellCatagory.ToString() + " 单元 U" + this.m_CellID.ToString("D4") + " 错误 " + ex.ToString());
                //object NewValue = new List<HHomMat2D>() { new HHomMat2D() };
                //m_Owner.UpdateVariableValue(m_CellID, ConstVavriable.outHomMat2D, NewValue);
                m_Calibrated = false;
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
