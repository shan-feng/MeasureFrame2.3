using ChoiceTech.Halcon.Control;
using CPublicDefine;
using Measure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MeasureFrame.IUI
{
    public partial class frm_AutoRun : DockContent
    {
        public static frm_AutoRun s_MainFrom;
        public void DlgInsertHe(List<HImageExt> list, string projectName)
        {
            if (projectName.Contains("CCD"))
            {
                foreach (var item in list)
                {
                    hWindow_HE1.showHE(item);
                }
                //try
                //{
                //    foreach (var item in list)
                //    {
                //        tempHWindow_HE.showHE(item);
                //    }
                //}
                //catch (Exception)
                //{
                //}
            }
            else if (projectName.Contains("Test"))
            {
                foreach (var item in list)
                {
                    hWindow_HE2.showHE(item);
                }
                //保存图片示例
                //try
                //{
                //    foreach (var item in list)
                //    {
                //        tempHWindow_HE.showHE(item);
                //    }
                //    tempHWindow_HE.SaveWindowDump(@"d:\test.png");
                //}
                //catch (Exception)
                //{
                //}
            }
        }

        HWindow_HE tempHWindow_HE = new HWindow_HE(); //该窗口为保存效果图的载体

        public frm_AutoRun()
        {
            InitializeComponent();

            s_MainFrom = this;
        }


      

        private void frm_AutoRun_Load(object sender, EventArgs e)
        {
            //视觉测量程序初始化
            tempHWindow_HE.Size = new Size(2592, 1944);
            CHelper.InsertHe2ExtWindow = new CHelper.InsertHE2AutoRunWindow(DlgInsertHe);
            try
            {
                //Measure.VBA_Function.Show("");
                //Measure.UserDefine.Circle_INFO

                Measure.HMeasureSYS.InitialVisionProgram(Measure.HMeasureSYS.sConfigPath);

                if (HMeasureSYS.CheckDevStatus() == false)
                {
                    MessageBox.Show("存在相机未连接,请检查");
                }
                //链接到视觉 使用tcp方式是为了更好的兼容
                StaticTCPIP.InitTcpClient(ref StaticTCPIP.gTcpClient, "127.0.0.1", 5000);

            }
            catch (Exception)
            {

                //throw;
            }
        }

        public static void UpdateLogInfo(string input)
        {
            if (s_MainFrom == null)
            {
                return;
            }
            if (s_MainFrom.Created)
            {
                s_MainFrom.txtbox_showLog.BeginInvoke(new Action(() =>
                {
                    if (s_MainFrom.txtbox_showLog.Lines.Length > 1000)
                    {
                        s_MainFrom.txtbox_showLog.Clear();
                    }
                    s_MainFrom.txtbox_showLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }:{input} {System.Environment.NewLine}");
                    s_MainFrom.txtbox_showLog.ScrollToCaret();
                }), null);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            HMeasureSYS.Sys_StartTest(0);
        }
        private void btnTest2_Click(object sender, EventArgs e)
        {
            HMeasureSYS.Sys_StartTest(1);
        }

        private void btnBothTest_Click(object sender, EventArgs e)
        {
            HMeasureSYS.Sys_Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            HMeasureSYS.Sys_Stop();
        }

        private void frm_AutoRun_FormClosing(object sender, FormClosingEventArgs e)
        {
            StaticTCPIP.DisConnectTcp(ref StaticTCPIP.gTcpClient);
        }
    }
}
