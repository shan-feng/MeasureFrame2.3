using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GxIAPINET;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace AcqDevice
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AcqDaheng : AcqAreaDeviceBase
    {
        [NonSerialized]
        private IGXDevice IGXDevice1 = null;
        [NonSerialized]
        /// <summary>
        /// Factory对像
        /// </summary>
        static IGXFactory IGXFactory1 = null;
        [NonSerialized]
        /// <summary>
        /// 流对像
        /// </summary>
        private IGXStream IGXStream1 = null;
        [NonSerialized]
        /// <summary>
        /// 远端设备属性控制器对像
        /// </summary>
        private IGXFeatureControl IGXFeatureControl = null;

        static IGXFactory GetIGXFactory()
        {
            if (IGXFactory1 == null)
            {
                IGXFactory1 = IGXFactory.GetInstance();
                IGXFactory1.Init();
            }
            return IGXFactory1;
        }
        public AcqDaheng(DeviceType _DeviceType) : base(_DeviceType)
        {
        }

        public int m_TrigerMode
        {
            set
            { _TrigerMode = value; }
            get
            { return _TrigerMode; }
        }

        public float m_ExposeTime
        {
            set
            {
                _ExposeTime = value;
            }
            get
            {
                return _ExposeTime;
            }
        }

        /// <summary>
        /// 搜索相机
        /// </summary>
        /// <param name="m_CamInfoList"></param>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();

            List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
            IGXFactory IGXFactory1 = IGXFactory.GetInstance();
            IGXFactory1.Init();
            IGXFactory1.UpdateDeviceList(200, listGXDeviceInfo);
            foreach (var item in listGXDeviceInfo)
            {
                string sn = item.GetSN();
                CamInfo _camInfo = new CamInfo();
                _camInfo.m_CamName = "Daheng" + sn;
                _camInfo.m_SerialNO = sn;
                _camInfo.m_UniqueName = "Daheng" + sn;
                _camInfo.m_MaskName = "Daheng" + sn;
                m_CamInfoList.Add(_camInfo);
            }
        }

        /// <summary>
        /// 连接相机
        /// </summary>
        public override void ConnectDev()
        {
            try
            {

                base.ConnectDev();
                // 如果设备已经连接先断开
                DisConnectDev();
                IGXDevice1 = IGXFactory1.OpenDeviceBySN(this.m_SerialNo, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                IGXFeatureControl = IGXDevice1.GetRemoteFeatureControl();
                if (null != IGXDevice1)
                {
                    IGXStream1 = IGXDevice1.OpenStream(0);
                }
                //初始化相机参数
                if (null != IGXFeatureControl)
                {
                    //设置采集模式连续采集------------------------------
                    IGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                    //设置触发模式为开 触发了才采集
                    IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                }
                //开启采集流通道
                if (null != IGXStream1)
                {
                    //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用
                    //类型)，若用户想用这个参数可以在委托函数中进行使用
                    IGXStream1.RegisterCaptureCallback(this, CaptureCallbackPro);
                    IGXStream1.StartGrab();
                }

                //发送开采命令
                if (null != IGXFeatureControl)
                {
                    IGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                }

                m_bConnected = true;
            }
            catch (Exception ex)
            {
                m_bConnected = false;
            }
        }

        /// <summary>
        /// 断开相机
        /// </summary>
        public override void DisConnectDev()
        {
            if (m_bConnected)
            {
                // Destroy the camera object.
                try
                {

                    try
                    {
                        // 如果未停采则先停止采集
                        if (null != IGXFeatureControl)
                        {
                            IGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                            IGXFeatureControl = null;
                        }
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        //停止流通道、注销采集回调和关闭流
                        if (null != IGXStream1)
                        {
                            IGXStream1.StopGrab();
                            //注销采集回调函数
                            IGXStream1.UnregisterCaptureCallback();
                            IGXStream1.Close();
                            IGXStream1 = null;
                        }
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        //关闭设备
                        if (null != IGXDevice1)
                        {
                            IGXDevice1.Close();
                            IGXDevice1 = null;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    m_bConnected = false;
                }
                catch (Exception e)
                {
                }
            }
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        public override bool setExposureTime(double dValue)
        {
            try
            {
                IGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(dValue);
                //camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(dValue);
                //bool ok= camera.Parameters[PLCamera.ExposureTimeAbs].TrySetValue(dValue);
                //double xxx=camera.Parameters[PLCamera.ExposureTimeAbs].GetValue();

                //double? xxx1 = camera.Parameters[PLCamera.ExposureTimeAbs].GetIncrement();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 设置触发
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public override bool SetTriggerMode(TRIGGER_MODE mode)
        {
            try
            {

                switch (mode)
                {
                    case TRIGGER_MODE.内触发:   // no acquisition
                        {
                            if (null != IGXFeatureControl)
                            {
                                //设置触发模式为关
                                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
                            }
                            break;
                        }
                    case TRIGGER_MODE.软触发:   // freerunning
                        {

                            if (null != IGXFeatureControl)
                            {
                                //设置触发模式为开
                                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                                IGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("S----");
                            }
                            break;
                        }
                    case TRIGGER_MODE.上升沿:   // Software trigger
                        {
                          
                            if (null != IGXFeatureControl)
                            {
                                //设置当前功能值
                                IGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line1");
                                //设置触发模式为开
                                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                                IGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line1");
                                IGXFeatureControl.GetEnumFeature("TriggerActivation").SetValue("O----");
                            }
                            break;
                        }
                    case TRIGGER_MODE.下降沿:   // Software trigger
                        {
                            if (null != IGXFeatureControl)
                            {
                                //设置当前功能值
                                IGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line1");
                                //设置触发模式为开
                                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                                IGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line1");
                                IGXFeatureControl.GetEnumFeature("TriggerActivation").SetValue("O----");
                            }
                            break;
                        }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }




        }

        private void SetTriggerMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    {
                        SetTriggerMode(TRIGGER_MODE.内触发);
                        break;
                    }
                case 1:
                    {

                        SetTriggerMode(TRIGGER_MODE.软触发);
                        break;
                    }
                case 2:
                    {
                        SetTriggerMode(TRIGGER_MODE.上升沿);
                        break;
                    }
                case 5:
                    {
                        SetTriggerMode(TRIGGER_MODE.下降沿);
                        break;
                    }
            }
        }


        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="byHand">是否手动采图</param>
        public override bool CaptureImage(bool byHand)
        {
            try
            {
                //if (camera == null)
                //{
                //    MessageBox.Show("相机未连接");
                //    //return false;
                //}
                //if (camera.IsConnected==false)
                //{
                //    MessageBox.Show("相机未连接");
                //    //return false;
                //}
                if (byHand)
                {

                    //设置曝光模式
                    int temp_Trigger = _TrigerMode;
                    SetTriggerMode(TRIGGER_MODE.软触发);
                    //拍一张
                    //发送软触发命令
                    if (null != IGXFeatureControl)
                    {
                        IGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();
                    }
                    //还原之前的触发模式
                    SetTriggerMode(temp_Trigger);
                }
                else
                {
                    if (_TrigerMode == 1)
                    {
                        SignalWait.WaitOne();
                        //拍一张
                        //发送软触发命令
                        if (null != IGXFeatureControl)
                        {
                            IGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();
                        }
                        SignalWait.Reset();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="filePath"></param>
        public override void LoadSetting(string filePath)
        {
            base.LoadSetting(filePath);
        }

        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="filePath"></param>
        public override void SaveSetting(string filePath)
        {
            base.SaveSetting(filePath);
            //if (camera!=null)
            //{
            //    camera.Parameters.Save
            //}
        }

        public override void setSetting()
        {
            //设置曝光模式
            SetTriggerMode(_TrigerMode);
            //设置曝光时间
            setExposureTime(_ExposeTime);

            base.setSetting();
        }

        public override void getSetting()
        {
            base.getSetting();
        }


        #region 相机事件

        private void CaptureCallbackPro(object objUserParam, IFrameData objIFrameData)
        {
            try
            {

                if (objIFrameData.GetPixelFormat() == GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8)
                {
                    m_Image.GenImage1("byte", (int)objIFrameData.GetWidth(), (int)objIFrameData.GetHeight(), objIFrameData.GetBuffer());

                    if (dispImgCallback != null)
                    {
                        dispImgCallback(m_Image, 1);//1 无意义
                    }

                }
                else if (objIFrameData.GetPixelFormat() == GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_RGB8_PLANAR)
                {

                    m_Image.GenImageInterleaved(objIFrameData.GetBuffer(),
                    "rgb",
                    (int)objIFrameData.GetWidth(), (int)objIFrameData.GetHeight(),
                    -1, "byte",
                     (int)objIFrameData.GetWidth(), (int)objIFrameData.GetHeight(),
                    0, 0, -1, 0);

                    if (dispImgCallback != null)
                    {
                        dispImgCallback(m_Image, 1);//1 无意义
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //使用委托传递出去
                eventWait.Set();
            }
        }
        #endregion

        /// <summary>
        /// 开始实时采集
        /// </summary>
        public void startGrab()
        {
            #region 修改触发模式
            if (null != IGXFeatureControl)
            {
                //设置触发模式为关
                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
            }
            #endregion
        }

        /// <summary>
        /// 停止实时采集
        /// </summary>
        public void stopGrab()
        {
            #region 修改触发模式
            if (null != IGXFeatureControl)
            {
                //设置触发模式为开
                IGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
            }
            #endregion
        }


        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
        }
    }
}
