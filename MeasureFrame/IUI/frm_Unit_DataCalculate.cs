using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Measure;
using System.IO;
using Measure.UserDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_DataCalculate : MeasureFrame.IUI.frm_Unit
    {
        public frm_Unit_DataCalculate()
            : base()
        {
            InitializeComponent();
            m_Unit = new CDataCalculate(CellCatagory.数值补偿和判定, HMeasureSYS.Cur_Project.m_LastCellID);

        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_DataCalculate(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_DataSave_Load(object sender, EventArgs e)
        {
            string m_FlowID = "U" + ((CDataCalculate)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CDataCalculate)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CDataCalculate)m_Unit).m_CellDesCribe;
            initCmbVariableName();
            InitDgvList();
        }


        private void InitDgvList()
        {
            dgv_VariableList.DataSource = new BindingList<FAI_Info>(((CDataCalculate)m_Unit).lstFAI);
        }


        private void initCmbVariableName()
        {
            List<string> datalist = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                && c.m_Data_Type == DataType.数值型 && c.m_Data_Group == DataGroup.单量).Select(c => c.m_Data_Name).ToList(); ;
            datalist.Insert(0, "无");
            cmb_VariableName.DataSource = datalist;
            cmb_VariableName.DisplayMember = "m_Data_Name";
        }
        private void initCmbResult()
        {
            List<F_DATA_CELL> datalist = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
                && c.m_Data_Type == DataType.布尔型 && c.m_Data_Group == DataGroup.单量);
            cmb_Result.DataSource = datalist;
            cmb_Result.DisplayMember = "m_Data_Name";
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (cmb_VariableName.SelectedIndex >= 0)
            {
                FAI_Info fai = new FAI_Info();
                fai.sVariableName = cmb_VariableName.Text;
                fai.sResultVariableName = cmb_Result.Text;
                fai.dK = double.Parse(txt_K.Text.Trim());
                fai.dB = double.Parse(txt_B.Text.Trim());
                fai.dLimitUp = double.Parse(txt_LimitUp.Text.Trim());
                fai.dLimitDown = double.Parse(txt_LimitDown.Text.Trim());
                ((CDataCalculate)m_Unit).lstFAI.Add(fai);
                dgv_VariableList.DataSource = new BindingList<FAI_Info>(((CDataCalculate)m_Unit).lstFAI);
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_VariableList.SelectedRows.Count > 0)
            {
                ((CDataCalculate)m_Unit).lstFAI.RemoveAt(dgv_VariableList.SelectedRows[0].Cells[0].RowIndex);
                dgv_VariableList.DataSource = new BindingList<FAI_Info>(((CDataCalculate)m_Unit).lstFAI);
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {

            ((CDataCalculate)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text;
            if (blnNewUnit)
            {
                ((CDataCalculate)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                F_DATA_CELL data = new F_DATA_CELL(((CDataCalculate)m_Unit).m_CellID, DataGroup.单量, DataType.字符串, ConstVavriable.outResult
                                                , "判定结果", "NG", 1
                                                , new List<string>() { ((CDataCalculate)m_Unit).sResult }, DataAtrribution.全局变量);
                ((CDataCalculate)m_Unit).m_Owner.m_VariableList.Add(data);

                blnNewUnit = false;
            }
            else
            {
                ((CDataCalculate)m_Unit).m_Owner.UpdateVariableValue(((CDataCalculate)m_Unit).m_CellID, ConstVavriable.outResult, new List<string>() { ((CDataCalculate)m_Unit).sResult });
            }
            
        }


        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_VariableList.SelectedRows.Count > 0)
            {
                FAI_Info fai = new FAI_Info();

                cmb_VariableName.Text = fai.sVariableName;
                cmb_Result.Text = fai.sResultVariableName;
                fai.dK = double.Parse(txt_K.Text.Trim());
                fai.dB = double.Parse(txt_B.Text.Trim());
                fai.dLimitUp = double.Parse(txt_LimitUp.Text.Trim());
                fai.dLimitDown = double.Parse(txt_LimitDown.Text.Trim());
                ((CDataCalculate)m_Unit).lstFAI[dgv_VariableList.SelectedRows[0].Cells[0].RowIndex] = fai;
                dgv_VariableList.DataSource = new BindingList<FAI_Info>(((CDataCalculate)m_Unit).lstFAI);
                dgv_VariableList.CurrentCell = dgv_VariableList.SelectedRows[0].Cells[0];
            }
        }

        private void bt_RemoveAll_Click(object sender, EventArgs e)
        {
            ((CDataCalculate)m_Unit).lstFAI.Clear();
            dgv_VariableList.DataSource = new BindingList<FAI_Info>(((CDataCalculate)m_Unit).lstFAI);
        }

        private void dgv_VariableList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FAI_Info fai = ((CDataCalculate)m_Unit).lstFAI[e.RowIndex];
                cmb_VariableName.Text = fai.sVariableName;
                txt_K.Text = fai.dK.ToString();
                txt_B.Text = fai.dB.ToString();
                txt_LimitUp.Text = fai.dLimitUp.ToString();
                txt_LimitDown.Text = fai.dLimitDown.ToString();
            }
        }

    }
}
