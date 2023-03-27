using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using ScintillaNET;
using System.Linq;
using System.IO;
using System.Reflection;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_Calculate : MeasureFrame.IUI.frm_Unit
    {
        ScintillaNET.Scintilla scEdit;
        public frm_Unit_Calculate()
            : base()
        {
            InitializeComponent();
            InitScintilla();
            m_Unit = new CCalculate(CellCatagory.数据计算, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_Calculate(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
            InitScintilla();
        }

        private void frm_Unit_Calculate_Load(object sender, EventArgs e)
        {
            string m_FlowID = "U" + ((CCalculate)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CCalculate)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CCalculate)m_Unit).m_CellDesCribe;
            if (((CCalculate)m_Unit).m_Script != "")
                scEdit.Text = ((CCalculate)m_Unit).m_Script.Substring(61, ((CCalculate)m_Unit).m_Script.Length - 124);
            scEdit.TextChanged += new EventHandler(scEdit_TextChanged);
        }

        private void bt_Compile_Click(object sender, EventArgs e)
        {
            //myVBAEngine.Clear();//清空所有脚本方法值
            StringBuilder str = new StringBuilder("sub Cal(ByVal param as object) \r\n");
            str.Append("try \r\n");
            str.Append("H.m_ProjectID=param \r\n");
            str.Append(scEdit.Text.Trim());
            str.Append("\r\nCatch ex As Exception \r\nh.show(ex.tostring) \r\nEnd Try");
            str.Append("\r\nend sub");
            ((CCalculate)m_Unit).m_VBAEngine.ScriptText = str.ToString();

            if (((CCalculate)m_Unit).m_VBAEngine.Compile() == false)
            {
                //MessageBox.Show(this, "编译错误:" + myVBAEngine.CompilerOutput, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ErrorInfo.Text = "编译错误:" + ((CCalculate)m_Unit).m_VBAEngine.CompilerOutput;
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

        private void bt_Run_Click(object sender, EventArgs e)
        {
            try
            {
                // 调用脚本执行指定名称的脚本方法
                object[] param = { HMeasureSYS.Cur_Project.m_ProjectID };
                ((CCalculate)m_Unit).m_VBAEngine.Execute("Cal", param, true);
            }
            catch (Exception ext)
            {
                txt_ErrorInfo.Text = "执行脚本错误:" + ext.Message;
                txt_ErrorInfo.ForeColor = Color.Red;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            ((CCalculate)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text;
            StringBuilder str = new StringBuilder("sub Cal(ByVal param as object) \r\n");
            str.Append("try \r\n");
            str.Append("H.m_ProjectID=param \r\n");
            str.Append(scEdit.Text.Trim());
            str.Append("\r\nCatch ex As Exception \r\nh.show(ex.tostring) \r\nEnd Try");
            str.Append("\r\nend sub");
            ((CCalculate)m_Unit).m_Script = str.ToString();
            if (blnNewUnit)
            {
                blnNewUnit = false;
                ((CCalculate)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
            }
        }

        #region Scintilla
        private const int LINE_NUMBERS_MARGIN_WIDTH = 35; // TODO Don't hardcode this
        bool isCompleted = false;
        private void InitScintilla()
        {
            scEdit = new ScintillaNET.Scintilla();
            groupBox1.Controls.Add(scEdit);
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

            //匹配不区分大小写
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
            if (c != '\0' && c != ' ' && c != '\r' && c != '\t' && c != '(')
            {
                if (c == '.')
                {
                    string str = scEdit.GetWordFromPosition(currentPos);
                    if (str.ToUpper() == "H")
                    {
                        //scEdit.AutoComplete.Show();
                    }
                }
                else
                {
                    if (isCompleted == true)
                    {
                        isCompleted = false;
                        return;
                    }
                    //scEdit.AutoComplete.List.Concat(getMethodsList());
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

        private void bt_Exit_Click(object sender, EventArgs e)
        {

        }
    }
}
