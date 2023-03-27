using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;
using CPublicDefine;
using Helper;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_CorrectPosition : frm_Unit_ImageBase
    {
        private ROI m_ModelRegion;
        private ROI m_SearchRegion;
        public frm_Unit_CorrectPosition() :
            base()
        {
            InitializeComponent();
            m_Unit = new CCorrect_Position(CellCatagory.位置补正, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_CorrectPosition(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_CorrectPosition_Load(object sender, EventArgs e)
        {
            try
            {
                InitCurrentCmbImgList();
                m_ModelRegion = ((CCorrect_Position)m_Unit).m_ModelRegion;
                m_SearchRegion = ((CCorrect_Position)m_Unit).m_SearchRegion;
                chk_disableAngle.Checked = ((CCorrect_Position)m_Unit).disableAngle;


                cmb_Shape1.SelectedIndex = 0;
                cmb_Shape2.SelectedIndex = 0;
                if (!blnNewUnit)
                {
                    nud_StartPhi.Value = (decimal)((CCorrect_Position)m_Unit).dStartPhi;
                    nud_EndPhi.Value = (decimal)((CCorrect_Position)m_Unit).dEndPhi;
                    //初始化下拉列表
                    cmb_ModelType.Text = ((CCorrect_Position)m_Unit).m_ModelType.ToString();
                    cmb_CurrentImg.Text = ((CCorrect_Position)m_Unit).m_CurrentImgName;
                    nud_StartPhi.Value = (decimal)((CCorrect_Position)m_Unit).dStartPhi;
                    nud_EndPhi.Value = (decimal)((CCorrect_Position)m_Unit).dEndPhi;
                    if (m_ModelRegion != null)
                    {
                        bt_Color1.BackColor = ColorTranslator.FromHtml(m_ModelRegion.sColor);
                    }
                    if (m_SearchRegion != null)
                    {
                        bt_Color2.BackColor = ColorTranslator.FromHtml(m_SearchRegion.sColor);
                    }
                    //检测范围
                    MeasureROI roi检测范围 = new MeasureROI(m_Unit.m_CellID.ToString(), m_Unit.m_CellCatagory.ToString(), m_Unit.m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(m_ModelRegion.genXLD()));
                    m_Unit.m_Image.UpdateRoiList(roi检测范围);
                    //搜索范围
                    MeasureROI roi搜索范围 = new MeasureROI(m_Unit.m_CellID.ToString(), m_Unit.m_CellCatagory.ToString(), m_Unit.m_CellDesCribe, enMeasureROIType.搜索范围.ToString(), "red", new HObject(m_SearchRegion.genXLD()));
                    m_Unit.m_Image.UpdateRoiList(roi搜索范围);

                    PaintMetrology();
                }
                else
                {
                    cmb_ModelType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

            }

            frm_Main.thisHandle.hWindow_Fit.RePaint += new HalconControl.DelegateRePaint(PaintMetrology);
        }

        private void bt_Color1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                bt_Color1.BackColor = colorDialog.Color;
            }
        }

        private void bt_Color2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                bt_Color2.BackColor = colorDialog.Color;

            }
        }

        private void bt_Draw1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            string color = ColorHelper.ToHexColor(bt_Color1.BackColor);
            if (cmb_Shape1.SelectedIndex == 0)
            {
                double _rowBegin, _colBegin, _rowEnd, _colEnd;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle1(color, out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                m_ModelRegion = new Rectangle_INFO(_rowBegin, _colBegin, _rowEnd, _colEnd);
            }
            else if (cmb_Shape1.SelectedIndex == 1)
            {
                double _row, _column, _phi, _length1, _length2;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle2(color, out _row, out _column, out _phi, out _length1, out _length2);
                m_ModelRegion = new Rectangle2_INFO(_row, _column, _phi, _length1, _length2);
            }
            else if (cmb_Shape1.SelectedIndex == 2)
            {
                double _row, _column, _radius;
                frm_Main.thisHandle.hWindow_Fit.DrawCircle(color, out _row, out _column, out _radius);
                m_ModelRegion = new Circle_INFO(_row, _column, _radius);
            }
            else if (cmb_Shape1.SelectedIndex == 3)
            {
                double _row, _column, _phi, _radius1, _radius2;
                frm_Main.thisHandle.hWindow_Fit.DrawEllipse(color, out _row, out _column, out _phi, out _radius1, out _radius2);
                m_ModelRegion = new Ellipse_INFO(_row, _column, _phi, _radius1, _radius2);
            }
            else if (cmb_Shape1.SelectedIndex == 4)
            {
                this.Visible = false;
                HRegion hregion;
                if (m_ModelRegion != null)//需要判断是否为null 20171102
                {
                    hregion = frm_Main.thisHandle.hWindow_Fit.SetROI(m_ModelRegion.genRegion());
                }
                else
                {
                    hregion = frm_Main.thisHandle.hWindow_Fit.SetROI(new HRegion());
                }

                m_ModelRegion = new UserDefinedShape_INFO(hregion);
                this.Visible = true;
            }

            m_ModelRegion.sColor = color;
            //检测范围
            MeasureROI roi检测范围 = new MeasureROI(m_Unit.m_CellID.ToString(), m_Unit.m_CellCatagory.ToString(), m_Unit.m_CellDesCribe, enMeasureROIType.检测范围.ToString(), "green", new HObject(m_ModelRegion.genXLD()));
            m_Unit.m_Image.UpdateRoiList(roi检测范围);
            PaintMetrology();
            this.Visible = true;
        }

        private void bt_Draw2_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            string color = ColorHelper.ToHexColor(bt_Color2.BackColor);
            if (cmb_Shape2.SelectedIndex == 0)
            {
                double _rowBegin, _colBegin, _rowEnd, _colEnd;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle1(color, out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                m_SearchRegion = new Rectangle_INFO(_rowBegin, _colBegin, _rowEnd, _colEnd);
            }
            else if (cmb_Shape2.SelectedIndex == 1)
            {
                double _row, _column, _phi, _length1, _length2;
                frm_Main.thisHandle.hWindow_Fit.DrawRectangle2(color, out _row, out _column, out _phi, out _length1, out _length2);
                m_SearchRegion = new Rectangle2_INFO(_row, _column, _phi, _length1, _length2);
            }
            else if (cmb_Shape2.SelectedIndex == 2)
            {
                double _row, _column, _radius;
                frm_Main.thisHandle.hWindow_Fit.DrawCircle(color, out _row, out _column, out _radius);
                m_SearchRegion = new Circle_INFO(_row, _column, _radius);
            }
            else if (cmb_Shape2.SelectedIndex == 3)
            {
                double _row, _column, _phi, _radius1, _radius2;
                frm_Main.thisHandle.hWindow_Fit.DrawEllipse(color, out _row, out _column, out _phi, out _radius1, out _radius2);
                m_SearchRegion = new Ellipse_INFO(_row, _column, _phi, _radius1, _radius2);
            }

            m_SearchRegion.sColor = color;
            //搜索范围
            MeasureROI roi搜索范围 = new MeasureROI(m_Unit.m_CellID.ToString(), m_Unit.m_CellCatagory.ToString(), m_Unit.m_CellDesCribe, enMeasureROIType.搜索范围.ToString(), "red", new HObject(m_SearchRegion.genXLD()));
            m_Unit.m_Image.UpdateRoiList(roi搜索范围);
            PaintMetrology();

            this.Visible = true;
        }


        private void bt_Save_Click(object sender, EventArgs e)
        {

            bt_Save.Enabled = false;
            if (m_ModelRegion == null || m_SearchRegion == null)
            {
                MessageBox.Show("请设置模板区域和搜索区域");
                bt_Save.Enabled = true;
                return;
            }
            if (((CCorrect_Position)m_Unit).m_ModelType == ModelType.形状模板)
                ((CCorrect_Position)m_Unit).m_Model = new HShapeModel();
            else
                ((CCorrect_Position)m_Unit).m_Model = new HNCCModel();
            ((CCorrect_Position)m_Unit).m_ModelRegion = m_ModelRegion;
            ((CCorrect_Position)m_Unit).m_ModelType = (ModelType)Enum.Parse(typeof(ModelType), cmb_ModelType.Text);
            ((CCorrect_Position)m_Unit).m_SearchRegion = m_SearchRegion;

            ((CCorrect_Position)m_Unit).dStartPhi = (double)nud_StartPhi.Value;
            ((CCorrect_Position)m_Unit).dEndPhi = (double)nud_EndPhi.Value;
            ((CCorrect_Position)m_Unit).m_CurrentImgName = cmb_CurrentImg.Text;
            m_Unit.Execute();
            PaintMetrology();
            bt_Save.Enabled = true;

        }

        private void frm_Unit_CorrectPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Main.thisHandle.hWindow_Fit.RePaint -= new HalconControl.DelegateRePaint(PaintMetrology);
        }

        private void chk_disableAngle_CheckedChanged(object sender, EventArgs e)
        {
            ((CCorrect_Position)m_Unit).disableAngle = chk_disableAngle.Checked;
        }

        /// <summary>
        /// 涂抹模板区域 magical 20171028
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Paint_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HRegion hregion = frm_Main.thisHandle.hWindow_Fit.SetROI(m_ModelRegion.genRegion());
            m_ModelRegion = new UserDefinedShape_INFO(hregion);
            this.Visible = true;
        }

        private void cmb_CurrentImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Unit.m_Owner.QueryImage(ImageCatagory.当前图像, cmb_CurrentImg.Text, out m_Unit.m_Image);
            PaintMetrology();
        }
    }
}
