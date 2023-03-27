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


namespace MeasureFrame.IUI
{
    public partial class frm_Unit_ImageLineReg : MeasureFrame.IUI.frm_Unit
    {
        public frm_Unit_ImageLineReg()
            : base()
        {
            InitializeComponent();
            m_Unit = new CImageReg_Line(CellCatagory.线阵图像单元, HMeasureSYS.Cur_Project.m_LastCellID);
            blnNewUnit = true;
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_ImageLineReg(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_ImageReg_Load(object sender, EventArgs e)
        {
            string m_FlowID = "U" + ((CImageReg_Line)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CImageReg_Line)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CImageReg_Line)m_Unit).m_CellDesCribe;
            InitCmbDevice();
            InitCmboutImgList();
            InitCmbTriggerSource();
            InitCmbAdjust();

            InitRegisterCmbImgList();

            cmb_imgAdjust.SelectedIndex = 0;

            if (!blnNewUnit)
            {
                cmb_RegisterImg.Text = ((CImageReg_Line)m_Unit).m_RegImgName.ToString();

                cmb_Device.Text = ((CImageReg_Line)m_Unit).m_DeviceID;
                cmb_OutImage.Text = ((CImageReg_Line)m_Unit).m_ImageName;
                cmb_TriggerSource.Text = ((CImageReg_Line)m_Unit).m_TriggerSource;
                cmb_EndTrigger.Text = ((CImageReg_Line)m_Unit).m_EndTriggerSource;
                txt_NeedProfiles.Text = ((CImageReg_Line)m_Unit).m_AcqDevice.m_NeededProfile.ToString();
                cmb_imgAdjust.Text = ((CImageReg_Line)m_Unit).m_ImgAdjust.ToString();
                if (((CImageReg_Line)m_Unit).m_AcqDevice.m_DeviceType == DeviceType.KEYENCE_LINELASER)
                    cmb_OutImgMode.SelectedIndex = ((AcqKeyenceLaser)((CImageReg_Line)m_Unit).m_AcqDevice).OutDataMode;
            }

        }

        private void InitCmbDevice()
        {
            cmb_Device.DisplayMember = "m_DeviceID";
            this.cmb_Device.DataSource = new BindingList<AcqDeviceBase>(HMeasureSYS.g_AcqDeviceList.FindAll(c => c.m_SensorType == SENSOR_TYPE.Line));
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
            strList.Add("TR1");
            strList.Add("TR2");
            strList.Add("TR3");
            strList.Add("TR4");
            cmb_TriggerSource.DataSource = strList;
        }
        private void InitCmbEndTriggerSource()
        {
            List<string> strList = new List<string>();
            strList.Add("EndTR1");
            strList.Add("EndTR2");
            strList.Add("EndTR3");
            strList.Add("EndTR4");
            cmb_EndTrigger.DataSource = strList;
        }
        private void InitCmbAdjust()
        {
            string[] list = Enum.GetNames(typeof(IMG_ADJUST));
            cmb_imgAdjust.DataSource = list.ToList();
        }
        private void cmb_IndexChange(object sender, EventArgs e)
        {
            ((CImageReg_Line)m_Unit).m_AcqDevice = (AcqLineDeviceBase)HMeasureSYS.g_AcqDeviceList.FirstOrDefault(c => c.m_DeviceID == cmb_Device.Text.Trim() && c.m_SensorType == SENSOR_TYPE.Line);
            if (((CImageReg_Line)m_Unit).m_AcqDevice.m_DeviceType == DeviceType.KEYENCE_LINELASER)
                cmb_OutImgMode.Enabled = true;
            else
                cmb_OutImgMode.Enabled = false;
        }

        private void cmb_OutImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            HImageExt image;
            HMeasureSYS.Cur_Project.QueryImage(ImageCatagory.当前图像, cmb_OutImage.Text, out image);
            if (image.IsInitialized())
            {
                frm_Main.thisHandle.hWindow_Fit.Image = image;
                frm_Main.thisHandle.hWindow_Fit.DispImageFit();
            }

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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {

                //base.bt_Save_Click(sender, e);
                ((CImageReg_Line)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
                ((CImageReg_Line)m_Unit).m_ImgAdjust = (IMG_ADJUST)cmb_imgAdjust.SelectedIndex;
                ((CImageReg_Line)m_Unit).m_DeviceID = cmb_Device.Text.Trim();
                ((CImageReg_Line)m_Unit).m_ImageName = cmb_OutImage.Text.Trim();
                ((CImageReg_Line)m_Unit).m_TriggerSource = cmb_TriggerSource.Text.Trim();
                ((CImageReg_Line)m_Unit).m_EndTriggerSource = cmb_EndTrigger.Text.Trim();
                ((CImageReg_Line)m_Unit).m_AcqDevice.m_NeededProfile = int.Parse(txt_NeedProfiles.Text.Trim());
                ((CImageReg_Line)m_Unit).m_RegImgName = cmb_RegisterImg.Text;
                if (((CImageReg_Line)m_Unit).m_AcqDevice.m_DeviceType == DeviceType.KEYENCE_LINELASER)
                    ((AcqKeyenceLaser)((CImageReg_Line)m_Unit).m_AcqDevice).OutDataMode = cmb_OutImgMode.SelectedIndex;
                if (blnNewUnit == true)
                {
                    ((CImageReg_Line)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                    //添加变量对变量列表,本单元没有变量
                    blnNewUnit = false;
                }

                this.Close();

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
    }
}
