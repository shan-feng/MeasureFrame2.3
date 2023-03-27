using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using HalconDotNet;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using MVSDK;//使用SDK接口
using CameraHandle = System.Int32;
using MvApi = MVSDK.MvApi;
using System.IO;
using System.Runtime.Serialization;

namespace AcqDevice
{
    [Serializable]
    public class AcqMindVision : AcqAreaDeviceBase
    {
        private int _LostCount = 0;//记录是否丢帧
        public IntPtr m_handle;
        private int m_Handle = -1;

        public int m_LostCount
        {
            get { return _LostCount; }
        }

        public float m_ExposeTime
        {
            set { _ExposeTime = value; }
            get { return _ExposeTime; }
        }

        public int m_TrigerMode
        {
            set { _TrigerMode = value; }
            get { return _TrigerMode; }
        }

        public float m_Framerate
        {
            set { _Framerate = value; }
            get { return _Framerate; }
        }

        private CameraSdkStatus status = CameraSdkStatus.CAMERA_STATUS_SUCCESS; //返回信号
#if DEBUG
        float timeout = 15.0f;// extended timeout for maintaining connection during a debug session
#else
        float timeout = 3.0f;                     // timeout: the time without traffic or heartbeat
                                                 //          after which a camera drops a connection
#endif
        #region variable
        public CameraHandle m_hCamera = 0;             // 句柄
        //protected IntPtr m_ImageBuffer;             // 预览通道RGB图像缓存
        //protected IntPtr m_ImageBufferSnapshot;     // 抓拍通道RGB图像缓存
        //protected static tSdkCameraCapbility tCameraCapability;  // 相机特性描述
        //protected int m_iDisplayedFrames = 0;    //已经显示的总帧数
        protected CAMERA_SNAP_PROC m_CaptureCallback;
        //protected IntPtr m_iCaptureCallbackCtx;     //图像回调函数的上下文参数
        //protected tSdkFrameHead m_tFrameHead;
        //protected bool m_bSaveImage = false;
        public tSdkCameraDevInfo m_DevInfo;
        #endregion
        //private bool isCapturing = false;
        static tSdkCameraDevInfo[] tCameraDevInfoList;

        public AcqMindVision(DeviceType _DeviceType)
            : base(_DeviceType)
        {
            _TrigerMode = 2;
        }

        public AcqMindVision(DeviceType _DeviceType, System.IntPtr mhandle)
            : base(_DeviceType)
        {
            m_handle = mhandle;
            _TrigerMode = 2;
        }

        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            IntPtr _Grabber;
            if (MvApi.CameraGrabber_CreateFromDevicePage(out _Grabber) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
            {
                tSdkCameraDevInfo _DevInfo;
                MvApi.CameraGrabber_GetCameraDevInfo(_Grabber, out _DevInfo);
                CamInfo _camInfo = new CamInfo();
                _camInfo.m_CamName = System.Text.Encoding.Default.GetString(_DevInfo.acProductName).Split('\0')[0];
                _camInfo.m_SerialNO = System.Text.Encoding.Default.GetString(_DevInfo.acSn).Split('\0')[0];
                _camInfo.m_UniqueName = System.Text.Encoding.Default.GetString(_DevInfo.acFriendlyName).Split('\0')[0];
                _camInfo.m_MaskName = System.Text.Encoding.Default.GetString(_DevInfo.acLinkName).Split('\0')[0];
                _camInfo.mExtInfo = _DevInfo;
                m_CamInfoList.Add(_camInfo);
                MvApi.CameraGrabber_Destroy(_Grabber);
            }
        }

        public override void ConnectDev()
        {
            base.ConnectDev();
            DisConnectDev();// 如果设备已经连接先断开
            IntPtr m_Grabber = IntPtr.Zero;
            CAMERA_SNAP_PROC pCaptureCallOld = null;
            tSdkCameraCapbility tCameraCapability;
            IntPtr m_iCaptureCallbackCtx = IntPtr.Zero;
            if (MvApi.CameraGrabber_Create(out m_Grabber, ref m_DevInfo) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
            {
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out m_hCamera);//获得句柄
                status = MvApi.CameraInit(ref m_DevInfo, -1, -1, ref m_hCamera);
                status = MvApi.CameraGetCapability(m_hCamera, out tCameraCapability);
                if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                {
                    //tSdkImageResolution tResolution = new tSdkImageResolution();
                    //status = MvApi.CameraSetResolutionForSnap(m_hCamera, ref tResolution);
                    _ImgWidth = tCameraCapability.sResolutionRange.iWidthMax;
                    _ImgHeight = tCameraCapability.sResolutionRange.iHeightMax;

                    m_CaptureCallback = new CAMERA_SNAP_PROC(ImageCaptureCallback);
                    status = MvApi.CameraSetCallbackFunction(m_hCamera, m_CaptureCallback, m_iCaptureCallbackCtx, ref pCaptureCallOld);
                    m_bConnected = true;
                    return;
                }
            }
            else
            {
                m_bConnected = false;
            }
            Marshal.FreeHGlobal(m_Grabber);
            Marshal.FreeHGlobal(m_iCaptureCallbackCtx);

        }

        public override void DisConnectDev()
        {
            if (m_bConnected)
            {
                status = MvApi.CameraUnInit(m_hCamera);
                m_bConnected = false;
                m_Handle = -1;
            }
        }

        public override void setSetting()
        {
            //设置曝光模式
            status = MvApi.CameraSetTriggerMode(m_hCamera, _TrigerMode);
            //设置曝光时间
            status = MvApi.CameraSetExposureTime(m_hCamera, _ExposeTime);
            //置帧率
            status = MvApi.CameraSetFrameSpeed(m_hCamera, (int)_Framerate);
            base.setSetting();
        }

        public override void getSetting()
        {
            status = MvApi.CameraGetTriggerMode(m_hCamera, ref _TrigerMode);
            double dbtemp = 0;
            status = MvApi.CameraGetExposureTime(m_hCamera, ref dbtemp);
            _ExposeTime = (float)dbtemp;
            int inttemp = 0;
            status = MvApi.CameraGetFrameSpeed(m_hCamera, ref inttemp);
            _Framerate = inttemp;
            base.getSetting();
        }

        public override void LoadSetting(string filePath)
        {
            if (File.Exists(filePath))
            {
                base.LoadSetting(filePath);
                //status = MvApi.CameraLoadParameter(m_hCamera,);
            }
        }

        public override void SaveSetting(string filePath)
        {
            base.SaveSetting(filePath);
            //status = MvApi.CameraSetCallbackFunction();
        }

        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="byHand">是否手动采图</param>
        public override bool CaptureImage(bool byHand)
        {
            try
            {
                if (byHand)
                {
                    CameraHandle triggerMode = -1;
                    status = MvApi.CameraGetTriggerMode(m_hCamera, ref triggerMode);
                    if (triggerMode != 1)
                        status = MvApi.CameraSetTriggerMode(m_hCamera, 1);
                    if (m_hCamera <= 0)
                        return false;//相机还未初始化，句柄无效
                    status = MvApi.CameraSoftTrigger(m_hCamera);
                    MvApi.CameraSetTriggerMode(m_hCamera, triggerMode);
                }
                else
                {
                    if (_TrigerMode == 1)
                    {
                        SignalWait.WaitOne();
                        //status = MvApi.CameraPlay(m_hCamera);
                        status = MvApi.CameraSoftTrigger(m_hCamera);
                        SignalWait.Reset();
                    }
                }

                if (status != CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                {
                    MessageBox.Show("Errorflag: " + status.ToString());
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public void ImageCaptureCallback(CameraHandle hCamera, IntPtr pFrameBuffer, ref tSdkFrameHead pFrameHead, IntPtr pContext)
        {
            //MvApi.CameraImageProcess(hCamera, pFrameBuffer, m_ImageBuffer, ref pFrameHead);//图像处理，将原始输出转换为RGB格式的位图数据，同时叠加白平衡、饱和度、LUT等ISP处理。
            //MvApi.CameraImageOverlay(hCamera, m_ImageBuffer, ref pFrameHead); //叠加十字线、自动曝光窗口、白平衡窗口信息(仅叠加设置为可见状态的)。  
            //MvApi.CameraDisplayRGB24(hCamera, m_ImageBuffer, ref pFrameHead);//调用SDK封装好的接口，显示预览图像
            //m_tFrameHead = pFrameHead;
            //m_iDisplayedFrames++;

            try
            {
                m_Image.GenImage1("byte", _ImgWidth, _ImgHeight, pFrameBuffer);
                if (dispImgCallback != null)
                {
                    dispImgCallback(m_Image, (int)pContext);
                }
                else
                {//使用委托传递出去
                    eventWait.Set();
                }
                return;
            }
            catch (System.Exception ex)
            {
                eventWait.Set();
                return;
            }
        }

        public override bool SetTriggerMode(TRIGGER_MODE mode)
        {
            switch (mode)
            {
                case TRIGGER_MODE.内触发:   // no acquisition
                    {
                        status = MvApi.CameraSetTriggerMode(m_hCamera, 0);
                        break;
                    }
                case TRIGGER_MODE.软触发:   // freerunning
                    {
                        status = MvApi.CameraSetTriggerMode(m_hCamera, 1);
                        break;
                    }
                case TRIGGER_MODE.上升沿:   // Software trigger
                    {
                        status = MvApi.CameraSetTriggerMode(m_hCamera, 2);
                        break;
                    }
                case TRIGGER_MODE.下降沿:   // Software trigger
                    {
                        status = MvApi.CameraSetTriggerMode(m_hCamera, 2);
                        break;
                    }
            }
            if (status == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                return true;
            else
                return false;
        }

        public void SoftTriggerOne()
        {
            MvApi.CameraSoftTrigger(m_hCamera);
        }
    }
}
