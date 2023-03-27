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
using System.Diagnostics;
using System.Xml;
using System.Net.NetworkInformation;

namespace AcqDevice
{
    [Serializable]
    public class AcqWenglorLaser : AcqLineDeviceBase
    {
        private Thread M2GLScannerThread = null;
        public AcqWenglorLaser(DeviceType _DeviceType) : base(_DeviceType)
        {
        }

        public IntPtr intptrScanner;//handle
        /// <summary>
        /// 帧率
        /// </summary>
        public int m_FrameRate = 1000;

        /// <summary>
        /// 曝光us
        /// </summary>
        public int m_ExposureTime = 20;
        public int m_iTriggerSource { get; set; }
        public int m_iROIHeightZ { get; set; }
        public int m_iROIOffsetZ { get; set; }
        public int m_iEncoderStep { get; set; }
        public int[] iConnectionStatus = new int[1];

        public int m_iPicCntErr { get; set; }

        public bool m_bCalibrateAng = false;//是否标定角度
        public double m_tanValue = 0.0;
        public int iXLength = 1280;

        //public int m_TriggerMode=0; //0--内部触发, 1---编码器触发
        //public int m_ResampleMode; //重采样模式。0---7
        //public int m_ReflectsMode; //0--All,1--first,2--last,3--largest area,4--largest intensity,5--only single
        public int m_TriggerOneStep;//每采集一帧多少个脉冲

        //private CLLTI.ProfileCallBackNewProfile _callback;
        //profile 委托
        public dlg_LaserProfile dlg_RePaint = null;

        double[] m_doX = new double[Wenglor_SDK.iETHERNETSCANNER_SCANXMAX * Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX + 1];
        double[] m_doZ = new double[Wenglor_SDK.iETHERNETSCANNER_SCANXMAX * Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX + 1];
        int[] m_iIntensity = new int[Wenglor_SDK.iETHERNETSCANNER_SCANXMAX * Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX + 1];
        int[] m_iPeakWidth = new int[Wenglor_SDK.iETHERNETSCANNER_SCANXMAX * Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX + 1];
        int[] m_iEncoder = new int[1];
        int[] m_iPicCnt = new int[1];
        int[] m_iPicCntTemp = new int[1];

        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>
        public static void SearchCameras(out List<CamInfo> m_CamInfoList)
        {
            m_CamInfoList = new List<CamInfo>();
            try
            {
                Dictionary<IPAddress, PhysicalAddress> all = Helper.ComputerHelper.GetAllDevicesOnLAN();
                foreach (KeyValuePair<IPAddress, PhysicalAddress> kvp in all)
                {
                    //if (Helper.ComputerHelper._GetIPAddress().ToString() == kvp.Key.ToString())
                    //    continue;

                    CamInfo cam = new CamInfo();
                    cam.m_CamName = "WENGLOR_LINELASER";
                    cam.m_UniqueName = kvp.Key.ToString();
                    cam.m_MaskName = "255.255.255.0";
                    cam.m_SerialNO = kvp.Value.ToString();
                    m_CamInfoList.Add(cam);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// 查找相机，添加到相机列表中
        /// </summary>

        public void ConnectDev(string ipAddress, string strPort)
        {
            if (m_bConnected)
            {
                return;
            }
            int iTimeOut = 3000;
            intptrScanner = Wenglor_SDK.EthernetScanner_Connect(ipAddress, strPort, iTimeOut);
            int iRes = -1;

            DateTime startConnectTime = DateTime.Now;
            TimeSpan connectTime = new TimeSpan();
            do
            {
                if (connectTime.TotalMilliseconds > iTimeOut)
                {
                    MessageBox.Show("Error: No Connection!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Thread.Sleep(100);
                Wenglor_SDK.EthernetScanner_GetConnectStatus(intptrScanner, iConnectionStatus);
                connectTime = DateTime.Now - startConnectTime;
            } while (iConnectionStatus[0] != Wenglor_SDK.iETHERNETSCANNER_TCPSCANNERCONNECTED);

            if (iConnectionStatus[0] == Wenglor_SDK.iETHERNETSCANNER_TCPSCANNERCONNECTED)
            {
                //Request the special parameters from Scanner for the DLL
                byte[] buffer = Encoding.ASCII.GetBytes("SetInitializeAcquisition\n");
                iRes = Wenglor_SDK.EthernetScanner_WriteData(intptrScanner, buffer, buffer.Length);
                if (iRes == Wenglor_SDK.iETHERNETSCANNER_ERROR)
                {
                    Debug.WriteLine("EthernetScanner_WriteData: {0}", iRes);
                    return;
                }

            }

            DateTime startGetInfoTime = DateTime.Now;
            TimeSpan timeGetInfo = new TimeSpan();
            do
            {
                Thread.Sleep(100);
                StringBuilder m_strEthernetScanner1InfoXML = new StringBuilder(new String(' ', Wenglor_SDK.iETHERNETSCANNER_GETINFOSIZEMAX));
                iRes = Wenglor_SDK.EthernetScanner_GetInfo(intptrScanner,
                    m_strEthernetScanner1InfoXML, Wenglor_SDK.iETHERNETSCANNER_GETINFOSIZEMAX, "xml");
                timeGetInfo = DateTime.Now - startGetInfoTime;
            } while (iRes < 0 && timeGetInfo.TotalMilliseconds < iTimeOut);


            m_bConnected = true;
            DownLoadPara();
            ThreadStart();
        }

        public void DisConnectDev()
        {
            if (m_bConnected && intptrScanner != (System.IntPtr)null)
            {
                m_bConnected = false;
                Wenglor_SDK.EthernetScanner_Disconnect(intptrScanner);
                intptrScanner = (IntPtr)null;
            }
            return;
        }

        public Boolean SetAcquisitionStart()
        {
            return SendCommand("SetAcquisitionStart");
        }

        public Boolean SetAcquisitionStop()
        {
            return SendCommand("SetAcquisitionStop");
        }

        //float exposuretime -单位us Default: 150
        public bool SetExposeTime(int iExposureTime) //设置帧率和曝光时间
        {
            return SendCommand("SetExposureTime=" + iExposureTime.ToString());
        }

        //0 Internal triggering,1 Synchronized trigger mode over sync In on E/A,2 Encoder initiated trigger mode
        public bool SetTriggerSource(int iTriggerSource)
        {
            return SendCommand("SetTriggerSource=" + iTriggerSource.ToString());
        }

        /// <summary>
        /// 设置检测Z区域的高度
        /// </summary>
        /// <param name="HeightZ">数值    MLSL: 35. ..1280    MLWL: 35...2048</param>
        /// <returns>返回值</returns>
        public bool SetROIHeightZ(int iHeightZ)
        {
            return SendCommand("SetROI1HeightZ=" + iHeightZ.ToString());
        }

        public bool SetROIOffsetZ(int iOffset)
        {
            return SendCommand("SetROI1OffsetZ=" + iOffset.ToString());
        }

        public bool SetEncoderStep(int iEncoderStep)
        {
            return SendCommand("SetTriggerAmountProfilesY=" + iEncoderStep.ToString());
        }

        public bool SetFramRate(int iFramRate)
        {
            return SendCommand("SetAcquisitionLineTime=" + ((int)(1000000 / iFramRate)).ToString());
        }

        /// <summary>
        /// 向镭射发送命令
        /// </summary>
        /// <param name="strCommand">命令字符串</param>
        /// <returns>返回命令是否执行成功</returns>
        public bool SendCommand(string strCommand)
        {

            if (m_bConnected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(strCommand.Trim());
                int iRes = Wenglor_SDK.EthernetScanner_WriteData(intptrScanner, buffer, buffer.Length);
                if (iRes == Wenglor_SDK.iETHERNETSCANNER_ERROR)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void M2GLScannerThreadProc()
        {
            //if the scanner was disconnected try to resetart the sending of the data
            while (m_bConnected)
            {
                //int dd = Environment.TickCount;
                Thread.Sleep(1);
                Wenglor_SDK.EthernetScanner_GetConnectStatus(intptrScanner, iConnectionStatus);
                if (iConnectionStatus[0] != Wenglor_SDK.iETHERNETSCANNER_TCPSCANNERCONNECTED)
                {
                    continue;
                }
                int iRes = Wenglor_SDK.EthernetScanner_GetXZIExtended(
                                                                    intptrScanner,
                                                                    m_doX,
                                                                    m_doZ,
                                                                    m_iIntensity,
                                                                    m_iPeakWidth,
                                                                    Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX * Wenglor_SDK.iETHERNETSCANNER_SCANXMAX,
                                                                    m_iEncoder,
                                                                    null,
                                                                    1000,
                                                                    null,
                                                                    0,
                                                                    m_iPicCnt);
                if (iRes == Wenglor_SDK.iETHERNETSCANNER_ERROR)
                {
                    continue;
                }
                NewProfile(m_doX.Take(iRes).ToArray(), m_doZ.Take(iRes).ToArray(), iRes);
                if ((m_iPicCnt[0] - m_iPicCntTemp[0]) != 1)
                {
                    if ((m_iPicCnt[0] != 0) && (m_iPicCntTemp[0] != 0xFFFF))
                    {
                        m_iPicCntErr++;
                    }
                }
                m_iPicCntTemp[0] = m_iPicCnt[0];
            }
        }
        public bool GetData(ref double[] adValueX, ref double[] adValueZ)
        {
            if (m_bConnected)
            {
                Wenglor_SDK.EthernetScanner_GetConnectStatus(intptrScanner, iConnectionStatus);
                if (iConnectionStatus[0] != Wenglor_SDK.iETHERNETSCANNER_TCPSCANNERCONNECTED)
                {
                    return false;
                }
                int iRes = Wenglor_SDK.EthernetScanner_GetXZIExtended(
                                                                    intptrScanner,
                                                                    m_doX,
                                                                    m_doZ,
                                                                    m_iIntensity,
                                                                    m_iPeakWidth,
                                                                    Wenglor_SDK.iETHERNETSCANNER_PEAKSPERCMOSSCANLINEMAX * Wenglor_SDK.iETHERNETSCANNER_SCANXMAX,
                                                                    m_iEncoder,
                                                                    null,
                                                                    1000,
                                                                    null,
                                                                    0,
                                                                    m_iPicCnt);
                if (iRes == Wenglor_SDK.iETHERNETSCANNER_ERROR)
                {
                    return false;
                }
                adValueX = m_doX.Take(iRes).ToArray();
                adValueZ = m_doZ.Take(iRes).ToArray();
                return true;
            }
            else
                return false;
        }
        private void NewProfile(double[] adValueX, double[] adValueZ, int iLength)
        {
            try
            {
                if (m_bCalibrateAng)
                    //y = x.Zip(y, (a, b) => b + a * tan_value * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();
                    adValueZ = adValueX.Zip(adValueZ, (a, b) => b + a * m_tanValue * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();

                //保存图像
                if (m_bEnableRevData && m_CurrentProfile < m_NeededProfile)
                {
                    if (m_Image == null || !m_Image.IsInitialized())
                    {
                        m_bEnableRevData = false;
                        return;
                    }
                    m_Image.SetGrayval(HTuple.TupleGenConst(iLength, m_CurrentProfile), HTuple.TupleGenSequence(0, iLength - 1, 1), (new HTuple(adValueZ)).TupleMult(1000));

                    m_CurrentProfile++;
                }
                else if (m_bEnableRevData && m_CurrentProfile == m_NeededProfile)
                {
                    m_bEnableRevData = false;
                }

                //显示profile
                if (dlg_RePaint != null)
                {
                    dlg_RePaint(adValueX, adValueZ);
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
                m_Image = new HImage("real", 1280, m_NeededProfile);

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
                bool ret = SetFramRate(m_FrameRate);
                Thread.Sleep(100);
                ret = ret && SetROIHeightZ(m_iROIHeightZ);
                Thread.Sleep(100);
                ret = ret && SetROIOffsetZ(m_iROIOffsetZ);
                Thread.Sleep(100);
                ret = ret && SetEncoderStep(m_iEncoderStep);
                Thread.Sleep(100);
                ret = ret && SetTriggerSource(m_iTriggerSource);
                Thread.Sleep(100);
                ret = ret && SetExposeTime(m_ExposureTime);
                return ret;
            }
            else
                return false;
        }

        public bool DownLoadPara()//下载参数到本地
        {
            if (m_bConnected)
            {
                StringBuilder m_strEthernetScanner1InfoXML = null;
                m_strEthernetScanner1InfoXML = new StringBuilder(new String(' ', Wenglor_SDK.iETHERNETSCANNER_GETINFOSIZEMAX));
                int iRes = Wenglor_SDK.EthernetScanner_GetInfo(intptrScanner,
                    m_strEthernetScanner1InfoXML, Wenglor_SDK.iETHERNETSCANNER_GETINFOSIZEMAX, "xml");
                if (iRes > 0)
                {
                    GetXMLParser(m_strEthernetScanner1InfoXML);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void GetXMLParser(StringBuilder strXML)
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodes = null;
            doc.LoadXml(strXML.ToString());

            XmlNodeList nodes1 = doc.DocumentElement.SelectNodes("/device/general");

            nodes = doc.DocumentElement.SelectNodes("/device/settings/triggersource");
            foreach (XmlNode node in nodes)
            {
                m_iTriggerSource = int.Parse(node.SelectSingleNode("current").InnerText);
            }

            nodes = doc.DocumentElement.SelectNodes("/device/settings/acquisitionlinetime");
            foreach (XmlNode node in nodes)
            {
                string strTemp_1 = node.SelectSingleNode("current").InnerText;
                if (strTemp_1 == "0")
                    strTemp_1 = "200";
                m_FrameRate = 1000000 / int.Parse(strTemp_1);
            }

            nodes = doc.DocumentElement.SelectNodes("/device/settings/exposuretime");
            foreach (XmlNode node in nodes)
            {
                m_ExposureTime = int.Parse(node.SelectSingleNode("current").InnerText);
            }

            nodes = doc.DocumentElement.SelectNodes("/device/settings/roi/z1/height");
            foreach (XmlNode node in nodes)
            {
                m_iROIHeightZ = int.Parse(node.SelectSingleNode("current").InnerText);
            }

            nodes = doc.DocumentElement.SelectNodes("/device/settings/roi/z1/offset");
            foreach (XmlNode node in nodes)
            {
                m_iROIOffsetZ = int.Parse(node.SelectSingleNode("current").InnerText);
            }

            nodes = doc.DocumentElement.SelectNodes("/device/settings/triggerencoderstep");
            foreach (XmlNode node in nodes)
            {
                m_iEncoderStep = int.Parse(node.SelectSingleNode("current").InnerText);
            }
        }
        private void ThreadStart()
        {
            M2GLScannerThread = new Thread(new ThreadStart(M2GLScannerThreadProc));
            M2GLScannerThread.Start();
        }
    }

}
