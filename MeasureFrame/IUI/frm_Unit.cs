using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit : Form
    {
        protected bool blnNewUnit = true;
        protected CMeasureCell m_Unit;
        public frm_Unit()
        {
            InitializeComponent();
            blnNewUnit = true;
        }
        public frm_Unit(ref CMeasureCell MeasurCellBase)
        {
            InitializeComponent();
            m_Unit = MeasurCellBase;
            blnNewUnit = false;
            chk_Shield.Checked = m_Unit.blnShield;
            txt_UnitDescrible.Text = m_Unit.m_CellDesCribe;
            string m_FlowID = "U" + m_Unit.m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + m_Unit.m_CellCatagory.ToString();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            blnNewUnit = false;
            m_Unit.blnShield = chk_Shield.Checked;
            m_Unit.m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            frm_Main.thisHandle.UpdateFlowList();

        }


        /// <summary>
        /// 绘画出模型
        /// </summary>
        protected void PaintMetrology()
        {
            frm_Main.thisHandle.UpdateWindow(m_Unit);
        }

    }
}
