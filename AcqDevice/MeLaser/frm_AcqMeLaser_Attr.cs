using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using Helper;

namespace AcqDevice
{

    public partial class frm_AcqMeLaser_Attr : Form
    {
        AcqMeLaser m_AcqMeLaser;

        //private float startX = -62;
        //private float lengthX = 126;
        //private float startY = 50;
        //private float lengthY = 90;
        //只针对当前镭射型号有用
        private float startX = -20;
        private float lengthX = 40;
        private float startY = 50;
        private float lengthY = 30;
        int scale_num = 6;
        //四条直线
        private float X1 = 160, X2 = 280, X3 = 400, X4 = 520;
        Bitmap bmp = null;

        //double[] adValueX;
        //double[] adValueZ;
        float cursorX = 0, cursorY = 0;
        //激光

        bool bLeftButton = false, bLineMove = false;

        public frm_AcqMeLaser_Attr(ref AcqDeviceBase _AcqDevice)
        {
            InitializeComponent();
            try
            {
                m_AcqMeLaser = (AcqMeLaser)_AcqDevice;

                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                m_AcqMeLaser.dlg_RePaint = rePaint;
                pic_singleProfile.MouseWheel += new MouseEventHandler(pic_singleProfile_MouseWheel);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frm_CorrectLaser_Load(object sender, EventArgs e)
        {
            m_AcqMeLaser.DownLoadPara();
            txt_allowAngle.Text = m_AcqMeLaser.m_tanValue.ToString();
            check_mCaliAngle.Checked = m_AcqMeLaser.m_bCalibrateAng;
            txt_ExposeTime.Text = m_AcqMeLaser.m_ExposureTime.ToString();
            txt_FrameRate.Text = m_AcqMeLaser.m_FrameRate.ToString();
            txt_MeasureFeild.Text = m_AcqMeLaser.m_MeasureField.ToString();
            if (m_AcqMeLaser.m_MeasureField == 7)
            {
                cmb_MeasureFeild.SelectedIndex = 0;
                txt_MeasureFeild.Enabled = false;
            }
            else if (m_AcqMeLaser.m_MeasureField == 2)
            {
                cmb_MeasureFeild.SelectedIndex = 1;
                txt_MeasureFeild.Enabled = false;
            }
            else if (m_AcqMeLaser.m_MeasureField == 0)
            {
                cmb_MeasureFeild.SelectedIndex = 2;
                txt_MeasureFeild.Enabled = false;
            }
            else
            {
                cmb_MeasureFeild.SelectedIndex = 3;
                txt_MeasureFeild.Enabled = true;
            }
            cmb_TriggerMode.SelectedIndex = m_AcqMeLaser.m_TriggerMode;
            cmb_Resolutions.Text = m_AcqMeLaser.m_uiResolution.ToString();
            txt_EncoderStep.Text = m_AcqMeLaser.m_TriggerOneStep.ToString();
            txt_EncoderOneStepUm.Text = m_AcqMeLaser.m_TriggerStepUm.ToString();
            //m_AcqMeLaser.SetTriggerMode(0);
            pic_singleProfile.Focus();
        }


        public void SetYAxis(ref Graphics g, PictureBox picBox, float start, float length, int scale_num)
        {
            Pen pen = new Pen(Color.Red, 2);//画笔
            g.DrawLine(pen, 30, 0, 30, picBox.Height);//绘制y坐标轴

            Pen p2 = new Pen(Color.Blue, 2);//用来画间隔
            SolidBrush sb = new SolidBrush(Color.Blue);//用来填充标注字的颜色

            float start_x = 25, start_y = picBox.Height - 30, end_x = 35, end_y = picBox.Height - 30;//第一条线的起始位置
            for (int i = 0; i <= scale_num; i++)
            {
                g.DrawLine(p2, start_x, start_y - i * (picBox.Height - 60) / scale_num, end_x, end_y - i * (picBox.Height - 60) / scale_num);
                string tempy = (start + i * length / scale_num).ToString("0.00");
                g.DrawString(tempy, new Font("宋体", 9), sb, 4, start_y - i * (picBox.Height - 60) / scale_num - 12);
            }
        }

        public void SetXAxis(ref Graphics g, PictureBox picBox, float start, float length, int scale_num)
        {

            Pen pen = new Pen(Color.Red, 2);//画笔
            g.DrawLine(pen, 0, picBox.Height - 30, picBox.Width, picBox.Height - 30);//绘制y坐标轴

            Pen p2 = new Pen(Color.Blue, 2);//用来画间隔
            SolidBrush sb = new SolidBrush(Color.Blue);//用来填充标注字的颜色

            float start_x = 30, start_y = picBox.Height - 25, end_x = 30, end_y = picBox.Height - 35;//第一条线的起始位置
            for (int i = 0; i <= scale_num; i++)
            {
                g.DrawLine(p2, start_x + i * (picBox.Width - 60) / scale_num, start_y, end_x + i * (picBox.Width - 60) / scale_num, end_y);
                string tempx = (start + i * length / scale_num).ToString("0.00");
                g.DrawString(tempx, new Font("宋体", 9), sb, start_x + i * (picBox.Width - 60) / scale_num - 8, picBox.Height - 18);
            }
        }
        public void SetPoint(ref Graphics g, int width, int height, double[] x, double[] y)
        {
            //计算当前线的实际距离
            double dis_x1 = (X1 - 30) * lengthX / (width - 60) + startX;
            double dis_x2 = (X2 - 30) * lengthX / (width - 60) + startX;
            double dis_x3 = (X3 - 30) * lengthX / (width - 60) + startX;
            double dis_x4 = (X4 - 30) * lengthX / (width - 60) + startX;
            List<double> value_list1 = new List<double>();
            List<double> value_list2 = new List<double>();
            List<double> x_list1 = new List<double>();
            List<double> x_list2 = new List<double>();


            //y = x.Zip(y, (a, b) => b + a * tan_value * Convert.ToInt16(Convert.ToBoolean(b))).ToArray();

            Pen pen = new Pen(Color.Green, 1);//画笔
            SolidBrush sb = new SolidBrush(Color.Green);
            if (x != null)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (y[i] == 0.0)
                        continue;
                    if (dis_x1 < x[i] && x[i] < dis_x2)
                    {
                        x_list1.Add(x[i]);
                        value_list1.Add(y[i]);
                    }
                    else if (dis_x3 < x[i] && x[i] < dis_x4)
                    {
                        x_list2.Add(x[i]);
                        value_list2.Add(y[i]);
                    }

                    //转换为坐标
                    float x_float = (float)((width - 60) * (x[i] - startX) / lengthX) + 30;
                    float y_float = height - 30 - (float)((height - 60) * (y[i] - startY) / lengthY);
                    g.DrawEllipse(pen, x_float, y_float, 1, 1);
                    g.FillEllipse(sb, x_float, y_float, 1, 1);
                }
            }
            if (value_list1.Count > 0 && value_list2.Count > 0)
            {
                x_list1 = x_list1.Concat(x_list2).ToList();
                value_list1 = value_list1.Concat(value_list2).ToList();
                double k = 0.0, b = 0.0;
                HMath.fitLine(x_list1.ToArray(), value_list1.ToArray(), x_list1.Count, out k, out b);
                //double v = (value_list2.Average() - value_list1.Average()) * 2 / (x_list2[x_list2.Count - 1] + x_list2[0] - x_list1[x_list1.Count - 1] - x_list1[0]);
                txt_xielv.Text = k.ToString("0.000000");
            }
        }

        public void rePaint(double[] adValueX, double[] adValueZ)
        {
            if (pic_singleProfile.IsHandleCreated)
                if (pic_singleProfile.InvokeRequired)
                {
                    try
                    {
                        pic_singleProfile.Invoke(new MethodInvoker(delegate
                        {
                            rePaint(adValueX, adValueZ);
                        }));
                    }
                    catch (System.Exception ex)
                    {

                    }

                }
                else
                {
                    bmp = new Bitmap(pic_singleProfile.Width, pic_singleProfile.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.Black);

                    Pen pen1 = new Pen(Color.Gray, 1);//画笔
                    Pen pen2 = new Pen(Color.Yellow, 1);//画笔
                    g.DrawLine(pen1, X1, 0, X1, pic_singleProfile.Height);
                    g.DrawLine(pen1, X2, 0, X2, pic_singleProfile.Height);
                    g.DrawLine(pen2, X3, 0, X3, pic_singleProfile.Height);
                    g.DrawLine(pen2, X4, 0, X4, pic_singleProfile.Height);

                    SetXAxis(ref g, pic_singleProfile, startX, lengthX, scale_num);
                    SetYAxis(ref g, pic_singleProfile, startY, lengthY, scale_num);
                    double[] tempZ = new double[adValueZ.Length];
                    adValueZ.CopyTo(tempZ, 0);
                    SetPoint(ref g, pic_singleProfile.Width, pic_singleProfile.Height, adValueX, tempZ);

                    Graphics gph = Graphics.FromHwnd(this.pic_singleProfile.Handle);
                    gph.DrawImage(bmp, 0, 0);
                }
        }

        private void pic_singleProfile_MouseWheel(object sender, MouseEventArgs e)
        {
            //当前线到中点的实际距离
            float temp_x1 = (X1 - pic_singleProfile.Width / 2) * lengthX;
            float temp_x2 = (X2 - pic_singleProfile.Width / 2) * lengthX;
            float temp_x3 = (X3 - pic_singleProfile.Width / 2) * lengthX;
            float temp_x4 = (X4 - pic_singleProfile.Width / 2) * lengthX;
            float zoom = (float)(-e.Delta / 120 * 0.1 + 1);
            //             startX = startX + (float)(lengthX * 0.05 * e.Delta / 120);
            //             startY = startY + (float)(lengthY * 0.05 * e.Delta / 120);
            startX = (startX * 2 + lengthX) / 2 - lengthX * zoom / 2;
            startY = (startY * 2 + lengthY) / 2 - lengthY * zoom / 2;
            lengthX = lengthX * zoom;
            lengthY = lengthY * zoom;

            //(picBox.Width - 60) * (x[i] - startX) / lengthX
            X1 = temp_x1 / lengthX + pic_singleProfile.Width / 2;
            X2 = temp_x2 / lengthX + pic_singleProfile.Width / 2;
            X3 = temp_x3 / lengthX + pic_singleProfile.Width / 2;
            X4 = temp_x4 / lengthX + pic_singleProfile.Width / 2;

            //rePaint();
        }

        private void pic_singleProfile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cursorX = e.X;
                cursorY = e.Y;
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    bLineMove = true;
                }
                else
                {
                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                }
                bLeftButton = true;
            }
        }

        private void pic_singleProfile_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    bLineMove = false;
                }
                else
                {
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;
                }
                bLeftButton = false;
            }
        }

        private void pic_singleProfile_MouseMove(object sender, MouseEventArgs e)
        {
            pic_singleProfile.Focus();
            if (!bLeftButton)
            {
                if ((X1 - 3 < e.X && e.X < X1 + 3) || (X2 - 3 < e.X && e.X < X2 + 3) || (X3 - 3 < e.X && e.X < X3 + 3) || (X4 - 3 < e.X && e.X < X4 + 3))
                {
                    this.Cursor = System.Windows.Forms.Cursors.SizeAll;
                }
                else
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
            if (bLeftButton)
            {
                float moveX = e.X - cursorX;
                float moveY = e.Y - cursorY;
                if (this.Cursor == System.Windows.Forms.Cursors.SizeAll)
                {
                    //移动线
                    if (X1 - 3 < cursorX && cursorX < X1 + 3)
                        X1 = X1 + moveX > X2 - 50 ? X2 - 50 : X1 + moveX;
                    if (X2 - 3 < cursorX && cursorX < X2 + 3)
                    {
                        if (moveX > 0)
                            X2 = X2 + moveX > X3 - 50 ? X3 - 50 : X2 + moveX;
                        else
                            X2 = X2 + moveX < X1 + 50 ? X1 + 50 : X2 + moveX;
                    }
                    if (X3 - 3 < cursorX && cursorX < X3 + 3)
                        if (moveX > 0)
                            X3 = X3 + moveX > X4 - 50 ? X4 - 50 : X3 + moveX;
                        else
                            X3 = X3 + moveX < X2 + 50 ? X2 + 50 : X3 + moveX;
                    if (X4 - 3 < cursorX && cursorX < X4 + 3)
                        X4 = X4 + moveX < X3 + 50 ? X3 + 50 : X4 + moveX;
                }
                else if (this.Cursor == System.Windows.Forms.Cursors.Hand)
                {
                    //移动视野
                    X1 = X1 - moveX;
                    X2 = X2 - moveX;
                    X3 = X3 - moveX;
                    X4 = X4 - moveX;

                    startX = startX - moveX * lengthX / (pic_singleProfile.Width - 60);
                    startY = startY + moveY * lengthY / (pic_singleProfile.Height - 60);

                }

                cursorX = e.X;
                cursorY = e.Y;
                //rePaint();
            }
        }

        private void bt_Comfirm_Click(object sender, EventArgs e)
        {
            //补偿倾斜角度
            if (txt_allowAngle.Text.Trim() != string.Empty)
                m_AcqMeLaser.m_tanValue = Convert.ToDouble(txt_allowAngle.Text);
            if (check_mCaliAngle.Checked)
                m_AcqMeLaser.m_bCalibrateAng = true;
            else
                m_AcqMeLaser.m_bCalibrateAng = false;
            m_AcqMeLaser.m_FrameRate = double.Parse(txt_FrameRate.Text);
            m_AcqMeLaser.m_ExposureTime = double.Parse(txt_ExposeTime.Text);
            m_AcqMeLaser.m_MeasureField = uint.Parse(txt_MeasureFeild.Text);
            m_AcqMeLaser.new_uiResolution = uint.Parse(cmb_Resolutions.Text);
            m_AcqMeLaser.m_TriggerMode = cmb_TriggerMode.SelectedIndex;
            m_AcqMeLaser.m_TriggerOneStep = int.Parse(txt_EncoderStep.Text);
            m_AcqMeLaser.m_TriggerStepUm = double.Parse(txt_EncoderOneStepUm.Text);
            m_AcqMeLaser.dlg_RePaint = null;
            Application.DoEvents();
            //Thread.Sleep(500);
            m_AcqMeLaser.UpLoadPara();
            m_AcqMeLaser.dlg_RePaint = rePaint;
        }

        private void frm_AcqMeLaser_Attr_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_AcqMeLaser.dlg_RePaint = null;
        }

        private void cmb_TriggerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TriggerMode.SelectedIndex == 0)
            {
                txt_EncoderOneStepUm.Enabled = false;
                txt_EncoderStep.Enabled = false;
            }
            else
            {
                txt_EncoderOneStepUm.Enabled = true;
                txt_EncoderStep.Enabled = true;
            }
        }

        private void cmb_MeasureFeild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_MeasureFeild.SelectedIndex == 0)
            {
                txt_MeasureFeild.Text = (7).ToString();
                txt_MeasureFeild.Enabled = false;
            }
            else if (cmb_MeasureFeild.SelectedIndex == 1)
            {
                txt_MeasureFeild.Text = (2).ToString();
                txt_MeasureFeild.Enabled = false;
            }
            else if (cmb_MeasureFeild.SelectedIndex == 2)
            {
                txt_MeasureFeild.Text = (0).ToString();
                txt_MeasureFeild.Enabled = false;
            }
            else
            {
                txt_MeasureFeild.Enabled = true;
            }
        }
    }
}
