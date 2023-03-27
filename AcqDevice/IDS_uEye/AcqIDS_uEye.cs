using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;

namespace AcqDevice
{
    [Serializable]
    public class AcqIDS_uEye : AcqAreaDeviceBase
    {
        [NonSerialized]
        public uEye.Camera m_Camera = new uEye.Camera();

        public AcqIDS_uEye(DeviceType _DeviceType) : base(_DeviceType)
        {
        }
        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();

            uEye.Types.CameraInformation[] cameraList;
            uEye.Info.Camera.GetCameraList(out cameraList);
            foreach (uEye.Types.CameraInformation info in cameraList)
            {
                CamInfo _camInfo = new CamInfo();
                _camInfo.m_CamName = info.Model;
                _camInfo.m_SerialNO = info.DeviceID.ToString();
                uEye.Types.ETH.DeviceInformation eth = new uEye.Types.ETH.DeviceInformation();
                uEye.Info.Camera.GetDeviceInfo(Convert.ToInt32(info.DeviceID), out eth);
                _camInfo.m_UniqueName = eth.DeviceHeartbeat.PersistentIpConfiguration.Address.ToString();
                _camInfo.m_MaskName = eth.DeviceHeartbeat.PersistentIpConfiguration.Subnetmask.ToString();
                m_CamInfoList.Add(_camInfo);
            }
        }

        public override void ConnectDev()
        {
            DisConnectDev();
            uEye.Defines.Status statusRet = uEye.Defines.Status.NO_SUCCESS;
            statusRet = m_Camera.Init(int.Parse(m_SerialNo) | (Int32)uEye.Defines.DeviceEnumeration.UseDeviceID);
            if (statusRet != uEye.Defines.Status.SUCCESS)
            {
                MessageBox.Show("Initializing the camera failed");
                return;
            }

            Int32[] memList;
            statusRet = m_Camera.Memory.GetList(out memList);
            statusRet = m_Camera.Memory.Free(memList);
            //statusRet = m_Camera.Parameter.Load(m_SettingPath);
            m_Camera.Parameter.Load();
            SetTriggerMode();

            statusRet = m_Camera.Memory.Allocate();
            if (statusRet != uEye.Defines.Status.SUCCESS)
            {
                MessageBox.Show("Allocating memory failed");
                return;
            }

            System.Drawing.Rectangle rect;
            statusRet = m_Camera.Size.AOI.Get(out rect);
            _ImgWidth = rect.Width;
            _ImgHeight = rect.Height;

            m_bConnected = true;
            // set event
            m_Camera.EventFrame += onFrameEvent;
        }

        public override void DisConnectDev()
        {
            if (m_bConnected && m_Camera.IsOpened)
            {
                m_Camera.EventFrame -= onFrameEvent;
                m_Camera.Exit();
            }
            m_bConnected = false;
        }

        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="byHand">是否手动采图</param>
        public override bool CaptureImage(bool byHand)
        {
            try
            {
                uEye.Defines.Status statusRet = uEye.Defines.Status.NO_SUCCESS;
                uEye.Defines.TriggerMode TriggerMode;
                m_Camera.Trigger.Get(out TriggerMode);
                if (byHand)
                {
                    if (TriggerMode == uEye.Defines.TriggerMode.Software)
                    {
                        statusRet = m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Force);
                    }
                    else
                    {
                        statusRet = m_Camera.Acquisition.Stop();
                        statusRet = m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Software);
                        statusRet = m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Force);

                        statusRet = m_Camera.Trigger.Set(TriggerMode);
                        statusRet = m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                    }
                }
                else
                {
                    if (TriggerMode == uEye.Defines.TriggerMode.Software)
                    {
                        SignalWait.WaitOne();
                        statusRet = m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Force);
                        SignalWait.Reset();
                    }
                }
                if (statusRet != uEye.Defines.Status.SUCCESS)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        private void onFrameEvent(object sender, EventArgs e)
        {
            // convert sender object to our camera object
            uEye.Camera camera = sender as uEye.Camera;
            if (camera.IsOpened)
            {
                uEye.Defines.DisplayMode mode;
                camera.Display.Mode.Get(out mode);

                // only display in dib mode
                if (mode == uEye.Defines.DisplayMode.DiB)
                {
                    Int32 s32MemID;
                    camera.Memory.GetActive(out s32MemID);
                    camera.Memory.Lock(s32MemID);

                    System.Drawing.Rectangle rect;
                    m_Camera.Size.AOI.Get(out rect);
                    _ImgWidth = rect.Width;
                    _ImgHeight = rect.Height;

                    IntPtr imgPtr;
                    m_Camera.Memory.ToIntPtr(s32MemID, out imgPtr);
                    m_Image.GenImage1("byte", _ImgWidth, _ImgHeight, imgPtr);
                    //_Image.WriteImage("bmp", 0, "E:/test0.bmp");
                    if (dispImgCallback != null)
                    {
                        dispImgCallback(m_Image, s32MemID);
                    }
                    else
                    {
                        //使用委托传递出去
                        eventWait.Set();
                    }
                    camera.Memory.Unlock(s32MemID);
                }

            }
        }

        public override bool setExposureTime(double dValue)
        {
            try
            {
                uEye.Defines.Status statusRet;
                // set exposure
                statusRet = m_Camera.Timing.Exposure.Set(dValue);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void SetTriggerMode()
        {
            uEye.Defines.TriggerMode TriggerMode;
            m_Camera.Trigger.Get(out TriggerMode);
            if (TriggerMode == uEye.Defines.TriggerMode.Continuous)
            {
                m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Continuous);
                m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
            }
            // Software trigger
            else if (TriggerMode == uEye.Defines.TriggerMode.Software)
            {
                //m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.Wait);
                m_Camera.Acquisition.Stop();
                m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Software);
                //m_Camera.Acquisition.Freeze(uEye.Defines.DeviceParameter.DontWait );
            }
            // Hardware trigger falling edge
            else if (TriggerMode == uEye.Defines.TriggerMode.Hi_Lo)
            {
                //m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Hi_Lo);
                m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
            }
            // Hardware trigger rising edge
            else if (TriggerMode == uEye.Defines.TriggerMode.Lo_Hi)
            {
                //m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Lo_Hi);
                m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
            }
            else
            {
                m_Camera.Acquisition.Capture();
            }
        }

        public override bool SetTriggerMode(TRIGGER_MODE mode)
        {
            uEye.Defines.Status statusRet = uEye.Defines.Status.NO_SUCCESS;
            switch (mode)
            {
                case TRIGGER_MODE.内触发:   // no acquisition
                    {
                        m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.Wait);
                        m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Continuous);
                        m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                        break;
                    }
                case TRIGGER_MODE.软触发:   // freerunning
                    {
                        m_Camera.Acquisition.Stop();
                        m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Software);
                        break;
                    }
                case TRIGGER_MODE.上升沿:   // Software trigger
                    {
                        m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Lo_Hi);
                        m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                        break;
                    }
                case TRIGGER_MODE.下降沿:   // Software trigger
                    {
                        m_Camera.Trigger.Set(uEye.Defines.TriggerMode.Hi_Lo);
                        m_Camera.Acquisition.Capture(uEye.Defines.DeviceParameter.DontWait);
                        break;
                    }
            }
            if (statusRet == uEye.Defines.Status.SUCCESS)
                return true;
            else
                return false;
        }
        [OnDeserializing()]
        internal void OnDeSerializingMethod(StreamingContext context)
        {
            m_Camera = new uEye.Camera();
        }
    }
}
