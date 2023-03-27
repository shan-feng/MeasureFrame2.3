using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using System.IO.Ports;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_SerialComm : frm_Unit
    {
       

        private List<Communication_Info> m_CommInfoList = new List<Communication_Info>();
        public frm_Unit_SerialComm():base()
        {
            InitializeComponent();
            m_Unit = new CSerialComm(CellCatagory.串口通讯, HMeasureSYS.Cur_Project.m_LastCellID);
        }
        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_SerialComm(ref CMeasureCell MeasurCellBase):base(ref MeasurCellBase)
        {
            InitializeComponent();
        }

        private void frm_Unit_SerialComm_Load(object sender, EventArgs e)
        {
            InitSerialPort();
            InitUnitList();
            InitcmbDataType();
            InitcmbSpilt();
            InitcmbEnd();
            m_CommInfoList = ((CSerialComm)m_Unit).m_CommunicationInfo_List;
            dgv_ResultViewList.DataSource = new BindingList<Communication_Info>(m_CommInfoList);
        }

        private void InitSerialPort()
        {
            cmb_PortName.Text = ((CSerialComm)m_Unit).mSerialPort.PortName;
            cmb_BaudRate.Text = ((CSerialComm)m_Unit).mSerialPort.BaudRate.ToString();
            cmb_Parity.Text = ((CSerialComm)m_Unit).mSerialPort.Parity.ToString();
            cmb_StopBits.SelectedIndex = (int)(((CSerialComm)m_Unit).mSerialPort.StopBits)-1;
            cmb_DataBits.Text = ((CSerialComm)m_Unit).mSerialPort.DataBits.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (((CSerialComm)m_Unit).mSerialPort.IsOpen)
            {
                groupBox5.Enabled = false;
                bt_Open.Enabled = false;
                bt_Close.Enabled = true;
                bt_Send.Enabled = true;

                //读取字符串
                string str = ((CSerialComm)m_Unit).mSerialPort.ReadExisting();
                txt_RecieveData.AppendText(str);
                ((CSerialComm)m_Unit).mSerialPort.DiscardInBuffer();
                //((CSerialComm)m_Unit).mSerialPort.DiscardOutBuffer();
            }
            else
            {
                groupBox5.Enabled = true;
                bt_Open.Enabled = true;
                bt_Close.Enabled = false;
                bt_Send.Enabled = false;
            }
        }

        private void bt_Open_Click(object sender, EventArgs e)
        {
            try
            {
                SaveCommSetting();
                if (!((CSerialComm)m_Unit).mSerialPort.IsOpen)
                    ((CSerialComm)m_Unit).mSerialPort.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            try
            {
                if (((CSerialComm)m_Unit).mSerialPort.IsOpen)
                {
                    ((CSerialComm)m_Unit).mSerialPort.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bt_Send_Click(object sender, EventArgs e)
        {
            ((CSerialComm)m_Unit).mSerialPort.WriteLine(txt_SendData.Text);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            SaveCommSetting();
            if (blnNewUnit)
            {
                ((CSerialComm)m_Unit).m_Owner = HMeasureSYS.Cur_Project;
                blnNewUnit = false;
            }

            ((CSerialComm)m_Unit).m_CellDesCribe = txt_UnitDescrible.Text.Trim();
            ((CSerialComm)m_Unit).m_CommunicationInfo_List = m_CommInfoList;
            
        }

        private void SaveCommSetting()
        {
            if (!((CSerialComm)m_Unit).mSerialPort.IsOpen)
            {
                ((CSerialComm)m_Unit).mSerialPort.PortName = cmb_PortName.Text;
                ((CSerialComm)m_Unit).mSerialPort.BaudRate = int.Parse(cmb_BaudRate.Text);
                ((CSerialComm)m_Unit).mSerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmb_Parity.Text);
                ((CSerialComm)m_Unit).mSerialPort.StopBits = (StopBits)(cmb_StopBits.SelectedIndex + 1);
                ((CSerialComm)m_Unit).mSerialPort.DataBits = int.Parse(cmb_DataBits.Text);
            }
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

        private void dgv_ResultViewList_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
