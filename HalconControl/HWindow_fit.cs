// 版权所有(C) ChoiceTech Corporation。保留所有权利。
// 此代码的发布遵从
// ChoiceTech 公共许可(HY-PL，http://choicetech.cn/hy-pl.html)的条款。
//
//版权所有(C) ChoiceTech Corporation。保留所有权利。

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using CPublicDefine;
using Tool;

namespace HalconControl
{
    public delegate void DelegateRePaint();
    public partial class HWindow_Fit : UserControl
    {
        #region 私有变量定义.
        private HImage ImgView;
        private HImage hv_image;
        private HWindow hv_window;
        private int hv_imageWidth, hv_imageHeight;
        private double mposition_row, mposition_col;
        private int _offsetRow, _offsetCol, _dispWidth, _dispHeight;
        // 设定图像的窗口显示部分
        private int zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol;
        // 获取图像的当前显示部分
        private int current_beginRow, current_beginCol, current_endRow, current_endCol;
        // 窗口和图像的宽高比
        private double ratio_win, ratio_img;
        //鼠标在控件上的按下or松开状态
        private bool b_leftButton, b_rightButton;
        //记录鼠标按下时鼠标在图像的相对位置
        private double start_positionRow, start_positionColumn;
        //记录是否3D
        private bool b_3Dview = false;
        double hv_lastRow;
        double hv_lastCol;
        //是否涂抹
        private bool blnDraw = false;
        private int drawMode = 0;// 0 - 绘制模式 增加ROI 1- 涂抹减去ROI
        private HRegion brushRegion = new HRegion();
        private DateTime lastTime = DateTime.Now;

        //底部label显示的图像信息 magical20171026
        private string str_value;//灰度值
        private string str_position;//鼠标位置
        private double focusScore;//图像清晰度评分
        private HRegion focusRegion;//图像清晰度区域
        /// *Tenegrad    Tenegrad函数法 对于高像素的图片,如2900W,该算法时间约为100ms,其他均大于200ss
        /// *Deviation   '方差法
        /// *laplace    '拉普拉斯能量函数
        /// *energy     '能量梯度函数 效果最好
        /// *Brenner    ' Brenner函数法
        private string focusMethod = "energy";


        private string str_imgSize;
        private ContextMenuStrip hv_MenuStrip;

        ToolStripMenuItem fit_strip;
        ToolStripMenuItem saveImg_strip;
        ToolStripMenuItem blnCross_strip;
        ToolStripMenuItem blnFocus_strip;//显示清晰度评价 magical 20171026
        ToolStripMenuItem barVisible_strip;
        ToolStripMenuItem histogram_strip;
        public ToolStripMenuItem view3D_strip;
        ToolStripMenuItem window_backcolor;
        public ToolStripMenuItem ImgToDepthColor;
        public int i3DMaxvalue
        {
            set
            {
                trackBar_limitUp.Maximum = value;
                trackBar_limitDown.Maximum = value;
                trackBar_limitUp.Value = value;
            }
        }
        public int i3DMinvalue
        {
            set
            {
                trackBar_limitUp.Minimum = value;
                trackBar_limitDown.Minimum = value;
                trackBar_limitDown.Value = value;
            }
        }
        #endregion

        public event DelegateRePaint RePaint;
        public HImage Image
        {
            get { return this.hv_image; }
            set
            {
                ImgView = value;
                this.hv_image = value;
                if (hv_image != null && value.IsInitialized())
                {
                    hv_image.GetImageSize(out hv_imageWidth, out hv_imageHeight);

                    str_imgSize = String.Format("{0}X{1}", hv_imageWidth, hv_imageHeight);

                    string type = hv_image.GetImageType().ToString();

                    if (blnFocus_strip.Checked && focusRegion != null && focusRegion.IsInitialized())//如果选中显示图像清晰度 magical 20171026
                    {
                        focusScore = FocusTool.evaluate_definition(this.hv_image.ReduceDomain(focusRegion), focusMethod);
                        this.Invoke(new Action(
                        delegate
                        {
                            m_CtrlHStatusLabelCtrl.Text = str_imgSize + "    " + str_position + "    " + str_value + "  清晰度:  " + focusScore;
                        }));
                    }

                    if (type.Contains("real"))
                    {
                        ImgToDepthColor.Visible = true;
                        view3D_strip.Visible = true;
                    }
                    else
                    {
                        ImgToDepthColor.Visible = false;
                        view3D_strip.Visible = false;
                    }

                    barVisible_strip.Enabled = true;
                    fit_strip.Enabled = true;
                    histogram_strip.Enabled = true;
                    saveImg_strip.Enabled = true;
                    view3D_strip.Enabled = true;
                    ImgToDepthColor.Enabled = true;
                    if (ImgToDepthColor.Checked || view3D_strip.Checked)
                    {
                        ImgView = CHelper.ScaleImageRange(hv_image, trackBar_limitDown.Value, trackBar_limitUp.Value);
                        //CHelper.ConvertImgToDepthColor(hv_image, out hv_image, trackBar_limitUp.Value, trackBar_limitDown.Value);
                    }
                    hv_window.SetDraw("margin");
                    hv_window.DispObj(ImgView);
                    PaintCross();
                }
            }
        }

        public HWindow HWindowID
        {
            get { return this.mCtrl_HWindow.HalconWindow; }
        }
        public IntPtr HWindowHalconID
        {
            get { return this.mCtrl_HWindow.HalconID; }
        }
        public int offsetRow
        {
            get { return _offsetRow; }
        }
        public int offsetCol
        {
            get { return _offsetCol; }
        }
        public int dispWidth
        {
            get { return _dispWidth; }
        }
        public int dispHeight
        {
            get { return _dispHeight; }
        }

        protected override void OnSizeChanged(EventArgs e)
        {

            //将控件嵌入dock内部会在此处崩溃 由于只是将图像缩放恢复为正常显示 故直接try 屏蔽异常
            try
            {
                base.OnSizeChanged(e);
            }
            catch (Exception)
            {
            }

        }
        public void DrawRectangle1Mod(string color, double row1, double col1, double row2, double col2, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd)
        {
            try
            {
                Double _rowBegin, _colBegin, _rowEnd, _colEnd;

                //ShieldMouseEvent();
                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawRectangle1Mod(row1, col1, row2, col2, out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                HRegion rectangle = new HRegion();
                rectangle.GenRectangle1(_rowBegin, _colBegin, _rowEnd, _colEnd);
                rectangle.DispObj(hv_window);
                //ReloadMouseEvent();
                rectangle.Dispose();
                rowBegin = _rowBegin;
                colBegin = _colBegin;
                rowEnd = _rowEnd;
                colEnd = _colEnd;
            }
            catch (System.Exception ex)
            {
                rowBegin = 0.0;
                colBegin = 0.0;
                rowEnd = 0.0;
                colEnd = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }
        /// <summary>
        ///  在图像中绘制矩形区域
        /// </summary>
        /// <param name="rowBegin"></param>
        /// <param name="colBegin"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colEnd"></param>
        public void DrawRectangle1(string color, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd)
        {

            try
            {
                Double _rowBegin, _colBegin, _rowEnd, _colEnd;

                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawRectangle1(out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                HRegion rectangle = new HRegion();
                rectangle.GenRectangle1(_rowBegin, _colBegin, _rowEnd, _colEnd);
                rectangle.DispObj(hv_window);
                rectangle.Dispose();
                ReloadMouseEvent();

                rowBegin = _rowBegin;
                colBegin = _colBegin;
                rowEnd = _rowEnd;
                colEnd = _colEnd;
            }
            catch (System.Exception ex)
            {
                rowBegin = 0.0;
                colBegin = 0.0;
                rowEnd = 0.0;
                colEnd = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        /// <summary>
        ///  在图像中绘制矩形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="phi"></param>
        /// <param name="length1"></param>
        /// <param name="length2"></param>
        public void DrawRectangle2(string color, out double row, out double column, out double phi, out double length1, out double length2)
        {

            try
            {
                Double _row, _column, _phi, _length1, _length2;

                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawRectangle2(out _row, out _column, out _phi, out _length1, out _length2);
                HRegion rectangle = new HRegion();
                rectangle.GenRectangle2(_row, _column, _phi, _length1, _length2);
                rectangle.DispObj(hv_window);
                rectangle.Dispose();
                ReloadMouseEvent();

                row = _row;
                column = _column;
                phi = _phi;
                length1 = _length1;
                length2 = _length2;
            }
            catch (System.Exception ex)
            {
                row = 0.0;
                column = 0.0;
                phi = 0.0;
                length1 = 0.0;
                length2 = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        /// <summary>
        /// 在图像中绘制圆形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radius"></param>
        public void DrawCircle(string color, out double row, out double column, out double radius)
        {
            try
            {

                Double _row, _column, _radius;
                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawCircle(out _row, out _column, out _radius);

                HRegion circle = new HRegion();
                circle.GenCircle(_row, _column, _radius);
                circle.DispObj(hv_window);
                circle.Dispose();
                ReloadMouseEvent();

                row = _row;
                column = _column;
                radius = _radius;

            }
            catch (Exception ex)
            {
                row = 0.0;
                column = 0.0;
                radius = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        public void DrawPoint(string color, out double Row, out double Col)
        {
            try
            {
                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawPoint(out Row, out Col);
                hv_window.DispCross(Row, Col, 10, 0);
                hv_window.DispRectangle2(Row, Col, 0, 3, 3);
                ReloadMouseEvent();
            }
            catch (Exception ex)
            {
                Row = 0;
                Col = 0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        /// <summary>
        /// 在图像中绘制直线
        /// </summary>
        /// <param name="color"></param>
        /// <param name="beginRow"></param>
        /// <param name="beginCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        public void DrawLine(string color, out double beginRow, out double beginCol, out double endRow, out double endCol)
        {
            try
            {

                Double _beginRow, _beginCol, _endRow, _endCol;
                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawLine(out _beginRow, out _beginCol, out _endRow, out _endCol);

                hv_window.DispLine(_beginRow, _beginCol, _endRow, _endCol);
                ReloadMouseEvent();

                beginRow = _beginRow;
                beginCol = _beginCol;
                endRow = _endRow;
                endCol = _endCol;

            }
            catch (Exception ex)
            {
                beginRow = 0.0;
                beginCol = 0.0;
                endRow = 0.0;
                endCol = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }
        /// <summary>
        /// 在图像中绘制椭圆形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radius"></param>
        public void DrawEllipse(string color, out double row, out double column, out double phi, out double radius1, out double radius2)
        {
            try
            {

                Double _row, _column, _phi, _radius1, _radius2;
                ShieldMouseEvent();

                mCtrl_HWindow.Focus();
                hv_window.SetColor(color);
                hv_window.DrawEllipse(out _row, out _column, out _phi, out _radius1, out _radius2);

                HRegion ellipse = new HRegion();
                ellipse.GenEllipse(_row, _column, _phi, _radius1, _radius2);
                ellipse.DispObj(hv_window);
                ellipse.Dispose();
                ReloadMouseEvent();

                row = _row;
                column = _column;
                phi = _phi;
                radius1 = _radius1;
                radius2 = _radius2;

            }
            catch (Exception ex)
            {
                row = 0.0;
                column = 0.0;
                phi = 0.0;
                radius1 = 0.0;
                radius2 = 0.0;
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        public HWindow_Fit()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            hv_window = this.mCtrl_HWindow.HalconWindow;
            //hv_window.SetDraw("margin");
            //              设定鼠标按下时图标的形状
            //              'arrow'  'default' 'crosshair' 'text I-beam' 'Slashed circle' 'Size All'
            //              'Size NESW' 'Size S' 'Size NWSE' 'Size WE' 'Vertical Arrow' 'Hourglass'
            //
            //hv_window.SetMshape("Hourglass");

            fit_strip = new ToolStripMenuItem("适应窗口(F)");
            fit_strip.Click += new EventHandler((s, e) => DispImageFit());

            barVisible_strip = new ToolStripMenuItem("显示StatusBar");
            barVisible_strip.CheckOnClick = true;
            barVisible_strip.Checked = true;
            barVisible_strip.CheckedChanged += new EventHandler(barVisible_strip_CheckedChanged);

            blnCross_strip = new ToolStripMenuItem("显示十字线");
            blnCross_strip.CheckOnClick = true;

            blnFocus_strip = new ToolStripMenuItem("显示图像清晰度");
            blnFocus_strip.CheckOnClick = true;
            blnFocus_strip.Click += new EventHandler((s, e) => FocusClick());


            saveImg_strip = new ToolStripMenuItem("保存结果图像(S)");
            saveImg_strip.Click += new EventHandler((s, e) => SaveWindowDumpDialog());

            histogram_strip = new ToolStripMenuItem("显示直方图(H)");
            //            histogram_strip.Click += new EventHandler((s, e) => ShowHistogram());
            histogram_strip.CheckOnClick = true;
            histogram_strip.Checked = false;

            view3D_strip = new ToolStripMenuItem("3D 视图");
            view3D_strip.CheckOnClick = true;
            view3D_strip.CheckedChanged += new EventHandler((s, e) => view3D_CheckedChanged(s, e));

            window_backcolor = new ToolStripMenuItem("窗体颜色");
            window_backcolor.CheckOnClick = true;
            window_backcolor.Click += new EventHandler((s, e) => win_BackColorChanged(s, e));

            ImgToDepthColor = new ToolStripMenuItem("彩色视图");
            ImgToDepthColor.CheckOnClick = true;
            ImgToDepthColor.CheckedChanged += new EventHandler((s, e) => ImgToDepthColor_CheckedChanged(s, e));

            hv_MenuStrip = new ContextMenuStrip();
            hv_MenuStrip.Items.Add(fit_strip);
            hv_MenuStrip.Items.Add(barVisible_strip);
            hv_MenuStrip.Items.Add(blnCross_strip);
            hv_MenuStrip.Items.Add(blnFocus_strip);

            //            hv_MenuStrip.Items.Add(histogram_strip);
            //hv_MenuStrip.Items.Add(new ToolStripSeparator());
            hv_MenuStrip.Items.Add(saveImg_strip);
            hv_MenuStrip.Items.Add(view3D_strip);
            hv_MenuStrip.Items.Add(ImgToDepthColor);
            hv_MenuStrip.Items.Add(window_backcolor);

            barVisible_strip.Enabled = true;
            barVisible_strip.Visible = false;
            fit_strip.Enabled = false;
            histogram_strip.Enabled = false;
            saveImg_strip.Enabled = false;
            ImgToDepthColor.Enabled = false;
            ImgToDepthColor.Checked = false;
            view3D_strip.Enabled = false;
            view3D_strip.Visible = true;
            window_backcolor.Enabled = true;

            mCtrl_HWindow.ContextMenuStrip = hv_MenuStrip;
            mCtrl_HWindow.SizeChanged += new EventHandler((s, e) => DispImageFit());

            hv_MenuStrip.MouseEnter += new EventHandler((s, e) => { mCtrl_HWindow.HMouseWheel -= HWindowControl_HMouseWheel; });
            hv_MenuStrip.MouseLeave += new EventHandler((s, e) => { mCtrl_HWindow.HMouseWheel += HWindowControl_HMouseWheel; });

        }

        private void FocusClick()//评价图像清晰度 magical20171026
        {

            mCtrl_HWindow.HalconWindow.SetDraw("margin");
            if (blnFocus_strip.Checked)//如果选中显示图像清晰度
            {
                //画出兴趣图像区域
                double _rowBegin, _colBegin, _rowEnd, _colEnd;

                if (focusRegion == null)
                {
                    focusRegion = new HRegion();
                }
                else
                {
                    focusRegion.Dispose();
                }

                this.DrawRectangle1("red", out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                focusRegion.GenRectangle1(_rowBegin, _colBegin, _rowEnd, _colEnd);

                focusScore = FocusTool.evaluate_definition(this.hv_image.ReduceDomain(focusRegion), focusMethod);
                m_CtrlHStatusLabelCtrl.Text = str_imgSize + "    " + str_position + "    " + str_value + "  清晰度:  " + focusScore;
            }
        }

        void barVisible_strip_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem strip = sender as ToolStripMenuItem;

            this.SuspendLayout();

            if (strip.Checked)
            {
                m_CtrlHStatusLabelCtrl.Visible = true;
                mCtrl_HWindow.Height = this.Height - m_CtrlHStatusLabelCtrl.Height - m_CtrlHStatusLabelCtrl.Margin.Top - m_CtrlHStatusLabelCtrl.Margin.Bottom;
                //mCtrl_HWindow.HMouseMove += HWindowControl_HMouseMove;
            }
            else
            {
                m_CtrlHStatusLabelCtrl.Visible = false;
                mCtrl_HWindow.Height = this.Height;
                //mCtrl_HWindow.HMouseMove -= HWindowControl_HMouseMove;
            }
            DispImageFit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SaveWindowDumpDialog()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //string imgFileName;

                sfd.Filter = "HE图像|*.he|PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(sfd.FileName))
                        return;
                    if (hv_image is HImageExt)
                        ((HImageExt)hv_image).WriteImageExt(sfd.FileName);
                    else
                    {
                        string ext = Path.GetExtension(sfd.FileName);
                        hv_image.WriteImage(ext.Substring(1), 0, sfd.FileName);
                    }
                    //imgFileName = sfd.FileName;
                    //SaveWindowDump(imgFileName, new Size(1280, 1024));
                }
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }

        }
        /// <summary>
        /// 保存结果至特定分辨率的图像文件
        /// </summary>
        /// <param name="fileName">图像文件路径</param>
        /// <param name="size">图像分辨率</param>
        public void SaveWindowDump(string fileName, Size size)
        {
            try
            {
                if (ImgView != null && ImgView.IsInitialized())
                {
                    HWindowControl hw = new HWindowControl();
                    hw.WindowSize = size;

                    DispImageFit();
                    hw.HalconWindow.DumpWindow("png best", fileName);
                    hw.Dispose();
                }
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        public void DispImageFit()
        {
            try
            {
                if (ImgView != null && ImgView.IsInitialized())
                {
                    ratio_win = (double)mCtrl_HWindow.WindowSize.Width / (double)mCtrl_HWindow.WindowSize.Height;
                    ratio_img = (double)hv_imageWidth / (double)hv_imageHeight;

                    int _beginRow, _begin_Col, _endRow, _endCol;

                    if (ratio_win >= ratio_img)
                    {
                        _beginRow = 0;
                        _endRow = hv_imageHeight - 1;
                        _begin_Col = (int)(-hv_imageWidth * (ratio_win / ratio_img - 1d) / 2d);
                        _endCol = (int)(hv_imageWidth + hv_imageWidth * (ratio_win / ratio_img - 1d) / 2d);
                    }
                    else
                    {
                        _begin_Col = 0;
                        _endCol = hv_imageWidth - 1;
                        _beginRow = (int)(-hv_imageHeight * (ratio_img / ratio_win - 1d) / 2d);
                        _endRow = (int)(hv_imageHeight + hv_imageHeight * (ratio_img / ratio_win - 1d) / 2d);
                    }
                    zoom_beginRow = _beginRow;
                    zoom_beginCol = _begin_Col;
                    zoom_endRow = _endRow;
                    zoom_endCol = _endCol;
                    HSystem.SetSystem("flush_graphic", "false");
                    mCtrl_HWindow.HalconWindow.ClearWindow();
                    HSystem.SetSystem("flush_graphic", "true");
                    mCtrl_HWindow.HalconWindow.SetPart(_beginRow, _begin_Col, _endRow, _endCol);
                    _offsetRow = _beginRow;
                    _offsetCol = _begin_Col;
                    _dispWidth = _endRow - _beginRow;
                    _dispHeight = _endCol - _begin_Col;
                    mCtrl_HWindow.HalconWindow.DispObj(ImgView);

                    PaintCross();
                    if (RePaint != null)
                    {
                        RePaint();
                    }
                }
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        private void PaintCross()
        {
            if (blnCross_strip.Checked)
            {
                //显示十字线
                HXLDCont xldCross = new HXLDCont();
                mCtrl_HWindow.HalconWindow.SetColor("green");

                mCtrl_HWindow.HalconWindow.DispLine(hv_imageHeight / 2.0, 0, hv_imageHeight / 2.0, hv_imageWidth);
                mCtrl_HWindow.HalconWindow.DispLine(0, hv_imageWidth / 2.0, hv_imageHeight, hv_imageWidth / 2.0);
            }

            //显示清晰评价区域
            if (blnFocus_strip.Checked && focusRegion != null && focusRegion.IsInitialized())
            {
                mCtrl_HWindow.HalconWindow.DispObj(focusRegion);
            }
        }


        //3D展示
        private void view3D_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = ImgToDepthColor.Checked || view3D_strip.Checked;
                if (view3D_strip.Checked)
                {
                    b_3Dview = true;
                    hv_window.SetPaint(((new HTuple("3d_plot")).TupleConcat("shaded")).TupleConcat(8));
                    //hv_window.SetWindowParam("display_axes", "false");
                    hv_window.SetWindowParam("display_grid", "false");
                    //hv_window.SetLut("rainbow");
                    ImgView = CHelper.ScaleImageRange(hv_image, trackBar_limitDown.Value, trackBar_limitUp.Value);

                }
                else
                {
                    b_3Dview = false;
                    hv_window.SetPaint("default");
                }
                if (!(ImgToDepthColor.Checked || view3D_strip.Checked))
                {
                    ImgView = hv_image;
                }
                DispImageFit();
                //if (hv_image != null && hv_image.IsInitialized())
                //{
                //    hv_window.DispObj(hv_image);
                //}
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }
        //更改背景
        private void win_BackColorChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                mCtrl_HWindow.HalconWindow.SetWindowParam("background_color", "white");
            }
            else
            {
                mCtrl_HWindow.HalconWindow.SetWindowParam("background_color", "black");
            }
            refreshWindow();
        }

        private void ImgToDepthColor_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = ImgToDepthColor.Checked || view3D_strip.Checked;
            if (ImgToDepthColor.Checked)
            {
                hv_window.SetLut("rainbow");
                ImgView = CHelper.ScaleImageRange(hv_image, trackBar_limitDown.Value, trackBar_limitUp.Value);
            }
            else
            {
                hv_window.SetLut("default");
            }
            if (!(ImgToDepthColor.Checked || view3D_strip.Checked))
            {
                ImgView = hv_image;
            }
            if (ImgView != null && ImgView.IsInitialized())
            {
                hv_window.DispObj(ImgView);
            }
        }

        private void HWindowControl_HMouseWheel(object sender, HMouseEventArgs e)
        {
            if (ImgView != null && ImgView.IsInitialized() && !b_3Dview)
            {
                try
                {
                    int button_state;
                    hv_window.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    hv_window.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
                }
                catch (Exception ex)
                {
                    m_CtrlHStatusLabelCtrl.Text = ex.Message;
                }

                if (e.Delta > 0)                 // 放大图像
                {
                    zoom_beginRow = (int)(current_beginRow + (mposition_row - current_beginRow) * 0.100d);
                    zoom_beginCol = (int)(current_beginCol + (mposition_col - current_beginCol) * 0.100d);
                    zoom_endRow = (int)(current_endRow - (current_endRow - mposition_row) * 0.100d);
                    zoom_endCol = (int)(current_endCol - (current_endCol - mposition_col) * 0.100d);

                }
                else                // 缩小图像
                {
                    zoom_beginRow = (int)(mposition_row - (mposition_row - current_beginRow) / 0.900d);
                    zoom_beginCol = (int)(mposition_col - (mposition_col - current_beginCol) / 0.900d);
                    zoom_endRow = (int)(mposition_row + (current_endRow - mposition_row) / 0.900d);
                    zoom_endCol = (int)(mposition_col + (current_endCol - mposition_col) / 0.900d);
                }
                try
                {
                    int hw_width, hw_height;
                    hw_width = mCtrl_HWindow.WindowSize.Width;
                    hw_height = mCtrl_HWindow.WindowSize.Height;

                    bool _isOutOfArea = true;
                    bool _isOutOfSize = true;
                    bool _isOutOfPixel = true; //避免像素过大

                    _isOutOfArea = zoom_beginRow >= hv_imageHeight || zoom_endRow <= 0 || zoom_beginCol >= hv_imageWidth || zoom_endCol < 0;
                    _isOutOfSize = (zoom_endRow - zoom_beginRow) > hv_imageHeight * 20 || (zoom_endCol - zoom_beginCol) > hv_imageWidth * 20;
                    _isOutOfPixel = hw_height / (zoom_endRow - zoom_beginRow) > 500 || hw_width / (zoom_endCol - zoom_beginCol) > 500;

                    if (_isOutOfArea || _isOutOfSize)
                    {
                        DispImageFit();
                    }
                    else if (!_isOutOfPixel)
                    {

                        HSystem.SetSystem("flush_graphic", "false");
                        hv_window.ClearWindow();
                        HSystem.SetSystem("flush_graphic", "true");

                        //hv_window.SetPaint(new HTuple("default"));
                        //              保持图像显示比例
                        zoom_endCol = zoom_beginCol + (zoom_endRow - zoom_beginRow) * hw_width / hw_height;
                        hv_window.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
                        hv_window.DispObj(ImgView);
                    }
                    PaintCross();
                    if (RePaint != null)
                    {
                        RePaint();
                    }
                }
                catch (Exception ex)
                {
                    DispImageFit();
                    m_CtrlHStatusLabelCtrl.Text = ex.Message;
                }
            }
        }

        private void HWindowControl_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (hv_image != null && hv_image.IsInitialized())
            {
                try
                {
                    int button_state;
                    double positionRow, positionColumn;
                    bool _isXOut = true, _isYOut = true;
                    HTuple channel_count;
                    HTuple hv_mode = new HTuple();


                    HOperatorSet.CountChannels(hv_image, out channel_count);

                    hv_window.GetMpositionSubPix(out positionRow, out positionColumn, out button_state);
                    str_position = String.Format("ROW: {0:0000.0}, COLUMN: {1:0000.0}", positionRow, positionColumn);

                    _isXOut = (positionColumn < 0 || positionColumn >= hv_imageWidth);
                    _isYOut = (positionRow < 0 || positionRow >= hv_imageHeight);


                    if (!_isXOut && !_isYOut)
                    {

                        if (!b_3Dview)
                        {
                            try
                            {
                                if ((int)channel_count == 1)
                                {
                                    double grayVal;
                                    grayVal = hv_image.GetGrayval((int)positionRow, (int)positionColumn);
                                    str_value = String.Format("Val: {0:000.0}", grayVal);
                                }
                                else if ((int)channel_count == 3)
                                {
                                    double grayValRed, grayValGreen, grayValBlue;

                                    HImage _RedChannel, _GreenChannel, _BlueChannel;

                                    _RedChannel = hv_image.AccessChannel(1);
                                    _GreenChannel = hv_image.AccessChannel(2);
                                    _BlueChannel = hv_image.AccessChannel(3);

                                    grayValRed = _RedChannel.GetGrayval((int)positionRow, (int)positionColumn);
                                    grayValGreen = _GreenChannel.GetGrayval((int)positionRow, (int)positionColumn);
                                    grayValBlue = _BlueChannel.GetGrayval((int)positionRow, (int)positionColumn);

                                    _RedChannel.Dispose();
                                    _GreenChannel.Dispose();
                                    _BlueChannel.Dispose();

                                    str_value = String.Format("Val: ({0:000.0}, {1:000.0}, {2:000.0})", grayValRed, grayValGreen, grayValBlue);
                                }
                                else
                                {
                                    str_value = "";
                                }


                                if (blnFocus_strip.Checked)//如果选中显示图像清晰度
                                {
                                    m_CtrlHStatusLabelCtrl.Text = str_imgSize + "    " + str_position + "    " + str_value + "  清晰度:  " + focusScore;
                                }
                                else
                                {
                                    m_CtrlHStatusLabelCtrl.Text = str_imgSize + "    " + str_position + "    " + str_value;
                                }
                            }
                            catch (System.Exception ex)
                            {
                                m_CtrlHStatusLabelCtrl.Text = ex.Message;
                            }

                        }

                        //当鼠标左键按下移动时，移动图片，并且鼠标变成手状
                        switch (button_state)
                        {
                            case 0:
                                this.Cursor = System.Windows.Forms.Cursors.Default;

                                break;
                            case 1:
                                if (b_3Dview)
                                {
                                    hv_mode = "rotate";
                                    hv_window.UpdateWindowPose(hv_lastRow, hv_lastCol, positionColumn, positionRow, hv_mode);
                                    hv_window.DispObj(ImgView);
                                }
                                else if (!b_3Dview && b_leftButton)
                                {

                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                    HSystem.SetSystem("flush_graphic", "false");
                                    hv_window.ClearWindow();
                                    HSystem.SetSystem("flush_graphic", "true");
                                    hv_window.SetPaint(new HTuple("default"));
                                    //              保持图像显示比例
                                    zoom_beginCol -= (int)(positionColumn - start_positionColumn);
                                    zoom_beginRow -= (int)(positionRow - start_positionRow);
                                    zoom_endCol -= (int)(positionColumn - start_positionColumn);
                                    zoom_endRow -= (int)(positionRow - start_positionRow);
                                    hv_window.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
                                    hv_window.DispObj(ImgView);
                                    PaintCross();
                                    if (RePaint != null)
                                    {
                                        RePaint();
                                    }

                                }
                                break;
                            case 2:
                                break;
                            case 9:
                                if (b_3Dview)
                                {
                                    hv_mode = "scale";
                                    hv_window.UpdateWindowPose(hv_lastRow, hv_lastCol, positionColumn, positionRow, hv_mode);
                                    hv_window.DispImage(ImgView);
                                }
                                break;
                            case 17:
                                if (b_3Dview)
                                {
                                    hv_mode = "move";
                                    hv_window.UpdateWindowPose(hv_lastRow, hv_lastCol, positionColumn, positionRow, hv_mode);
                                    hv_window.DispImage(ImgView);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    hv_lastCol = positionRow;
                    hv_lastRow = positionColumn;
                }
                catch (Exception ex)
                {
                    m_CtrlHStatusLabelCtrl.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// 清空图像显示
        /// </summary>
        public void ClearHWindow()
        {
            HSystem.SetSystem("flush_graphic", "false");
            hv_window.ClearWindow();

            barVisible_strip.Enabled = true;
            fit_strip.Enabled = false;
            histogram_strip.Enabled = false;
            saveImg_strip.Enabled = false;
            HSystem.SetSystem("flush_graphic", "true");
        }


        private void mCtrl_HWindow_HMouseDown(object sender, HMouseEventArgs e)
        {
            int temp_button_state;
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        if (blnDraw)
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Default;
                            if ((DateTime.Now - lastTime).TotalMilliseconds < 500)
                            {
                                drawMode = Math.Abs(drawMode - 1);
                            }
                            lastTime = DateTime.Now;
                        }
                        else
                            this.Cursor = System.Windows.Forms.Cursors.Hand;
                        hv_window.GetMpositionSubPix(out start_positionRow, out start_positionColumn, out temp_button_state);
                        b_leftButton = true;
                        break;
                    case MouseButtons.Right:
                        b_rightButton = true;
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                        break;
                    case MouseButtons.Middle:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        private void mCtrl_HWindow_HMouseUp(object sender, HMouseEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                        b_leftButton = false;
                        break;
                    case MouseButtons.Right:
                        b_rightButton = false;
                        break;
                    case MouseButtons.Middle:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                m_CtrlHStatusLabelCtrl.Text = ex.Message;
            }
        }

        /// <summary>
        /// 刷新控件
        /// </summary>
        public void refreshWindow()
        {
            HSystem.SetSystem("flush_graphic", "false");
            hv_window.ClearWindow();
            HSystem.SetSystem("flush_graphic", "true");
            if (ImgView != null && ImgView.IsInitialized())
            {
                hv_window.DispObj(ImgView);
            }
        }

        /// <summary>
        /// 屏蔽鼠标事件
        /// </summary>
        public void ShieldMouseEvent()
        {
            mCtrl_HWindow.ContextMenuStrip = null;
            this.mCtrl_HWindow.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.mCtrl_HWindow_HMouseDown);
            this.mCtrl_HWindow.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.mCtrl_HWindow_HMouseUp);
            mCtrl_HWindow.HMouseMove -= HWindowControl_HMouseMove;
            mCtrl_HWindow.HMouseWheel -= HWindowControl_HMouseWheel;
        }

        /// <summary>
        /// 重新加载　鼠标事件
        /// </summary>
        public void ReloadMouseEvent()
        {
            mCtrl_HWindow.ContextMenuStrip = hv_MenuStrip;
            this.mCtrl_HWindow.HMouseDown += new HalconDotNet.HMouseEventHandler(this.mCtrl_HWindow_HMouseDown);
            this.mCtrl_HWindow.HMouseUp += new HalconDotNet.HMouseEventHandler(this.mCtrl_HWindow_HMouseUp);
            mCtrl_HWindow.HMouseMove += HWindowControl_HMouseMove;
            mCtrl_HWindow.HMouseWheel += HWindowControl_HMouseWheel;
        }

        private void trackBar_limitDown_Scroll(object sender, EventArgs e)
        {
            if (trackBar_limitUp.Value <= trackBar_limitDown.Value)
            {
                trackBar_limitUp.Value = trackBar_limitDown.Value + 1;
            }
            if (view3D_strip.Checked)
            {
                view3D_CheckedChanged(sender, e);
            }
            else if (ImgToDepthColor.Checked)
            {
                ImgToDepthColor_CheckedChanged(sender, e);
            }
        }

        private void trackBar_limitUp_Scroll(object sender, EventArgs e)
        {
            if (trackBar_limitDown.Value >= trackBar_limitUp.Value)
            {
                trackBar_limitDown.Value = trackBar_limitUp.Value - 1;
            }
            if (view3D_strip.Checked)
            {
                view3D_CheckedChanged(sender, e);
            }
            else if (ImgToDepthColor.Checked)
            {
                ImgToDepthColor_CheckedChanged(sender, e);
            }
        }

        #region 绘制任意屏蔽区域  edit by zhangli at 2017/10/24
        public HRegion SetROI(HRegion region)
        {
            this.mCtrl_HWindow.Focus();//必须先聚焦

            try
            {


                mCtrl_HWindow.HMouseMove -= HWindowControl_HMouseMove;
                blnDraw = true;
                double Row = 0, Column = 0;
                //鼠标状态
                int hv_Button = 0;
                // 4为鼠标右键
                while (hv_Button != 4)
                {
                    //一直在循环,需要让halcon控件也响应事件,不然到时候跳出循环,之前的事件会一起爆发触发,
                    Application.DoEvents();
                    //获取鼠标坐标
                    try
                    {
                        hv_window.GetMpositionSubPix(out Row, out Column, out hv_Button);

                        hv_window.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
                        double d = Math.Sqrt(Math.Pow(current_endRow - current_beginRow, 2) + Math.Pow(current_endCol - current_beginCol, 2));
                        brushRegion.GenCircle(Row, Column, d / 50.0);
                    }
                    catch (HalconException ex)
                    {
                        hv_Button = 0;
                    }

                    //check if mouse cursor is over window
                    if (Row >= 0 && Column >= 0)
                    {
                        //1为鼠标左键
                        if (hv_Button == 1)
                        {
                            //画出笔刷
                            switch (drawMode)
                            {
                                case 0:
                                    {
                                        if (region.IsInitialized())
                                            region = region.Union2(brushRegion);
                                        else
                                            region = brushRegion;
                                    }
                                    break;
                                case 1:
                                    region = region.Difference(brushRegion);
                                    break;
                                default:
                                    MessageBox.Show("设置错误");
                                    break;
                            }//end switch

                        }//end if
                    }
                    HOperatorSet.SetSystem("flush_graphic", "false");//magical 20171028 防止画面闪烁
                    hv_window.DispObj(ImgView);

                    hv_window.SetDraw("margin");
                    hv_window.SetLineWidth(1);

                    hv_window.SetColor("green");//这一段也必须放在中间
                    if (region != null && region.IsInitialized())
                        hv_window.DispObj(region);

                    HOperatorSet.SetSystem("flush_graphic", "true");//很奇怪必须放在这里,不能把下面的给包含进去 magical20171028

                    if (drawMode == 0)
                        hv_window.SetColor("green");
                    else
                        hv_window.SetColor("gray");
                    if (brushRegion != null && brushRegion.IsInitialized())
                        hv_window.DispObj(brushRegion);




                }//end while
                blnDraw = false;
                mCtrl_HWindow.HMouseMove += HWindowControl_HMouseMove;
                return region;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region "显示文字"

        #endregion

    }
}
