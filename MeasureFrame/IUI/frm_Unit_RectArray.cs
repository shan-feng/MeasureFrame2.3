using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Measure;
using HalconDotNet;
using System.Globalization;
using System.Linq;
using Measure.UserDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_Unit_RectArray : MeasureFrame.IUI.frm_Unit_ImageBase
    {
        public List<Rectangle2_INFO> m_Rectangle2List;
        private frm_RectArray m_frm_RectArray;
        private HXLDCont m_Regions = new HXLDCont();
        /// <summary>
        /// 补正坐标系
        /// </summary>
        [NonSerialized]
        public Coordinate_INFO Coord = new Coordinate_INFO();
        public frm_Unit_RectArray() :
            base()
        {
            InitializeComponent();
            m_Unit = new CRectArray(CellCatagory.矩形阵列, HMeasureSYS.Cur_Project.m_LastCellID);
            m_Rectangle2List = new List<Rectangle2_INFO>();
        }

        /// <summary>
        /// 构造函数，打开已有的单元
        /// </summary>
        /// <param name="MeasurCellBase"></param>
        public frm_Unit_RectArray(ref CMeasureCell MeasurCellBase)
            : base(ref MeasurCellBase)
        {
            InitializeComponent();
            m_Rectangle2List = ((CRectArray)m_Unit).m_RectArray;
        }

        private void frm_Unit_RectArray_Load(object sender, EventArgs e)
        {
            //初始化下拉列表
            InitCmbFilter();
            InitCmbPosition();
            string temp_color = ((CRectArray)m_Unit).m_DrawColor.Substring(1, 2);
            int r = Convert.ToInt32(temp_color, 16);
            temp_color = ((CRectArray)m_Unit).m_DrawColor.Substring(3, 2);
            int g = Convert.ToInt32(temp_color, 16);
            temp_color = ((CRectArray)m_Unit).m_DrawColor.Substring(5, 2);
            int b = Convert.ToInt32(temp_color, 16);
            bt_Color1.BackColor = Color.FromArgb(r, g, b);
            cmb_refPosition.Text = "无";
            if (!blnNewUnit)
            {
                cmb_CurrentImg.Text = ((CRectArray)m_Unit).m_CurrentImgName;
                cmb_refPosition.Text = "U" + ((CRectArray)m_Unit).m_homMatUnitID.ToString("D4");
            }
            cmb_Filter.Text = ((CRectArray)m_Unit).m_PreTreatment.ToString();
            dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);
            base.frm_OnLoad();
            cmb_refPosition.SelectedIndexChanged += new System.EventHandler(this.UpdateParam);
            dgv_RectInfo.DataSourceChanged += new System.EventHandler(this.UpdateParam);

            UpdateParam(sender, e);
        }

        /// <summary>
        /// 初始化滤波下来列表
        /// </summary>
        protected void InitCmbFilter()
        {
            List<string> FilterList = new List<string>();
            Type tPreTreatMent = typeof(PreTreatMent);
            foreach (string s in Enum.GetNames(tPreTreatMent))
            {
                FilterList.Add(s);
            }
            cmb_Filter.DataSource = FilterList;
        }

        /// <summary>
        /// 初始化位置补正列表
        /// </summary>
        public void InitCmb_Position()
        {
            List<string> m_PositionList = new List<string>() { "无" };//直线单元ID列表
            IEnumerable<string> resultList = from datacell in HMeasureSYS.Cur_Project.m_VariableList
                                             where datacell.m_Data_Type == DataType.坐标系 && datacell.m_Data_CellID != HMeasureSYS.U000
                                             select "U" + datacell.m_Data_CellID.ToString("D4");
            m_PositionList.AddRange(resultList.ToList());
            cmb_refPosition.DataSource = m_PositionList;
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Rectangle2_INFO rect = new Rectangle2_INFO();
            rect.CenterX = Double.Parse(txt_CenterX.Text.Trim());
            rect.CenterY = Double.Parse(txt_CenterY.Text.Trim());
            rect.Length1 = Double.Parse(txt_Length1.Text.Trim());
            rect.Length2 = Double.Parse(txt_Length2.Text.Trim());
            rect.Phi = Double.Parse(txt_Phi.Text.Trim());
            m_Rectangle2List.Add(rect);
            dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);
            dgv_RectInfo.CurrentCell = dgv_RectInfo.Rows[dgv_RectInfo.Rows.Count - 1].Cells[0];
        }

        private void bt_RectArray_Click(object sender, EventArgs e)
        {
            if (m_frm_RectArray == null || m_frm_RectArray.IsDisposed)
            {
                m_frm_RectArray = new frm_RectArray();
                m_frm_RectArray.Show(this);
            }
            else
            {
                m_frm_RectArray.Activate();
            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_RectInfo.SelectedRows.Count > 0)
            {
                int Index = dgv_RectInfo.SelectedRows[0].Cells[0].RowIndex;
                Rectangle2_INFO temp_Rectangle = new Rectangle2_INFO();
                temp_Rectangle.CenterX = Double.Parse(txt_CenterX.Text.Trim());
                temp_Rectangle.CenterY = Double.Parse(txt_CenterY.Text.Trim());
                temp_Rectangle.Length1 = Double.Parse(txt_Length1.Text.Trim());
                temp_Rectangle.Length2 = Double.Parse(txt_Length2.Text.Trim());
                temp_Rectangle.Phi = Double.Parse(txt_Phi.Text.Trim());
                m_Rectangle2List.RemoveAt(Index);
                m_Rectangle2List.Insert(Index, temp_Rectangle);
                dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);
                dgv_RectInfo.CurrentCell = dgv_RectInfo.Rows[Index].Cells[0];
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_RectInfo.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgv_RectInfo.SelectedRows[0];
                int index = r.Cells[0].RowIndex;
                m_Rectangle2List.RemoveAt(index);
                dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);

                if (index > 0)
                {
                    dgv_RectInfo.CurrentCell = dgv_RectInfo.Rows[index - 1].Cells[0];
                }
            }
        }

        private void bt_DeleteAll_Click(object sender, EventArgs e)
        {
            m_Rectangle2List.Clear();
            dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);

        }

        private void dgv_RectInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Rectangle2_INFO temp_Rectangle = m_Rectangle2List[e.RowIndex];
                txt_CenterX.Text = temp_Rectangle.CenterX.ToString();
                txt_CenterY.Text = temp_Rectangle.CenterY.ToString();
                txt_Length1.Text = temp_Rectangle.Length1.ToString();
                txt_Length2.Text = temp_Rectangle.Length2.ToString();
                txt_Phi.Text = temp_Rectangle.Phi.ToString();
            }
        }

        protected override void UpdateParam(object sender, EventArgs e)
        {
            if (cmb_refPosition.SelectedIndex > 0)
                ((CRectArray)m_Unit).m_homMatUnitID = int.Parse(cmb_refPosition.Text.Substring(1));
            else
                ((CRectArray)m_Unit).m_homMatUnitID = -1;
            ((CRectArray)m_Unit).m_CurrentImgName = cmb_CurrentImg.Text;
            ((CRectArray)m_Unit).m_PreTreatment = (PreTreatMent)Enum.Parse(typeof(PreTreatMent), cmb_Filter.Text);
            ((CRectArray)m_Unit).m_RectArray = m_Rectangle2List;
            m_Unit.Execute();//再检测
            PaintMetrology();
        }

        private void dgv_RectInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(this.dgv_RectInfo.RowHeadersDefaultCellStyle.ForeColor);
            int num = e.RowIndex + 1;
            e.Graphics.DrawString(num.ToString(CultureInfo.CurrentUICulture), this.dgv_RectInfo.DefaultCellStyle.Font, brush, (float)(e.RowBounds.Location.X + 20), (float)(e.RowBounds.Location.Y + 4));

        }

        private void bt_Color1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true; //是否显示ColorDialog有半部分
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)//确定事件响应
            {
                Color color_from = colorDialog.Color;
                bt_Color1.BackColor = color_from;
                string m_DrawColor1 = color_from.ToArgb().ToString("X02");
                m_DrawColor1 = m_DrawColor1.Substring(2);
                m_DrawColor1 = m_DrawColor1.Insert(0, "#");
                ((CRectArray)m_Unit).m_DrawColor = m_DrawColor1;
            }
        }

        public void updataDataList()
        {
            dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);
        }
        //private void setRegion()
        //{
        //    HTuple rows = new HTuple();
        //    HTuple cols = new HTuple();
        //    HTuple phis = new HTuple();
        //    HTuple length1 = new HTuple();
        //    HTuple length2 = new HTuple();
        //    foreach (Rectangle2_INFO rect in m_Rectangle2List)
        //    {
        //        rows.Append(rect.CenterY);
        //        cols.Append(rect.CenterX);
        //        phis.Append(rect.Phi);
        //        length1.Append(rect.Length1);
        //        length2.Append(rect.Length2);
        //    }
        //    if (rows.Length>0)
        //    {
        //        m_Regions.GenRectangle2ContourXld(rows, cols, phis, length1, length2);
        //        m_Regions=m_Regions.AffineTransContourXld(m_HMat2D);
        //    }
        //    else
        //    {
        //        m_Regions = new HXLDCont();
        //    }

        //}

        private void InitCmbPosition()
        {
            List<string> strList = new List<string>();
            var result = HMeasureSYS.Cur_Project.m_VariableList.FindAll(c => c.m_Data_CellID != HMeasureSYS.U000 && c.m_Data_Type == DataType.坐标系).Select(c => "U" + c.m_Data_CellID.ToString("D4"));
            strList = result.ToList();
            strList.Insert(0, "无");
            cmb_refPosition.DataSource = strList;
        }

        private void cmb_refPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_refPosition.Text == "无")
            {
                Coord = new Coordinate_INFO();
            }
            else
            {
                F_DATA_CELL data = HMeasureSYS.Cur_Project.m_VariableList.FirstOrDefault(c => c.m_Data_CellID == int.Parse(cmb_refPosition.Text.Substring(1)) &&
                    c.m_Data_Type == DataType.坐标系);
                Coord = ((List<Coordinate_INFO>)data.m_Data_Value)[0];
            }
            updataDataList();
        }
    }
}
