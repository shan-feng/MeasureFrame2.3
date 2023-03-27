namespace MeasureFrame.IUI
{
    partial class frm_Unit_HalconEngine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Broswe = new System.Windows.Forms.Button();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_VariableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabP_In = new System.Windows.Forms.TabPage();
            this.dgv_InList = new System.Windows.Forms.DataGridView();
            this.m_Data_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_DataTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_RemoveAll = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.tabP_out = new System.Windows.Forms.TabPage();
            this.dgv_OutList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.bt_Edit2 = new System.Windows.Forms.Button();
            this.bt_add2 = new System.Windows.Forms.Button();
            this.bt_Delete2 = new System.Windows.Forms.Button();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabP_In.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InList)).BeginInit();
            this.tabP_out.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OutList)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Size = new System.Drawing.Size(879, 62);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tab_Main.Size = new System.Drawing.Size(879, 696);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.tabMain);
            this.gb_main.Controls.Add(this.groupBox2);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Size = new System.Drawing.Size(861, 657);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 25);
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabP_baseSetting.Size = new System.Drawing.Size(871, 667);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Broswe);
            this.groupBox1.Controls.Add(this.txt_FilePath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(851, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "脚本路径";
            // 
            // bt_Broswe
            // 
            this.bt_Broswe.Location = new System.Drawing.Point(595, 38);
            this.bt_Broswe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Broswe.Name = "bt_Broswe";
            this.bt_Broswe.Size = new System.Drawing.Size(100, 30);
            this.bt_Broswe.TabIndex = 8;
            this.bt_Broswe.Text = "浏览";
            this.bt_Broswe.UseVisualStyleBackColor = true;
            this.bt_Broswe.Click += new System.EventHandler(this.bt_Broswe_Click);
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Location = new System.Drawing.Point(75, 41);
            this.txt_FilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.ReadOnly = true;
            this.txt_FilePath.Size = new System.Drawing.Size(491, 25);
            this.txt_FilePath.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_VariableName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmb_DataType);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 113);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(851, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变量选择";
            // 
            // cmb_VariableName
            // 
            this.cmb_VariableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VariableName.FormattingEnabled = true;
            this.cmb_VariableName.Location = new System.Drawing.Point(569, 26);
            this.cmb_VariableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_VariableName.Name = "cmb_VariableName";
            this.cmb_VariableName.Size = new System.Drawing.Size(160, 23);
            this.cmb_VariableName.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "变量名称：";
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Items.AddRange(new object[] {
            "数值型",
            "字符串",
            "旋转矩形",
            "图像",
            "椭圆",
            "圆",
            "直线"});
            this.cmb_DataType.Location = new System.Drawing.Point(207, 26);
            this.cmb_DataType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(160, 23);
            this.cmb_DataType.TabIndex = 9;
            this.cmb_DataType.SelectedIndexChanged += new System.EventHandler(this.cmb_DataType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "变量类型：";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabP_In);
            this.tabMain.Controls.Add(this.tabP_out);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(5, 191);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(851, 461);
            this.tabMain.TabIndex = 2;
            // 
            // tabP_In
            // 
            this.tabP_In.Controls.Add(this.dgv_InList);
            this.tabP_In.Controls.Add(this.bt_RemoveAll);
            this.tabP_In.Controls.Add(this.bt_Edit);
            this.tabP_In.Controls.Add(this.bt_Add);
            this.tabP_In.Controls.Add(this.bt_Delete);
            this.tabP_In.Location = new System.Drawing.Point(4, 25);
            this.tabP_In.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_In.Name = "tabP_In";
            this.tabP_In.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_In.Size = new System.Drawing.Size(843, 432);
            this.tabP_In.TabIndex = 0;
            this.tabP_In.Text = "输入参数列表";
            this.tabP_In.UseVisualStyleBackColor = true;
            // 
            // dgv_InList
            // 
            this.dgv_InList.AllowUserToAddRows = false;
            this.dgv_InList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_InList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_InList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgv_InList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_InList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_InList.Location = new System.Drawing.Point(4, 73);
            this.dgv_InList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_InList.Name = "dgv_InList";
            this.dgv_InList.ReadOnly = true;
            this.dgv_InList.RowHeadersWidth = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_InList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_InList.RowTemplate.Height = 23;
            this.dgv_InList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_InList.Size = new System.Drawing.Size(835, 355);
            this.dgv_InList.TabIndex = 29;
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
            // bt_RemoveAll
            // 
            this.bt_RemoveAll.Location = new System.Drawing.Point(568, 18);
            this.bt_RemoveAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_RemoveAll.Name = "bt_RemoveAll";
            this.bt_RemoveAll.Size = new System.Drawing.Size(100, 46);
            this.bt_RemoveAll.TabIndex = 28;
            this.bt_RemoveAll.Text = "全部删除";
            this.bt_RemoveAll.UseVisualStyleBackColor = true;
            this.bt_RemoveAll.Click += new System.EventHandler(this.bt_RemoveAll_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(248, 16);
            this.bt_Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(100, 48);
            this.bt_Edit.TabIndex = 27;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(77, 15);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(100, 48);
            this.bt_Add.TabIndex = 26;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(408, 16);
            this.bt_Delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(100, 46);
            this.bt_Delete.TabIndex = 24;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // tabP_out
            // 
            this.tabP_out.Controls.Add(this.dgv_OutList);
            this.tabP_out.Controls.Add(this.bt_Clear);
            this.tabP_out.Controls.Add(this.bt_Edit2);
            this.tabP_out.Controls.Add(this.bt_add2);
            this.tabP_out.Controls.Add(this.bt_Delete2);
            this.tabP_out.Location = new System.Drawing.Point(4, 25);
            this.tabP_out.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_out.Name = "tabP_out";
            this.tabP_out.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_out.Size = new System.Drawing.Size(1112, 302);
            this.tabP_out.TabIndex = 1;
            this.tabP_out.Text = "输出参数列表";
            this.tabP_out.UseVisualStyleBackColor = true;
            // 
            // dgv_OutList
            // 
            this.dgv_OutList.AllowUserToAddRows = false;
            this.dgv_OutList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_OutList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_OutList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OutList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_OutList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_OutList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_OutList.Location = new System.Drawing.Point(4, -57);
            this.dgv_OutList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_OutList.Name = "dgv_OutList";
            this.dgv_OutList.ReadOnly = true;
            this.dgv_OutList.RowHeadersWidth = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_OutList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_OutList.RowTemplate.Height = 23;
            this.dgv_OutList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_OutList.Size = new System.Drawing.Size(1104, 355);
            this.dgv_OutList.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "m_Data_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "m_Data_Type";
            this.dataGridViewTextBoxColumn2.HeaderText = "类型";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "m_Data_Num";
            this.dataGridViewTextBoxColumn3.HeaderText = "变量个数";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "m_DataTip";
            this.dataGridViewTextBoxColumn4.HeaderText = "备注";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(568, 12);
            this.bt_Clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(100, 46);
            this.bt_Clear.TabIndex = 33;
            this.bt_Clear.Text = "全部删除";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // bt_Edit2
            // 
            this.bt_Edit2.Location = new System.Drawing.Point(248, 11);
            this.bt_Edit2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Edit2.Name = "bt_Edit2";
            this.bt_Edit2.Size = new System.Drawing.Size(100, 48);
            this.bt_Edit2.TabIndex = 32;
            this.bt_Edit2.Text = "修改";
            this.bt_Edit2.UseVisualStyleBackColor = true;
            this.bt_Edit2.Click += new System.EventHandler(this.bt_Edit2_Click);
            // 
            // bt_add2
            // 
            this.bt_add2.Location = new System.Drawing.Point(77, 10);
            this.bt_add2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_add2.Name = "bt_add2";
            this.bt_add2.Size = new System.Drawing.Size(100, 48);
            this.bt_add2.TabIndex = 31;
            this.bt_add2.Text = "添加";
            this.bt_add2.UseVisualStyleBackColor = true;
            this.bt_add2.Click += new System.EventHandler(this.bt_add2_Click);
            // 
            // bt_Delete2
            // 
            this.bt_Delete2.Location = new System.Drawing.Point(408, 11);
            this.bt_Delete2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Delete2.Name = "bt_Delete2";
            this.bt_Delete2.Size = new System.Drawing.Size(100, 46);
            this.bt_Delete2.TabIndex = 29;
            this.bt_Delete2.Text = "删除";
            this.bt_Delete2.UseVisualStyleBackColor = true;
            this.bt_Delete2.Click += new System.EventHandler(this.bt_Delete2_Click);
            // 
            // frm_Unit_HalconEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 830);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Unit_HalconEngine";
            this.Text = "frm_Unit_HalconEngine";
            this.Load += new System.EventHandler(this.frm_Unit_HalconEngine_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabP_In.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InList)).EndInit();
            this.tabP_out.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OutList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Broswe;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabP_In;
        private System.Windows.Forms.TabPage tabP_out;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_VariableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_RemoveAll;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button bt_Edit2;
        private System.Windows.Forms.Button bt_add2;
        private System.Windows.Forms.Button bt_Delete2;
        private System.Windows.Forms.DataGridView dgv_InList;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataTip;
        private System.Windows.Forms.DataGridView dgv_OutList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}