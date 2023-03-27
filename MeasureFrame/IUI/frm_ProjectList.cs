using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Measure;

namespace MeasureFrame.IUI
{
    public partial class frm_ProjectList : Form
    {
        private ContextMenuStrip m_MenuStrip = new ContextMenuStrip();
        private int CopyIndex = -1;
        public frm_ProjectList()
        {
            InitializeComponent();
        }

        private void frm_ProjectList_Load(object sender, EventArgs e)
        {
            InitMenuStrip();
            dgv_List.DataSource = HMeasureSYS.g_ProjectList.ToArray();
        }

        private void frm_ConfigList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //HMeasureSYS.SaveProjectList();
            this.Dispose();
        }

        private void Bt_Add_Click(object sender, EventArgs e)
        {
            CProject p = new CProject();
            HMeasureSYS.g_ProjectList.Add(p);
            dgv_List.DataSource = HMeasureSYS.g_ProjectList.ToArray();
            //Directory.CreateDirectory(Application.StartupPath + "\\VisionConfig\\" + p.m_ProjectName);
            //Directory.CreateDirectory(Application.StartupPath + "\\VisionConfig\\" + p.m_ProjectName + "\\RegisterIMG");
        }

        private void Bt_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_List.CurrentRow != null && dgv_List.CurrentRow.Index >= 0)
                {
                    if (HMeasureSYS.Cur_Project == HMeasureSYS.g_ProjectList[dgv_List.CurrentRow.Index])
                    {
                        MessageBox.Show("不能删除当前编辑项目");
                        return;
                    }
                    if (MessageBox.Show("是否删除该项目?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //Directory.Delete(Application.StartupPath + "\\VisionConfig\\" + HMeasureSYS.g_ProjectList[dgv_List.CurrentRow.Index].m_ProjectName, true);
                        HMeasureSYS.g_ProjectList.RemoveAt(dgv_List.CurrentRow.Index);
                        dgv_List.DataSource = HMeasureSYS.g_ProjectList.ToArray();
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void dgv_List_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    int count = HMeasureSYS.g_ProjectList.Where(c => c.m_ProjectName == e.FormattedValue.ToString().Trim() && c != HMeasureSYS.g_ProjectList[e.RowIndex]).Count();
                    if (count > 0)
                    {
                        this.dgv_List.Rows[e.RowIndex].ErrorText = "项目名称不能重复";
                        //this.dgv_List.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                        dgv_List.BeginEdit(false);
                        e.Cancel = true;
                    }
                    else
                    {
                        this.dgv_List.Rows[e.RowIndex].ErrorText = string.Empty;
                        Directory.Move(Application.StartupPath + "\\VisionConfig\\" + HMeasureSYS.g_ProjectList[e.RowIndex].m_ProjectName.Trim(),
Application.StartupPath + "\\VisionConfig\\" + e.FormattedValue.ToString().Trim());
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_List.CurrentRow != null && dgv_List.CurrentRow.Index >= 0)
                {
                    if (HMeasureSYS.Cur_Project == HMeasureSYS.g_ProjectList[dgv_List.CurrentRow.Index])
                    {
                        this.Close();
                        return;
                    }
                    DialogResult result = MessageBox.Show("是否保存项目？", "提醒", MessageBoxButtons.YesNoCancel);
                    //显示进度条
                    CProgress m_Progress = new CProgress();
                    if (result == DialogResult.Yes)
                    {
                        HMeasureSYS.SaveConfig(HMeasureSYS.sConfigPath);
                        frm_Main.thisHandle.LoadProject(HMeasureSYS.g_ProjectList[dgv_List.CurrentRow.Index]);
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        frm_Main.thisHandle.LoadProject(HMeasureSYS.g_ProjectList[dgv_List.CurrentRow.Index]);
                        this.Close();
                    }
                    m_Progress.SetProgressValue(100, this);
                }
            }
            catch (System.Exception ex)
            {

            }
        }


        private void InitMenuStrip()
        {

            ToolStripMenuItem strip_Copy = new ToolStripMenuItem("复制");
            strip_Copy.Click += new EventHandler((s, e) => OnStrip_Copy(s, e));

            ToolStripMenuItem strip_Post = new ToolStripMenuItem("粘贴");
            strip_Post.Click += new EventHandler((s, e) => OnStrip_Post(s, e));

            m_MenuStrip.Items.Add(strip_Copy);
            m_MenuStrip.Items.Add(strip_Post);
            m_MenuStrip.Opening += new CancelEventHandler((s, e) => On_MenuStrip_Opening());

            dgv_List.ContextMenuStrip = m_MenuStrip;
        }

        public void On_MenuStrip_Opening()
        {
            m_MenuStrip.Items[0].Enabled = true;
            m_MenuStrip.Items[1].Enabled = true;

            if (dgv_List.SelectedRows.Count < 1)
            {
                m_MenuStrip.Items[0].Enabled = false;
            }
            if (CopyIndex < 0)
            {
                m_MenuStrip.Items[1].Enabled = false;
            }
        }
        public void OnStrip_Copy(object sender, EventArgs e)
        {
            if (dgv_List.SelectedRows.Count > 0)
            {
                CopyIndex = dgv_List.SelectedRows[0].Index;
            }
        }
        public void OnStrip_Post(object sender, EventArgs e)
        {
            if (CopyIndex > -1 && HMeasureSYS.g_ProjectList.Count > CopyIndex)
            {
                CProject temp = (CProject)HMeasureSYS.g_ProjectList[CopyIndex].Clone();
                CProject.m_LastProjectID++;
                temp.m_ProjectID = CProject.m_LastProjectID;
                temp.m_ProjectName = "NewProject_" + temp.m_ProjectID.ToString();
                HMeasureSYS.g_ProjectList.Add(temp);
                dgv_List.DataSource = HMeasureSYS.g_ProjectList.ToArray();
            }
        }
    }
}
