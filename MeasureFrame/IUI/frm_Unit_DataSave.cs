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
using Helper;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_DataSave : MeasureFrame.IUI.frm_Unit
    {

        private List<F_DATA_CELL> m_DataList = new List<F_DATA_CELL>();
        private ToolStripMenu<F_DATA_CELL> menu = new ToolStripMenu<F_DATA_CELL>();
        public frm_Unit_DataSave()
            : base()
        {
            InitializeComponent();
            m_Unit = new CDataSave(CellCatagory.数据存储, HMeasureSYS.Cur_Project.m_LastCellID);

        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_DataSave(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_DataSave_Load(object sender, EventArgs e)
        {
            chb_he.Checked = ((CDataSave)m_Unit).saveHeFlag;//复显checkbox magical 20170822
            string m_FlowID = "U" + ((CDataSave)m_Unit).m_CellID.ToString("D4");
            this.Text = m_FlowID + " : " + ((CDataSave)m_Unit).m_CellCatagory.ToString();
            txt_UnitDescrible.Text = ((CDataSave)m_Unit).m_CellDesCribe;
            txt_FilePath.Text = ((CDataSave)m_Unit).m_filePath;
            dgv_VariableList.AutoGenerateColumns = false;
            InitCmbDataType();
            InitDgvList();
            InitAttriList();
        }

        private void InitCmbDataType()
        {
            List<string> listName = new List<string>();
            listName.Add("数值型");
            listName.Add("字符串");
            listName.Add("点2D");
            listName.Add("点3D");
            listName.Add("图像");
            cmb_DataType.DataSource = listName;
        }

        private void InitDgvList()
        {
            m_DataList.Clear();
            foreach (string s in ((CDataSave)m_Unit).m_VariableList)
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000
                    && c.m_Data_Name == s);
                m_DataList.Add(data);
            }

            menu.SetMenuStripVisible(true, true, false, false, false, false, false, false);
            menu.DataGrid = dgv_VariableList;
            menu.lstDataSource = m_DataList;
            //dgv_VariableList.DataSource = new BindingList<F_DATA_CELL>(m_DataList);
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
                m_DataList.Add(data);
                dgv_VariableList.DataSource = new BindingList<F_DATA_CELL>(m_DataList);
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_VariableList.SelectedRows.Count > 0)
            {
                m_DataList.RemoveAt(dgv_VariableList.SelectedRows[0].Cells[0].RowIndex);
                dgv_VariableList.DataSource = new BindingList<F_DATA_CELL>(m_DataList);
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            string fileName = txt_FilePath.Text.Trim();
            //try
            //{
            //    if (!File.Exists(fileName))
            //    {
            //        FileInfo fi = new FileInfo(fileName);
            //    }
            //}
            //catch
            //{
            //    // 非法
            //    MessageBox.Show("文件保存路劲非法");
            //    return;
            //}
            ((CDataSave)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text;
            ((CDataSave)m_Unit).m_filePath = fileName;
            ((CDataSave)m_Unit).m_VariableList.Clear();
            foreach (F_DATA_CELL data in m_DataList)
            {
                ((CDataSave)m_Unit).m_VariableList.Add(data.m_Data_Name);
            }
            if (blnNewUnit)
            {
                ((CDataSave)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }
            

            this.Close();
        }

        private void bt_Broswe_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fD = new FolderBrowserDialog();
            if (fD.ShowDialog() == DialogResult.OK)
            {
                txt_FilePath.Text = fD.SelectedPath;
            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_VariableList.SelectedRows.Count > 0)
            {
                F_DATA_CELL datacell = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == HMeasureSYS.U000 &&
                    c.m_Data_Name == dgv_VariableList.SelectedRows[0].Cells[0].Value.ToString().Trim());

                m_DataList[dgv_VariableList.SelectedRows[0].Cells[0].RowIndex] = datacell;
                dgv_VariableList.DataSource = new BindingList<F_DATA_CELL>(m_DataList);
                dgv_VariableList.CurrentCell = dgv_VariableList.SelectedRows[0].Cells[0];
            }
        }

        private void bt_RemoveAll_Click(object sender, EventArgs e)
        {
            m_DataList.Clear();
            dgv_VariableList.DataSource = new BindingList<F_DATA_CELL>(m_DataList);
        }

        private void dgv_VariableList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmb_DataType.Text = m_DataList[e.RowIndex].m_Data_Type.ToString();
                cmb_VariableName.Text = m_DataList[e.RowIndex].m_Data_Name.ToString();
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 图像变量保存格式 未选中保存为png格式,选中保存为he格式 magical 20170822
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_he_CheckedChanged(object sender, EventArgs e)
        {
            ((CDataSave)m_Unit).saveHeFlag = chb_he.Checked;
        }
    }
}
