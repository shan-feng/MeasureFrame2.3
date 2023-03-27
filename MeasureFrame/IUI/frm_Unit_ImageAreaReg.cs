using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Measure;
using AcqDevice;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;
using Helper;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_ImageAreaReg : MeasureFrame.IUI.frm_Unit
    {
        public frm_Unit_ImageAreaReg()
            : base()
        {
            InitializeComponent();
            m_Unit = new CImageReg_Area(CellCatagory.面阵图像单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_ImageAreaReg(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_ImageReg_Load(object sender, EventArgs e)
        {
            //gb_main.Enabled = !HMeasureSYS.Cur_Project.m_Status;
            timer1.Start();
            string m_FlowID = "U" + ((CImageReg_Area)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CImageReg_Area)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CImageReg_Area)m_Unit).m_CellDesCribe;
            cmb_Shape2.SelectedIndex = 0;
            txt_ExposureTime.Text = ((CImageReg_Area)m_Unit).m_ExposureTime.ToString();
            InitCmbDevice();
            InitCmboutImgList();
            InitCmbTriggerSource();
            InitCmbAdjust();
            InitHomt2DImgList();
            InitDistortionCalibList();
            InitRegisterCmbImgList();
            if (!blnNewUnit)
            {

              
                cmb_TriggerSource.Text = ((CImageReg_Area)m_Unit).m_TriggerSource;
                cmb_Device.Text = ((CImageReg_Area)m_Unit).m_DeviceID;
                cmb_OutImage.Text = ((CImageReg_Area)m_Unit).m_ImageName;
                cmb_imgAdjust.Text = ((CImageReg_Area)m_Unit).m_ImgAdjust.ToString();
                cmb_RegisterImg.Text = ((CImageReg_Area)m_Unit).m_RegImgName.ToString();
                if (((CImageReg_Area)m_Unit).HomMatUnitID == -1)
                    cmb_hom2D.Text = "无";
                else
                    cmb_hom2D.Text = "U" + ((CImageReg_Area)m_Unit).HomMatUnitID.ToString("D4");

                cmb_DistortionCalib.Text = "U" + ((CImageReg_Area)m_Unit).DistortionID.ToString("D4");
                //添加是否自动采集 20180828 yoga
                chkAcqAuto.Checked = ((CImageReg_Area)m_Unit).m_IsAcqAuto;
            }
            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
            PaintMetrology();
        }

        private void InitCmbDevice()
        {
            this.cmb_Device.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList.FindAll(c => c.m_SensorType == SENSOR_TYPE.Area));
            cmb_Device.DisplayMember = "m_DeviceID";
        }

        protected void InitCmboutImgList()
        {
            List<string> m_CurrentImageNames = new List<string>();//当前图像名称列表
            List<F_DATA_CELL> imgList = new List<F_DATA_CELL>();
            HMeasureSet.getVariableImageList(HMeasureSYS.Cur_Project.m_VariableList, out imgList);
            foreach (F_DATA_CELL datacell in imgList)
            {
                m_CurrentImageNames.Add(datacell.m_Data_Name);
            }
            cmb_OutImage.DataSource = m_CurrentImageNames;
        }

        private void InitCmbTriggerSource()
        {
            List<string> strList = new List<string>();
            strList.Add("");
            strList.Add("TR1");
            strList.Add("TR2");
            strList.Add("TR3");
            strList.Add("TR4");
            cmb_TriggerSource.DataSource = strList;
        }

        private void InitCmbAdjust()
        {
            string[] list = Enum.GetNames(typeof(IMG_ADJUST));
            cmb_imgAdjust.DataSource = list.ToList();
        }

        private void cmb_IndexChange(object sender, EventArgs e)
        {
            ((CImageReg_Area)m_Unit).m_AcqDevice = (AcqAreaDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == cmb_Device.Text.Trim() && c.m_SensorType == SENSOR_TYPE.Area);
        }


        private void cmb_OutImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            HImageExt image = new HImageExt();
            HMeasureSYS.Cur_Project.QueryImage(ImageCatagory.当前图像, cmb_OutImage.Text, out image);
            if (image.IsInitialized())
            {
                frm_Main.thisHandle.hWindow_Fit.Image = image;
                //frm_Main.thisHandle.hWindow_Fit.HWindowID.DispImage(image);
            }

        }
        private void bt_DisImage_Click(object sender, EventArgs e)
        {
            ((CImageReg_Area)m_Unit).Execute(true);
            F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == cmb_OutImage.Text.Trim());
            frm_Main.thisHandle.hWindow_Fit.Image = ((List<HImageExt>)datacell.m_Data_Value)[0];
            frm_Main.thisHandle.hWindow_Fit.DispImageFit();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //base.bt_Save_Click(sender, e);
                ((CImageReg_Area)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
                ((CImageReg_Area)m_Unit).m_DeviceID = cmb_Device.Text.Trim();
                ((CImageReg_Area)m_Unit).m_ImageName = cmb_OutImage.Text.Trim();
                ((CImageReg_Area)m_Unit).m_TriggerSource = cmb_TriggerSource.Text.Trim();
                ((CImageReg_Area)m_Unit).m_ImgAdjust = (IMG_ADJUST)cmb_imgAdjust.SelectedIndex;
                ((CImageReg_Area)m_Unit).m_ExposureTime = double.Parse(txt_ExposureTime.Text.Trim());
                ((CImageReg_Area)m_Unit).m_RegImgName = cmb_RegisterImg.Text;
                //添加是否自动采集 20180828 yoga
                ((CImageReg_Area)m_Unit).m_IsAcqAuto =chkAcqAuto.Checked;
                if (cmb_hom2D.Text.Trim() == "无")
                    ((CImageReg_Area)m_Unit).HomMatUnitID = -1;
                else
                    ((CImageReg_Area)m_Unit).HomMatUnitID = int.Parse(cmb_hom2D.Text.Substring(1));
                if (cmb_DistortionCalib.Text.Trim() == "无")
                    ((CImageReg_Area)m_Unit).DistortionID = -1;
                else
                    //((CImageReg_Area)m_Unit).DistortionID = int.Parse(cmb_DistortionHalcon.Text.Substring(1));
                    ((CImageReg_Area)m_Unit).DistortionID = int.Parse(cmb_DistortionCalib.Text.Substring(1));

                if (blnNewUnit == true)
                {
                    ((CImageReg_Area)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                    //添加变量对变量列表,本单元没有变量
                    blnNewUnit = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Draw2_Click(object sender, EventArgs e)
        {
            bt_Draw2.Enabled = false;
            string mColor = ColorHelper.ToHexColor(bt_Color2.BackColor);
            if (cmb_Shape2.SelectedIndex == 0)
            {
                double _rowBegin, _colBegin, _rowEnd, _colEnd;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle1(mColor, out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                ((CImageReg_Area)m_Unit).m_dispROI = new Rectangle_INFO(_rowBegin, _colBegin, _rowEnd, _colEnd);
            }
            if (cmb_Shape2.SelectedIndex == 1)
            {
                double _row, _column, _phi, _length1, _length2;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle2(mColor, out _row, out _column, out _phi, out _length1, out _length2);
                ((CImageReg_Area)m_Unit).m_dispROI = new Rectangle2_INFO(_row, _column, _phi, _length1, _length2);
            }
            if (cmb_Shape2.SelectedIndex == 2)
            {
                double _row, _column, _radius;
                frm_Main.thisHandle.hWindow_Fit.DrawCircle(mColor, out _row, out _column, out _radius);
                ((CImageReg_Area)m_Unit).m_dispROI = new Circle_INFO(_row, _column, _radius);
            }
            if (cmb_Shape2.SelectedIndex == 3)
            {
                double _row, _column, _phi, _radius1, _radius2;
                frm_Main.thisHandle.hWindow_Fit.DrawEllipse(mColor, out _row, out _column, out _phi, out _radius1, out _radius2);
                ((CImageReg_Area)m_Unit).m_dispROI = new Ellipse_INFO(_row, _column, _phi, _radius1, _radius2);
            }
            ((CImageReg_Area)m_Unit).m_dispROI.sColor = mColor;
            bt_Draw2.Enabled = true;
            PaintMetrology();
            //frm_Main.thisHandle.hWindow_Fit.refreshWindow();
        }

        private void bt_Color2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                bt_Color2.BackColor = colorDialog.Color;
            }
        }
        /// <summary>
        /// 初始化区域标定畸变列表
        /// </summary>
        protected void InitDistortionCalibList()
        {
            List<string> m_Distortion = new List<string>() { "无" };
            //IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
            //                                 where datacell.m_Data_Type == DataType.数值型 && datacell.m_Data_CellID != HMeasureSYS.U000
            //                                 && datacell.m_Data_Name == ConstVavriable.outCalib
            //                                 select "U" + datacell.m_Data_CellID.ToString("D4");
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_CellList
                                             where datacell.m_CellCatagory == CellCatagory.畸变标定
                                             select "U" + datacell.m_CellID.ToString("D4");
            m_Distortion.AddRange(resultList.ToList());
            cmb_DistortionCalib.DataSource = m_Distortion;
        }
        /// <summary>
        /// 初始化输出图像列表
        /// </summary>
        protected void InitHomt2DImgList()
        {
            List<string> m_PositionList = new List<string>() { "无" };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.位置转换2D && datacell.m_Data_CellID != HMeasureSYS.U000
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_hom2D.DataSource = m_PositionList;
        }

        /// <summary>
        /// 绘画出模型
        /// </summary>
        protected void PaintMetrology()
        {

            frm_Main frm_Main = frm_Main.thisHandle;
            //if (m_Image.IsInitialized())
            //{
            //    frm_Main.hWindow_Fit.Image = m_Image;
            //}
            if (((CImageReg_Area)m_Unit).m_dispROI != null)
            {
                frm_Main.hWindow_Fit.HWindowID.SetDraw("margin");
                frm_Main.hWindow_Fit.HWindowID.SetColor(((CImageReg_Area)m_Unit).m_dispROI.sColor);
                frm_Main.hWindow_Fit.HWindowID.DispXld(((CImageReg_Area)m_Unit).m_dispROI.genXLD());
            }
        }

        private void frm_Unit_ImageAreaReg_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bt_DisImage.Enabled = !HMeasureSYS.Cur_Project.m_Status;
        }

        /// <summary>
        /// 初始化注册图像列表
        /// </summary>
        protected void InitRegisterCmbImgList()
        {
            List<string> m_RegisterImageNames = new List<string>();//注册图像名称列表
            foreach (RegisterIMG_Info datacell in HMeasureSYS.Cur_Project.m_RegisterImg)
            {
                m_RegisterImageNames.Add(datacell.m_ImageID);
            }
            cmb_RegisterImg.DataSource = m_RegisterImageNames;
        }

        private void bt_ClearRoi_Click(object sender, EventArgs e)
        {
            ((CImageReg_Area)m_Unit).m_dispROI = null;
            //PaintMetrology();
            frm_Main frm_Main = frm_Main.thisHandle;
            frm_Main.hWindow_Fit.refreshWindow();
        }
    }
}
