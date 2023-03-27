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
    public partial class frm_Unit_MeasureEllipse : frm_Unit_Measure
    {
        /// <summary>
        /// 构造函数，新添加检测单元
        /// </summary>
        public frm_Unit_MeasureEllipse()
            : base()
        {
            InitializeComponent();
            m_Unit = new CMeasure_Ellipse(CellCatagory.椭圆单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_MeasureEllipse(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_MeasureEllipse_Load(object sender, EventArgs e)
        {
            if (!blnNewUnit)
            {
                nudCenterX.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.CenterX;
                nudCenterY.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.CenterY;
                nudRadius1.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Radius1;
                nudRadius2.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Radius2;
                nud_Phi.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Phi;
            }
            base.frm_OnLoad();

            this.nudCenterX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadius1.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadius2.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_Phi.ValueChanged += new System.EventHandler(this.UpdateParam);

            UpdateParam(sender, e);
        }

        protected void bt_draw_Click(object sender, EventArgs e)
        {
            this.nudCenterX.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nudRadius1.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nudRadius2.ValueChanged -= new System.EventHandler(this.UpdateParam);
            this.nud_Phi.ValueChanged -= new System.EventHandler(this.UpdateParam);

            this.Visible = false;
            Ellipse_INFO m_DrawEllipse = new Ellipse_INFO();
            frm_Main.thisHandle.hWindow_Fit.DrawEllipse(((CMeasure_Ellipse)m_Unit).m_drawColor, out m_DrawEllipse.CenterY, out m_DrawEllipse.CenterX, out m_DrawEllipse.Phi, out m_DrawEllipse.Radius1, out m_DrawEllipse.Radius2);
            //像素坐标转世界坐标
            m_DrawEllipse = HMeasureSet.Ellipse2WorldPlane(m_Unit.m_Image, m_DrawEllipse);
            ////世界坐标转当前相对坐标
            HHomMat2D hom = VBA_Function.setOrig(Coord.X, Coord.Y, -Coord.Phi);
            m_DrawEllipse.CenterX = hom.AffineTransPoint2d(m_DrawEllipse.CenterX, m_DrawEllipse.CenterY, out m_DrawEllipse.CenterY);
            ((CMeasure_Ellipse)m_Unit).m_InEllipse = m_DrawEllipse;
            nudCenterX.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.CenterX;
            nudCenterY.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.CenterY;
            nudRadius1.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Radius1;
            nudRadius2.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Radius2;
            nud_Phi.Value = (decimal)((CMeasure_Ellipse)m_Unit).m_InEllipse.Phi;

            m_Unit.Execute();//再检测
            PaintMetrology();
            this.Visible = true;

            this.nudCenterX.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudCenterY.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadius1.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nudRadius2.ValueChanged += new System.EventHandler(this.UpdateParam);
            this.nud_Phi.ValueChanged += new System.EventHandler(this.UpdateParam);
        }

        protected override void UpdateParam(object sender, EventArgs e)
        {
            Ellipse_INFO ellipse = new Ellipse_INFO((double)nudCenterY.Value, (double)nudCenterX.Value, (double)nud_Phi.Value, (double)nudRadius1.Value, (double)nudRadius2.Value);
            ((CMeasure_Ellipse)m_Unit).m_InEllipse = ellipse;
            base.UpdateParam(sender, e);
        }
    }
}
