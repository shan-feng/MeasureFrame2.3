using System;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading;

namespace Helper.Socket
{
    public class DMUdpClient : Component
    {
        public DMUdpClient()
        {
            this._IsAxUdpClientAgreement = true;
            this._RemoteIp = "127.0.0.1";
            this._RemotePort = 8900;
            this._LocalPort = 8899;
            this.CreateIContainer();
        }

        public DMUdpClient(IContainer container)
        {
            this._IsAxUdpClientAgreement = true;
            this._RemoteIp = "127.0.0.1";
            this._RemotePort = 8900;
            this._LocalPort = 8899;
            container.Add(this);
            this.CreateIContainer();
        }
        /// <summary>
        /// 是否开启AxUdpClient内部数据传输协议。\r\n如果是false则接收原始数据\r\n如果是true则开启内部文件传输协议
        /// </summary>
        [Description("是否开启AxUdpClient内部数据传输协议。\r\n如果是false则接收原始数据\r\n如果是true则开启内部文件传输协议")]
        [Category("UDP客户端属性")]
        public bool IsAxUdpClientAgreement
        {
            get
            {
                return this._IsAxUdpClientAgreement;
            }
            set
            {
                this._IsAxUdpClientAgreement = value;
            }
        }
        /// <summary>
        /// UDP客户端基类
        /// </summary>
        [Description("UDP客户端基类")]
        [Category("UDP客户端属性")]
        public UdpLibrary UdpLibrary
        {
            get
            {
                if (this._UdpLibrary == null)
                {
                    this._UdpLibrary = new UdpLibrary(this._LocalPort);
                    this._UdpLibrary.ReceiveData += this._UdpLibrary_ReceiveData;
                }
                return this._UdpLibrary;
            }
        }
        /// <summary>
        /// 远程监听IP
        /// </summary>
        [Description("远程监听IP")]
        [Category("UDP客户端属性")]
        public string RemoteIp
        {
            get
            {
                return this._RemoteIp;
            }
            set
            {
                this._RemoteIp = value;
            }
        }
        /// <summary>
        /// 远程监听端口
        /// </summary>
        [Category("UDP客户端属性")]
        [Description("远程监听端口")]
        public int RemotePort
        {
            get
            {
                return this._RemotePort;
            }
            set
            {
                this._RemotePort = value;
            }
        }
        /// <summary>
        /// 本地监听IP
        /// </summary>
        [Description("本地监听IP")]
        [Category("UDP客户端属性")]
        public int LocalPort
        {
            get
            {
                return this._LocalPort;
            }
            set
            {
                this._LocalPort = value;
            }
        }
        /// <summary>
        /// 远程主机网络端点
        /// </summary>
        [Category("UDP客户端属性")]
        [Description("远程主机网络端点")]
        public IPEndPoint RemoteEp
        {
            get
            {
                return new IPEndPoint(IPAddress.Parse(this._RemoteIp), this._RemotePort);
            }
        }
        /// <summary>
        /// 开启
        /// </summary>
        public void Start()
        {
            this.UdpLibrary.Start();
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            this.UdpLibrary.Stop();
        }
        /// <summary>
        /// 数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _UdpLibrary_ReceiveData(object sender, ReceiveDataEventArgs e)
        {
            if (!this.IsAxUdpClientAgreement)
            {
                this.OnReceiveByte(e);
                return;
            }
            MsgCell msgCell = new MsgCell();
            msgCell.FromBuffer(e.Buffer);
            int messageId = msgCell.MessageId;
            if (messageId != 16)
            {
                return;
            }
            this.OnReceiveTextMsg((MsgTypeCell)msgCell.Data);
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="data"></param>
        public void Send(int messageId, object data)
        {
            this.Send(messageId, data, this.RemoteEp);
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        public void SendText(string strmsg)
        {
            if (!this._IsAxUdpClientAgreement)
            {
                byte[] bytes = Encoding.Default.GetBytes(strmsg);
                this.UdpLibrary.Send(bytes, this.RemoteEp);
                return;
            }
            byte[] bytes2 = Encoding.Default.GetBytes(strmsg);
            MsgTypeCell data = new MsgTypeCell(MsgType.TxtMsg, bytes2);
            MsgCell cell = new MsgCell(16, data);
            this.UdpLibrary.Send(cell, this.RemoteEp);
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        public void SendText(byte[] strmsgBytes)
        {
            if (!this._IsAxUdpClientAgreement)
            {
                this.UdpLibrary.Send(strmsgBytes, this.RemoteEp);
                return;
            }
            MsgTypeCell data = new MsgTypeCell(MsgType.TxtMsg, strmsgBytes);
            MsgCell cell = new MsgCell(16, data);
            this.UdpLibrary.Send(cell, this.RemoteEp);
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        public void Send(int messageId, object data, IPEndPoint remoteIp)
        {
            MsgCell cell = new MsgCell(messageId, data);
            this.UdpLibrary.Send(cell, remoteIp);
        }
        /// <summary>
        /// 接收文本数据事件
        /// </summary>
        [Description("接收文本数据事件")]
        public event DMUdpClient.ReceiveByteEventHandler ReceiveByte
        {
            add
            {
                DMUdpClient.ReceiveByteEventHandler receiveByteEventHandler = this._ReceiveByteEventHandler;
                DMUdpClient.ReceiveByteEventHandler temp;
                do
                {
                    temp = receiveByteEventHandler;
                    DMUdpClient.ReceiveByteEventHandler value2 = (DMUdpClient.ReceiveByteEventHandler)Delegate.Combine(temp, value);
                    receiveByteEventHandler = Interlocked.CompareExchange<DMUdpClient.ReceiveByteEventHandler>(ref this._ReceiveByteEventHandler, value2, temp);
                }
                while (receiveByteEventHandler != temp);
            }
            remove
            {
                DMUdpClient.ReceiveByteEventHandler receiveByteEventHandler = this._ReceiveByteEventHandler;
                DMUdpClient.ReceiveByteEventHandler temp;
                do
                {
                    temp = receiveByteEventHandler;
                    DMUdpClient.ReceiveByteEventHandler value2 = (DMUdpClient.ReceiveByteEventHandler)Delegate.Remove(temp, value);
                    receiveByteEventHandler = Interlocked.CompareExchange<DMUdpClient.ReceiveByteEventHandler>(ref this._ReceiveByteEventHandler, value2, temp);
                }
                while (receiveByteEventHandler != temp);
            }
        }

        protected virtual void OnReceiveByte(ReceiveDataEventArgs e)
        {
            if (this._ReceiveByteEventHandler != null)
            {
                this._ReceiveByteEventHandler(e);
            }
        }
        /// <summary>
        /// 接收文本数据事件
        /// </summary>
        [Description("接收文本数据事件")]
        public event DMUdpClient.ReceiveTextMsgEventHandler ReceiveTextMsg
        {
            add
            {
                DMUdpClient.ReceiveTextMsgEventHandler receiveTextMsgEventHandler = this._ReceiveTextMsgEventHandler;
                DMUdpClient.ReceiveTextMsgEventHandler temp;
                do
                {
                    temp = receiveTextMsgEventHandler;
                    DMUdpClient.ReceiveTextMsgEventHandler value2 = (DMUdpClient.ReceiveTextMsgEventHandler)Delegate.Combine(temp, value);
                    receiveTextMsgEventHandler = Interlocked.CompareExchange<DMUdpClient.ReceiveTextMsgEventHandler>(ref this._ReceiveTextMsgEventHandler, value2, temp);
                }
                while (receiveTextMsgEventHandler != temp);
            }
            remove
            {
                DMUdpClient.ReceiveTextMsgEventHandler receiveTextMsgEventHandler = this._ReceiveTextMsgEventHandler;
                DMUdpClient.ReceiveTextMsgEventHandler temp;
                do
                {
                    temp = receiveTextMsgEventHandler;
                    DMUdpClient.ReceiveTextMsgEventHandler value2 = (DMUdpClient.ReceiveTextMsgEventHandler)Delegate.Remove(temp, value);
                    receiveTextMsgEventHandler = Interlocked.CompareExchange<DMUdpClient.ReceiveTextMsgEventHandler>(ref this._ReceiveTextMsgEventHandler, value2, temp);
                }
                while (receiveTextMsgEventHandler != temp);
            }
        }

        protected virtual void OnReceiveTextMsg(MsgTypeCell msgTypeCell)
        {
            if (this._ReceiveTextMsgEventHandler != null)
            {
                this._ReceiveTextMsgEventHandler(msgTypeCell);
            }
        }

        private void CreateIContainer()
        {
            this._IContainer = new Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this._IContainer != null)
            {
                this._IContainer.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool _IsAxUdpClientAgreement;
        private UdpLibrary _UdpLibrary;
        private string _RemoteIp;
        private int _RemotePort;
        private int _LocalPort;
        private DMUdpClient.ReceiveByteEventHandler _ReceiveByteEventHandler;
        private DMUdpClient.ReceiveTextMsgEventHandler _ReceiveTextMsgEventHandler;
        private IContainer _IContainer;

        public delegate void ReceiveByteEventHandler(ReceiveDataEventArgs e);
        public delegate void ReceiveTextMsgEventHandler(MsgTypeCell msgTypeCell);
    }
}
