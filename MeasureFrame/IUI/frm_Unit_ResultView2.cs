using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using System.Linq;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;

namespace MeasureFrame.IUI
{
    /// <summary>
    /// 使用
    /// </summary>
    public partial class frm_Unit_ResultView2 : MeasureFrame.IUI.frm_Unit
    {
        private ResultView_Info m_ResultView_Info = new ResultView_Info();
        private List<ResultView_Info> m_ResultViewList = new List<ResultView_Info>();
        private Font NormalStyle = new Font("宋体", 12, GraphicsUnit.Point);
        private string colorNormal = "#FF0000";
        private string colorNg = "#FF0000";
        private Rectangle rect = new Rectangle();
        private Graphics gph = Graphics.FromHwnd(IntPtr.Zero);

        public frm_Unit_ResultView2():base()
        {
            InitializeComponent();
            m_Unit = new CResultView2(CellCatagory.结果显示2, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        public frm_Unit_ResultView2(ref CMeasureCell MeasurCellBase):base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_ResultView2_Load(object sender, EventArgs e)
        {
            InitAttriList();
            InitCmbDataType();
            InitCmbCondition();
            check_Visible.Checked = ((CResultView2)m_Unit).bVisible;
            m_ResultViewList = new List<ResultView_Info>(((CResultView2)m_Unit).m_ViewList);
            dgv_ResultViewList.DataSource = new BindingList<ResultView_Info>(m_ResultViewList);
            string temp_color = colorNg.Substring(1, 2);
            int r = Convert.ToInt32(temp_color, 16);
            temp_color = colorNg.Substring(3, 2);
            int g = Convert.ToInt32(temp_color, 16);
            temp_color = colorNg.Substring(5, 2);
            int b = Convert.ToInt32(temp_color, 16);
            bt_Condition.BackColor = Color.FromArgb(r, g, b);
            //设置画布大小
            //rect = new Rectangle(frm_Main.thisHandle.hWindow_Fit.Location, frm_Main.thisHandle.hWindow_Fit.Size);
            rect.Width = frm_Main.thisHandle.hWindow_Fit.Width;
            rect.Height = frm_Main.thisHandle.hWindow_Fit.Height;
            //rect = Screen.GetWorkingArea(this); 
            frm_Main.thisHandle.hWindow_Fit.Image = new HImage("byte", rect.Width, rect.Height);
            frm_Main.thisHandle.hWindow_Fit.DispImageFit();
            //frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
            frm_Main.thisHandle.hWindow_Fit.ShieldMouseEvent();
            PaintMetrology();
        }

        private void cmb_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_DataType.Text == "无")
            {
                cmb_VariableName.DataSource = null;
                cmb_VariableName.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cmb_VariableName.DropDownStyle = ComboBoxStyle.DropDownList;
                List<F_DATA_CELL> dataList = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Type == (DataType)Enum.Parse(typeof(DataType), cmb_DataType.Text)
                    && c.m_Data_Group == DataGroup.单量);
                cmb_VariableName.DataSource = dataList;
                cmb_VariableName.DisplayMember = "m_Data_Name";
            }

        }

        private void bt_Font_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = NormalStyle;
            string temp_color = colorNormal.Substring(1, 2);
            int r = Convert.ToInt32(temp_color, 16);
            temp_color = colorNormal.Substring(3, 2);
            int g = Convert.ToInt32(temp_color, 16);
            temp_color = colorNormal.Substring(5, 2);
            int b = Convert.ToInt32(temp_color, 16);
            fd.Color = Color.FromArgb(r, g, b);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                NormalStyle = fd.Font;
                colorNormal = fd.Color.ToArgb().ToString("X02");
                colorNormal = colorNormal.Substring(2);
                colorNormal = colorNormal.Insert(0, "#");
            }
        }

        private void bt_Condition_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            //colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                Color color_from = colorDialog.Color;
                bt_Condition.BackColor = color_from;
                string m_DrawColor = color_from.ToArgb().ToString("X02");
                m_DrawColor = m_DrawColor.Substring(2);
                m_DrawColor = m_DrawColor.Insert(0, "#");
                m_ResultView_Info.m_NgColor = m_DrawColor;
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            m_ResultView_Info.m_DataType = cmb_DataType.Text;
            m_ResultView_Info.m_VariableName = cmb_VariableName.Text;
            m_ResultView_Info.m_ConditionVarName = cmb_Condition.Text;
            m_ResultView_Info.m_DisPosition = txt_Position.Text;
            m_ResultView_Info.m_NormalStyle = NormalStyle;
            m_ResultView_Info.m_NormalColor = colorNormal;
            m_ResultView_Info.m_NgColor = colorNg;
            m_ResultViewList.Add(m_ResultView_Info);
            dgv_ResultViewList.DataSource = new BindingList<ResultView_Info>(m_ResultViewList);
            PaintMetrology();
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_ResultViewList.SelectedRows.Count > 0)
            {
                int rowIndex = dgv_ResultViewList.SelectedCells[0].RowIndex;
                if (rowIndex >= 0)
                {
                    m_ResultView_Info.m_DataType = cmb_DataType.Text;
                    m_ResultView_Info.m_VariableName = cmb_VariableName.Text;
                    m_ResultView_Info.m_ConditionVarName = cmb_Condition.Text;
                    m_ResultView_Info.m_DisPosition = txt_Position.Text;
                    m_ResultView_Info.m_NormalStyle = NormalStyle;
                    m_ResultView_Info.m_NormalColor = colorNormal;
                    m_ResultView_Info.m_NgColor = colorNg;
                    m_ResultViewList[rowIndex] = m_ResultView_Info;
                    dgv_ResultViewList.DataSource = new BindingList<ResultView_Info>(m_ResultViewList);
                    PaintMetrology();
                }
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv_ResultViewList.SelectedCells[0].RowIndex;
            if (rowIndex >= 0)
            {
                m_ResultViewList.RemoveAt(rowIndex);
                dgv_ResultViewList.DataSource = new BindingList<ResultView_Info>(m_ResultViewList);
                PaintMetrology();
            }
        }

        private void bt_DeleteAll_Click(object sender, EventArgs e)
        {
            m_ResultViewList.Clear();
            dgv_ResultViewList.DataSource = new BindingList<ResultView_Info>(m_ResultViewList);
        }

        private void cmb_Condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Condition.Text == "无")
            {
                bt_Condition.Enabled = false;
            }
            else
            {
                bt_Condition.Enabled = true;
            }
        }


        private void InitAttriList()
        {
            List<string> listName = new List<string>();
            foreach (string s in Enum.GetNames(typeof(DataAtrribution)))
            {
                listName.Add(s);
            }
            cmb_Attribute.DataSource = listName;
        }

        private void InitCmbDataType()
        {
            List<string> listName = new List<string>();
            listName.Add("无");
            listName.Add("数值型");
            listName.Add("字符串");
            listName.Add("图像");

            cmb_DataType.DataSource = listName;
        }

        private void InitCmbCondition()
        {
            List<string> dataList = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                                                      && c.m_Data_Type == DataType.布尔型
                                                      && c.m_Data_Group == DataGroup.单量
                                                ).Select(c => c.m_Data_Name).ToList();

            dataList.Insert(0, "无");
            cmb_Condition.DataSource = dataList;
            cmb_Condition.DisplayMember = "m_Data_Name";
        }

        private void bt_SetDisPosition_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            bt_SetDisPosition.Enabled = false;
            double rowBegin, colBegin, rowEnd, colEnd;
            string[] oldPosition = txt_Position.Text.Trim().Split(',');
            frm_Main.thisHandle.hWindow_Fit.HWindowID.SetDraw("margin");
            //frm_Main.thisHandle.hWindow_Fit.HWindowID.SetColor("blue");
            frm_Main.thisHandle.hWindow_Fit.DrawRectangle1Mod("blue", double.Parse(oldPosition[0]),
                double.Parse(oldPosition[1]), double.Parse(oldPosition[2]), double.Parse(oldPosition[3]),
                out rowBegin, out colBegin, out rowEnd, out colEnd);
            txt_Position.Text = rowBegin.ToString("#0.000") + "," + colBegin.ToString("#0.000") + "," +
                rowEnd.ToString("#0.000") + "," + colEnd.ToString("#0.000");
            bt_SetDisPosition.Enabled = true;
            this.Visible = true;
        }

        private void dgv_ResultViewList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ResultView_Info result = m_ResultViewList[e.RowIndex];
                cmb_DataType.Text = result.m_DataType;
                cmb_VariableName.Text = result.m_VariableName;
                cmb_Condition.Text = result.m_ConditionVarName;
                txt_Position.Text = result.m_DisPosition;
                NormalStyle = result.m_NormalStyle;
                colorNg = result.m_NgColor;
                string strTmp = colorNg.Substring(1, 2);
                int r = Convert.ToInt32(strTmp, 16);
                strTmp = colorNg.Substring(3, 2);
                int g = Convert.ToInt32(strTmp, 16);
                strTmp = colorNg.Substring(5, 2);
                int b = Convert.ToInt32(strTmp, 16);
                bt_Condition.BackColor = Color.FromArgb(r, g, b);

            }
        }

        /// <summary>
        /// 绘画出模型
        /// </summary>
        public void PaintMetrology()
        {
            for (int i = 0; i < frm_Main.thisHandle.hWindow_Fit.Controls.Count - 3; i++)
            {
                frm_Main.thisHandle.hWindow_Fit.Controls.RemoveAt(0);
            }
            if (m_ResultViewList.Count > 0)
            {
                frm_Main frm_Main = frm_Main.thisHandle;
                //frm_Main.hWindow_Fit.HWindowID.ClearWindow();
                List<ResultView_Info> m_ImageList = m_ResultViewList.FindAll(c => c.m_DataType == DataType.图像.ToString());
                if (m_ImageList.Count > 0)
                {
                    //HImage backImg = new HImage("byte", rect.Width, rect.Height);
                    //if (backImg.IsInitialized())
                    //{
                    //    frm_Main.hWindow_Fit.Image = backImg;
                    //    frm_Main.hWindow_Fit.DispImageFit();
                    //}
                    foreach (ResultView_Info r in m_ImageList)
                    {
                        string[] sPosition = r.m_DisPosition.Split(',');
                        Point location = new Point((int)double.Parse(sPosition[1]), (int)double.Parse(sPosition[0]));
                        int _width = (int)double.Parse(sPosition[3]) - (int)double.Parse(sPosition[1]);
                        int _height = (int)double.Parse(sPosition[2]) - (int)double.Parse(sPosition[0]);

                        if (r.m_DataType == DataType.图像.ToString())
                        {
                            HImageExt tempImage = new HImageExt();
                            HMeasureSYS.Cur_Project.QueryImage(ImageCatagory.当前图像, r.m_VariableName, out tempImage);
                            if (tempImage.IsInitialized())
                            {
                                //tempImage = tempImage.ZoomImageSize(_width, _height, "constant");
                                HWindowControl h = new HWindowControl();
                                int width, height;
                                tempImage.GetImageSize(out width, out height);
                                h.Location = location;
                                h.Width = _width;
                                h.Height = _height;
                                frm_Main.hWindow_Fit.Controls.Add(h);
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
                                                h.HalconWindow.DispCircle(c.CenterY,c.CenterX,c.Radius);
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
                frm_Main.hWindow_Fit.HWindowID.SetLineWidth(1);
                foreach (ResultView_Info r in m_ResultViewList)
                {
                    frm_Main.hWindow_Fit.HWindowID.SetColor(r.m_NormalColor);
                    if (r.m_ConditionVarName != "无")
                    {
                        F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                            c.m_Data_Name == r.m_VariableName);
                        if (((List<Boolean>)data.m_Data_Value)[0] == false)
                        {
                            frm_Main.hWindow_Fit.HWindowID.SetColor(r.m_NgColor);
                        }
                    }
                    string dispMsg = string.Empty;
                    if (r.m_DataType == "无")
                    {
                        dispMsg = r.m_VariableName;
                    }
                    else if (r.m_DataType == DataType.数值型.ToString() || r.m_DataType == DataType.字符串.ToString())
                    {
                        F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
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
                    frm_Main.hWindow_Fit.HWindowID.SetColor("blue");
                    string[] sPosition = r.m_DisPosition.Split(',');
                    //
                    HRegion region = new HRegion();
                    region.GenRectangle1(double.Parse(sPosition[0]), double.Parse(sPosition[1]), double.Parse(sPosition[2]), double.Parse(sPosition[3]));
                    HXLDCont xld = region.GenContourRegionXld("border");
                    //按照像素画框
                    //HXLDCont xld = new HXLDCont();
                    //xld.GenRectangle2ContourXld(double.Parse(sPosition[0]) + rLength, double.Parse(sPosition[0]) + r.m_NormalStyle.Size / 2.0, 0, rLength, r.m_NormalStyle.Size / 2.0);
                    //xld.GenRectangle2ContourXld(double.Parse(sPosition[0]), double.Parse(sPosition[0]), 0, rLength, r.m_NormalStyle.Size / 2.0);
                    frm_Main.hWindow_Fit.HWindowID.DispXld(xld);
                    string h_font = "-" + r.m_NormalStyle.Name +
                        "-" + r.m_NormalStyle.Height.ToString() +
                        "-" + r.m_NormalStyle.Size.ToString() +
                        "-" + (r.m_NormalStyle.Italic ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Underline ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Strikeout ? 1 : 0).ToString() +
                        "-" + (r.m_NormalStyle.Bold ? 1 : 0).ToString() +
                        "-" + r.m_NormalStyle.GdiCharSet.ToString() + "-";
                    frm_Main.hWindow_Fit.HWindowID.SetFont(h_font);
                    frm_Main.hWindow_Fit.HWindowID.SetTposition((int)double.Parse(sPosition[0]), (int)double.Parse(sPosition[1]));

                    frm_Main.hWindow_Fit.HWindowID.WriteString(dispMsg);
                }
            }

        }

        private void frm_Unit_ResultView2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
            frm_Main.thisHandle.hWindow_Fit.ReloadMouseEvent();
            for (int i = 0; i < frm_Main.thisHandle.hWindow_Fit.Controls.Count - 3; i++)
            {
                frm_Main.thisHandle.hWindow_Fit.Controls.RemoveAt(0);
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (blnNewUnit)
            {
                ((CResultView2)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }
            ((CResultView2)m_Unit).bVisible = check_Visible.Checked;
            ((CResultView2)m_Unit).rect = rect;
            ((CResultView2)m_Unit).offsetRow = frm_Main.thisHandle.hWindow_Fit.offsetRow;
            ((CResultView2)m_Unit).offsetCol = frm_Main.thisHandle.hWindow_Fit.offsetCol;
            ((CResultView2)m_Unit).m_ViewList = m_ResultViewList;
            
            this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_ResultViewList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgv_ResultViewList_CellClick(sender, e);
            if (e.RowIndex >= 0)
            {
                ResultView_Info result = m_ResultViewList[e.RowIndex];
                if (result.m_DataType == DataType.图像.ToString())
                {
                    frm_DisObjList frmDisObjList = new frm_DisObjList(m_ResultViewList[e.RowIndex].m_dispObj);
                    frmDisObjList.ShowDialog(this);
                    frmDisObjList.Close();
                }
            }
        }

        public void UpdateDispObj(List<sDictionary> list)
        {
            if (dgv_ResultViewList.CurrentRow.Index > -1)
            {
                m_ResultViewList[dgv_ResultViewList.CurrentRow.Index].m_dispObj = list;

            }
        }
    }
}
