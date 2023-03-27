using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AcqDevice;
using HalconDotNet;

namespace AcqDevice
{
    public partial class frm_AcqSVS_hrAttr : Form
    {
        AcqSVS_hr m_AcqSVS_hr;
        private HalconControl.HWindow_Fit hWindow = null;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqSVS_hr.dispImgCallback = dispImage;
                }
            }
        }
        public frm_AcqSVS_hrAttr(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();
            m_AcqSVS_hr = (AcqSVS_hr)_AcqDevice;
        }

        ~frm_AcqSVS_hrAttr()
        {
            m_AcqSVS_hr.dispImgCallback = null;
        }

        private void frm_AcqSVS_hrAttr_Load(object sender, EventArgs e)
        {
            if (m_AcqSVS_hr.m_bConnected)
            {
                m_AcqSVS_hr.getSetting();
            }
            txt_ExposeTime.Text = m_AcqSVS_hr.m_ExposeTime.ToString();
            txt_Framerate.Text = m_AcqSVS_hr.m_Framerate.ToString();
            cmb_TrigerMode.SelectedIndex = m_AcqSVS_hr.m_TrigerMode - 1;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            m_AcqSVS_hr.m_ExposeTime = float.Parse(txt_ExposeTime.Text.Trim());
            m_AcqSVS_hr.m_Framerate = float.Parse(txt_Framerate.Text.Trim());
            m_AcqSVS_hr.m_TrigerMode = cmb_TrigerMode.SelectedIndex + 1;
            m_AcqSVS_hr.setSetting();
            m_AcqSVS_hr.SaveSetting(m_AcqSVS_hr.m_SettingPath);
            //this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_TrigerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_solftTrigger.Enabled = false;
            m_AcqSVS_hr.m_TrigerMode = cmb_TrigerMode.SelectedIndex + 1;
            m_AcqSVS_hr.setSetting();
            if (cmb_TrigerMode.SelectedIndex == 1)
            {
                bt_solftTrigger.Enabled = true;
            }
        }

        private void bt_solftTrigger_Click(object sender, EventArgs e)
        {
            m_AcqSVS_hr.CaptureImage(true);
        }

        private void dispImage(HImage image, int user)
        {
            hWindow.Image = image;
            //int width, height;
            //image.GetImageSize(out width, out height);
            //hWindow.SetPart(0, 0, height, width);
            //hWindow.HWindowID.DispImage(image);
        }
    }
}
