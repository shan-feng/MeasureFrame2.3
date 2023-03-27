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
    public partial class frm_Unit_MeasureCircle : frm_Unit_Measure
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_MeasureCircle() : base()
        {
            InitializeComponent();
            m_Unit = new CMeasure_Circle(CellCatagory.圆单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_MeasureCircle(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_MeasureCircle_Load(object sender, EventArgs e)
        {
            if (!blnNewUnit)
            {
                nudCenterX.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.CenterX;
                nudCenterY.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.CenterY;
                nudRadus.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.Radius;
            }
            base.frm_OnLoad();
            this.nudCenterX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadus.ValueChanged += new System.EventHandler(this.UpdateParam);
            UpdateParam(sender, e);
        }

        protected void bt_draw_Click(object sender, EventArgs e)
        {
            this.nudCenterX.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nudRadus.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.Visible = false;
            Circle_INFO m_DrawCircle = new Circle_INFO();
            frm_Main.thisHandle.hWindow_Fit.DrawCircle(((CMeasure_Circle)m_Unit).m_drawColor, out m_DrawCircle.CenterY, out m_DrawCircle.CenterX, out m_DrawCircle.Radius);
            //像素坐标转世界坐标
            m_DrawCircle = HMeasureSet.Circle2WorldPlane(m_Unit.m_Image, m_DrawCircle);
            ////世界坐标转当前相对坐标
            HHomMat2D hom = VBA_Function.setOrig(Coord.X, Coord.Y, -Coord.Phi);
            m_DrawCircle.CenterX = hom.AffineTransPoint2d(m_DrawCircle.CenterX, m_DrawCircle.CenterY, out m_DrawCircle.CenterY);
            ((CMeasure_Circle)m_Unit).m_InCircle = m_DrawCircle;
            nudCenterX.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.CenterX;
            nudCenterY.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.CenterY;
            nudRadus.Value = (decimal)((CMeasure_Circle)m_Unit).m_InCircle.Radius;

            m_Unit.Execute();//再检测
            PaintMetrology();
            this.Visible = true;

            this.nudCenterX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadus.ValueChanged += new System.EventHandler(this.UpdateParam);
        }
        
        protected override void UpdateParam(object sender, EventArgs e)
        {
            Circle_INFO circle = new Circle_INFO((double)nudCenterY.Value, (double)nudCenterX.Value, (double)nudRadus.Value);
            ((CMeasure_Circle)m_Unit).m_InCircle = circle;
            base.UpdateParam(sender, e);
        }
    }
}
