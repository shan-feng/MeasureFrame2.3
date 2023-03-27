using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Helper.Socket;

namespace Measure
{
    /// <summary>
    /// 异步通讯
    /// </summary>
    [Serializable]
    public class TCPServer2 : ISerializable
    {
        public DMTcpServer tcp;
        public TCPServer2()
        {
            InitVBAEngine();
            tcp = new DMTcpServer();
            tcp.OnReceviceByte += new DMTcpServer.ReceviceByteEventHandler(tcp_OnReceviceByte);
            tcp.OnErrorMsg += new DMTcpServer.ErrorMsgEventHandler(tcp_OnErrorMsg);
            tcp.OnStateInfo += new DMTcpServer.StateInfoEventHandler(tcp_OnStateInfo);
        }

        public XVBAEngine m_VBAEngine = null;

        /// <summary>
        /// 脚本代码
        /// </summary>
        public string m_Script
        {
            set { m_VBAEngine.ScriptText = value; }
            get { return m_VBAEngine.ScriptText; }
        }

        public bool Cal_Script()
        {
            try
            {
                if (!m_VBAEngine.bDebuged)
                {
                    if (!m_VBAEngine.Compile())
                    {
                        return false;
                    }
                }
                return m_VBAEngine.Execute("SocketCallback", null, true);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 初始化VBA脚本引擎
        /// </summary>
        private void InitVBAEngine()
        {
            // 创建脚本引擎
            m_VBAEngine = new XVBAEngine();
            m_VBAEngine.AddReferenceAssemblyByType(this.GetType());
            m_VBAEngine.AddReferenceAssemblyByType((new Measure.HMeasureSYS()).GetType());
            m_VBAEngine.VBCompilerImports.Add("Measure.Global");
            //m_VBAEngine.VBCompilerImports.Add("Measure.UserDefine");
            //设置脚本引擎全局对象
        }

        void tcp_OnReceviceByte(Socket temp, byte[] dataBytes)
        {
            string str = Encoding.Default.GetString(dataBytes).Trim('\0');
            object[] parameters = new object[1];
            parameters.SetValue(str, 0);
            if (!m_VBAEngine.bDebuged)
            {
                if (!m_VBAEngine.Compile())
                {
                    return;
                }
            }
            m_VBAEngine.Execute("SocketCallback", parameters, true);
        }


        void tcp_OnErrorMsg(string msg)
        {
            //throw new NotImplementedException();
            //MessageBox.Show(msg);
        }


        void tcp_OnStateInfo(string msg, SocketState state)
        {
            //throw new NotImplementedException();
        }

        ///<summary>
        ///发送给当前socket
        ///</summary>
        public void SendMsgUserToCurrent(byte[] b_msg)
        {
            tcp.SendData(((IPEndPoint)tcp.ServerSocket.RemoteEndPoint).Address.ToString(), ((IPEndPoint)tcp.ServerSocket.RemoteEndPoint).Port, b_msg);
        }

        ///<summary>
        ///发送给指定在socket
        ///</summary>
        public void SendMsgUserToSingle(Socket remote, byte[] b_msg)
        {
            if (remote.Connected)
            {
                tcp.SendData(((IPEndPoint)remote.RemoteEndPoint).Address.ToString(), ((IPEndPoint)remote.RemoteEndPoint).Port, b_msg);
            }
        }

        ///<summary>
        ///广播
        ///</summary>
        public void SendMsgUserToEveryone(byte[] b_msg)
        {
            foreach (Socket s in tcp.ClientSocketList)
            {
                if (s.Connected)
                {
                    tcp.SendData(((IPEndPoint)s.RemoteEndPoint).Address.ToString(), ((IPEndPoint)s.RemoteEndPoint).Port, b_msg);
                }
            }
        }

        public void Stop()
        {
            tcp.ServerSocket.Close();
            tcp.Stop();
            tcp.Dispose();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }
            info.AddValue("vbScript", m_Script);
            info.AddValue("tcpServerIP", tcp.ServerIp);
            info.AddValue("tcpServerPort", tcp.ServerPort);
        }

        /// <summary>
        /// 构造函数反序列化
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public TCPServer2(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new System.ArgumentNullException("info");
            }
            InitVBAEngine();
            tcp = new DMTcpServer();
            tcp.OnReceviceByte += new DMTcpServer.ReceviceByteEventHandler(tcp_OnReceviceByte);
            tcp.OnErrorMsg += new DMTcpServer.ErrorMsgEventHandler(tcp_OnErrorMsg);
            tcp.OnStateInfo += new DMTcpServer.StateInfoEventHandler(tcp_OnStateInfo);

            m_Script = info.GetString("vbScript");
            tcp.ServerIp = info.GetString("tcpServerIP");
            tcp.ServerPort = info.GetInt32("tcpServerPort");
        }
    }
}
