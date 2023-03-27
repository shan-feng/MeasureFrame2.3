using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using ScintillaNET;
using System.Linq;
using System.IO;
using System.Reflection;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_Delay : MeasureFrame.IUI.frm_Unit
    {
        
        public frm_Unit_Delay()
            : base()
        { 
            InitializeComponent();
            m_Unit = new CDelay(CellCatagory.延时单元, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_Delay(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_Calculate_Load(object sender, EventArgs e)
        {
            
            string m_FlowID = "U" + ((CDelay)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CDelay)m_Unit).m_CellCatagory.ToString();

            this.nupDelayTimeMs.Value = ((CDelay)m_Unit).DelayTime;
  
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            ((CDelay)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text;

            ((CDelay)m_Unit).DelayTime =(int) this.nupDelayTimeMs.Value;
            if (blnNewUnit)
            {
                blnNewUnit = false;
                ((CDelay)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
            }
        }
    }
}
