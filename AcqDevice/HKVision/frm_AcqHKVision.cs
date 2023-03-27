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
    public partial class frm_AcqHKVision : Form
    {
        AcqHKVision AcqHKVision;
        private HalconControl.HWindow_Fit hWindow = null;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    AcqHKVision.dispImgCallback = dispImage;
                }
            }
        }
        public frm_AcqHKVision(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();
            AcqHKVision = (AcqHKVision)_AcqDevice;
        }

        ~frm_AcqHKVision()
        {
            AcqHKVision.dispImgCallback = null;
        }

        private void frAcqHKVisionAttr_Load(object sender, EventArgs e)
        {
            if (AcqHKVision.m_bConnected)
            {
                AcqHKVision.getSetting();
            }
            txt_ExposeTime.Text = AcqHKVision.m_ExposeTime.ToString();
            txt_Framerate.Text = AcqHKVision.m_Framerate.ToString();
            cmb_TrigerMode.SelectedIndex = AcqHKVision.m_TrigerMode;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            AcqHKVision.m_ExposeTime = float.Parse(txt_ExposeTime.Text.Trim());
            AcqHKVision.m_Framerate = float.Parse(txt_Framerate.Text.Trim());
            AcqHKVision.m_TrigerMode = cmb_TrigerMode.SelectedIndex;
            AcqHKVision.setSetting();
            AcqHKVision.SaveSetting(AcqHKVision.m_SettingPath);
            //this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_TrigerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_solftTrigger.Enabled = false;
            AcqHKVision.m_TrigerMode = cmb_TrigerMode.SelectedIndex + 1;
            AcqHKVision.setSetting();
            if (cmb_TrigerMode.SelectedIndex == 1)
            {
                bt_solftTrigger.Enabled = true;
            }
        }

        private void bt_solftTrigger_Click(object sender, EventArgs e)
        {
            AcqHKVision.CaptureImage(true);
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
