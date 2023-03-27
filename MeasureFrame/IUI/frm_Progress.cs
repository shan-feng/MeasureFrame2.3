using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MeasureFrame.IUI
{
    public partial class frm_Progress : Form
    {
        public frm_Progress()
        {
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }
        public void SetProgressValue(float percent)
        {
            this.progressBar1.Value = (int)(progressBar1.Maximum * (percent / 100));
            //this.label1.Text = "Progress :" + value.ToString() + "%";

            // 这里关闭，比较好，呵呵！  
            if (percent == 100)
            {
                this.Close();
            }
        }

        private void timer_update_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Step = (progressBar1.Maximum - progressBar1.Value) / 20;
            this.progressBar1.PerformStep();
        }
    }
    public class CProgress
    {
        private frm_Progress m_Process;
        private delegate void funHandle(float nValue);
        private funHandle myHandle = null;

        public CProgress()
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadFun));
            thread.Start();
        }
        private void ThreadFun()
        {
            m_Process = new frm_Progress();
            myHandle = new funHandle(m_Process.SetProgressValue);
            m_Process.ShowDialog();
        }

        public void SetProgressValue(float value, Form f)
        {
            Thread.Sleep(200);
            f.Invoke(this.myHandle, new object[] { value });
        }
    }
}
