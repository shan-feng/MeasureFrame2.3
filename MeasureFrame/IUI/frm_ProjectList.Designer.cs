namespace MeasureFrame.IUI
{
    partial class frm_ProjectList
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
            this.dgv_List = new System.Windows.Forms.DataGridView();
            this.m_ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_IsStart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Bt_Add = new System.Windows.Forms.Button();
            this.Bt_Remove = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_List
            // 
            this.dgv_List.AllowUserToAddRows = false;
            this.dgv_List.AllowUserToDeleteRows = false;
            this.dgv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_ProjectID,
            this.m_ProjectName,
            this.m_IsStart});
            this.dgv_List.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_List.Location = new System.Drawing.Point(0, 0);
            this.dgv_List.Name = "dgv_List";
            this.dgv_List.RowTemplate.Height = 23;
            this.dgv_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_List.Size = new System.Drawing.Size(614, 363);
            this.dgv_List.TabIndex = 0;
            this.dgv_List.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_List_CellValidating);
            // 
            // m_ProjectID
            // 
            this.m_ProjectID.DataPropertyName = "m_ProjectID";
            this.m_ProjectID.HeaderText = "项目ID";
            this.m_ProjectID.Name = "m_ProjectID";
            this.m_ProjectID.ReadOnly = true;
            // 
            // m_ProjectName
            // 
            this.m_ProjectName.DataPropertyName = "m_ProjectName";
            this.m_ProjectName.HeaderText = "项目名称";
            this.m_ProjectName.Name = "m_ProjectName";
            this.m_ProjectName.Width = 200;
            // 
            // m_IsStart
            // 
            this.m_IsStart.DataPropertyName = "m_IsStart";
            this.m_IsStart.HeaderText = "启动加载";
            this.m_IsStart.Name = "m_IsStart";
            // 
            // Bt_Add
            // 
            this.Bt_Add.Location = new System.Drawing.Point(256, 384);
            this.Bt_Add.Name = "Bt_Add";
            this.Bt_Add.Size = new System.Drawing.Size(75, 36);
            this.Bt_Add.TabIndex = 1;
            this.Bt_Add.Text = "添加";
            this.Bt_Add.UseVisualStyleBackColor = true;
            this.Bt_Add.Click += new System.EventHandler(this.Bt_Add_Click);
            // 
            // Bt_Remove
            // 
            this.Bt_Remove.Location = new System.Drawing.Point(470, 384);
            this.Bt_Remove.Name = "Bt_Remove";
            this.Bt_Remove.Size = new System.Drawing.Size(75, 36);
            this.Bt_Remove.TabIndex = 2;
            this.Bt_Remove.Text = "删除";
            this.Bt_Remove.UseVisualStyleBackColor = true;
            this.Bt_Remove.Click += new System.EventHandler(this.Bt_Remove_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(364, 384);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 36);
            this.bt_Edit.TabIndex = 3;
            this.bt_Edit.Text = "编辑";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // frm_ProjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 442);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.Bt_Remove);
            this.Controls.Add(this.Bt_Add);
            this.Controls.Add(this.dgv_List);
            this.Name = "frm_ProjectList";
            this.Text = "工程列表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ConfigList_FormClosed);
            this.Load += new System.EventHandler(this.frm_ProjectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_List;
        private System.Windows.Forms.Button Bt_Add;
        private System.Windows.Forms.Button Bt_Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ProjectName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_IsStart;
        private System.Windows.Forms.Button bt_Edit;
    }
}