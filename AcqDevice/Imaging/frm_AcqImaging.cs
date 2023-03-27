using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using DVPCameraType;

namespace AcqDevice
{
    public class frm_AcqImaging
    {
        AcqImaging m_AcqImaging;
        private HalconControl.HWindow_Fit hWindow = null;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqImaging.dispImgCallback = dispImage;
                }
            }
        }

        public frm_AcqImaging(ref AcqDeviceBase _AcqDevice)
        {
            m_AcqImaging = (AcqImaging)_AcqDevice;
        }
        public void ShowAttr(IntPtr handle)
        {
            try
            {
                m_AcqImaging.camera.ShowPropertyDialog(handle);
                if (m_AcqImaging.camera.DeviceValid)
                {
                    m_AcqImaging.dispImgCallback = null;
                }
            }
            catch (Exception ex)
            { }
        }

        private void dispImage(HImage image, int user)
        {
            try
            {
                //GC.Collect();
                hWindow.Image = image.Clone();
                //hWindow.Image = image;
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
