using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helper;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using Measure;
using ScintillaNET;
using System.Reflection;

namespace MeasureFrame.IUI
{
    public partial class frm_TCP_IP_Server : Form
    {
        ScintillaNET.Scintilla scEdit;
        private TCPServer2 tcpServer = null;
        public frm_TCP_IP_Server(ref TCPServer2 tcp)
        {
            InitializeComponent();
            InitScintilla();
            tcpServer = tcp;
        }

        private void frm_TCP_IP_Server_Load(object sender, EventArgs e)
        {
            txt_Port.Text = tcpServer.tcp.ServerPort.ToString();
            txt_IPaddress.Text = tcpServer.tcp.ServerIp;
            if (tcpServer.m_Script!=string.Empty)
                scEdit.Text = tcpServer.m_Script.Substring(30, tcpServer.m_Script.Length - 37); ;
            scEdit.TextChanged += new EventHandler(scEdit_TextChanged);
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            tcpServer.tcp.ServerIp = txt_IPaddress.Text.Trim();
            tcpServer.tcp.ServerPort = int.Parse(txt_Port.Text.Trim());
            tcpServer.tcp.Start();
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            tcpServer.Stop();
        }

        private void bt_Test_Click(object sender, EventArgs e)
        {
            tcpServer.SendMsgUserToEveryone(Encoding.Default.GetBytes(txt_testInfo.Text.Trim()));
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            tcpServer.tcp.ServerPort = int.Parse(txt_Port.Text.Trim());
            tcpServer.tcp.ServerIp=txt_IPaddress.Text.Trim();
            StringBuilder str = new StringBuilder("sub SocketCallback(str) \r\n");
            str.Append(Environment.NewLine);
            str.Append(Environment.NewLine);
            str.Append(scEdit.Text.Trim());
            str.Append("\r\nend sub");
            tcpServer.m_Script = str.ToString();
            this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Compile_Click(object sender, EventArgs e)
        {
            //myVBAEngine.Clear();//清空所有脚本方法值
            StringBuilder str = new StringBuilder("sub SocketCallback(str) \r\n");
            str.Append(Environment.NewLine);
            str.Append(Environment.NewLine);
            str.Append(scEdit.Text.Trim());
            str.Append("\r\nend sub");
            tcpServer.m_Script = str.ToString();

            if (tcpServer.m_VBAEngine.Compile() == false)
            {
                //MessageBox.Show(this, "编译错误:" + myVBAEngine.CompilerOutput, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ErrorInfo.Text = "编译错误:" + tcpServer.m_VBAEngine.CompilerOutput;
                //int index = myVBAEngine.CompilerOutput.IndexOf("保留所有权利。");
                //txt_ErrorInfo.Text = "编译错误:" + myVBAEngine.CompilerOutput.Substring(index + 17, myVBAEngine.CompilerOutput.Length - index -17);
                txt_ErrorInfo.ForeColor = Color.Red;
            }
            else
            {
                //MessageBox.Show(this, "编译成功", "系统提示");
                txt_ErrorInfo.Text = "编译成功:";
                txt_ErrorInfo.ForeColor = Color.Black;
            }
        }

        private void timer_Update_Tick(object sender, EventArgs e)
        {
            if (tcpServer.tcp.IsStartListening)
            {
                toolStripStatusLabel1.Text = "服务器已启动";
                txt_IPaddress.Enabled = false;
                txt_Port.Enabled = false;
                bt_Start.Enabled = false;
                bt_Stop.Enabled = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "服务器已关闭";
                txt_IPaddress.Enabled = true;
                txt_Port.Enabled = true;
                bt_Start.Enabled = true;
                bt_Stop.Enabled = false;
            }
        }

        #region Scintilla
        private const int LINE_NUMBERS_MARGIN_WIDTH = 35; // TODO Don't hardcode this
        bool isCompleted = false;
        private void InitScintilla()
        {
            scEdit = new ScintillaNET.Scintilla();
            groupBox4.Controls.Add(scEdit);
            scEdit.Dock = DockStyle.Fill;
            //scEdit.CharAdded +=new EventHandler<CharAddedEventArgs>(scEdit_CharAdded);
            scEdit.AutoCompleteAccepted += new EventHandler<AutoCompleteAcceptedEventArgs>(scEdit_AutoCompleteAccepted);

            // Turn on line numbers?
            scEdit.Margins.Margin0.Width = LINE_NUMBERS_MARGIN_WIDTH;

            // Turn on white space?
            scEdit.Whitespace.Mode = WhitespaceMode.Invisible;

            // Turn on word wrap?
            scEdit.LineWrapping.Mode = LineWrappingMode.None;

            //折叠功能
            scEdit.LineWrapping.VisualFlags = ScintillaNET.LineWrappingVisualFlags.End;
            scEdit.Margins.Margin1.AutoToggleMarkerNumber = 0;
            scEdit.Margins.Margin1.IsClickable = true;
            scEdit.Margins.Margin2.Width = 16;

            // Show EOL?
            //scEdit.EndOfLine.IsVisible = false;
            SetLanguage("vbscript");
            //自动补齐
            scEdit.AutoComplete.List = scEdit.AutoComplete.List.Concat(getMethodsList()).ToList();
            scEdit.AutoComplete.List = scEdit.AutoComplete.List.Distinct().OrderBy(x => x.ToUpper()).ToList();
        }

        private void SetLanguage(string language)
        {
            // Use a built-in lexer and configuration
            scEdit.ConfigurationManager.Language = language;

            // Smart indenting...
            if ("cs".Equals(language, StringComparison.OrdinalIgnoreCase))
                scEdit.Indentation.SmartIndentType = SmartIndent.CPP;
            else
                scEdit.Indentation.SmartIndentType = SmartIndent.None;
        }
        private void scEdit_TextChanged(object sender, EventArgs e)
        {
            // Find the word start
            int currentPos = scEdit.CurrentPos;
            char c = scEdit.CharAt(currentPos);
            if (c != '\0' && c != ' ' && c != '\r' && c != '\t'&& c != '(')
            {
                if (c == '.')
                {
                    string str = scEdit.GetWordFromPosition(currentPos);
                    if (str.ToUpper() == "H")
                    {
                    }
                }
                else
                {
                    if (isCompleted == true)
                    {
                        isCompleted = false;
                        return;
                    }
                    scEdit.AutoComplete.Show();
                }
            }
        }

        private void scEdit_AutoCompleteAccepted(object sender, AutoCompleteAcceptedEventArgs e)
        {
            isCompleted = true;
        }

        public List<string> getMethodsList()
        {
            List<string> strList = new List<string>();
            strList.Add("h");
            //获取当前程序集的所有类

            foreach (Type t in Assembly.LoadFrom(Application.StartupPath + "/Measure.dll").GetTypes())
            {
                //只添加指定命名空间的类
                if (t.FullName.Contains("VBA_Function"))
                {
                    MethodInfo[] methods = t.GetMethods();
                    foreach (MethodInfo m in methods)
                    {
                        if (!m.ToString().Contains("<"))
                            strList.Add(m.ToString().Split(' ')[1].Split('(')[0].Replace("set_", "").Replace("get_", ""));
                    }
                    //strList.Add(t.Name);
                }
            }

            //return string.Join(" ", strList.Distinct().ToList().OrderBy(x => x.ToUpper())); 
            return strList.Distinct().ToList();
        }
        #endregion
    }
}
