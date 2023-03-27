using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace AcqDevice
{
    public partial class Frm_AcqDahengr_Attr : Form
    {

        AcqDaheng m_AcqDevice;
        private HalconControl.HWindow_Fit hWindow = null;

        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqDevice.dispImgCallback = dispImage;
                }
            }
        }

        public Frm_AcqDahengr_Attr(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();
            m_AcqDevice = (AcqDaheng)_AcqDevice;
        }

        ~Frm_AcqDahengr_Attr()
        {
            m_AcqDevice.dispImgCallback = null;
        }

        private void Frm_AcqBasler_Attr_Load(object sender, EventArgs e)
        {
            if (m_AcqDevice.m_bConnected)
            {
                m_AcqDevice.getSetting();
            }
            txt_ExposeTime.Text = m_AcqDevice.m_ExposeTime.ToString();
            cmb_TrigerMode.SelectedIndex = m_AcqDevice.m_TrigerMode;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            m_AcqDevice.m_ExposeTime = float.Parse(txt_ExposeTime.Text.Trim());
            m_AcqDevice.m_TrigerMode = cmb_TrigerMode.SelectedIndex;
            m_AcqDevice.setSetting();
            m_AcqDevice.SaveSetting(m_AcqDevice.m_SettingPath);
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_TrigerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_solftTrigger.Enabled = false;
            m_AcqDevice.m_TrigerMode = cmb_TrigerMode.SelectedIndex;
            m_AcqDevice.setSetting();
            if (cmb_TrigerMode.SelectedIndex == 1)
            {
                bt_solftTrigger.Enabled = true;
            }
        }

        private void bt_solftTrigger_Click(object sender, EventArgs e)
        {
            m_AcqDevice.CaptureImage(true);
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
