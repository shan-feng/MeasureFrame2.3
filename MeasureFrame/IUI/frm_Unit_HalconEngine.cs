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
    public partial class frm_Unit_HalconEngine : frm_Unit
    {
        private List<F_DATA_CELL> inDataList = new List<F_DATA_CELL>();
        private List<F_DATA_CELL> outDataList = new List<F_DATA_CELL>();
        public frm_Unit_HalconEngine()
            : base()
        {
            InitializeComponent();
            m_Unit = new CHalconEngine(CellCatagory.Halcon引擎, HMeasureSYS.Cur_Project.m_LastCellID);

        }
        public frm_Unit_HalconEngine(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void bt_Broswe_Click(object sender, EventArgs e)
        {
           OpenFileDialog fD = new OpenFileDialog();
            fD.Filter = "halcon执行文件|*.hdev";
            if (fD.ShowDialog() == DialogResult.OK)
            {
                txt_FilePath.Text = fD.FileName;
            }
        }

        private void cmb_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<F_DATA_CELL> datalist = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000
    && c.m_Data_Type == (DataType)Enum.Parse(typeof(DataType), cmb_DataType.Text));
            cmb_VariableName.DataSource = datalist;
            cmb_VariableName.DisplayMember = "m_Data_Name";
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (cmb_VariableName.SelectedIndex >= 0)
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Name == cmb_VariableName.Text);
                inDataList.Add(data);
                dgv_InList.DataSource = new BindingList<F_DATA_CELL>(inDataList);
            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_OutList.SelectedRows.Count > 0)
            {
                F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                    c.m_Data_Name == dgv_InList.SelectedRows[0].Cells[0].Value.ToString().Trim());

                inDataList[dgv_InList.SelectedRows[0].Cells[0].RowIndex] = datacell;
                dgv_InList.DataSource = new BindingList<F_DATA_CELL>(inDataList);
                dgv_InList.CurrentCell = dgv_InList.SelectedRows[0].Cells[0];
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_InList.SelectedRows.Count > 0)
            {
                inDataList.RemoveAt(dgv_InList.SelectedRows[0].Cells[0].RowIndex);
                dgv_InList.DataSource = new BindingList<F_DATA_CELL>(inDataList);
            }
        }

        private void bt_RemoveAll_Click(object sender, EventArgs e)
        {
            inDataList.Clear();
            dgv_InList.DataSource = new BindingList<F_DATA_CELL>(inDataList);
        }

        private void bt_add2_Click(object sender, EventArgs e)
        {
            if (cmb_VariableName.SelectedIndex >= 0)
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Name == cmb_VariableName.Text);
                outDataList.Add(data);
                dgv_OutList.DataSource = new BindingList<F_DATA_CELL>(outDataList);
            }
        }

        private void bt_Edit2_Click(object sender, EventArgs e)
        {
            if (dgv_OutList.SelectedRows.Count > 0)
            {
                F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                    c.m_Data_Name == dgv_OutList.SelectedRows[0].Cells[0].Value.ToString().Trim());

                outDataList[dgv_OutList.SelectedRows[0].Cells[0].RowIndex] = datacell;
                dgv_OutList.DataSource = new BindingList<F_DATA_CELL>(outDataList);
                dgv_OutList.CurrentCell = dgv_OutList.SelectedRows[0].Cells[0];
            }
        }

        private void bt_Delete2_Click(object sender, EventArgs e)
        {
            if (dgv_OutList.SelectedRows.Count > 0)
            {
                outDataList.RemoveAt(dgv_OutList.SelectedRows[0].Cells[0].RowIndex);
                dgv_OutList.DataSource = new BindingList<F_DATA_CELL>(outDataList);
            }
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            outDataList.Clear();
            dgv_OutList.DataSource = new BindingList<F_DATA_CELL>(outDataList);
        }

        private void frm_Unit_HalconEngine_Load(object sender, EventArgs e)
        {
            string m_FlowID = "U" + ((CHalconEngine)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CHalconEngine)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CHalconEngine)m_Unit).m_CellDesCribe;
            txt_FilePath.Text = ((CHalconEngine)m_Unit).filePhth;
            cmb_DataType.SelectedIndex = 0;
            InitInDgvList();
            InitOutDgvList();
        }

        private void InitInDgvList()
        {
            inDataList.Clear();
            foreach (string s in ((CHalconEngine)m_Unit).inParamList)
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Name == s);
                inDataList.Add(data);
            }
            dgv_InList.DataSource = new BindingList<F_DATA_CELL>(inDataList);
        }

        private void InitOutDgvList()
        {
            outDataList.Clear();
            foreach (string s in ((CHalconEngine)m_Unit).outParamList)
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Name == s);
                outDataList.Add(data);
            }
            dgv_OutList.DataSource = new BindingList<F_DATA_CELL>(outDataList);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            string fileName = txt_FilePath.Text.Trim();
            ((CHalconEngine)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text;
            ((CHalconEngine)m_Unit).filePhth = fileName;
            ((CHalconEngine)m_Unit).inParamList.Clear();
            foreach (F_DATA_CELL data in inDataList)
            {
                ((CHalconEngine)m_Unit).inParamList.Add(data.m_Data_Name);
            }

            ((CHalconEngine)m_Unit).outParamList.Clear();
            foreach (F_DATA_CELL data in outDataList)
            {
                ((CHalconEngine)m_Unit).outParamList.Add(data.m_Data_Name);
            }

            if (blnNewUnit)
            {
                ((CHalconEngine)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }
            ((frm_Main)Owner).UpdateFlowList();

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
