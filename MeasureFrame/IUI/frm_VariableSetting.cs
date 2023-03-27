using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using Measure.UserDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_VariableSetting : Form
    {
        int CurrentIndex = 0;
        public frm_VariableSetting()
        {
            InitializeComponent();
        }

        private void frm_VariableSettingcs_Load(object sender, EventArgs e)
        {
            InitCmbAttribute();
            InitCmbDatatype();
            updateVariableList();
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            string s_DataName = txt_Name.Text.Trim();
            //List<F_DATA_CELL> dataList = new List<F_DATA_CELL>();
            DataAtrribution atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
            if (s_DataName == string.Empty)
            {
                MessageBox.Show("变量名不允许为空");
                return;
            }
            if (IndexOfVariable(atrr, s_DataName) > -1)
            {
                MessageBox.Show("变量重定义");
                return;
            }


            F_DATA_CELL datacell = new F_DATA_CELL();
            datacell.m_Data_Atrr = atrr;
            if (check_Array.Checked)
            {
                datacell.m_Data_Group = Measure.DataGroup.数组;
            }
            else
                datacell.m_Data_Group = Measure.DataGroup.单量;

            datacell.m_bUserDefineVariable = true;
            //datacell.m_Data_InitValue = txt_InitValue.Text.Trim();
            datacell.m_Data_Num = 1;
            DataType type = (DataType)Enum.Parse(typeof(DataType), cmb_DataType.Text);
            datacell.InitValue(type, txt_InitValue.Text.Trim());
            //datacell.m_Data_Value = null;
            datacell.m_Data_Name = s_DataName;
            datacell.m_DataTip = txt_Tip.Text.Trim();
            switch (atrr)
            {
                case DataAtrribution.全局变量:
                    datacell.m_Data_CellID = HMeasureSYS.U000;
                    HMeasureSYS.Cur_Project.m_VariableList.Add(datacell);
                    break;
                case DataAtrribution.系统变量:
                    datacell.m_Data_CellID = HMeasureSYS.USys;
                    HMeasureSYS.g_VariableList.Add(datacell);
                    break;
            }
            CurrentIndex = dgv_VaviableList.RowCount;
            updateVariableList();
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_VaviableList.SelectedRows.Count > 0)
            {
                int index = -1;
                string s_NewDataName = txt_Name.Text.Trim();
                string s_DataName = dgv_VaviableList.SelectedRows[0].Cells["m_Data_Name"].Value.ToString().Trim();

                DataAtrribution atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
                index = IndexOfVariable(atrr, s_NewDataName);
                if (index > -1 && s_DataName!=s_NewDataName)
                {
                    MessageBox.Show("变量重定义");
                    return;
                }
                F_DATA_CELL datacell = getVariable(atrr, s_DataName);
                index = IndexOfVariable(atrr, s_DataName);

                datacell.m_Data_Atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
                if (check_Array.Checked)
                {
                    datacell.m_Data_Group = Measure.DataGroup.数组;
                }
                else
                    datacell.m_Data_Group = Measure.DataGroup.单量;

                datacell.m_Data_Name = txt_Name.Text.Trim();
                datacell.m_bUserDefineVariable = true;
                //datacell.m_Data_InitValue = txt_InitValue.Text.Trim();
                datacell.m_Data_Num = 1;
                DataType _Type = (DataType)Enum.Parse(typeof(DataType), cmb_DataType.Text);
                datacell.InitValue(_Type, txt_InitValue.Text.Trim());
                datacell.m_DataTip = txt_Tip.Text.Trim();
                switch (atrr)
                {
                    case DataAtrribution.全局变量:
                        datacell.m_Data_CellID = HMeasureSYS.U000;
                        HMeasureSYS.Cur_Project.m_VariableList[index] = datacell;
                        break;
                    case DataAtrribution.系统变量:
                        datacell.m_Data_CellID = HMeasureSYS.USys;
                        HMeasureSYS.g_VariableList[index] = datacell;
                        break;
                }
                CurrentIndex = dgv_VaviableList.CurrentRow.Index;
                updateVariableList();
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_VaviableList.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgv_VaviableList.SelectedRows[0];
                string s_DataName = r.Cells["m_Data_Name"].Value.ToString();
                DataAtrribution attr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
                int index = IndexOfVariable(attr, s_DataName);
                switch (attr)
                {
                    case DataAtrribution.全局变量:
                        HMeasureSYS.Cur_Project.m_VariableList.RemoveAt(index);
                        break;
                    case DataAtrribution.系统变量:
                        HMeasureSYS.g_VariableList.RemoveAt(index);
                        break;
                }
                CurrentIndex = dgv_VaviableList.CurrentRow.Index - 1;
                updateVariableList();
            }
        }

        private F_DATA_CELL getVariable(DataAtrribution atrr, string s_DataName)
        {
            //DataAtrribution atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
            F_DATA_CELL datacell = new F_DATA_CELL(); ;
            switch (atrr)
            {
                case DataAtrribution.全局变量:
                    datacell = HMeasureSYS.Cur_Project.m_VariableList.First(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == s_DataName);
                    break;
                case DataAtrribution.系统变量:
                    datacell = HMeasureSYS.g_VariableList.First(c => c.m_Data_Name == s_DataName);
                    break;
            }
            return datacell;
        }
        /// <summary>
        /// 获取当前变量
        /// </summary>
        /// <param name="sName">变量名称</param>
        /// <returns></returns>
        private int IndexOfVariable(DataAtrribution atrr, string sName)
        {
            //DataAtrribution atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
            int index = -1;
            switch (atrr)
            {
                case DataAtrribution.全局变量:
                    index = HMeasureSYS.Cur_Project.m_VariableList.FindIndex(c => c.m_Data_CellID == HMeasureSYS.U000 && c.m_Data_Name == sName);
                    break;
                case DataAtrribution.系统变量:
                    index = HMeasureSYS.g_VariableList.FindIndex(c => c.m_Data_Name == sName);
                    break;
            }
            return index;
        }

        private void bt_DeleteAll_Click(object sender, EventArgs e)
        {
            DataAtrribution attr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
            switch (attr)
            {
                case DataAtrribution.全局变量:
                    while (true)
                    {
                        int index = HMeasureSYS.Cur_Project.m_VariableList.FindIndex(c => c.m_Data_CellID == HMeasureSYS.U000);
                        if (index > -1)
                        {
                            HMeasureSYS.Cur_Project.m_VariableList.RemoveAt(index);
                        }
                        else
                            break;
                    }
                    break;
                case DataAtrribution.系统变量:
                    HMeasureSYS.g_VariableList.Clear();
                    break;
            }
            CurrentIndex = -1;
            updateVariableList();
        }

        private void InitCmbAttribute()
        {
            List<string> listName = new List<string>();
            foreach (string s in Enum.GetNames(typeof(DataAtrribution)))
            {
                listName.Add(s);
            }
            cmb_Attribute.DataSource = listName;
        }

        private void InitCmbDatatype()
        {
            List<string> listName = new List<string>();
            foreach (string s in Enum.GetNames(typeof(DataType)))
            {
                listName.Add(s);
            }
            cmb_DataType.DataSource = listName;
        }

        private void dgv_VaviableList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string s_DataName = dgv_VaviableList.SelectedRows[0].Cells["m_Data_Name"].Value.ToString();
                DataAtrribution attr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
                F_DATA_CELL datacell = getVariable(attr, s_DataName);
                txt_Name.Text = datacell.m_Data_Name;
                txt_InitValue.Text = datacell.m_Data_InitValue;
                cmb_Attribute.Text = datacell.m_Data_Atrr.ToString();
                txt_Tip.Text = datacell.m_DataTip;
                cmb_DataType.Text = datacell.m_Data_Type.ToString();
                if (datacell.m_Data_Group == DataGroup.单量)
                {
                    check_Array.Checked = false;
                }
                else
                {
                    check_Array.Checked = true;
                }
            }
        }

        private void cmb_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_DataType.Text == DataType.点2D.ToString() ||
                cmb_DataType.Text == DataType.点3D.ToString() ||
                cmb_DataType.Text == DataType.数值型.ToString())
            {
                check_Array.Enabled = true;
            }
            else
                check_Array.Enabled = false;
        }

        private void cmb_Attribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentIndex = -1;
            updateVariableList();
        }

        private void updateVariableList()
        {
            DataAtrribution atrr = (DataAtrribution)Enum.Parse(typeof(DataAtrribution), cmb_Attribute.Text);
            switch (atrr)
            {
                case DataAtrribution.全局变量:
                    if (HMeasureSYS.Cur_Project == null)
                        return;
                    dgv_VaviableList.DataSource = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == HMeasureSYS.U000).ToList();
                    break;
                case DataAtrribution.系统变量:
                    dgv_VaviableList.DataSource = HMeasureSYS.g_VariableList.ToList();//.FindAll(c => c.m_Data_Atrr == atrr).ToList();
                    break;
            }
            if (CurrentIndex>-1)
            {
                dgv_VaviableList.CurrentCell = dgv_VaviableList.Rows[CurrentIndex].Cells[0];
            }
        }
    }
}
