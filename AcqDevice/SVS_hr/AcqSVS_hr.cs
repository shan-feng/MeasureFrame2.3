using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using HalconDotNet;
using System.Runtime.Serialization;
using System.IO;

namespace AcqDevice
{
    [Serializable]
    public class AcqSVS_hr : AcqAreaDeviceBase
    {
        [NonSerialized]
        private GigeApi myApi;//api句柄
        private int m_CameraContainer = -1;//相机容器
        private int m_Handle = -1;
        private int m_StreamingChannel;
        private int _LostCount = 0;//记录是否丢帧
        [NonSerialized]
        private GigeApi.StreamCallback GigeCallBack;
        //[NonSerialized]
        //private GigeApi.EventCallback EventCallBack;
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

        private GigeApi.SVSGigeApiReturn apiReturn = GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS; //返回信号
#if DEBUG
        float timeout = 15.0f;// extended timeout for maintaining connection during a debug session
#else
        float timeout = 3.0f;                     // timeout: the time without traffic or heartbeat
                                                 //          after which a camera drops a connection
#endif

        public AcqSVS_hr(DeviceType _DeviceType) : base(_DeviceType)
        {
            myApi = new GigeApi();
        }

        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            int m_CameraContainer = -1;//相机容器

            GigeApi Api = new GigeApi();
            if (m_CameraContainer != GigeApi.SVGigE_NO_CLIENT)
            {
                Api.Gige_CameraContainer_delete(m_CameraContainer);
            }
            m_CameraContainer = Api.Gige_CameraContainer_create(GigeApi.SVGigETL_Type.SVGigETL_TypeFilter);
            if (m_CameraContainer >= 0)
            {
                if (Api.Gige_CameraContainer_discovery(m_CameraContainer) == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                {
                    int camAnz = Api.Gige_CameraContainer_getNumberOfCameras(m_CameraContainer);
                    if (camAnz > 0)
                    {
                        for (int n = 0; n < camAnz; n++)
                        {
                            CamInfo _camInfo = new CamInfo();
                            int handle = Api.Gige_CameraContainer_getCamera(m_CameraContainer, n);
                            _camInfo.m_CamName = Api.Gige_Camera_getModelName(handle);
                            _camInfo.m_SerialNO = Api.Gige_Camera_getSerialNumber(handle);
                            //uint netInt = Convert.ToUInt32(IPAddress.HostToNetworkOrder(handle));
                            _camInfo.m_UniqueName = Api.Gige_Camera_getIPAddress(handle);
                            _camInfo.m_MaskName = Api.Gige_Camera_getSubnetMask(handle);
                            m_CamInfoList.Add(_camInfo);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Error Containerdiscovery:");
                }
            }
            else
            {
                MessageBox.Show("Error ContainerCreate:");
            }
        }

        public override void ConnectDev()
        {
            base.ConnectDev();
            // 如果设备已经连接先断开
            DisConnectDev();
            //Open connection to camera. A control channel will be established.
            m_CameraContainer = myApi.Gige_CameraContainer_create(GigeApi.SVGigETL_Type.SVGigETL_TypeFilter);
            if (m_CameraContainer >= 0)
            {
                if (myApi.Gige_CameraContainer_discovery(m_CameraContainer) == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                {
                    m_Handle = myApi.Gige_CameraContainer_findCamera(m_CameraContainer, m_SerialNo);//也可以传入ip地址
                    apiReturn = myApi.Gige_Camera_openConnection(m_Handle, timeout);
                    if (apiReturn != GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                    {
                        if (apiReturn != GigeApi.SVSGigeApiReturn.SVGigE_SVCAM_STATUS_CAMERA_OCCUPIED)
                        {
                            unsafe
                            {
                                apiReturn = myApi.Gige_Camera_forceValidNetworkSettings(m_Handle, null, null);
                            }
                            if (apiReturn == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                            {
                                apiReturn = myApi.Gige_Camera_openConnection(m_Handle, timeout);
                            }
                            else
                                return;
                        }
                    }
                    setSetting();
                    //LoadSetting(m_SettingPath);
                    //注册回调函数
                    //GigeApi.StreamCallback 
                    GigeCallBack = new GigeApi.StreamCallback(myStreamCallback);
                    // Adjust camera to maximal possible packet size
                    int PacketSize = 0;
                    myApi.Gige_Camera_evaluateMaximalPacketSize(m_Handle, ref (PacketSize));
                    // Adjust desired binning mode (default = OFF, others: 2x2, 3x3, 4x4)
                    myApi.Gige_Camera_setBinningMode(m_Handle, GigeApi.BINNING_MODE.BINNING_MODE_OFF);
                    // Create a matching streaming channel
                    apiReturn = myApi.Gige_StreamingChannel_create(ref (m_StreamingChannel), m_CameraContainer, m_Handle, 10, GigeCallBack, 0);
                    //Create 
                    //EventCallBack = new GigeApi.EventCallback(myEventCallback);
                    //apiReturn = myApi.Gige_Stream_registerEventCallback(ref m_StreamingChannel, m_Handle, EventCallBack, 0);
                    myApi.Gige_Camera_getSizeX(m_Handle, ref _ImgWidth);
                    myApi.Gige_Camera_getSizeY(m_Handle, ref _ImgHeight);
                    GigeApi.SVGIGE_PIXEL_DEPTH pixDepth = GigeApi.SVGIGE_PIXEL_DEPTH.SVGIGE_PIXEL_DEPTH_8;
                    apiReturn = myApi.Gige_Camera_getPixelDepth(m_Handle, ref pixDepth);
                    if (apiReturn == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                    {
                        switch (pixDepth)
                        {
                            case (GigeApi.SVGIGE_PIXEL_DEPTH.SVGIGE_PIXEL_DEPTH_8): { _PixDepth = PIXEL_DEPTH.PIXEL_DEPTH_8; break; }
                            case (GigeApi.SVGIGE_PIXEL_DEPTH.SVGIGE_PIXEL_DEPTH_12): { _PixDepth = PIXEL_DEPTH.PIXEL_DEPTH_12; break; }
                            case (GigeApi.SVGIGE_PIXEL_DEPTH.SVGIGE_PIXEL_DEPTH_16): { _PixDepth = PIXEL_DEPTH.PIXEL_DEPTH_16; break; }

                        }
                    }
                    GigeApi.GVSP_PIXEL_TYPE pixType = GigeApi.GVSP_PIXEL_TYPE.GVSP_PIX_UNKNOWN;
                    apiReturn = myApi.Gige_Camera_getPixelType(m_Handle, ref (pixType));
                    if (apiReturn == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                    {
                        switch (pixType)
                        {
                            ///更多类型在此添加
                            case (GigeApi.GVSP_PIXEL_TYPE.GVSP_PIX_MONO8): { _PixType = PIXEL_TYPE.PIX_GRAY8; break; }
                        }
                    }

                    m_bConnected = true;
                }
            }
        }

        public override void DisConnectDev()
        {
            if (m_bConnected)
            {
                apiReturn = myApi.Gige_Camera_setAcquisitionControl(m_Handle, GigeApi.ACQUISITION_CONTROL.ACQUISITION_CONTROL_STOP);
                // Remove streaming channel
                //apiReturn = myApi.Gige_Stream_unregisterEventCallback(m_StreamingChannel, m_Handle, myEventCallback);
                apiReturn = myApi.Gige_StreamingChannel_delete(m_StreamingChannel);
                m_StreamingChannel = m_StreamingChannel - 1;
                // Close camera
                apiReturn = myApi.Gige_Camera_closeConnection(m_Handle);
                m_bConnected = false;
                m_Handle = -1;
                if (apiReturn != GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                {
                    MessageBox.Show("Errorflag: " + apiReturn.ToString());
                }
            }
        }

        [return: MarshalAs(UnmanagedType.Error)]
        public GigeApi.SVSGigeApiReturn myStreamCallback(int Image, int Context)
        {
            IntPtr imgPtr;
            try
            {
                imgPtr = myApi.Gige_Image_getDataPointer(Image);

                if ((long)(imgPtr) == 0)
                {
                    _LostCount++;
                    DisConnectDev();
                    MessageBox.Show("相机失连", "提示", MessageBoxButtons.OK,MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    return (GigeApi.SVSGigeApiReturn.SVGigE_SVCAM_STATUS_CONNECTION_LOST);
                }
                _ImgWidth = myApi.Gige_Image_getSizeX(Image);
                _ImgHeight = myApi.Gige_Image_getSizeY(Image);
                switch (_PixDepth)
                {
                    case (PIXEL_DEPTH.PIXEL_DEPTH_8):
                        {
                            m_Image.GenImage1("byte", _ImgWidth, _ImgHeight, imgPtr);
                            eventWait.Set();
                            //_Image.WriteImage("bmp", 0, "E:/test0.bmp");
                            if (dispImgCallback != null)
                            {
                                dispImgCallback(m_Image, Context);
                            }
                            break;
                        }
                }
                //使用委托传递出去
                //eventWait.Set();
                return (GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS);
            }
            catch (System.Exception ex)
            {
                eventWait.Set();
                //MessageBox.Show("callback error");
                return (GigeApi.SVSGigeApiReturn.SVGigE_ERROR);
            }

        }

        //public GigeApi.SVSGigeApiReturn myEventCallback([MarshalAs(UnmanagedType.I4)] int EventID, [MarshalAs(UnmanagedType.I4)] int Context)
        //{
        //    MessageBox.Show(EventID.ToString() + " " + Context.ToString());
        //    return GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS;
        //}

        public override void setSetting()
        {
            //设置曝光模式
            apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, (GigeApi.ACQUISITION_MODE)_TrigerMode);
            //设置曝光时间
            apiReturn = myApi.Gige_Camera_setExposureTime(m_Handle, _ExposeTime);
            //置帧率
            apiReturn = myApi.Gige_Camera_setFrameRate(m_Handle, _Framerate);
            //设置ip
            //apiReturn = myApi.Gige_Camera_setIPAddress(m_Handle, uint.Parse(_UniqueLabel), uint.Parse(_DevDirExt));
            base.setSetting();
        }

        public override void getSetting()
        {
            GigeApi.ACQUISITION_MODE trigerMode = GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_FIXED_FREQUENCY;
            apiReturn = myApi.Gige_Camera_getAcquisitionMode(m_Handle, ref trigerMode);
            _TrigerMode = (int)trigerMode;
            apiReturn = myApi.Gige_Camera_getExposureTime(m_Handle, ref _ExposeTime);
            apiReturn = myApi.Gige_Camera_getFrameRate(m_Handle, ref _Framerate);
            base.getSetting();
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        public override void LoadSetting(string filePath)
        {
            if (File.Exists(filePath))
            {
                base.LoadSetting(filePath);
                apiReturn = myApi.Gige_Camera_loadSettingsFromXml(m_Handle, filePath);
            }
        }

        public override void SaveSetting(string filePath)
        {
            base.SaveSetting(filePath);
            apiReturn = myApi.Gige_Camera_SaveSettingsToXml(m_Handle, filePath);
        }

        public override bool setExposureTime(double dValue)
        {
            m_ExposeTime = (float)dValue;
            apiReturn = myApi.Gige_Camera_setExposureTime(m_Handle, _ExposeTime);
            if (apiReturn == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                return true;
            else
                return false;
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
                    //设置曝光模式
                    int temp_Trigger = _TrigerMode;
                    apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_SOFTWARE_TRIGGER);
                    apiReturn = myApi.Gige_Camera_startAcquisitionCycle(m_Handle);
                    apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, (GigeApi.ACQUISITION_MODE)temp_Trigger);
                }
                else
                {
                    if (_TrigerMode == (int)GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_SOFTWARE_TRIGGER)
                    {
                        SignalWait.Reset();
                        SignalWait.WaitOne();
                        apiReturn = myApi.Gige_Camera_startAcquisitionCycle(m_Handle);
                    }
                }

                if (apiReturn != GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                {
                    MessageBox.Show("Errorflag: " + apiReturn.ToString());
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

        public override bool SetTriggerMode(TRIGGER_MODE mode)
        {
            switch (mode)
            {
                case TRIGGER_MODE.内触发:   // no acquisition
                    {
                        apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_FIXED_FREQUENCY);
                        break;
                    }
                case TRIGGER_MODE.软触发:   // freerunning
                    {
                        apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_SOFTWARE_TRIGGER);
                        break;
                    }
                case TRIGGER_MODE.上升沿:   // Software trigger
                    {
                        apiReturn = myApi.Gige_Camera_setTriggerPolarity(m_Handle, GigeApi.TRIGGER_POLARITY.TRIGGER_POLARITY_POSITIVE);
                        apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_EXT_TRIGGER_INT_EXPOSURE);
                        break;
                    }
                case TRIGGER_MODE.下降沿:   // Software trigger
                    {
                        apiReturn = myApi.Gige_Camera_setTriggerPolarity(m_Handle, GigeApi.TRIGGER_POLARITY.TRIGGER_POLARITY_NEGATIVE);
                        apiReturn = myApi.Gige_Camera_setAcquisitionMode(m_Handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_EXT_TRIGGER_INT_EXPOSURE);
                        break;
                    }
            }
            if (apiReturn == GigeApi.SVSGigeApiReturn.SVGigE_SUCCESS)
                return true;
            else
                return false;
        }
        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            myApi = new GigeApi();
        }
    }
}
