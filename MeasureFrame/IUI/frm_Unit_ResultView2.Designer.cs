namespace MeasureFrame.IUI
{
    partial class frm_Unit_ResultView2
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
            this.bt_SetDisPosition = new System.Windows.Forms.Button();
            this.cmb_Condition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Condition = new System.Windows.Forms.Button();
            this.bt_Font = new System.Windows.Forms.Button();
            this.txt_Position = new System.Windows.Forms.TextBox();
            this.cmb_VariableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.dgv_ResultViewList = new System.Windows.Forms.DataGridView();
            this.m_DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ConditionVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_DisPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_NormalStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_NgColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_Visible = new System.Windows.Forms.CheckBox();
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
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.check_Visible);
            this.gb_top.Size = new System.Drawing.Size(662, 50);
            this.gb_top.Controls.SetChildIndex(this.check_Visible, 0);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(662, 467);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.dgv_ResultViewList);
            this.gb_main.Controls.Add(this.bt_DeleteAll);
            this.gb_main.Controls.Add(this.bt_Delete);
            this.gb_main.Controls.Add(this.bt_Edit);
            this.gb_main.Controls.Add(this.bt_Add);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Size = new System.Drawing.Size(648, 435);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(654, 441);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Attribute);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bt_SetDisPosition);
            this.groupBox1.Controls.Add(this.cmb_Condition);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.bt_Condition);
            this.groupBox1.Controls.Add(this.bt_Font);
            this.groupBox1.Controls.Add(this.txt_Position);
            this.groupBox1.Controls.Add(this.cmb_VariableName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_DataType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示数据";
            // 
            // cmb_Attribute
            // 
            this.cmb_Attribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Attribute.Enabled = false;
            this.cmb_Attribute.FormattingEnabled = true;
            this.cmb_Attribute.Location = new System.Drawing.Point(103, 20);
            this.cmb_Attribute.Name = "cmb_Attribute";
            this.cmb_Attribute.Size = new System.Drawing.Size(121, 20);
            this.cmb_Attribute.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(29, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "变量范围：";
            // 
            // bt_SetDisPosition
            // 
            this.bt_SetDisPosition.Location = new System.Drawing.Point(267, 93);
            this.bt_SetDisPosition.Name = "bt_SetDisPosition";
            this.bt_SetDisPosition.Size = new System.Drawing.Size(87, 27);
            this.bt_SetDisPosition.TabIndex = 13;
            this.bt_SetDisPosition.Text = "设置显示位置";
            this.bt_SetDisPosition.UseVisualStyleBackColor = true;
            this.bt_SetDisPosition.Click += new System.EventHandler(this.bt_SetDisPosition_Click);
            // 
            // cmb_Condition
            // 
            this.cmb_Condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Condition.FormattingEnabled = true;
            this.cmb_Condition.Location = new System.Drawing.Point(360, 57);
            this.cmb_Condition.Name = "cmb_Condition";
            this.cmb_Condition.Size = new System.Drawing.Size(121, 20);
            this.cmb_Condition.TabIndex = 12;
            this.cmb_Condition.SelectedIndexChanged += new System.EventHandler(this.cmb_Condition_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "样式条件变量：";
            // 
            // bt_Condition
            // 
            this.bt_Condition.Location = new System.Drawing.Point(523, 95);
            this.bt_Condition.Name = "bt_Condition";
            this.bt_Condition.Size = new System.Drawing.Size(66, 27);
            this.bt_Condition.TabIndex = 10;
            this.bt_Condition.Text = "NG颜色";
            this.bt_Condition.UseVisualStyleBackColor = true;
            this.bt_Condition.Click += new System.EventHandler(this.bt_Condition_Click);
            // 
            // bt_Font
            // 
            this.bt_Font.Location = new System.Drawing.Point(523, 53);
            this.bt_Font.Name = "bt_Font";
            this.bt_Font.Size = new System.Drawing.Size(66, 26);
            this.bt_Font.TabIndex = 8;
            this.bt_Font.Text = "常规样式";
            this.bt_Font.UseVisualStyleBackColor = true;
            this.bt_Font.Click += new System.EventHandler(this.bt_Font_Click);
            // 
            // txt_Position
            // 
            this.txt_Position.Location = new System.Drawing.Point(360, 97);
            this.txt_Position.Name = "txt_Position";
            this.txt_Position.ReadOnly = true;
            this.txt_Position.Size = new System.Drawing.Size(121, 21);
            this.txt_Position.TabIndex = 7;
            this.txt_Position.Text = "50,50,100,150";
            // 
            // cmb_VariableName
            // 
            this.cmb_VariableName.FormattingEnabled = true;
            this.cmb_VariableName.Location = new System.Drawing.Point(103, 99);
            this.cmb_VariableName.Name = "cmb_VariableName";
            this.cmb_VariableName.Size = new System.Drawing.Size(121, 20);
            this.cmb_VariableName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量名称：";
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(103, 57);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(121, 20);
            this.cmb_DataType.TabIndex = 1;
            this.cmb_DataType.SelectedIndexChanged += new System.EventHandler(this.cmb_DataType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据类型：";
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(427, 155);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 27;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(314, 155);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 26;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(198, 155);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 34);
            this.bt_Edit.TabIndex = 25;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(79, 155);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 34);
            this.bt_Add.TabIndex = 24;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
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
            this.m_ConditionVarName,
            this.m_DisPosition,
            this.m_NormalStyle,
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
            this.dgv_ResultViewList.Size = new System.Drawing.Size(642, 234);
            this.dgv_ResultViewList.TabIndex = 28;
            this.dgv_ResultViewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ResultViewList_CellClick);
            this.dgv_ResultViewList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ResultViewList_CellDoubleClick);
            // 
            // m_DataType
            // 
            this.m_DataType.DataPropertyName = "m_DataType";
            this.m_DataType.Frozen = true;
            this.m_DataType.HeaderText = "变量类型";
            this.m_DataType.Name = "m_DataType";
            this.m_DataType.ReadOnly = true;
            this.m_DataType.Width = 110;
            // 
            // m_VariableName
            // 
            this.m_VariableName.DataPropertyName = "m_VariableName";
            this.m_VariableName.Frozen = true;
            this.m_VariableName.HeaderText = "变量名称";
            this.m_VariableName.Name = "m_VariableName";
            this.m_VariableName.ReadOnly = true;
            this.m_VariableName.Width = 110;
            // 
            // m_ConditionVarName
            // 
            this.m_ConditionVarName.DataPropertyName = "m_ConditionVarName";
            this.m_ConditionVarName.Frozen = true;
            this.m_ConditionVarName.HeaderText = "样式条件变量";
            this.m_ConditionVarName.Name = "m_ConditionVarName";
            this.m_ConditionVarName.ReadOnly = true;
            this.m_ConditionVarName.Width = 110;
            // 
            // m_DisPosition
            // 
            this.m_DisPosition.DataPropertyName = "m_DisPosition";
            this.m_DisPosition.Frozen = true;
            this.m_DisPosition.HeaderText = "显示位置";
            this.m_DisPosition.Name = "m_DisPosition";
            this.m_DisPosition.ReadOnly = true;
            this.m_DisPosition.Width = 110;
            // 
            // m_NormalStyle
            // 
            this.m_NormalStyle.DataPropertyName = "m_NormalStyle";
            this.m_NormalStyle.Frozen = true;
            this.m_NormalStyle.HeaderText = "常规样式";
            this.m_NormalStyle.Name = "m_NormalStyle";
            this.m_NormalStyle.ReadOnly = true;
            this.m_NormalStyle.Width = 110;
            // 
            // m_NgColor
            // 
            this.m_NgColor.DataPropertyName = "m_NgColor";
            this.m_NgColor.Frozen = true;
            this.m_NgColor.HeaderText = "NG颜色";
            this.m_NgColor.Name = "m_NgColor";
            this.m_NgColor.ReadOnly = true;
            // 
            // check_Visible
            // 
            this.check_Visible.AutoSize = true;
            this.check_Visible.Location = new System.Drawing.Point(509, 24);
            this.check_Visible.Name = "check_Visible";
            this.check_Visible.Size = new System.Drawing.Size(72, 16);
            this.check_Visible.TabIndex = 4;
            this.check_Visible.Text = "是否显示";
            this.check_Visible.UseVisualStyleBackColor = true;
            // 
            // frm_Unit_ResultView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(662, 575);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_ResultView2";
            this.Text = "结果展示2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_ResultView2_FormClosing);
            this.Load += new System.EventHandler(this.frm_Unit_ResultView2_Load);
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
        private System.Windows.Forms.Button bt_Condition;
        private System.Windows.Forms.Button bt_Font;
        private System.Windows.Forms.TextBox txt_Position;
        private System.Windows.Forms.ComboBox cmb_VariableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.DataGridView dgv_ResultViewList;
        private System.Windows.Forms.ComboBox cmb_Condition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_SetDisPosition;
        private System.Windows.Forms.CheckBox check_Visible;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_VariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ConditionVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DisPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_NormalStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_NgColor;
        private System.Windows.Forms.ComboBox cmb_Attribute;
        private System.Windows.Forms.Label label4;
    }
}
