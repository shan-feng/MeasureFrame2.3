using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace AcqDevice
{
    [Serializable]
    public class AcqKeyenceLaser : AcqLineDeviceBase
    {
        public static int DEVICE_COUNT = 0;
        /// <summary>Device ID (fixed to 0)</summary>
        private int DEVICE_ID = 0;//0~5

        /// <summary>Ethernet communication settings</summary>
        public override string m_UniqueLabel
        {
            get { return ethernetConfig.abyIpAddress.ToString() + ":" + ethernetConfig.wPortNo.ToString(); }
            set
            {
                //设置keyence ip地址
                string[] ipInfo = value.Split(':');
                string[] keyenceIp = ipInfo[0].Split('.');
                ethernetConfig.abyIpAddress = new byte[] {
                Convert.ToByte(keyenceIp[0]),
                Convert.ToByte(keyenceIp[1]),
                Convert.ToByte(keyenceIp[2]),
                Convert.ToByte(keyenceIp[3])
                };
                ethernetConfig.wPortNo = (ushort)(int.Parse(ipInfo[1]));
                highSpeedPort = (ushort)(ethernetConfig.wPortNo + 1);
            }
        }

        /// <summary>Ethernet communication port settings</summary>
        private UInt16 _highSpeedPort;

        /// <summary>connection mode 默认1  0 -USB 连接模式 1 - 高速网口连接模式，</summary>
        private int _connectMode = 1;

        /// <summary>批处理多少帧回调一次，默认每帧回调一次，设置单帧回调，目的是避免存留在内存里</summary>
        private uint _profileFrequence = 1;

        /// <summary>High-speed communication start profileNO</summary>
        private byte _StartProfileNo = 0;

        /// <summary>量程上下限</summary>
        private double LimitMin = -7.5;
        private double LimitMax = 7.5;

        /// <summary>
        /// 输出数据模式，0- 返回所有数据 1- 返回第一个镭射数据，2 -返回第二个镭射数据
        /// </summary>
        private int _outDataMode = 0;

        /// <summary>High-speed communication callback function</summary>
        [NonSerialized]
        private HighSpeedDataCallBack _callback;

        /// <summary>the size of header and footer</summary>
        //[NonSerialized]
        //int headerSize = Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) / sizeof(int);
        //[NonSerialized]
        //int footerSize = Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER)) / sizeof(int);

        LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
        LJV7IF_HIGH_SPEED_PRE_START_REQ req = new LJV7IF_HIGH_SPEED_PRE_START_REQ();
        //图像指针内存

        //IntPtr Imagebuffer;
        //int[] reciveBuffer;

        ///// <summary>统计接收到的帧数</summary>
        //private int _receiveCount = 0;

        /// <summary>
        /// 基恩士激光网卡设置
        /// </summary>
        private LJV7IF_ETHERNET_CONFIG ethernetConfig;

        //高速采集网络端口号
        public UInt16 highSpeedPort
        {
            get { return _highSpeedPort; }
            set { _highSpeedPort = value; }
        }
        //连接模式
        public int connectMode
        {
            get { return _connectMode; }
            set { _connectMode = value; }
        }
        //采集频率
        public uint frequence
        {
            get { return _profileFrequence; }
            set { _profileFrequence = value; }
        }
        //开始采集位置
        public byte StartProfileNo
        {
            get { return _StartProfileNo; }
            set { _StartProfileNo = value; }
        }
        /// <summary>
        /// 返回数据模式
        /// </summary>
        public int OutDataMode
        {
            get { return _outDataMode; }
            set { _outDataMode = value; }
        }

        public AcqKeyenceLaser(DeviceType _DeviceType)
            : base(_DeviceType)
        {
            DEVICE_ID = AcqKeyenceLaser.DEVICE_COUNT;
        }
        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            try
            {

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public override void ConnectDev()
        {
            DisConnectDev();
            Rc rc = Rc.Ok;
            // Initialize the DLL.
            rc = (Rc)NativeMethods.LJV7IF_Initialize();
            if (CheckReturnCode(rc))
            {
                // Open communication path.
                if (connectMode == 0)
                {
                    rc = (Rc)NativeMethods.LJV7IF_UsbOpen(DEVICE_ID);
                }
                else if (connectMode == 1)
                {
                    rc = (Rc)NativeMethods.LJV7IF_EthernetOpen(DEVICE_ID, ref ethernetConfig);
                    if (rc != Rc.Ok)
                    {
                        rc = (Rc)NativeMethods.LJV7IF_EthernetOpen(DEVICE_ID, ref ethernetConfig);
                    }
                }

                if (CheckReturnCode(rc))
                {
                    if (InitDevice())
                    {
                        m_bConnected = true;
                    }
                }
            }
        }

        /// <summary>
        ///停止中断设备连接
        ////// <summary>
        public override void DisConnectDev()
        {
            //Marshal.FreeHGlobal(Imagebuffer);
            //reciveBuffer = null;

            Rc rc = Rc.Ok;

            // Stop high-speed data communication.
            rc = (Rc)NativeMethods.LJV7IF_StopHighSpeedDataCommunication(DEVICE_ID);
            if (CheckReturnCode(rc))
            {
                // Exit high-speed data communication.
                rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(DEVICE_ID);
                if (CheckReturnCode(rc))
                {
                    rc = (Rc)NativeMethods.LJV7IF_CommClose(DEVICE_ID);
                    if (CheckReturnCode(rc))
                    {
                        rc = (Rc)NativeMethods.LJV7IF_Finalize();
                        m_bConnected = false;
                    }
                }
            }

        }

        /// <summary>
        /// 开始采集数据
        /// </summary>
        public Boolean InitDevice()
        {
            try
            {
                Rc rc = Rc.Ok;
                //clear all data in buffer
                rc = (Rc)NativeMethods.LJV7IF_ClearMemory(DEVICE_ID);
                if (CheckReturnCode(rc))
                {
                    rc = (Rc)NativeMethods.LJV7IF_StopHighSpeedDataCommunication(DEVICE_ID);
                    if (CheckReturnCode(rc))
                    {
                        rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(DEVICE_ID);
                        if (CheckReturnCode(rc))
                        {

                            uint threadId = (uint)(DEVICE_ID + 1);

                            _callback = new HighSpeedDataCallBack(ReceiveData);
                            if (_connectMode == 0)
                            {
                                // Initialize USB high-speed data communication
                                rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataUsbCommunicationInitalize(DEVICE_ID, _callback, frequence, threadId);
                            }
                            else if (_connectMode == 1)
                            {
                                // Initialize Ethernet high-speed data communication
                                rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataEthernetCommunicationInitalize(DEVICE_ID, ref ethernetConfig,
                                    highSpeedPort, _callback, frequence, threadId);
                            }
                            if (CheckReturnCode(rc))
                            {

                                // High-speed data communication start prep
                                rc = (Rc)NativeMethods.LJV7IF_PreStartHighSpeedDataCommunication(DEVICE_ID, ref req, ref profileInfo);

                                if (CheckReturnCode(rc))
                                {
                                    rc = (Rc)NativeMethods.LJV7IF_StartHighSpeedDataCommunication(DEVICE_ID);
                                    if (CheckReturnCode(rc))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;

                //接受到连接信息后初始化
                //Imagebuffer = Marshal.AllocHGlobal(m_NeededProfile * (DEVICE_ID + 1) * profileInfo.wProfDataCnt * sizeof(int));
                //reciveBuffer = new int[profileInfo.wProfDataCnt * (DEVICE_ID + 1) * m_NeededProfile];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// The check of a return code 
        /// </summary>
        /// <param name="rc">Return code </param>
        /// <returns>OK or not</returns>
        /// <remarks>If not OK, return false after displaying message.</remarks>
        private bool CheckReturnCode(Rc rc)
        {
            if (rc == Rc.Ok) return true;
            //MessageBox.Show(string.Format("Error: 0x{0,8:x}", rc), "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// High-speed communication callback process
        /// </summary>
        /// <param name="buffer">Pointer to beginning of received data</param>
        /// <param name="size">Byte size per 1 profile in received data</param>
        /// <param name="count">Profile count</param>
        /// <param name="notify">Exited or not</param>
        /// <param name="user">Information passed when high-speed data communication was initialized (thread ID)</param>
        private void ReceiveData(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            try
            {
                for (int i = 0; i < count; i++)
                {
                    //保存图像
                    if (m_bEnableRevData && m_CurrentProfile < m_NeededProfile)
                    {
                        //adValueZ = adValueX.Zip(adValueZ, (a, b) => b + a * m_tanValue * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();
                        uint profileSize = size / sizeof(int);
                        int[] bufferArray = new int[profileSize * count];
                        int[] adValueZ = new int[profileInfo.wProfDataCnt * count];
                        int headerSize = Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) / sizeof(int);
                        Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));
                        Array.Copy(bufferArray, headerSize, adValueZ, 0, profileInfo.wProfDataCnt * count);
                        //Marshal.Copy(buffer, bufferArray, headerSize, (int)(profileInfo.wProfDataCnt * count));
                        //adValueZ = Array.ConvertAll(bufferArray, d => d / 100000.0);//本质上是遍历

                        if (m_Image == null || !m_Image.IsInitialized())
                        {
                            m_bEnableRevData = false;
                            return;
                        }
                        //m_Image.SetGrayval(HTuple.TupleGenConst(800, m_CurrentProfile), HTuple.TupleGenSequence(0, 800 - 1, 1), (new HTuple(adValueZ)).TupleDiv(100000));
                        m_Image.SetGrayval(HTuple.TupleGenConst(profileInfo.wProfDataCnt, m_CurrentProfile), HTuple.TupleGenSequence(0, profileInfo.wProfDataCnt - 1, 1), (new HTuple(adValueZ)).TupleDiv(100.0));
                        m_CurrentProfile++;
                    }
                    else if (m_bEnableRevData && m_CurrentProfile == m_NeededProfile)
                    {
                        m_bEnableRevData = false;
                        //使用委托传递出去
                        eventWait.Set();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return;
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
                m_Image = new HImage("real", (int)profileInfo.wProfDataCnt, m_NeededProfile);
                //m_bEnableRevData = true;
                //NativeMethods.LJV7IF_StartMeasure(DEVICE_ID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public override void setTrigger()
        {
            //NativeMethods.LJV7IF_ClearMemory(DEVICE_ID);
            //Rc c=(Rc)NativeMethods.LJV7IF_StartMeasure(DEVICE_ID);

            m_Image = new HImage("real", (int)profileInfo.wProfDataCnt, m_NeededProfile);
            m_bEnableRevData = true;
            m_CurrentProfile = 0;
        }

        public override void SetEndTrigger()
        {
            //NativeMethods.LJV7IF_StopMeasure(DEVICE_ID);
            if (m_bEnableRevData == true)
            {
                m_bEnableRevData = false;
                eventWait.Set();
            }
            //m_CurrentProfile = 0;
        }

    }
}
