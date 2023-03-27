using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Measure;
using WeifenLuo.WinFormsUI.Docking;

namespace MeasureFrame.IUI
{
    public partial class frm_ViewLog : DockContent
    {
        public frm_ViewLog()
        {
            InitializeComponent();
            CHelper.g_ViewLogWnd = this.Handle;
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case CHelper.VIEW_MESSAGE:
                    {

                        int num = txt_log.Lines.Count();
                        if (num > 1000)
                            txt_log.Text = string.Empty;
                        //string sTime=DateTime.Now.ToLocalTime().ToString();
                        string sTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff");
                        string sMsg = string.Empty;


                        int projectID = m.WParam.ToInt32();
                        int unitID = m.LParam.ToInt32();
                        CProject pro = HMeasureSYS.g_ProjectList.First(c => c.m_ProjectID == projectID);
                        string pName = pro.m_ProjectName;
                        CMeasureCell cell = pro.m_CellList.First(c => c.m_CellID == unitID);
                        sMsg = "工程 " + pName + " 单元 U" + unitID.ToString("D4") + " 准备" + cell.m_CellCatagory.ToString() + " >>>>>>\r\n";

                        sMsg = sTime + sMsg;
                        txt_log.AppendText(sMsg);
                    }
                    break;
                default:
                    base.DefWndProc(ref m);//一定要调用基类函数，以便系统处理其它消息。
                    break;
            }

        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            txt_log.Text = "";
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "txt Files format (*.txt)|*.txt";
            try
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(fd.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        StreamWriter myWriter = new StreamWriter(fs, Encoding.UTF8);
                        myWriter.Write(txt_log.Text);
                        myWriter.Close();
                        fs.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {

            }

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            CHelper.g_ViewLogWnd = IntPtr.Zero;
            base.OnClosed(e);
        }
    }
}
