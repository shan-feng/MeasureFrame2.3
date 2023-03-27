using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using DVPCameraType;

namespace AcqDevice
{
    public class frm_AcqDo3Think
    {
        AcqDo3Think m_AcqDo3Think;
        private HalconControl.HWindow_Fit hWindow = null;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqDo3Think.dispImgCallback = dispImage;
                }
            }
        }

        public frm_AcqDo3Think(ref AcqDeviceBase _AcqDevice)
        {
            m_AcqDo3Think = (AcqDo3Think)_AcqDevice;
        }
        public void ShowAttr(IntPtr handle)
        {
            if (m_AcqDo3Think.m_handle > 0)
            {
                DVPCamera.dvpShowPropertyModalDialog(m_AcqDo3Think.m_handle, handle);
                m_AcqDo3Think.dispImgCallback = null;
            }
        }

        private void dispImage(HImage image, int user)
        {
            try
            {
                hWindow.Image = image;
                //hWindow.HWindowID.DispImage(image);
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
