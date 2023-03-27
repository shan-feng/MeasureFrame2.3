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
    public partial class Frm_AcqBasler_Attr : Form
    {

        AcqBasler m_AcqBasler;
        private HalconControl.HWindow_Fit hWindow = null;

        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqBasler.dispImgCallback = dispImage;
                }
            }
        }

        public Frm_AcqBasler_Attr(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();
            m_AcqBasler = (AcqBasler)_AcqDevice;
        }

        ~Frm_AcqBasler_Attr()
        {
            m_AcqBasler.dispImgCallback = null;
        }

        private void Frm_AcqBasler_Attr_Load(object sender, EventArgs e)
        {
            if (m_AcqBasler.m_bConnected)
            {
                m_AcqBasler.getSetting();
            }
            txt_ExposeTime.Text = m_AcqBasler.m_ExposeTime.ToString();
            cmb_TrigerMode.SelectedIndex = m_AcqBasler.m_TrigerMode;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            m_AcqBasler.m_ExposeTime = float.Parse(txt_ExposeTime.Text.Trim());
            m_AcqBasler.m_TrigerMode = cmb_TrigerMode.SelectedIndex;
            m_AcqBasler.setSetting();
            m_AcqBasler.SaveSetting(m_AcqBasler.m_SettingPath);
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_TrigerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_solftTrigger.Enabled = false;
            m_AcqBasler.m_TrigerMode = cmb_TrigerMode.SelectedIndex;
            m_AcqBasler.setSetting();
            if (cmb_TrigerMode.SelectedIndex == 1)
            {
                bt_solftTrigger.Enabled = true;
            }
        }

        private void bt_solftTrigger_Click(object sender, EventArgs e)
        {
            m_AcqBasler.CaptureImage(true);
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
