//extern alias Dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization;
using DVPCameraType;
using System.Diagnostics;

namespace AcqDevice
{
    [Serializable]
    public class AcqDo3Think : AcqAreaDeviceBase//, ISerializable
    {
        public uint m_handle = 0;
        [NonSerialized]
        DVPCamera.dvpStreamCallback callback;
        public AcqDo3Think(DeviceType _DeviceType) : base(_DeviceType)
        {
        }

        /// <summary>
        /// 构造函数反序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public AcqDo3Think(SerializationInfo info, StreamingContext context)
            : base(DeviceType.Do3Think)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            ////this.m_DevInfo = (tDSCameraDevInfo)info.GetValue("m_DevInfo", typeof(tDSCameraDevInfo));
            //this.m_DevInfo.acDevFileName = info.GetString("acDevFileName");
            //this.m_DevInfo.acFileName = info.GetString("acFileName");
            //this.m_DevInfo.acFirmwareVersion = info.GetString("acFirmwareVersion");
            //this.m_DevInfo.acFriendlyName = info.GetString("acFriendlyName");
            //this.m_DevInfo.acPortType = info.GetString("acPortType");
            //this.m_DevInfo.acProductName = info.GetString("acProductName");
            //this.m_DevInfo.acProductSeries = info.GetString("acProductSeries");
            //this.m_DevInfo.acSensorType = info.GetString("acSensorType");
            //this.m_DevInfo.acVendorName = info.GetString("acVendorName");
            ////this.m_iCameraID = info.GetInt32("m_iCameraID");
            //this.m_bConnected = info.GetBoolean("m_bConnected");
            //m_sCameraName = info.GetString("m_sCameraName");
            //_TrigerMode = 1;
        }

        //回调函数
        public int dvpStreamCallback(/*dvpHandle*/uint handle, dvpStreamEvent _event, /*void **/IntPtr pContext, ref dvpFrame refFrame, /*void **/IntPtr pBuffer)
        {
            try
            {
                dvpRegion roi = new dvpRegion();
                DVPCamera.dvpGetRoi(m_handle, ref roi);
                _ImgWidth = roi.W;
                _ImgHeight = roi.H;
                m_Image.GenImage1("byte", _ImgWidth, _ImgHeight, pBuffer);
                if (dispImgCallback != null)
                {
                    dispImgCallback(m_Image, (int)handle);
                }
                else
                {
                    //使用委托传递出去
                    eventWait.Set();
                }
                return 1;
            }
            catch (System.Exception ex)
            {
                eventWait.Set();
                return 0;
            }
        }

        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            dvpStatus status;
            uint i, n = 0;
            dvpCameraInfo dev_info = new dvpCameraInfo();
            status = DVPCamera.dvpRefresh(ref n);
            Debug.Assert(status == dvpStatus.DVP_STATUS_OK);
            //m_n_dev_count = (int)n;
            if (status == dvpStatus.DVP_STATUS_OK)
            {
                for (i = 0; i < n; i++)
                {
                    // Acquire each camera's information one by one.
                    status = DVPCamera.dvpEnum(i, ref dev_info);
                    Debug.Assert(status == dvpStatus.DVP_STATUS_OK);
                    if (status == dvpStatus.DVP_STATUS_OK)
                    {
                        CamInfo _camInfo = new CamInfo();
                        _camInfo.m_UniqueName = dev_info.FriendlyName;
                        _camInfo.m_CamName = dev_info.UserID;
                        _camInfo.m_SerialNO = dev_info.SerialNumber;
                        _camInfo.m_MaskName = dev_info.PortInfo;
                        _camInfo.mExtInfo = dev_info;
                        m_CamInfoList.Add(_camInfo);//获得相机信息
                    }
                }
            }
        }

        public override void ConnectDev()
        {

            base.ConnectDev();
            DisConnectDev(); // 如果设备已经连接先断开
            if (!m_bConnected)
            {
                dvpStatus status;
                // Open the pointed device by the selected FriendlyName.
                status = DVPCamera.dvpOpenByName(m_UniqueLabel, dvpOpenMode.OPEN_NORMAL, ref m_handle);
                if (status != dvpStatus.DVP_STATUS_OK)
                {
                    MessageBox.Show("Open failed!");
                    return;
                }
                callback = new DVPCamera.dvpStreamCallback(dvpStreamCallback);//申请回调函数指针缓存
                status = DVPCamera.dvpRegisterStreamCallback(m_handle, callback, dvpStreamEvent.STREAM_EVENT_PROCESSED, IntPtr.Zero);
                if (status != dvpStatus.DVP_STATUS_OK) //初始化相机
                {
                    return;
                }
                status = DVPCamera.dvpStart(m_handle);
                if (status != dvpStatus.DVP_STATUS_OK)
                {
                    MessageBox.Show("Start the video stream failed!");
                    return;
                }
                m_bConnected = true;
            }
        }

        public override void DisConnectDev()
        {
            if (m_bConnected)
            {
                dvpStatus status;
                dvpStreamState state = dvpStreamState.STATE_STOPED;
                // Implement a button to start and stop according to the current video's status.
                status = DVPCamera.dvpGetStreamState(m_handle, ref state);
                if (state != dvpStreamState.STATE_STOPED)
                {
                    status = DVPCamera.dvpStop(m_handle);
                }
                status = DVPCamera.dvpClose(m_handle);
                m_handle = 0;
                m_bConnected = false;
            }
        }

        #region 设置参数
        //设置曝光模式
        //设置曝光时间
        //置帧率
        //设置ip
        public override void setSetting()
        {
            base.setSetting();
        }

        public override void getSetting()
        {
            base.getSetting();
        }

        public override void LoadSetting(string filePath)
        {
            base.LoadSetting(filePath);
        }

        public override void SaveSetting(string filePath)
        {
            base.SaveSetting(filePath);
        }

        public override bool SetTriggerMode(TRIGGER_MODE mode)
        {
            dvpStatus status = dvpStatus.DVP_STATUS_OK;
            switch (mode)
            {
                case TRIGGER_MODE.内触发:   // no acquisition
                    {
                        status = DVPCamera.dvpSetTriggerInputType(m_handle, dvpTriggerInputType.TRIGGER_IN_OFF);
                        break;
                    }
                case TRIGGER_MODE.软触发:   // freerunning
                    {
                        //status = myApi.Gige_Camera_setAcquisitionMode(m_handle, GigeApi.ACQUISITION_MODE.ACQUISITION_MODE_SOFTWARE_TRIGGER);
                        break;
                    }
                case TRIGGER_MODE.上升沿:   // Software trigger
                    {
                        status = DVPCamera.dvpSetTriggerInputType(m_handle, dvpTriggerInputType.TRIGGER_POS_EDGE);
                        break;
                    }
                case TRIGGER_MODE.下降沿:   // Software trigger
                    {
                        status = DVPCamera.dvpSetTriggerInputType(m_handle, dvpTriggerInputType.TRIGGER_NEG_EDGE);
                        break;
                    }
            }
            if (status == dvpStatus.DVP_STATUS_OK)
                return true;
            else
                return false;
        }
        #endregion

        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="byHand">是否手动采图</param>
        public override bool CaptureImage(bool byHand)
        {
            try
            {
                dvpStatus status = dvpStatus.DVP_STATUS_FAILED;
                if (byHand)
                {
                    //设置曝光模式

                    bool bFlg = false;
                    status = DVPCamera.dvpGetTriggerState(m_handle, ref bFlg);
                    status = DVPCamera.dvpSetTriggerState(m_handle, true);
                    status = DVPCamera.dvpTriggerFire(m_handle);
                    status = DVPCamera.dvpSetTriggerState(m_handle, bFlg);

                }
                else
                {
                    bool bFlg = false;
                    status = DVPCamera.dvpGetTriggerState(m_handle, ref bFlg);
                    if (bFlg)//1 为软触发
                    {
                        SignalWait.WaitOne();
                        status = DVPCamera.dvpTriggerFire(m_handle);
                        SignalWait.Reset();
                    }
                }
                if (status != dvpStatus.DVP_STATUS_OK)
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

        private bool IsValidHandle(uint handle)
        {
            bool bValidHandle = false;
            dvpStatus status = DVPCamera.dvpIsValid(handle, ref bValidHandle);
            if (status == dvpStatus.DVP_STATUS_OK)
            {
                return bValidHandle;
            }
            return false;
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //if (info == null)
            //    throw new System.ArgumentNullException("info");
            ////info.AddValue("m_DevInfo", m_DevInfo);
            //info.AddValue("acDevFileName", m_DevInfo.acDevFileName);
            //info.AddValue("acFileName", m_DevInfo.acFileName);
            //info.AddValue("acFirmwareVersion", m_DevInfo.acFirmwareVersion);
            //info.AddValue("acFriendlyName", m_DevInfo.acFriendlyName);
            //info.AddValue("acPortType", m_DevInfo.acPortType);
            //info.AddValue("acProductName", m_DevInfo.acProductName);
            //info.AddValue("acProductSeries", m_DevInfo.acProductSeries);
            //info.AddValue("acSensorType", m_DevInfo.acSensorType);
            //info.AddValue("acVendorName", m_DevInfo.acVendorName);
            ////info.AddValue("m_iCameraID", m_iCameraID);
            //info.AddValue("m_bConnected", m_bConnected);
            //info.AddValue("m_sCameraName", m_sCameraName);
        }
    }
}
