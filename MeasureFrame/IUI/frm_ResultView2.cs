using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_ResultView2 : Form
    {
        private double scaleX = 1.0;//相对绘图框的缩放比例
        private double scaleY = 1.0;
        public frm_ResultView2()
        {
            InitializeComponent();
            CHelper.g_ResultViewWnd = this.Handle;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }
        private HImage Image
        {
            set
            {
                if (value != null && value.IsInitialized())
                {
                    int width, height;
                    value.GetImageSize(out width, out height);
                    mCtrl_HWindow.HalconWindow.SetPart(0, 0, height, width);
                    mCtrl_HWindow.HalconWindow.DispImage(value);
                }
            }
        }

        public void ShowMSG(CMeasureCell cell)
        {
            for (int i = 0; i < mCtrl_HWindow.Controls.Count ; i++)
            {
                frm_Main.thisHandle.hWindow_Fit.Controls.RemoveAt(0);
            }
            scaleX = mCtrl_HWindow.Width * 1.0/((CResultView2)cell).rect.Width;
            scaleY = mCtrl_HWindow.Height * 1.0/((CResultView2)cell).rect.Height;
            List<ResultView_Info> m_ResultViewList = ((CResultView2)cell).m_ViewList;
            mCtrl_HWindow.HalconWindow.ClearWindow();

            if (m_ResultViewList.Count > 0)
            {
                List<ResultView_Info> m_ImageList = m_ResultViewList.FindAll(c => c.m_DataType == DataType.图像.ToString());
                if (m_ImageList.Count > 0)
                {
                    foreach (ResultView_Info r in m_ImageList)
                    {
                        string[] sPosition = r.m_DisPosition.Split(',');
                        PointF point1 = getNewPosition(double.Parse(sPosition[1]), double.Parse(sPosition[0]));
                        PointF point2 = getNewPosition(double.Parse(sPosition[3]), double.Parse(sPosition[2]));
                        int _width = Convert.ToInt32(point2.X - point1.X);
                        int _height = Convert.ToInt32(point2.Y - point1.Y);
                        if (r.m_DataType == DataType.图像.ToString())
                        {
                            HImageExt tempImage;
                            HMeasureSYS.Cur_Project.QueryImage(ImageCatagory.当前图像, r.m_VariableName, out tempImage);
                            if (tempImage.IsInitialized())
                            {
                                HWindowControl h = new HWindowControl();
                                int width, height;
                                tempImage.GetImageSize(out width, out height);
                                h.Location = new Point((int)point1.X ,(int)point1.Y);
                                h.Width = _width;
                                h.Height = _height;
                                mCtrl_HWindow.Controls.Add(h);
                                h.BringToFront();
                                h.HalconWindow.SetPart(0, 0, height, width);
                                h.HalconWindow.DispImage(tempImage);
                                foreach (sDictionary s in r.m_dispObj)
                                {
                                    F_DATA_CELL data = HMeasureSYS.Cur_Project.QueryVariableValue(s.m_UnitID, s.m_VariableName);
                                    HXLDCont xld = new HXLDCont();
                                    h.HalconWindow.SetColor("red");
                                    switch (data.m_Data_Type)
                                    {
                                        case DataType.点2D:
                                            List<PointF> points = (List<PointF>)data.m_Data_Value;
                                            foreach (PointF p in points)
                                            {
                                                h.HalconWindow.DispCross((double)p.Y, (double)p.X, 1.0, 0);
                                            }
                                            break;
                                        case DataType.椭圆:
                                            List<Ellipse_INFO> ellipses = (List<Ellipse_INFO>)data.m_Data_Value;
                                            foreach (Ellipse_INFO e in ellipses)
                                            {
                                                h.HalconWindow.DispEllipse(e.CenterY, e.CenterX, e.Phi, e.Radius1, e.Radius2);
                                            }
                                            break;
                                        case DataType.圆:
                                            List<Circle_INFO> circles = (List<Circle_INFO>)data.m_Data_Value;
                                            foreach (Circle_INFO c in circles)
                                            {
                                                h.HalconWindow.DispCircle(c.CenterY, c.CenterX, c.Radius);
                                            }
                                            break;
                                        case DataType.直线:
                                            List<Line_INFO> lines = (List<Line_INFO>)data.m_Data_Value;
                                            foreach (Line_INFO l in lines)
                                            {
                                                h.HalconWindow.DispLine(l.StartY, l.StartX, l.EndY, l.EndX);
                                            }
                                            break;
                                    }
                                }
                            }

                        }
                    }
                }
                foreach (ResultView_Info r in m_ResultViewList)
                {
                    mCtrl_HWindow.HalconWindow.SetColor(r.m_NormalColor);
                    if (r.m_ConditionVarName != "无")
                    {
                        F_DATA_CELL data = cell.m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                            c.m_Data_Name == r.m_VariableName);
                        if (((List<Boolean>)data.m_Data_Value)[0] == false)
                        {
                            mCtrl_HWindow.HalconWindow.SetColor(r.m_NgColor);
                        }
                    }
                    string dispMsg = string.Empty;
                    if (r.m_DataType == "无")
                    {
                        dispMsg = r.m_VariableName;
                    }
                    else if (r.m_DataType == DataType.数值型.ToString() || r.m_DataType == DataType.字符串.ToString())
                    {
                        F_DATA_CELL data = cell.m_Owner.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                            c.m_Data_Name == r.m_VariableName && c.m_Data_Group == DataGroup.单量);
                        if (data.m_Data_Type == DataType.数值型)
                        {
                            dispMsg = ((List<double>)data.m_Data_Value)[0].ToString("#0.0000");
                        }
                        else if (data.m_Data_Type == DataType.字符串)
                        {
                            dispMsg = ((List<string>)data.m_Data_Value)[0].ToString();
                        }
                    }
                    //double rLength=dispMsg.Length*r.m_NormalStyle.Size/2.0;
                    mCtrl_HWindow.HalconWindow.SetColor("blue");
                    string[] sPosition = r.m_DisPosition.Split(',');
                    PointF point1 = getNewPosition(double.Parse(sPosition[1]), double.Parse(sPosition[0]));
                    PointF point2 = getNewPosition(double.Parse(sPosition[3]), double.Parse(sPosition[2]));
                    HRegion region = new HRegion();
                    region.GenRectangle1(Convert.ToDouble(point1.Y), Convert.ToDouble(point1.X), Convert.ToDouble(point2.Y), Convert.ToDouble(point2.X));
                    HXLDCont xld = region.GenContourRegionXld("border");
                    //按照像素画框
                    //HXLDCont xld = new HXLDCont();
                    //xld.GenRectangle2ContourXld(double.Parse(sPosition[0]) + rLength, double.Parse(sPosition[0]) + r.m_NormalStyle.Size / 2.0, 0, rLength, r.m_NormalStyle.Size / 2.0);
                    mCtrl_HWindow.HalconWindow.DispXld(xld);
                    region.Dispose();
                    xld.Dispose();
                    string h_font = "-" + r.m_NormalStyle.Name +
                        "-" + (r.m_NormalStyle.Height*scaleY).ToString() +
                        "-" + (r.m_NormalStyle.Size*scaleX).ToString() +
                        "-" + (r.m_NormalStyle.Italic ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Underline ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Strikeout ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Bold ? 1 : 0).ToString() +
                        "-" + r.m_NormalStyle.GdiCharSet.ToString() + "-";
                    mCtrl_HWindow.HalconWindow.SetFont(h_font);
                    mCtrl_HWindow.HalconWindow.SetTposition((int)point1.Y, (int)point1.X);

                    mCtrl_HWindow.HalconWindow.WriteString(dispMsg);
                }
            }
        }

        private void frm_ResultView_Load(object sender, EventArgs e)
        {
            
            mCtrl_HWindow.HalconWindow.SetLineWidth(1);
            CHelper.dlgUpdate = new Measure.CHelper.DlgUpdateWindow(ShowMSG);
        }

        private void frm_ResultView_FormClosed(object sender, FormClosedEventArgs e)
        {
            CHelper.g_ResultViewWnd = IntPtr.Zero;
        }

        private PointF getNewPosition(double x,double y)
        {
            PointF position=new PointF();
            position.X = Convert.ToSingle(mCtrl_HWindow.Width / 2.0 + (x - mCtrl_HWindow.Width / (scaleX * 2.0)) * scaleX);
            position.Y = Convert.ToSingle(mCtrl_HWindow.Height / 2.0 + (y - mCtrl_HWindow.Height / (scaleY*2.0)) * scaleY);
            return position;
        }

        private void frm_ResultView_FormClosing(object sender, FormClosingEventArgs e)
        {
            CHelper.dlgUpdate = null;
        }
    }
}
