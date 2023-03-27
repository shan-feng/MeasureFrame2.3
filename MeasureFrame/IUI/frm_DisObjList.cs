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
    public partial class frm_DisObjList : Form
    {
        List<sDictionary> dispList;
        List<tempList> query;
        public frm_DisObjList(List<sDictionary> list)
        {
            InitializeComponent();
            dispList = list;
        }

        private void frm_DisObjList_Load(object sender, EventArgs e)
        {
            List<F_DATA_CELL> dataList = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_Type == DataType.点2D ||
                c.m_Data_Type == DataType.矩形阵列 || c.m_Data_Type == DataType.椭圆 || c.m_Data_Type == DataType.圆 ||
                c.m_Data_Type == DataType.直线 || c.m_Data_Type == DataType.坐标系);

            //var query = from v in dataList
            //            select new { m_Data_CellID = v.m_Data_CellID, m_Data_Name=v.m_Data_Name, m_isDisp = (dispList.FindIndex(d => d.m_UnitID == v.m_Data_CellID && d.m_VariableName == v.m_Data_Name)) };
            query = dataList.Select(v => new tempList
            {
                m_Data_CellID = v.m_Data_CellID,
                m_Data_Name = v.m_Data_Name,
                m_isDisp = (dispList.FindIndex(d => d.m_UnitID == v.m_Data_CellID && d.m_VariableName == v.m_Data_Name) > -1)
            }).ToList();
            dgv_DisObj.DataSource = query;
        }

        private void dgv_DisObj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dgv_DisObj.EndEdit();
                dispList = query.Where(c => c.m_isDisp == true).Select(d => new sDictionary
                {
                    m_UnitID = d.m_Data_CellID,
                    m_VariableName = d.m_Data_Name
                }).ToList();
                ((frm_Unit_ResultView2)(this.Owner)).UpdateDispObj(dispList);
                ((frm_Unit_ResultView2)this.Owner).PaintMetrology();
            }
        }
    }
    public class tempList
    {
        public int m_Data_CellID { get; set; }
        public string m_Data_Name { get; set; }
        public bool m_isDisp { get; set; }
    }
}
