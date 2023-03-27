using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Measure;
using System.Globalization;
using Measure.UserDefine;

namespace MeasureFrame.IUI
{
    public partial class frm_RectArray : Form
    {
        private List<Rectangle2_INFO> m_Rectangle2List;
        public frm_RectArray()
        {
            InitializeComponent();
            m_Rectangle2List = new List<Rectangle2_INFO>();
        }

        private void bt_RectArray_Click(object sender, EventArgs e)
        {
            int rowNum = int.Parse(txt_RowNum.Text.Trim());
            int colNum = int.Parse(txt_ColNum.Text.Trim());
            if (rowNum < 1 || colNum < 1)
            {
                MessageBox.Show("行列数要大于0!");
                return;
            }
            double Length1=Double.Parse(txt_Length1.Text.Trim());
            double Length2=Double.Parse(txt_Length2.Text.Trim());
            double Phi=Double.Parse(txt_Phi.Text.Trim());
            double firstPointX = Double.Parse(txt_firstPointX.Text.Trim());
            double firstPointY = Double.Parse(txt_firstPointY.Text.Trim());
            double secondPointX = Double.Parse(txt_secondPointX.Text.Trim());
            double secondPointY = Double.Parse(txt_secondPointY.Text.Trim());

            double xstep = 0;
            double ystep = 0;
            if (colNum > 1)
            {
                xstep = (firstPointX - secondPointX) / (colNum - 1);
            }
            if (rowNum > 1)
            {
                ystep = (firstPointY - secondPointY) / (rowNum - 1);
            }

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {

                    {
                        Rectangle2_INFO rect=new Rectangle2_INFO();
                        rect.CenterX = firstPointX + j * xstep;
                        rect.CenterY = firstPointY + i * ystep;
                        rect.Length1=Length1;
                        rect.Length2=Length2;
                        rect.Phi=Phi;
                        m_Rectangle2List.Add(rect);
                    }
                }
            }
            dgv_RectInfo.DataSource = new BindingList<Rectangle2_INFO>(m_Rectangle2List);
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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            ((frm_Unit_RectArray)this.Owner).m_Rectangle2List=((frm_Unit_RectArray)this.Owner).m_Rectangle2List.Concat(m_Rectangle2List).ToList();
            ((frm_Unit_RectArray)this.Owner).updataDataList();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_RectInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(this.dgv_RectInfo.RowHeadersDefaultCellStyle.ForeColor);
            int num = e.RowIndex + 1;
            e.Graphics.DrawString(num.ToString(CultureInfo.CurrentUICulture), this.dgv_RectInfo.DefaultCellStyle.Font, brush, (float)(e.RowBounds.Location.X + 20), (float)(e.RowBounds.Location.Y + 4));
        }
    }
}
