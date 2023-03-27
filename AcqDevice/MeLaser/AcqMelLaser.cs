using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Helper;
using System.Runtime.InteropServices;
using HalconDotNet;
using System.Threading;

namespace AcqDevice
{
    [Serializable]
    public class AcqMeLaser : AcqLineDeviceBase
    {
        public AcqMeLaser(DeviceType _DeviceType) : base(_DeviceType)
        {
        }

        private const int MAX_INTERFACE_COUNT = 5;
        private const int MAX_RESOULUTIONS = 6;
        [NonSerialized]
        public uint m_hLLT = 0;  //dll句柄

        public CLLTI.TScannerType m_tscanCONTROLType;

        /// <summary>
        /// 帧率
        /// </summary>
        public double m_FrameRate = 1000;

        /// <summary>
        /// 曝光
        /// </summary>
        public double m_ExposureTime = 0.1;

        /// <summary>
        /// 关闭时间
        /// </summary>
        public uint m_uiShutterTime { get; set; }
        /// <summary>
        /// 空闲时间
        /// </summary>
        public uint m_uiIdleTime { get; set; }

        public bool m_bCalibrateAng = false;//是否标定角度
        public double m_tanValue = 0.0;
        public int m_ProfileMode = 3;
        public uint m_uiResolution = 1280;//分辨率
        public uint new_uiResolution = 640;//分辨率


        public int m_TriggerMode = 0; //0--内部触发, 1---编码器触发
        public uint m_MeasureField;  //测量区域设置设置值,7-small,2-stanard,0-larger
        public int m_ResampleMode; //重采样模式。0---7
        //int m_MedianFilter; //中值滤波，0--Disable,1--size3,2--size5,3--size7
        //int m_AverageFilter;//均值滤波，0--Disable,1--size3,2--size5,3--size7
        public int m_ReflectsMode; //0--All,1--first,2--last,3--largest area,4--largest intensity,5--only single
        public int m_TriggerOneStep;//每步多少个脉冲
        public double m_TriggerStepUm; //一个脉冲触发等于多少um;

        private CLLTI.ProfileCallBackNewProfile _callback;
        //profile 委托
        public dlg_LaserProfile dlg_RePaint = null;

        private bool SetResolutions(uint value)
        {
            try
            {
                int iRetValue;

                EnableMeasurement(false);
                if ((iRetValue = CLLTI.SetResolution(m_hLLT, value)) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    OnError("Error during SetResolution", iRetValue);
                }
                m_uiResolution = value;

                double dTempLog = 1.0 / Math.Log(2.0);
                uint dwResolutionBitField = (uint)Math.Floor((Math.Log((double)value) * dTempLog) + 0.5);
                if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_REARRANGEMENT_PROFILE, 0x00100c03 | dwResolutionBitField << 12)) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    OnError("Error during SetFeature(FEATURE_FUNCTION_REARRANGEMENT_PROFILE)", iRetValue);
                    return false;
                }

                EnableMeasurement(true);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }

        private bool GetResolutions()
        {
            //获取支持的分辨率类型
            uint[] auiResolutions = new uint[MAX_RESOULUTIONS];
            if (CLLTI.GetResolutions(m_hLLT, auiResolutions, auiResolutions.GetLength(0)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                LogHandler.Instance.VTLogInfo("Error during GetResolutions");
                return false;
            }
            m_uiResolution = auiResolutions[0];
            return true;
        }
        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            try
            {
                uint m_hLLT = 0;  //dll句柄
                // CLLTI.ProfileReceiveMethod fnProfileReceiveMethod = null;
                uint[] auiFirewireInterfaces = new uint[MAX_INTERFACE_COUNT];
                uint[] auiResolutions = new uint[MAX_RESOULUTIONS];
                int iFirewireInterfaceCount = 0;
                //Create a Firewire Device -> returns handle to LLT device
                if (m_hLLT == 0)
                {
                    m_hLLT = CLLTI.CreateLLTDevice(CLLTI.TInterfaceType.INTF_TYPE_ETHERNET);
                }
                if (m_hLLT == 0)
                    return;//没有找到设备

                //Gets the available interfaces from the scanCONTROL-device
                iFirewireInterfaceCount = CLLTI.GetDeviceInterfacesFast(m_hLLT, auiFirewireInterfaces,
                                                                    auiFirewireInterfaces.GetLength(0));
                if (iFirewireInterfaceCount >= 1)
                {
                    for (int i = 0; i < iFirewireInterfaceCount; i++)
                    {
                        CamInfo cam = new CamInfo();
                        cam.m_CamName = "ME_LINELASER";

                        IPAddress ipaddress = IPAddress.Parse(auiFirewireInterfaces[i].ToString());
                        cam.m_UniqueName = ipaddress.ToString();
                        cam.m_MaskName = "255.255.255.0";

                        //IPAddress ip = IPAddress.Parse(cam.m_UniqueName);
                        //byte[] b = ip.GetAddressBytes();
                        //Array.Reverse(b);
                        //uint ipValue = BitConverter.ToUInt32(b, 0);
                        //uint  m_temp = CLLTI.CreateLLTDevice(CLLTI.TInterfaceType.INTF_TYPE_ETHERNET);
                        //CLLTI.SetDeviceInterface(m_temp, ipValue, 0);

                        byte[] b = ipaddress.GetAddressBytes();
                        Array.Reverse(b);
                        uint ipValue = BitConverter.ToUInt32(b, 0);
                        cam.m_SerialNO = ipValue.ToString();

                        m_CamInfoList.Add(cam);
                    }
                    ////Console.WriteLine("\nSelect the device interface " + auiFirewireInterfaces[0]);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public override void ConnectDev()
        {
            bool bOK = true;
            int iRetValue;
            DisConnectDev();
            if (m_hLLT == 0)
                m_hLLT = CLLTI.CreateLLTDevice(CLLTI.TInterfaceType.INTF_TYPE_ETHERNET);
            IPAddress ip = IPAddress.Parse(m_UniqueLabel);
            byte[] b = ip.GetAddressBytes();
            Array.Reverse(b);
            uint ipValue = BitConverter.ToUInt32(b, 0);
            if ((iRetValue = CLLTI.SetDeviceInterface(m_hLLT, ipValue, 0)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                //OnError("Error during SetDeviceInterface", iRetValue);
                bOK = false;
                return;
            }
            if (bOK)
            {
                if ((iRetValue = CLLTI.Connect(m_hLLT)) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    //OnError("Error during Connect", iRetValue);
                    bOK = false;
                }
                else
                    m_bConnected = true;
            }
            //Get scanCONTROL type
            if ((iRetValue = CLLTI.GetLLTType(m_hLLT, ref m_tscanCONTROLType)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                LogHandler.Instance.VTLogInfo("Error during GetLLTType");
                bOK = false;
            }

            _callback = new CLLTI.ProfileCallBackNewProfile(NewProfile);
            if (CLLTI.RegisterCallback(m_hLLT, CLLTI.TCallbackType.STD_CALL, _callback, m_hLLT) < CLLTI.GENERAL_FUNCTION_OK)
            {
                LogHandler.Instance.VTLogInfo("Error during RegisterCallback");
            }
            EnableMeasurement(true);
            UpLoadPara();
            //GetResolutions();
        }

        public override void DisConnectDev()
        {
            int iRetValue;
            if (m_bConnected && m_hLLT != 0)
            {
                if ((iRetValue = CLLTI.TransferProfiles(m_hLLT, CLLTI.TTransferProfileType.NORMAL_TRANSFER, Convert.ToInt32(false))) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    return;
                }
                if ((iRetValue = CLLTI.Disconnect(m_hLLT)) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    return;
                }
                //if ((iRetValue = CLLTI.DelDevice(m_hLLT)) < CLLTI.GENERAL_FUNCTION_OK)
                //{
                //    return;
                //}
                //m_hLLT = 0;
                m_bConnected = false;
            }
            return;
        }

        //float exposuretime -单位ms, 最小值0.01ms
        public bool SetRateTime(int rate, float exposuretime) //设置帧率和曝光时间
        {
            m_FrameRate = rate;

            if (exposuretime < 0.01)
                exposuretime = 0.01F;

            float idlems = (1000.0F / rate - exposuretime);

            uint shuttertime = (uint)(exposuretime * 1000 / 10.0 + 0.5); //ms->10us
            //int idletime = (int)((1000.0 / rate - exposuretime) * 1000 / 10.0 + 0.5);

            uint idletime = (uint)(idlems * 1000 / 10.0 + 0.5);
            if (idletime < 1)
            {
                idletime = 1;
            }

            SetIdleTime(idletime);
            SetShutterTime(shuttertime);

            return true;
        }


        public bool SetMeasureField(uint field)
        {
            if (field < 0 || field > 127)
                field = 0;
            bool bOK = true;
            int iRetValue;
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_MEASURINGFIELD, field)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_MEASURINGFIELD)", iRetValue);
                bOK = false;
            }
            /*
            //    CString sType;
            //    if(m_tscanCONTROLType >= scanCONTROL27xx_25 && m_tscanCONTROLType <= scanCONTROL27xx_xxx)
            //    {
            //        sType = "The scanCONTROL is a scanCONTROL27xx";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL26xx_25)
            //    {
            //        m_DistZLowLimit = 53; //上下最大限制
            //        m_DistZUpperLimit = 79;
            //        sType =  "The scanCONTROL is a scanCONTROL26xx-25";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL26xx_50)
            //    {
            //        m_DistZLowLimit = 50; //上下最大限制
            //        m_DistZUpperLimit = 146;
            //        sType =  "The scanCONTROL is a scanCONTROL26xx-50";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL26xx_100)
            //    {
            //        m_DistZLowLimit = 125; //上下最大限制
            //        m_DistZUpperLimit = 390;
            //        sType =  "The scanCONTROL is a scanCONTROL26xx-100";
            //    }
            //    else if(m_tscanCONTROLType >= scanCONTROL26xx_25 && m_tscanCONTROLType <= scanCONTROL26xx_xxx)
            //    {
            //        sType = "The scanCONTROL is a scanCONTROL26xx";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL29xx_25)
            //    {
            //        m_DistZLowLimit = 47; //上下最大限制
            //        m_DistZUpperLimit = 87;
            //        sType =  "The scanCONTROL is a scanCONTROL29xx-25";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL29xx_50)
            //    {
            //        m_DistZLowLimit = 50; //上下最大限制
            //        m_DistZUpperLimit = 140;
            //        sType =  "The scanCONTROL is a scanCONTROL29xx-50";
            //    }
            //    else if(m_tscanCONTROLType == scanCONTROL29xx_100)
            //    {
            //        m_DistZLowLimit = 125; //上下最大限制
            //        m_DistZUpperLimit = 390;
            //        sType =  "The scanCONTROL is a scanCONTROL29xx-100";
            //    }
            //    else if(m_tscanCONTROLType >= scanCONTROL29xx_25 && m_tscanCONTROLType <= scanCONTROL29xx_xxx)
            //    {
            //        m_DistZLowLimit = 53; //上下最大限制
            //        m_DistZUpperLimit = 390;
            //        sType =  "The scanCONTROL is a scanCONTROL29xx";
            //    }
            //    m_DistZLowLimit = 40; //上下最大限制
            //    m_DistZUpperLimit = 140;
            //    //AfxMessageBox(sType);
            //	if(field == 99)
            //    {
            //        int  low =  1 * (m_DistZUpperLimit - m_DistZLowLimit) / 8 + m_DistZLowLimit;
            //        int  hight =  2 * (m_DistZUpperLimit - m_DistZLowLimit) / 8 + m_DistZLowLimit;
            //        m_DistZLowLimit = low;
            //        m_DistZUpperLimit = hight;
            //    }
            //    
            //    CString ss;
            //    ss.Format(_T("MeasureField = %d,%f,%f "), field,m_DistZLowLimit,m_DistZUpperLimit);
            //    //AfxMessageBox(ss);
            */
            return bOK;

        }

        public bool GetMeasureField()
        {
            int iRetValue;
            uint field = 0;
            if ((iRetValue = CLLTI.GetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_MEASURINGFIELD, ref field)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_MEASURINGFIELD)", iRetValue);
                return false;
            }
            return true;
        }
        public bool SetShutterTime(uint shuttertime)
        {
            bool bOK = true;
            int iRetValue;
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_SHUTTERTIME, shuttertime)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_SHUTTERTIME)", iRetValue);
                bOK = false;
            }
            m_uiShutterTime = shuttertime;
            return bOK;
        }
        public bool SetIdleTime(uint idletime)
        {
            bool bOK = true;
            int iRetValue;
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_IDLETIME, idletime)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_IDLETIME)", iRetValue);
                bOK = false;
            }
            m_uiIdleTime = idletime;
            return bOK;
        }

        //Displaying the error text
        void OnError(string strErrorTxt, int iErrorValue)
        {
            byte[] acErrorString = new byte[200];

            Console.WriteLine(strErrorTxt);
            if (CLLTI.TranslateErrorValue(m_hLLT, iErrorValue, acErrorString, acErrorString.GetLength(0))
                                            >= CLLTI.GENERAL_FUNCTION_OK)
                MessageBox.Show(System.Text.Encoding.ASCII.GetString(acErrorString, 0, acErrorString.GetLength(0)));
            //Console.WriteLine(System.Text.Encoding.ASCII.GetString(acErrorString, 0, acErrorString.GetLength(0)));
        }

        public bool SetTriggerMode(int mode)
        {
            if (m_bConnected == false)
            {
                return false;
            }
            bool bOK = true;
            int iRetValue;

            //编码器触发模式
            //digital inputs function 
            uint dwio = 0;
            if ((iRetValue = CLLTI.GetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_RS422_INTERFACE_FUNCTION, ref dwio)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during GetSerial", iRetValue);
                return false;
            }
            dwio = /*dwio & 0xFFFFFF0F*/0;
            uint digital_input = /*(2 << 4) + dwio*/0;
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_RS422_INTERFACE_FUNCTION, digital_input)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_TRIGGER)", iRetValue);
                bOK = false;
            }

            dwio = 0;
            if ((iRetValue = CLLTI.GetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_MAINTENANCEFUNCTIONS, ref dwio)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during GetSerial", iRetValue);
                return false;
            }
            dwio = /*dwio & 0xFFFFFFf7*/0;
            digital_input = (1 << 3) + dwio;
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_MAINTENANCEFUNCTIONS, digital_input)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_TRIGGER)", iRetValue);
                bOK = false;
            }


            uint triggervalue = 0;
            uint encoder_divisior = (uint)(m_TriggerOneStep / m_TriggerStepUm);

            uint trigger_mode = 3; //encoder mode
            uint trigger_source = 1;
            uint trigger_polarity = 0; //low active
            uint enable_extern_trigger = 1;


            if (mode == 1)
            {
                enable_extern_trigger = 1;
            }
            else //intenal trigger
            {
                trigger_mode = 0;
                enable_extern_trigger = 0;
            }

            triggervalue = encoder_divisior + (trigger_mode << 16) + (trigger_source << 21) + (trigger_polarity << 24) + (enable_extern_trigger << 25);

            if (mode == 0)
            {
                triggervalue = 0;
            }
            if ((iRetValue = CLLTI.SetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_TRIGGER, triggervalue)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_TRIGGER)", iRetValue);
                bOK = false;
            }
            return bOK;
        }

        public bool GetTriggerMode()
        {
            if (m_bConnected == false)
            {
                return false;
            }
            int iRetValue;
            uint triggervalue = 0;
            if ((iRetValue = CLLTI.GetFeature(m_hLLT, CLLTI.FEATURE_FUNCTION_TRIGGER, ref triggervalue)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetFeature(FEATURE_FUNCTION_TRIGGER)", iRetValue);
                return false;
            }
            if (triggervalue == 0)
                m_TriggerMode = 0;
            else
                m_TriggerMode = 1;
            return true;
        }

        //设置Profile数据模式
        public bool SetProfileMode(CLLTI.TProfileConfig mode = CLLTI.TProfileConfig.PURE_PROFILE)
        {
            bool bOK = true;
            int iRetValue;
            if ((iRetValue = CLLTI.SetProfileConfig(m_hLLT,/*PROFILE*//*CLLTI.TProfileConfig.PURE_PROFILE*/mode)) < CLLTI.GENERAL_FUNCTION_OK)
            {
                OnError("Error during SetProfileConfig", iRetValue);
                bOK = false;
            }
            m_ProfileMode = 0;

            return bOK;
        }


        public bool EnableMeasurement(bool bEnable) //是否允许开始数据采集
        {
            try
            {
                if (m_bConnected == false)
                {
                    return false;
                }
                int iRetValue;

                if ((iRetValue = CLLTI.TransferProfiles(m_hLLT, CLLTI.TTransferProfileType.NORMAL_TRANSFER, Convert.ToInt32(bEnable))) < CLLTI.GENERAL_FUNCTION_OK)
                {
                    OnError("Error during TransferProfiles", iRetValue);
                    return false;
                }
                //Thread.Sleep(500);
                return true;
            }
            catch (System.Exception ex)
            {
                OnError(ex.ToString(), 0);
                return false;
            }

        }


        private void NewProfile(IntPtr pucData, uint uiSize, IntPtr pUserData)
        {
            try
            {
                if (uiSize > 0)
                {

                    double[] adValueX = new double[m_uiResolution];
                    double[] adValueZ = new double[m_uiResolution];
                    ushort[] adValueW = new ushort[m_uiResolution];
                    //copy数据到内存 
                    Byte[] bufferArray = new Byte[uiSize];

                    Marshal.Copy(pucData, bufferArray, 0, (int)uiSize);

                    CLLTI.ConvertProfile2Values((uint)(pUserData.ToInt32()), bufferArray, m_uiResolution, CLLTI.TProfileConfig.PURE_PROFILE, m_tscanCONTROLType,
                        0, 1, adValueW, null, null, adValueX, adValueZ, null, null);
                    if (m_bCalibrateAng)
                        //y = x.Zip(y, (a, b) => b + a * tan_value * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();
                        adValueZ = adValueX.Zip(adValueZ, (a, b) => b + a * m_tanValue * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();

                    //保存图像
                    if (m_bEnableRevData && m_CurrentProfile < m_NeededProfile)
                    {
                        //m_ListValue.Add(adValueZ);
                        if (m_Image == null || !m_Image.IsInitialized())
                        {
                            m_bEnableRevData = false;
                            return;
                        }
                        m_Image.SetGrayval(HTuple.TupleGenConst(m_uiResolution, m_CurrentProfile), HTuple.TupleGenSequence(0, m_uiResolution - 1, 1), (new HTuple(adValueZ)).TupleMult(1000));
                        //for (int i = 0; i < m_uiResolution; i++)
                        //{
                        //    m_Image.SetGrayval(m_CurrentProfile, i, adValueZ[i]);
                        //}
                        m_CurrentProfile++;
                    }
                    else if (m_bEnableRevData && m_CurrentProfile == m_NeededProfile)
                    {
                        m_bEnableRevData = false;
                        //m_CurrentProfile = 0;
                        //使用委托传递出去
                        eventWait.Set();
                    }

                    //显示profile
                    if (dlg_RePaint != null)
                    {
                        dlg_RePaint(adValueX, adValueZ);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="byHand">是否手动采图</param>
        public override bool CaptureImage(bool byHand = false)
        {
            try
            {
                m_CurrentProfile = 0;
                m_Image = new HImage("real", (int)m_uiResolution, m_NeededProfile);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool UpLoadPara()//上传参数到Laser
        {
            if (m_bConnected)
            {
                if (SetResolutions(new_uiResolution) == false)
                {
                    return false;
                }
                //设置触发模式
                if (SetTriggerMode(m_TriggerMode) == false)
                {
                    return false;
                }
                //设置Profile mode
                if (SetProfileMode() == false)
                {
                    return false;
                }
                if (SetMeasureField(m_MeasureField) == false)
                {
                    return false;
                }
                //设置Shutter Time//设置Idle Time
                if (SetRateTime((int)m_FrameRate, (float)m_ExposureTime) == false)
                {
                    return false;
                }
                //CaptureImage();
                return true;
            }
            else
                return false;

        }

        public bool DownLoadPara()//下载参数到本地
        {
            if (m_bConnected)
            {
                if (GetTriggerMode() == false)
                    return false;

                if (GetMeasureField() == false)
                    return false;

                //获取分辨率
                //if (GetResolutions() == false)
                //{
                //    return false;
                //}
                return true;
            }
            else
                return false;
        }
    }
}
