namespace MeasureFrame.IUI
{
    partial class frm_Unit_DataSave
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Attribute = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Broswe = new System.Windows.Forms.Button();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.cmb_VariableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.dgv_VariableList = new System.Windows.Forms.DataGridView();
            this.m_Data_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_DataTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_RemoveAll = new System.Windows.Forms.Button();
            this.chb_he = new System.Windows.Forms.CheckBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VariableList)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(287, 21);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Size = new System.Drawing.Size(551, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(551, 524);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.bt_RemoveAll);
            this.gb_main.Controls.Add(this.bt_Edit);
            this.gb_main.Controls.Add(this.bt_Add);
            this.gb_main.Controls.Add(this.dgv_VariableList);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.bt_Delete);
            this.gb_main.Size = new System.Drawing.Size(537, 492);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(447, 20);
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(543, 498);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_he);
            this.groupBox1.Controls.Add(this.cmb_Attribute);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bt_Broswe);
            this.groupBox1.Controls.Add(this.txt_FilePath);
            this.groupBox1.Controls.Add(this.cmb_VariableName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_DataType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "存储数据";
            // 
            // cmb_Attribute
            // 
            this.cmb_Attribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Attribute.Enabled = false;
            this.cmb_Attribute.FormattingEnabled = true;
            this.cmb_Attribute.Location = new System.Drawing.Point(89, 22);
            this.cmb_Attribute.Name = "cmb_Attribute";
            this.cmb_Attribute.Size = new System.Drawing.Size(121, 20);
            this.cmb_Attribute.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "变量范围：";
            // 
            // bt_Broswe
            // 
            this.bt_Broswe.Location = new System.Drawing.Point(407, 99);
            this.bt_Broswe.Name = "bt_Broswe";
            this.bt_Broswe.Size = new System.Drawing.Size(75, 24);
            this.bt_Broswe.TabIndex = 6;
            this.bt_Broswe.Text = "浏览";
            this.bt_Broswe.UseVisualStyleBackColor = true;
            this.bt_Broswe.Click += new System.EventHandler(this.bt_Broswe_Click);
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(17, 102);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.ReadOnly = true;
            this.txt_FilePath.Size = new System.Drawing.Size(369, 21);
            this.txt_FilePath.TabIndex = 5;
            // 
            // cmb_VariableName
            // 
            this.cmb_VariableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VariableName.FormattingEnabled = true;
            this.cmb_VariableName.Location = new System.Drawing.Point(361, 58);
            this.cmb_VariableName.Name = "cmb_VariableName";
            this.cmb_VariableName.Size = new System.Drawing.Size(121, 20);
            this.cmb_VariableName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量名称：";
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(89, 58);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(121, 20);
            this.cmb_DataType.TabIndex = 1;
            this.cmb_DataType.SelectedIndexChanged += new System.EventHandler(this.cmb_DataType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "变量类型：";
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(278, 161);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 37);
            this.bt_Delete.TabIndex = 2;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // dgv_VariableList
            // 
            this.dgv_VariableList.AllowUserToAddRows = false;
            this.dgv_VariableList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VariableList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VariableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_VariableList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_Data_Name,
            this.m_Data_Type,
            this.m_Data_Num,
            this.m_DataTip});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_VariableList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VariableList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_VariableList.Location = new System.Drawing.Point(3, 205);
            this.dgv_VariableList.Name = "dgv_VariableList";
            this.dgv_VariableList.ReadOnly = true;
            this.dgv_VariableList.RowHeadersWidth = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_VariableList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_VariableList.RowTemplate.Height = 23;
            this.dgv_VariableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_VariableList.Size = new System.Drawing.Size(531, 284);
            this.dgv_VariableList.TabIndex = 20;
            this.dgv_VariableList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_VariableList_CellContentClick);
            // 
            // m_Data_Name
            // 
            this.m_Data_Name.DataPropertyName = "m_Data_Name";
            this.m_Data_Name.HeaderText = "名称";
            this.m_Data_Name.Name = "m_Data_Name";
            this.m_Data_Name.ReadOnly = true;
            this.m_Data_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_Data_Name.Width = 110;
            // 
            // m_Data_Type
            // 
            this.m_Data_Type.DataPropertyName = "m_Data_Type";
            this.m_Data_Type.HeaderText = "类型";
            this.m_Data_Type.Name = "m_Data_Type";
            this.m_Data_Type.ReadOnly = true;
            this.m_Data_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_Data_Type.Width = 110;
            // 
            // m_Data_Num
            // 
            this.m_Data_Num.DataPropertyName = "m_Data_Num";
            this.m_Data_Num.HeaderText = "变量个数";
            this.m_Data_Num.Name = "m_Data_Num";
            this.m_Data_Num.ReadOnly = true;
            this.m_Data_Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_DataTip
            // 
            this.m_DataTip.DataPropertyName = "m_DataTip";
            this.m_DataTip.HeaderText = "备注";
            this.m_DataTip.Name = "m_DataTip";
            this.m_DataTip.ReadOnly = true;
            this.m_DataTip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.m_DataTip.Width = 200;
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(30, 160);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 38);
            this.bt_Add.TabIndex = 21;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(158, 161);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 38);
            this.bt_Edit.TabIndex = 22;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_RemoveAll
            // 
            this.bt_RemoveAll.Location = new System.Drawing.Point(398, 162);
            this.bt_RemoveAll.Name = "bt_RemoveAll";
            this.bt_RemoveAll.Size = new System.Drawing.Size(75, 37);
            this.bt_RemoveAll.TabIndex = 23;
            this.bt_RemoveAll.Text = "全部删除";
            this.bt_RemoveAll.UseVisualStyleBackColor = true;
            this.bt_RemoveAll.Click += new System.EventHandler(this.bt_RemoveAll_Click);
            // 
            // chb_he
            // 
            this.chb_he.AutoSize = true;
            this.chb_he.Location = new System.Drawing.Point(295, 20);
            this.chb_he.Name = "chb_he";
            this.chb_he.Size = new System.Drawing.Size(126, 16);
            this.chb_he.TabIndex = 9;
            this.chb_he.Text = "图像保存为.he格式";
            this.chb_he.UseVisualStyleBackColor = true;
            this.chb_he.CheckedChanged += new System.EventHandler(this.chb_he_CheckedChanged);
            // 
            // frm_Unit_DataSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(551, 632);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_DataSave";
            this.Text = "数据存储";
            this.Load += new System.EventHandler(this.frm_Unit_DataSave_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VariableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_VariableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_VariableList;
        private System.Windows.Forms.Button bt_Broswe;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_RemoveAll;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.ComboBox cmb_Attribute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataTip;
        private System.Windows.Forms.CheckBox chb_he;
    }
}
