namespace MeasureFrame.IUI
{
    partial class frm_DisObjList
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
            this.dgv_DisObj = new System.Windows.Forms.DataGridView();
            this.m_Data_CellID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_isDisp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DisObj)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DisObj
            // 
            this.dgv_DisObj.AllowUserToAddRows = false;
            this.dgv_DisObj.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DisObj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DisObj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DisObj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_Data_CellID,
            this.m_Data_Name,
            this.m_isDisp});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DisObj.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DisObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DisObj.Location = new System.Drawing.Point(0, 0);
            this.dgv_DisObj.MultiSelect = false;
            this.dgv_DisObj.Name = "dgv_DisObj";
            this.dgv_DisObj.RowTemplate.Height = 23;
            this.dgv_DisObj.Size = new System.Drawing.Size(304, 485);
            this.dgv_DisObj.TabIndex = 0;
            this.dgv_DisObj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DisObj_CellContentClick);
            // 
            // m_Data_CellID
            // 
            this.m_Data_CellID.DataPropertyName = "m_Data_CellID";
            this.m_Data_CellID.Frozen = true;
            this.m_Data_CellID.HeaderText = "单元ID";
            this.m_Data_CellID.Name = "m_Data_CellID";
            this.m_Data_CellID.ReadOnly = true;
            // 
            // m_Data_Name
            // 
            this.m_Data_Name.DataPropertyName = "m_Data_Name";
            this.m_Data_Name.Frozen = true;
            this.m_Data_Name.HeaderText = "变量名称";
            this.m_Data_Name.Name = "m_Data_Name";
            this.m_Data_Name.ReadOnly = true;
            // 
            // m_isDisp
            // 
            this.m_isDisp.DataPropertyName = "m_isDisp";
            this.m_isDisp.Frozen = true;
            this.m_isDisp.HeaderText = "是否显示";
            this.m_isDisp.Name = "m_isDisp";
            this.m_isDisp.Width = 60;
            // 
            // frm_DisObjList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 485);
            this.Controls.Add(this.dgv_DisObj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_DisObjList";
            this.Text = "显示图形变量列表";
            this.Load += new System.EventHandler(this.frm_DisObjList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DisObj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DisObj;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_CellID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_isDisp;
    }
}