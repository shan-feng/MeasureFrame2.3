using Helper.Socket;
using MeasureFrame.IUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureFrame
{
    static class StaticTCPIP
    {
        public static Helper.Socket.DMTcpClient gTcpClient;

        public static bool InitTcpClient(ref DMTcpClient tcpClient, string serverIP, int port)
        {
            try
            {
                if (tcpClient == null)
                {
                    tcpClient = new Helper.Socket.DMTcpClient();
                    tcpClient.ServerIp = serverIP;
                    tcpClient.ServerPort = port;
                    tcpClient.ReConnectionTime = 2000;
                    tcpClient.OnReceviceByte += TcpClient_OnReceviceByte;
                }
                else if (tcpClient.Tcpclient.Connected == true)
                {
                    return true;
                }
                tcpClient.StartConnection();
                return true;
            }
            catch (Exception)
            {

                //throw;
            }
            return false;
        }
        public static void DisConnectTcp(ref DMTcpClient tcpClient)
        {
            if (tcpClient != null)
            {
                tcpClient.OnReceviceByte -= TcpClient_OnReceviceByte;
                tcpClient.StopConnection();
                tcpClient.Dispose();
            }
        }

        private static void TcpClient_OnReceviceByte(byte[] date)
        {
            string strReceive = Helper.DBCTool.ToDBC(System.Text.Encoding.Default.GetString(date));
            frm_AutoRun.UpdateLogInfo("视觉返回结果: " + strReceive);
        }

    }
}
