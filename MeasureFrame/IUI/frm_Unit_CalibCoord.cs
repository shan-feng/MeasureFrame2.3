using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using AcqDevice;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    /// <summary>
    /// 相机和机械坐标标定
    /// </summary>
    public partial class frm_Unit_CalibCoord : MeasureFrame.IUI.frm_Unit
    {

        HXLDCont m_MeasureXLD = new HXLDCont();
        HXLDCont m_MeasureCross = new HXLDCont();
        HXLDCont m_ResultXLD = new HXLDCont();
        public frm_Unit_CalibCoord()
            : base()
        {
            InitializeComponent();
            m_Unit = new CCalib_Coord(CellCatagory.相机机械坐标转换, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_CalibCoord(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_CalibCoord_Load(object sender, EventArgs e)
        {

            InitCmbDevice();
            cmb_Device.Tag = "0";
            cmb_Device.Text = ((CCalib_Coord)m_Unit).DeviceID;
            dgv_Points.DataSource = ((CCalib_Coord)m_Unit).m_DTCoord;
            dgv_SingleData.DataSource = ((CCalib_Coord)m_Unit).m_DTCoordSingle;
            cmb_AxisCount.SelectedIndex = ((CCalib_Coord)m_Unit).CaliAxisCount;
            chk_axisX.Checked = ((CCalib_Coord)m_Unit).blnXSingle;
            chkRbootMode.Checked = ((CCalib_Coord)m_Unit).blnRbootMode;
            //if (((CCalib_Coord)m_Unit).m_Calibrated)
            //{
            txt_CameraAxisPhi.Text = (((CCalib_Coord)m_Unit).PhiSingle * 180 / Math.PI).ToString("#0.000000");

            //需要每次标定才能得到对应的值
            if (((CCalib_Coord)m_Unit).CaliAxisCount == 1)
            {
                double sx, sy, phi, theta, tx, ty;
                sx = ((CCalib_Coord)m_Unit).m_homMat2D.HomMat2dToAffinePar(out sy, out phi, out theta, out tx, out ty);

                Label_sx.Text = sx.ToString("#0.000000");
                Label_sy.Text = sy.ToString("#0.000000");
                Label_phi.Text = (new HTuple(phi)).TupleDeg().D.ToString("#0.000000");
                Label_theta.Text = (new HTuple(theta)).TupleDeg().D.ToString("#0.000000");
                Label_tx.Text = tx.ToString("#0.000000");
                Label_ty.Text = ty.ToString("#0.000000");

            }
            measureControlOneAxis.ShowDefultValue();
            measureControlXY.ShowDefultValue();
            //}
            //frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(iPaintMetrology);
        }


        private void InitCmbDevice()
        {
            //此处更换为图像采集工具 yoga 2017-8-31 10:10:06
            //this.cmb_Device.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList.FindAll(c => c.m_SensorType == SENSOR_TYPE.Area));
            //cmb_Device.DisplayMember = "m_DeviceID";

            List<string> m_PositionList = new List<string>() { "无" };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_CellList
                                             where datacell.m_CellCatagory == CellCatagory.面阵图像单元// ||datacell.m_Data_Type == DataType.位置转换2D && datacell.m_Data_CellID != HMeasureSYS.U000
                                             select "U" + datacell.m_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_Device.DataSource = m_PositionList;
            cmb_Device.SelectedIndex = 0;

            if (((CCalib_Coord)m_Unit).AcqUnitID == -1)
            {
                cmb_Device.Text = "无";
            }
            else
            {
                cmb_Device.Text = "U" + ((CCalib_Coord)m_Unit).AcqUnitID.ToString("D4");
            }

        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {

                ((CCalib_Coord)m_Unit).m_Calibrated = false;
                ((CCalib_Coord)m_Unit).CaliAxisCount = cmb_AxisCount.SelectedIndex;
                ((CCalib_Coord)m_Unit).blnXSingle = chk_axisX.Checked;
                ((CCalib_Coord)m_Unit).blnRbootMode = chkRbootMode.Checked;
                ((CCalib_Coord)m_Unit).DeviceID = cmb_Device.Text;

               
                ((CCalib_Coord)m_Unit).Execute();

                txt_CameraAxisPhi.Text = (((CCalib_Coord)m_Unit).PhiSingle * 180 / Math.PI).ToString("#0.000000");
                //如果标定未成功  后续显示结果会bug yoga 2018-9-3 11:48:59
                if (((CCalib_Coord)m_Unit).m_Calibrated==false)
                {
                    MessageBox.Show("标定未成功!");
                    return;
                }
                double sx, sy, phi, theta, tx, ty;
                sx = ((CCalib_Coord)m_Unit).m_homMat2D.HomMat2dToAffinePar(out sy, out phi, out theta, out tx, out ty);
                //逆时针为正，顺时针为负
                Label_sx.Text = sx.ToString("#0.000000");
                Label_sy.Text = sy.ToString("#0.000000");
                Label_phi.Text = (new HTuple(phi)).TupleDeg().D.ToString("#0.000000"); //坐标系X轴角度差
                Label_theta.Text = (new HTuple(theta)).TupleDeg().D.ToString("#0.000000");//新坐标系相对于90度直角坐标系角度
                Label_tx.Text = tx.ToString("#0.000000");
                Label_ty.Text = ty.ToString("#0.000000");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dgv_Points_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ((CCalib_Coord)m_Unit).m_Calibrated = false;
        }

        private void bt_FindCircle_Click(object sender, EventArgs e)
        {
            bt_FindCircle.Enabled = false;
            Circle_INFO m_DrawCircle = new Circle_INFO();

            if (frm_Main.thisHandle.hWindow_Fit.Image == null || frm_Main.thisHandle.hWindow_Fit.Image.IsInitialized() == false)
            {
                MessageBox.Show("当前无图像数据!!");
                bt_FindCircle.Enabled = true;
                return;
            }
            //显示当前图像,擦除之前绘制的圆形,方便重新绘制--yoga20180821
            frm_Main.thisHandle.hWindow_Fit.HWindowID.DispObj(frm_Main.thisHandle.hWindow_Fit.Image);

            frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
            frm_Main.thisHandle.hWindow_Fit.DrawCircle("#00FF00", out m_DrawCircle.CenterY, out m_DrawCircle.CenterX, out m_DrawCircle.Radius);

            DetectCircle(m_DrawCircle);

            double x, y, z;
            HMeasureSYS.Cur_Project.GetCurrentPosi(out x, out y, out z);
            txt_currPosi.Text = x.ToString("#0.0000") + "," + y.ToString("#0.0000") + "," + z.ToString("#0.0000");

            bt_FindCircle.Enabled = true;
        }

        private void DetectCircle(Circle_INFO circle)
        {
            Circle_INFO CircleInfo = new Circle_INFO();
            HTuple row, col;
            //Metrology_INFO m_MetrologyInfo = new Metrology_INFO(15, 4, 30, 4, new HTuple(), new HTuple(), 0);

            Metrology_INFO m_MetrologyInfo;
            if (cmb_AxisCount.SelectedIndex == 0)
            {
                m_MetrologyInfo = measureControlOneAxis.GetMetrologInfo(); 
            }
            else
            {
                m_MetrologyInfo = measureControlXY.GetMetrologInfo();
            }

            HMeasureSet.MeasureCircle(frm_Main.thisHandle.hWindow_Fit.Image, circle, m_MetrologyInfo, null, out CircleInfo, out row, out col, out m_MeasureXLD);

            txt_Row.Text = CircleInfo.CenterY.ToString("0.000000");
            txt_Col.Text = CircleInfo.CenterX.ToString("0.000000");
            txt_rowS.Text = CircleInfo.CenterY.ToString("0.000000");
            txt_colS.Text = CircleInfo.CenterX.ToString("0.000000");
            m_MeasureCross.GenCrossContourXld(row, col, (HTuple)m_MetrologyInfo.Length2, new HTuple(45).TupleRad());
            m_ResultXLD.GenCircleContourXld(CircleInfo.CenterY, CircleInfo.CenterX, CircleInfo.Radius, 0, 6.28318, "positive", 1);
            iPaintMetrology();
        }

        /// <summary>
        /// 绘画出模型
        /// </summary>
        protected void iPaintMetrology()
        {

            frm_Main frm_Main = frm_Main.thisHandle;

            //此处必须先显示图像,否则会出现残留,后续的xld直接绘制,当前却没有清除  --yoga20180821
            if (frm_Main.hWindow_Fit.Image!=null&& frm_Main.hWindow_Fit.Image.IsInitialized())
            {

                HSystem.SetSystem("flush_graphic", "false");
                frm_Main.hWindow_Fit.HWindowID.ClearWindow();

                frm_Main.hWindow_Fit.HWindowID.DispObj(frm_Main.hWindow_Fit.Image);
                frm_Main.hWindow_Fit.HWindowID.SetColor("#FF0000");
                if (m_ResultXLD.IsInitialized())
                {
                    frm_Main.hWindow_Fit.HWindowID.DispXld(m_ResultXLD);
                }

                frm_Main.hWindow_Fit.HWindowID.SetColor("#00FF00");
                if (m_MeasureXLD.IsInitialized())
                {
                    frm_Main.hWindow_Fit.HWindowID.DispXld(m_MeasureXLD);
                }

                frm_Main.hWindow_Fit.HWindowID.SetColor("#0000FF");
                if (m_MeasureCross.IsInitialized())
                {
                    frm_Main.hWindow_Fit.HWindowID.DispXld(m_MeasureCross);
                }

                HSystem.SetSystem("flush_graphic", "true");
                frm_Main.hWindow_Fit.HWindowID.DispLine(-100.0, -100.0, -100.0, -100.0);
            }
           
        }

        private void frm_Unit_CalibCoord_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
            frm_Main.thisHandle.hWindow_Fit.RePaint -=new HalconControl.DelegateRePaint(iPaintMetrology);
        }

        private void bt_getCurrPosi_Click(object sender, EventArgs e)
        {
            DataRow row = ((CCalib_Coord)m_Unit).m_DTCoord.NewRow();
            string[] tmp = txt_currPosi.Text.Split(',');
            if (tmp.Length > 2)
            {
                row[0] = double.Parse(tmp[0].Trim());
                row[1] = double.Parse(tmp[1].Trim());
                row[2] = double.Parse(txt_Row.Text.Trim());
                row[3] = double.Parse(txt_Col.Text.Trim());
                ((CCalib_Coord)m_Unit).m_DTCoord.Rows.Add(row);
                dgv_Points.DataSource = ((CCalib_Coord)m_Unit).m_DTCoord;
            }
        }
        private void cmb_AxisCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_AxisCount.SelectedIndex == 0)
            {
                tabP_baseSetting.Parent = null;
                tabP_SingleAxis.Parent = tab_Main;
            }
            else
            {
                tabP_baseSetting.Parent = tab_Main;
                tabP_SingleAxis.Parent = null;
            }
        }

        private void bt_MarkS_Click(object sender, EventArgs e)
        {
            bt_MarkS.Enabled = false;
            Circle_INFO m_DrawCircle = new Circle_INFO();

            if (frm_Main.thisHandle.hWindow_Fit.Image == null || frm_Main.thisHandle.hWindow_Fit.Image.IsInitialized() == false)
            {
                MessageBox.Show("当前无图像数据!!");
                bt_FindCircle.Enabled = true;
                return;
            }
            //显示当前图像,擦除之前绘制的圆形,方便重新绘制--yoga20180821
            frm_Main.thisHandle.hWindow_Fit.HWindowID.DispObj(frm_Main.thisHandle.hWindow_Fit.Image);
            frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
            frm_Main.thisHandle.hWindow_Fit.DrawCircle("#00FF00", out m_DrawCircle.CenterY, out m_DrawCircle.CenterX, out m_DrawCircle.Radius);

            DetectCircle(m_DrawCircle);
            bt_MarkS.Enabled = true;
        }

        private void bt_addRow_Click(object sender, EventArgs e)
        {
            DataRow row = ((CCalib_Coord)m_Unit).m_DTCoordSingle.NewRow();
            row[0] = double.Parse(txt_rowS.Text.Trim());
            row[1] = double.Parse(txt_colS.Text.Trim());
            ((CCalib_Coord)m_Unit).m_DTCoordSingle.Rows.Add(row);
            dgv_Points.DataSource = ((CCalib_Coord)m_Unit).m_DTCoord;
        }

        private void bt_DisImage_Click(object sender, EventArgs e)
        {
            if (cmb_Device.Text!="无")
            {

                int unitID= int.Parse(cmb_Device.Text.Substring(1));

                CMeasureCell unitAcq= m_Unit.m_Owner.m_CellList.FirstOrDefault(c => c.m_CellID == unitID);

                if (unitAcq!=null)
                {
                    unitAcq.Execute(true);

                    F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == ((CImageReg_Area)unitAcq).m_ImageName);
                    frm_Main.thisHandle.hWindow_Fit.Image = ((List<HImageExt>)datacell.m_Data_Value)[0];
                    frm_Main.thisHandle.hWindow_Fit.DispImageFit();
                    m_ResultXLD = new HXLDCont();
                    m_MeasureCross = new HXLDCont();
                    m_MeasureXLD = new HXLDCont();
                    iPaintMetrology();
                }

                //if (((CCalib_Coord)m_Unit).AcqDevice==null)
                //{
                //    MessageBox.Show("采集设备为空");
                //    return;
                //}
                //if (((CCalib_Coord)m_Unit).AcqDevice.m_bConnected==false)
                //{
                //    MessageBox.Show("采集设备未连接,请检查");
                //    return;
                //}
                //((CCalib_Coord)m_Unit).AcqDevice.eventWait.Reset();
                ////发送采集命令
                //if (((CCalib_Coord)m_Unit).AcqDevice.CaptureImage(true))
                //{
                //    ((CCalib_Coord)m_Unit).AcqDevice.eventWait.WaitOne();
                //    frm_Main.thisHandle.hWindow_Fit.Image = ((CCalib_Coord)m_Unit).AcqDevice.m_Image;
                //    frm_Main.thisHandle.hWindow_Fit.DispImageFit();
                //    m_ResultXLD = new HXLDCont();
                //    m_MeasureCross = new HXLDCont();
                //    m_MeasureXLD = new HXLDCont();
                //    iPaintMetrology();
                //}
            }
        }

        private void cmb_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Device.Text.Trim() == "无"|| cmb_Device.Text.Trim().Length<1)
            {
                ((CCalib_Coord)m_Unit).AcqUnitID = -1;
            }
            else
            {

                ((CCalib_Coord)m_Unit).AcqUnitID = int.Parse(cmb_Device.Text.Substring(1));
            }
        }
    }
}
