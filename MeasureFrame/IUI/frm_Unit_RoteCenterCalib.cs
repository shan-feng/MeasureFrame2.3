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

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_RoteCenterCalib : MeasureFrame.IUI.frm_Unit
    {
        HXLDCont m_MeasureXLD = new HXLDCont();
        HXLDCont m_MeasureCross = new HXLDCont();
        HXLDCont m_ResultXLD = new HXLDCont();
        public frm_Unit_RoteCenterCalib()
            : base()
        {
            InitializeComponent();
            m_Unit = new CRoteCenterCalib(CellCatagory.旋转中心标定, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_RoteCenterCalib(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_RoteCenterCalib_Load(object sender, EventArgs e)
        {
            InitCmbDevice();
            cmb_Device.Tag = "0";
            InitCmb_Position();
            if (!blnNewUnit)
            {
                nud_MachineX.Value = (decimal)((CRoteCenterCalib)m_Unit).MachinePoint.X;
                nud_MachineY.Value = (decimal)((CRoteCenterCalib)m_Unit).MachinePoint.Y;
                txt_WordX.Text = ((CRoteCenterCalib)m_Unit).WorldPoint.X.ToString();
                txt_WordY.Text = ((CRoteCenterCalib)m_Unit).WorldPoint.Y.ToString();
                dgv_Points.DataSource = ((CRoteCenterCalib)m_Unit).DTCoord;
                cmb_Device.Text = ((CRoteCenterCalib)m_Unit).DeviceID;
                cmb_CalibCoordID.Text = "U" + ((CRoteCenterCalib)m_Unit).iCalibCoordID.ToString("D4");
                
            }
            measureControl1.ShowDefultValue();

            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(this.iPaintMetrology);
        }
        private void InitCmbDevice()
        {
            //this.cmb_Device.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList.FindAll(c => c.m_SensorType == SENSOR_TYPE.Area));
            //cmb_Device.DisplayMember = "m_DeviceID";

            List<string> m_PositionList = new List<string>() { "无" };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_CellList
                                             where datacell.m_CellCatagory == CellCatagory.面阵图像单元// ||datacell.m_Data_Type == DataType.位置转换2D && datacell.m_Data_CellID != HMeasureSYS.U000
                                             select "U" + datacell.m_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_Device.DataSource = m_PositionList;
            cmb_Device.SelectedIndex = 0;

            if (((CRoteCenterCalib)m_Unit).AcqUnitID == -1)
            {
                cmb_Device.Text = "无";
            }
            else
            {
                cmb_Device.Text = "U" + ((CRoteCenterCalib)m_Unit).AcqUnitID.ToString("D4");
            }
        }
        /// <summary>
        /// 初始化位置补正列表
        /// </summary>
        public void InitCmb_Position()
        {
            List<string> m_PositionList = new List<string>() { };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.位置转换2D
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_CalibCoordID.DataSource = m_PositionList;
        }
        private void dgv_Points_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ((CRoteCenterCalib)m_Unit).Calibrated = false;
        }

        private void bt_FindCircle_Click(object sender, EventArgs e)
        {
            try
            {
                bt_GetMark.Enabled = false;
                Circle_INFO m_DrawCircle = new Circle_INFO();

                if (frm_Main.thisHandle.hWindow_Fit.Image==null|| frm_Main.thisHandle.hWindow_Fit.Image.IsInitialized()==false)
                {
                    MessageBox.Show("当前无图像数据!!");
                    return;
                }
                //显示当前图像,擦除之前绘制的圆形,方便重新绘制--yoga20180821
                frm_Main.thisHandle.hWindow_Fit.HWindowID.DispObj(frm_Main.thisHandle.hWindow_Fit.Image);
                frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
                frm_Main.thisHandle.hWindow_Fit.DrawCircle("#00FF00", out m_DrawCircle.CenterY, out m_DrawCircle.CenterX, out m_DrawCircle.Radius);

                //Metrology_INFO m_MetrologyInfo = new Metrology_INFO(15, 4, 30, 4, new HTuple(), new HTuple(), 0);
                Metrology_INFO m_MetrologyInfo = measureControl1.GetMetrologInfo();
                Circle_INFO CircleInfo = new Circle_INFO();
                HTuple row, col;
                HMeasureSet.MeasureCircle(frm_Main.thisHandle.hWindow_Fit.Image, m_DrawCircle, m_MetrologyInfo, null, out CircleInfo, out row, out col, out m_MeasureXLD);
                m_MeasureCross.GenCrossContourXld(row, col, (HTuple)m_MetrologyInfo.Length2, new HTuple(45).TupleRad());
                m_ResultXLD.GenCircleContourXld(CircleInfo.CenterY, CircleInfo.CenterX, CircleInfo.Radius, 0, 6.28318, "positive", 1);
                DataRow newRow = ((CRoteCenterCalib)m_Unit).DTCoord.NewRow();
                newRow[0] = CircleInfo.CenterY;
                newRow[1] = CircleInfo.CenterX;
                ((CRoteCenterCalib)m_Unit).DTCoord.Rows.Add(newRow);
                dgv_Points.DataSource = ((CRoteCenterCalib)m_Unit).DTCoord;
                bt_GetMark.Enabled = true;
            }
            catch (Exception ex)
            {
                bt_GetMark.Enabled = true;
            }
            iPaintMetrology();
        }

        private void bt_DisImage_Click(object sender, EventArgs e)
        {

            if (cmb_Device.Text != "无")
            {

                int unitID = int.Parse(cmb_Device.Text.Substring(1));

                CMeasureCell unitAcq = m_Unit.m_Owner.m_CellList.FirstOrDefault(c => c.m_CellID == unitID);

                if (unitAcq != null)
                {
                    unitAcq.Execute(true);

                    F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == ((CImageReg_Area)unitAcq).m_ImageName);
                    frm_Main.thisHandle.hWindow_Fit.Image = ((List<CPublicDefine.HImageExt>)datacell.m_Data_Value)[0];
                    frm_Main.thisHandle.hWindow_Fit.DispImageFit();
                    m_ResultXLD = new HXLDCont();
                    m_MeasureCross = new HXLDCont();
                    m_MeasureXLD = new HXLDCont();
                    iPaintMetrology();
                }
            }
            //    if (cmb_Device.SelectedIndex > -1 && cmb_Device.Tag == "0")
            //{
            //    ((CRoteCenterCalib)m_Unit).AcqDevice.eventWait.Reset();
            //    //发送采集命令
            //    if (((CRoteCenterCalib)m_Unit).AcqDevice.CaptureImage(true))
            //    {
            //        ((CRoteCenterCalib)m_Unit).AcqDevice.eventWait.WaitOne();
            //        frm_Main.thisHandle.hWindow_Fit.Image = ((CRoteCenterCalib)m_Unit).AcqDevice.m_Image;
            //        frm_Main.thisHandle.hWindow_Fit.DispImageFit();
            //        m_ResultXLD = new HXLDCont();
            //        m_MeasureCross = new HXLDCont();
            //        m_MeasureXLD = new HXLDCont();
            //    }
            //}
        }
        /// <summary>
        /// 绘画出模型
        /// </summary>
        protected void iPaintMetrology()
        {

            frm_Main frm_Main = frm_Main.thisHandle;

            //此处必须先显示图像,否则会出现残留,后续的xld直接绘制,当前却没有清除  --yoga20180821
            if (frm_Main.hWindow_Fit.Image != null && frm_Main.hWindow_Fit.Image.IsInitialized())
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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Device.SelectedIndex < 0)
                {
                    MessageBox.Show("采集设备不允许为空！");
                    return;
                }
                if (cmb_CalibCoordID.SelectedIndex < 0)
                {
                    MessageBox.Show("9点标定单元不允许为空！");
                    return;
                }
                if (((CRoteCenterCalib)m_Unit).DTCoord.Rows.Count < 3)
                {
                    MessageBox.Show("标定点必须大于3组！");
                    return;
                }
                ((CRoteCenterCalib)m_Unit).Calibrated = false;
                ((CRoteCenterCalib)m_Unit).DeviceID = cmb_Device.Text.Trim();
                ((CRoteCenterCalib)m_Unit).iCalibCoordID = int.Parse(cmb_CalibCoordID.Text.Substring(1));
                ((CRoteCenterCalib)m_Unit).MachinePoint = new PointF((float)nud_MachineX.Value, (float)nud_MachineY.Value);
                m_Unit.Execute();
                txt_WordX.Text = ((CRoteCenterCalib)m_Unit).WorldPoint.X.ToString();
                txt_WordY.Text = ((CRoteCenterCalib)m_Unit).WorldPoint.Y.ToString();
                blnNewUnit = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void cmb_Device_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_Device.Text.Trim() == "无" || cmb_Device.Text.Trim().Length < 1)
            {
                ((CRoteCenterCalib)m_Unit).AcqUnitID = -1;
            }
            else
            {

                ((CRoteCenterCalib)m_Unit).AcqUnitID = int.Parse(cmb_Device.Text.Substring(1));
            }

            //if (cmb_Device.SelectedIndex > -1 && cmb_Device.Tag == "0")
            //{
            //    ((CRoteCenterCalib)m_Unit).DeviceID = cmb_Device.Text;
            //}
        }
    }
}
