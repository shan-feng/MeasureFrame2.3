using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using System.Linq;
using Helper;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_TcpSend : MeasureFrame.IUI.frm_Unit
    {

        private List<Communication_Info> m_CommInfoList = new List<Communication_Info>();
        private ToolStripMenu<Communication_Info> menu=new ToolStripMenu<Communication_Info>();
        public frm_Unit_TcpSend()
            : base()
        {
            InitializeComponent();
            m_Unit = new CTCP_Send(CellCatagory.TCP_IP通讯, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_TcpSend(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_TcpCommunication_Load(object sender, EventArgs e)
        {
            InitUnitList();
            InitcmbDataType();
            InitcmbSpilt();
            InitcmbEnd();
            m_CommInfoList = ((CTCP_Send)m_Unit).m_CommunicationInfo_List;

            menu.SetMenuStripVisible(true, true, false, false, false, false, false, false);
            menu.DataGrid = dgv_ResultViewList;
            menu.lstDataSource = m_CommInfoList;

            //dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (cmb_dataName.Text == "")
            {
                MessageBox.Show("不允许为空");
                return;
            }
            Communication_Info commInfo = new Communication_Info();
            commInfo.m_DataType = cmb_dataType.Text;
            commInfo.m_VariableName = cmb_dataName.Text;
            commInfo.m_UnitID = cmb_UnitList.Text;
            commInfo.m_SpiltStr = cmb_SpiltStr.Text;
            commInfo.m_EndStr = cmb_EndStr.Text;
            m_CommInfoList.Add(commInfo);
            dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (cmb_dataName.Text == "")
            {
                MessageBox.Show("不允许为空");
                return;
            }
            if (dgv_ResultViewList.SelectedRows.Count > 0)
            {
                int rowIndex = dgv_ResultViewList.SelectedCells[0].RowIndex;
                if (rowIndex >= 0)
                {
                    Communication_Info commInfo = new Communication_Info();
                    commInfo.m_DataType = cmb_dataType.Text;
                    commInfo.m_VariableName = cmb_dataName.Text;
                    commInfo.m_UnitID = cmb_UnitList.Text;
                    commInfo.m_SpiltStr = cmb_SpiltStr.Text;
                    commInfo.m_EndStr = cmb_EndStr.Text;
                    m_CommInfoList[rowIndex] = commInfo;
                    dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
                }
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv_ResultViewList.SelectedCells[0].RowIndex;
            if (rowIndex >= 0)
            {
                m_CommInfoList.RemoveAt(rowIndex);
                dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
            }
        }

        private void bt_DeleteAll_Click(object sender, EventArgs e)
        {
            m_CommInfoList.Clear();
            dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
        }

        private void dgv_Celllick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Communication_Info commInfo = m_CommInfoList[e.RowIndex];
                cmb_dataType.Text = commInfo.m_DataType;
                cmb_UnitList.Text = commInfo.m_UnitID;
                cmb_dataName.Text = commInfo.m_VariableName;
                cmb_SpiltStr.Text = commInfo.m_SpiltStr;
                cmb_EndStr.Text = commInfo.m_EndStr;

            }
        }

        private void InitcmbDataType()
        {
            List<string> listName = new List<string>();
            listName.Add("数值型");
            listName.Add("字符串");
            listName.Add("点2D");
            listName.Add("点3D");
            listName.Add("坐标系");

            cmb_dataType.DataSource = listName;
        }

        private void InitUnitList()
        {
            List<string> UnitNameList = HMeasureSYS.Cur_Project.m_CellList.Select(c => "U" + c.m_CellID.ToString("D4")).ToList();
            UnitNameList.Insert(0, "U0000");
            cmb_UnitList.DataSource = UnitNameList;
        }

        private void InitcmbSpilt()
        {
            List<string> listName = new List<string>();

            listName.Add("逗 号");
            listName.Add("分 号");
            listName.Add("空 格");
            listName.Add("# 号");
            listName.Add("$ 号");
            listName.Add("* 号");
            listName.Add("@ 号");
            listName.Add("% 号");
            listName.Add("& 号");

            cmb_SpiltStr.DataSource = listName;
        }
        private void InitcmbEnd()
        {
            List<string> listName = new List<string>();

            listName.Add("NULL");
            listName.Add("逗 号");
            listName.Add("分 号");
            listName.Add("# 号");
            listName.Add("$ 号");
            listName.Add("* 号");
            listName.Add("@ 号");
            listName.Add("% 号");
            listName.Add("& 号");

            cmb_EndStr.DataSource = listName;
        }

        private void cmb_Data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_dataType.Text != "" && cmb_UnitList.Text != "")
            {
                List<F_DATA_CELL> dataList = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID == int.Parse(cmb_UnitList.Text.Substring(1))
                    && c.m_Data_Type == (DataType)Enum.Parse(typeof(DataType), cmb_dataType.Text));
                cmb_dataName.DataSource = dataList;
                cmb_dataName.DisplayMember = "m_Data_Name";
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (blnNewUnit)
            {
                ((CTCP_Send)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }

            ((CTCP_Send)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            ((CTCP_Send)m_Unit).m_CommunicationInfo_List = m_CommInfoList;
            
            this.Close();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
