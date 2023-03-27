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
using System.Linq;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_MeasureLine : frm_Unit_Measure
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_MeasureLine()
            : base()
        {
            InitializeComponent();
            m_Unit = new CMeasure_Line(CellCatagory.直线单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_MeasureLine(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }


        private void frm_Unit_MeasureLine_Load(object sender, EventArgs e)
        {
            if (!blnNewUnit)
            {
                nudStartX.Value = (decimal)((CMeasure_Line)m_Unit).m_InLine.StartX;
                nud_StartY.Value = (decimal)((CMeasure_Line)m_Unit).m_InLine.StartY;
                nud_EndX.Value = (decimal)((CMeasure_Line)m_Unit).m_InLine.EndX;
                nud_EndY.Value = (decimal)((CMeasure_Line)m_Unit).m_InLine.EndY;
            }
            base.frm_OnLoad();

            this.nudStartX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_StartY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_EndX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_EndY.ValueChanged += new System.EventHandler(this.UpdateParam);

            UpdateParam(sender, e);
        }

        protected void bt_draw_Click(object sender, EventArgs e)
        {
            this.nudStartX.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nud_StartY.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nud_EndX.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nud_EndY.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.Visible = false;
            Line_INFO m_DrawLine = new Line_INFO();
            frm_Main.thisHandle.hWindow_Fit.DrawLine(((CMeasure_Line)m_Unit).m_drawColor, out m_DrawLine.StartY, out m_DrawLine.StartX, out m_DrawLine.EndY, out m_DrawLine.EndX);
            //像素坐标转世界坐标
            m_DrawLine=HMeasureSet.Line2WorldPlane(m_Unit.m_Image, m_DrawLine);
            ////世界坐标转当前相对坐标
            HHomMat2D hom = VBA_Function.setOrig(Coord.X, Coord.Y, -Coord.Phi);
            m_DrawLine.StartX = hom.AffineTransPoint2d(m_DrawLine.StartX, m_DrawLine.StartY, out m_DrawLine.StartY);
            m_DrawLine.EndX = hom.AffineTransPoint2d(m_DrawLine.EndX, m_DrawLine.EndY, out m_DrawLine.EndY);
            nudStartX.Value = (decimal)m_DrawLine.StartX;
            nud_StartY.Value = (decimal)m_DrawLine.StartY;
            nud_EndX.Value = (decimal)m_DrawLine.EndX;
            nud_EndY.Value = (decimal)m_DrawLine.EndY;
            ((CMeasure_Line)m_Unit).m_InLine = m_DrawLine;

            m_Unit.Execute();//再检测
            PaintMetrology();
            this.Visible = true;

            this.nudStartX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_StartY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_EndX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_EndY.ValueChanged += new System.EventHandler(this.UpdateParam);
        }
        
        protected override void UpdateParam(object sender, EventArgs e)
        {
            Line_INFO line = new Line_INFO((double)nud_StartY.Value, (double)nudStartX.Value, (double)nud_EndY.Value, (double)nud_EndX.Value);
            ((CMeasure_Line)m_Unit).m_InLine = line;
            base.UpdateParam(sender, e);
        }
    }
}
