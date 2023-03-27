namespace MeasureFrame.IUI
{
    partial class frm_Flow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_FlowList = new System.Windows.Forms.DataGridView();
            this.UnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCatogory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hWindow_Fit = new HalconControl.HWindow_Fit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_FlowList
            // 
            this.dgv_FlowList.AllowUserToAddRows = false;
            this.dgv_FlowList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgv_FlowList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_FlowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_FlowList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnitID,
            this.UnitCatogory,
            this.UnitRemark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FlowList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_FlowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FlowList.Location = new System.Drawing.Point(3, 3);
            this.dgv_FlowList.MultiSelect = false;
            this.dgv_FlowList.Name = "dgv_FlowList";
            this.dgv_FlowList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FlowList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_FlowList.RowHeadersWidth = 36;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgv_FlowList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_FlowList.RowTemplate.Height = 23;
            this.dgv_FlowList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FlowList.Size = new System.Drawing.Size(294, 554);
            this.dgv_FlowList.TabIndex = 7;
            // 
            // UnitID
            // 
            this.UnitID.DataPropertyName = "UnitID";
            this.UnitID.Frozen = true;
            this.UnitID.HeaderText = "单元ID";
            this.UnitID.Name = "UnitID";
            this.UnitID.ReadOnly = true;
            this.UnitID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitID.Width = 80;
            // 
            // UnitCatogory
            // 
            this.UnitCatogory.DataPropertyName = "UnitCatagory";
            this.UnitCatogory.Frozen = true;
            this.UnitCatogory.HeaderText = "单元类型";
            this.UnitCatogory.Name = "UnitCatogory";
            this.UnitCatogory.ReadOnly = true;
            this.UnitCatogory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitCatogory.Width = 90;
            // 
            // UnitRemark
            // 
            this.UnitRemark.DataPropertyName = "UnitRemark";
            this.UnitRemark.Frozen = true;
            this.UnitRemark.HeaderText = "备注";
            this.UnitRemark.Name = "UnitRemark";
            this.UnitRemark.ReadOnly = true;
            this.UnitRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitRemark.Width = 120;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.hWindow_Fit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_FlowList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1069, 560);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // hWindow_Fit
            // 
            this.hWindow_Fit.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Fit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Fit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Fit.ForeColor = System.Drawing.SystemColors.Control;
            this.hWindow_Fit.Image = null;
            this.hWindow_Fit.Location = new System.Drawing.Point(304, 4);
            this.hWindow_Fit.Margin = new System.Windows.Forms.Padding(4);
            this.hWindow_Fit.Name = "hWindow_Fit";
            this.hWindow_Fit.Size = new System.Drawing.Size(761, 552);
            this.hWindow_Fit.TabIndex = 8;
            // 
            // frm_Flow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 560);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HideOnClose = true;
            this.Name = "frm_Flow";
            this.Text = "视觉编辑";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FlowList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCatogory;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitRemark;
        public System.Windows.Forms.DataGridView dgv_FlowList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public HalconControl.HWindow_Fit hWindow_Fit;
    }
}