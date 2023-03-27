using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using HalconDotNet;
using System.Runtime.Serialization;
using TIS.Imaging;
using System.IO;

namespace AcqDevice
{
    [Serializable]
    public class AcqImaging : AcqAreaDeviceBase
    {
        [NonSerialized]
        private TIS.Imaging.VCDAbsoluteValueProperty ExposureAbsoluteValue;//绝对曝光值属性
        //[NonSerialized]
        //private TIS.Imaging.VCDSwitchProperty ExposureSwith;//开关属性
        [NonSerialized]
        private TIS.Imaging.VCDButtonProperty Softtrigger;//触发属性
        [NonSerialized]
        private TIS.Imaging.VCDSwitchProperty TrigEnableSwitch;//触发使能开关
        [NonSerialized]
        private TIS.Imaging.VCDAbsoluteValueProperty Trigger_Delay_Time;//触发延时属性值对象
        //[NonSerialized]
        //private TIS.Imaging.VCDSwitchProperty TriPolarity;//触发极性属性
        [NonSerialized]
        private TIS.Imaging.VCDAbsoluteValueProperty Trigger_Debounce_Time;//Debounce属性

        [NonSerialized]
        public TIS.Imaging.ICImagingControl camera = new ICImagingControl();
        public float m_ExposeTime
        {
            set { _ExposeTime = value; }
            get { return _ExposeTime; }
        }
        public object extInfo
        {
            set { camera.Device = ((Device)value).Name; }
            get { return camera.Device; }
        }

        public AcqImaging(DeviceType _DeviceType) : base(_DeviceType)
        {
        }

        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            TIS.Imaging.ICImagingControl imgControl = new TIS.Imaging.ICImagingControl();
            DialogResult result = imgControl.ShowDeviceSettingsDialog();
            if (result == DialogResult.OK)
            {
                CamInfo _camInfo = new CamInfo();
                string temp = string.Empty;
                imgControl.DeviceCurrent.GetSerialNumber(out temp);
                _camInfo.m_CamName = "Imaging" + imgControl.DeviceCurrent.Name + temp;
                _camInfo.m_SerialNO = temp;
                _camInfo.m_UniqueName = temp;
                _camInfo.m_MaskName = temp;
                _camInfo.mExtInfo = imgControl.DeviceCurrent;
                m_CamInfoList.Add(_camInfo);
            }

        }

        public override void ConnectDev()
        {
            try
            {
                base.ConnectDev();
                // 如果设备已经连接先断开
                DisConnectDev();

                if (!camera.DeviceValid)
                {
                    m_bConnected = false;
                    return;
                }
                
                //初始化控件
                TriEnable(camera);//触发初始化
                camera.LiveCaptureContinuous = true;//设为回调模式
                                                    //camera.LiveDisplayDefault = false;
                camera.MemoryCurrentGrabberColorformat = TIS.Imaging.ICImagingControlColorformats.ICY8;//黑白格式为：ICY8；彩色格式为：ICRGB32,彩色格式需要更新
                camera.ImageAvailable += new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(TIS_ImageAvailable);

                camera.LiveStart();
                m_bConnected = true;
            }
            catch (Exception ex)
            {
                m_bConnected = false;
            }

        }

        public override void DisConnectDev()
        {
            if (m_bConnected /*&& camera.DeviceValid*/)
            {
                camera.ImageAvailable -= new System.EventHandler<TIS.Imaging.ICImagingControl.ImageAvailableEventArgs>(TIS_ImageAvailable);
                camera.LiveStop();
                m_bConnected = false;
            }
        }

        [return: MarshalAs(UnmanagedType.Error)]
        private void TIS_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            //TIS.Imaging.ICImagingControl IC_Callback = sender as TIS.Imaging.ICImagingControl;
            try
            {
                m_Image.GenImage1("byte", e.ImageBuffer.Size.Width, e.ImageBuffer.Size.Height, e.ImageBuffer.GetImageDataPtr());
                eventWait.Set();
                if (dispImgCallback != null)
                {
                    dispImgCallback(m_Image, 0);
                }
            }
            catch (System.Exception ex)
            {
                eventWait.Set();
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
                if (byHand)
                {
                    //设置曝光模式
                    bool blnTriger = camera.DeviceTrigger;
                    TrigEnableSwitch.Switch = true;
                    Strigger(camera);

                    //TrigEnableSwitch.Switch = blnTriger;
                }
                else
                {
                    //if (_TrigerMode == 1)
                    if (camera.DeviceCurrent!=null&&camera.DeviceTrigger == true)
                    {
                        SignalWait.Reset();
                        SignalWait.WaitOne();
                        //拍一张
                        Strigger(camera);
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

        public override void SaveSetting(string filePath)
        {
            camera.SaveDeviceStateToFile(filePath);
        }
        public override void LoadSetting(string filePath)
        {
            if (File.Exists(filePath))
            {
                camera.LoadDeviceStateFromFile(filePath, true);
            }
        }
        //SN号打开相机
        public void OpenBySN(TIS.Imaging.ICImagingControl icImagingControl1, string Ctemp)
        {
            string temp = "";
            if (icImagingControl1.Devices.Length > 0)
            {
                foreach (Device Dev in icImagingControl1.Devices)
                {
                    if (Dev.GetSerialNumber(out temp))
                    {
                        if (temp == Ctemp)//判断是否等于指定相机序号
                        {
                            icImagingControl1.Device = Dev.Name;
                            break;
                        }
                    }
                }
                if (!icImagingControl1.DeviceValid)
                {
                    MessageBox.Show("映美精没有找到相机，是否SN号有误！");

                }
            }
            else
            {
                MessageBox.Show("没有找到设备,请确认相机是否连接好");
            }
        }

        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            camera = new ICImagingControl();
        }
        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            OpenBySN(camera, m_SerialNo);
            if(camera.DeviceCurrent != null)
            camera.DeviceFrameRate = 24;//默认设置帧率24帧
        }
        #region 功能函数


        public override bool setExposureTime(double dValue)
        {
            try
            {
                dValue = dValue / 1000;
                //ExposureSwith = (TIS.Imaging.VCDSwitchProperty)camera.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Auto + ":" + VCDIDs.VCDInterface_Switch);
                //ExposureSwith.Switch = false;//关闭自动曝光
                //绝对曝光对象初始化
                ExposureAbsoluteValue = (TIS.Imaging.VCDAbsoluteValueProperty)camera.VCDPropertyItems.FindInterface(VCDIDs.VCDID_Exposure + ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);

                if (dValue <= ExposureAbsoluteValue.RangeMin)
                {
                    ExposureAbsoluteValue.Value = ExposureAbsoluteValue.RangeMin;
                }
                else if (dValue >= ExposureAbsoluteValue.RangeMax)
                {
                    ExposureAbsoluteValue.Value = ExposureAbsoluteValue.RangeMax;
                }
                else
                {
                    ExposureAbsoluteValue.Value = dValue;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        //触发使能初始化
        public void TriEnable(TIS.Imaging.ICImagingControl icImagingControl1)
        {
            TrigEnableSwitch = (TIS.Imaging.VCDSwitchProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_Value + ":" + TIS.Imaging.VCDIDs.VCDInterface_Switch);
        }

        //软触发
        public void Strigger(TIS.Imaging.ICImagingControl icImagingControl1)
        {
            try
            {
                Softtrigger = (TIS.Imaging.VCDButtonProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_SoftwareTrigger + ":" + TIS.Imaging.VCDIDs.VCDInterface_Button);

            Softtrigger.Push();//软触发
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Strigger(icImagingControl1);
            }
            
        }

        //触发延时
        public void TrigDelay(TIS.Imaging.ICImagingControl icImagingControl1, double Dtime)
        {
            Trigger_Delay_Time = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_TriggerDelay + ":" + TIS.Imaging.VCDIDs.VCDInterface_AbsoluteValue);

            if (Dtime <= Trigger_Delay_Time.RangeMin)
            {
                Trigger_Delay_Time.Value = Trigger_Delay_Time.RangeMin;
            }
            else if (Dtime >= Trigger_Delay_Time.RangeMax)
            {
                Trigger_Delay_Time.Value = Trigger_Delay_Time.RangeMax;
            }
            else
            {
                Trigger_Delay_Time.Value = Dtime;
            }

        }

        //Debounce
        public void TriDebounce(TIS.Imaging.ICImagingControl icImagingControl1, double DeTime)
        {
            Trigger_Debounce_Time = (TIS.Imaging.VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_TriggerMode + ":" +
                TIS.Imaging.VCDIDs.VCDElement_TriggerDebounceTime + ":" + TIS.Imaging.VCDIDs.VCDInterface_AbsoluteValue);

            if (DeTime <= Trigger_Debounce_Time.RangeMin)
            {
                Trigger_Debounce_Time.Value = Trigger_Debounce_Time.RangeMin;
            }
            else if (DeTime >= Trigger_Debounce_Time.RangeMax)
            {
                Trigger_Debounce_Time.Value = Trigger_Debounce_Time.RangeMax;
            }
            else
            {
                Trigger_Debounce_Time.Value = DeTime;
            }
        }

        #endregion
    }
}
