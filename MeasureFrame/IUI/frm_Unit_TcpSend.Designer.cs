namespace MeasureFrame.IUI
{
    partial class frm_Unit_TcpSend
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
            this.cmb_UnitList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_EndStr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_SpiltStr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_dataName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_dataType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_EndPointList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ResultViewList = new System.Windows.Forms.DataGridView();
            this.m_DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_SpiltStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_NgColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultViewList)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(263, 20);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Size = new System.Drawing.Size(558, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(558, 498);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.dgv_ResultViewList);
            this.gb_main.Controls.Add(this.bt_DeleteAll);
            this.gb_main.Controls.Add(this.bt_Delete);
            this.gb_main.Controls.Add(this.bt_Edit);
            this.gb_main.Controls.Add(this.bt_Add);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Size = new System.Drawing.Size(544, 466);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(411, 20);
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(550, 472);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_UnitList);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmb_EndStr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_SpiltStr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_dataName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmb_dataType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_EndPointList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯设置";
            // 
            // cmb_UnitList
            // 
            this.cmb_UnitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnitList.FormattingEnabled = true;
            this.cmb_UnitList.Location = new System.Drawing.Point(86, 63);
            this.cmb_UnitList.Name = "cmb_UnitList";
            this.cmb_UnitList.Size = new System.Drawing.Size(137, 20);
            this.cmb_UnitList.TabIndex = 11;
            this.cmb_UnitList.SelectedIndexChanged += new System.EventHandler(this.cmb_Data_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "变量单元:";
            // 
            // cmb_EndStr
            // 
            this.cmb_EndStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EndStr.FormattingEnabled = true;
            this.cmb_EndStr.Location = new System.Drawing.Point(371, 102);
            this.cmb_EndStr.Name = "cmb_EndStr";
            this.cmb_EndStr.Size = new System.Drawing.Size(137, 20);
            this.cmb_EndStr.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "终结符:";
            // 
            // cmb_SpiltStr
            // 
            this.cmb_SpiltStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SpiltStr.FormattingEnabled = true;
            this.cmb_SpiltStr.Location = new System.Drawing.Point(86, 102);
            this.cmb_SpiltStr.Name = "cmb_SpiltStr";
            this.cmb_SpiltStr.Size = new System.Drawing.Size(137, 20);
            this.cmb_SpiltStr.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "分隔符:";
            // 
            // cmb_dataName
            // 
            this.cmb_dataName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dataName.FormattingEnabled = true;
            this.cmb_dataName.Location = new System.Drawing.Point(371, 63);
            this.cmb_dataName.Name = "cmb_dataName";
            this.cmb_dataName.Size = new System.Drawing.Size(137, 20);
            this.cmb_dataName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "变量名称:";
            // 
            // cmb_dataType
            // 
            this.cmb_dataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dataType.FormattingEnabled = true;
            this.cmb_dataType.Location = new System.Drawing.Point(371, 31);
            this.cmb_dataType.Name = "cmb_dataType";
            this.cmb_dataType.Size = new System.Drawing.Size(137, 20);
            this.cmb_dataType.TabIndex = 3;
            this.cmb_dataType.SelectedIndexChanged += new System.EventHandler(this.cmb_Data_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量类型:";
            // 
            // cmb_EndPointList
            // 
            this.cmb_EndPointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EndPointList.Enabled = false;
            this.cmb_EndPointList.FormattingEnabled = true;
            this.cmb_EndPointList.Items.AddRange(new object[] {
            "默认"});
            this.cmb_EndPointList.Location = new System.Drawing.Point(86, 28);
            this.cmb_EndPointList.Name = "cmb_EndPointList";
            this.cmb_EndPointList.Size = new System.Drawing.Size(172, 20);
            this.cmb_EndPointList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户端:";
            // 
            // dgv_ResultViewList
            // 
            this.dgv_ResultViewList.AllowUserToAddRows = false;
            this.dgv_ResultViewList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ResultViewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ResultViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ResultViewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_DataType,
            this.m_VariableName,
            this.m_SpiltStr,
            this.m_NgColor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ResultViewList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ResultViewList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ResultViewList.Location = new System.Drawing.Point(3, 198);
            this.dgv_ResultViewList.Name = "dgv_ResultViewList";
            this.dgv_ResultViewList.ReadOnly = true;
            this.dgv_ResultViewList.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ResultViewList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ResultViewList.RowTemplate.Height = 23;
            this.dgv_ResultViewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ResultViewList.Size = new System.Drawing.Size(538, 265);
            this.dgv_ResultViewList.TabIndex = 33;
            this.dgv_ResultViewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Celllick);
            // 
            // m_DataType
            // 
            this.m_DataType.DataPropertyName = "m_DataType";
            this.m_DataType.Frozen = true;
            this.m_DataType.HeaderText = "变量类型";
            this.m_DataType.Name = "m_DataType";
            this.m_DataType.ReadOnly = true;
            this.m_DataType.Width = 130;
            // 
            // m_VariableName
            // 
            this.m_VariableName.DataPropertyName = "m_VariableName";
            this.m_VariableName.Frozen = true;
            this.m_VariableName.HeaderText = "变量名称";
            this.m_VariableName.Name = "m_VariableName";
            this.m_VariableName.ReadOnly = true;
            this.m_VariableName.Width = 130;
            // 
            // m_SpiltStr
            // 
            this.m_SpiltStr.DataPropertyName = "m_SpiltStr";
            this.m_SpiltStr.Frozen = true;
            this.m_SpiltStr.HeaderText = "分隔符";
            this.m_SpiltStr.Name = "m_SpiltStr";
            this.m_SpiltStr.ReadOnly = true;
            this.m_SpiltStr.Width = 130;
            // 
            // m_NgColor
            // 
            this.m_NgColor.DataPropertyName = "m_EndStr";
            this.m_NgColor.Frozen = true;
            this.m_NgColor.HeaderText = "终结符";
            this.m_NgColor.Name = "m_NgColor";
            this.m_NgColor.ReadOnly = true;
            this.m_NgColor.Width = 130;
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(436, 158);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 32;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(323, 158);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 31;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(207, 158);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 34);
            this.bt_Edit.TabIndex = 30;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(88, 158);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 34);
            this.bt_Add.TabIndex = 29;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // frm_Unit_TcpCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(558, 606);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_TcpCommunication";
            this.Load += new System.EventHandler(this.frm_Unit_TcpCommunication_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultViewList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_EndStr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_SpiltStr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_dataName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_dataType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_EndPointList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ResultViewList;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_VariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_SpiltStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_NgColor;
        private System.Windows.Forms.ComboBox cmb_UnitList;
        private System.Windows.Forms.Label label7;
    }
}
