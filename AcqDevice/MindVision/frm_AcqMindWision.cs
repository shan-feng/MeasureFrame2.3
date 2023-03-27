using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using MVSDK;
using CameraHandle = System.Int32;
using Helper;
using HalconControl;

namespace AcqDevice
{
    public class frm_AcqMindWision
    {
        AcqMindVision m_AcqMindWision;
        private HalconControl.HWindow_Fit hWindow = null;
        private CAMERA_PAGE_MSG_PROC mPageMsgCallBack;
        public HalconControl.HWindow_Fit m_HWindow
        {
            set
            {
                hWindow = value;
                if (hWindow != null)
                {
                    m_AcqMindWision.dispImgCallback = dispImage;
                }
            }
        }

        public frm_AcqMindWision(ref AcqDeviceBase _AcqDevice)
        {
            m_AcqMindWision = (AcqMindVision)_AcqDevice;
        }
        public void ShowAttr(IntPtr handle)
        {
            //const int GWL_STYLE=-16;
            //const int WS_CAPTION = 0x00C00000;
            //const int WS_THICKFRAME = 0x00040000;
            if (m_AcqMindWision.m_hCamera > 0)
            {
                mPageMsgCallBack = new CAMERA_PAGE_MSG_PROC(PageMsgCallbackCtx);
                MvApi.CameraCreateSettingPage(m_AcqMindWision.m_hCamera, handle, m_AcqMindWision.m_DevInfo.acFriendlyName, mPageMsgCallBack,/*m_iSettingPageMsgCallbackCtx*/IntPtr.Zero, 0);
                //去掉边框
                //IntPtr hWnd = Helper.User32API.FindWindow(null, System.Text.Encoding.Default.GetString(m_AcqMindWision.m_DevInfo.acFriendlyName));
                //User32API.SetWindowLong(hWnd, GWL_STYLE, User32API.GetWindowLong(hWnd, GWL_STYLE) & ~WS_CAPTION & ~WS_THICKFRAME);
                MvApi.CameraShowSettingPage(m_AcqMindWision.m_hCamera, 1);
            }
        }

        private void dispImage(HImage image, int user)
        {
            try
            {
                hWindow.Invoke(new Action(delegate
                {
                    IntPtr hWnd = Helper.User32API.FindWindow(null, System.Text.Encoding.Default.GetString(m_AcqMindWision.m_DevInfo.acFriendlyName));
                    if (!User32API.IsWindowVisible(hWnd))
                    {
                        mPageMsgCallBack = null;
                        m_AcqMindWision.dispImgCallback = null;
                        return;
                    }
                    hWindow.Image = image;
                    //hWindow.HWindowID.DispImage(image);
                }));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PageMsgCallbackCtx(CameraHandle hCamera, uint MSG, uint uParam, IntPtr pContext)
        {
            if (MSG == 3 && uParam == 0)
            {
                m_AcqMindWision.getSetting();
            }
            //if MSG
        }
    }
}
