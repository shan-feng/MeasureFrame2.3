namespace MeasureFrame.IUI
{
    partial class frm_VariableSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Attribute = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.check_Array = new System.Windows.Forms.CheckBox();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Tip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_InitValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_VaviableList = new System.Windows.Forms.DataGridView();
            this.m_Data_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_InitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Atrr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_DataTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_CellID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mUserDefined = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Data_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VaviableList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Attribute);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.check_Array);
            this.groupBox1.Controls.Add(this.cmb_DataType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Tip);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_InitValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmb_Attribute
            // 
            this.cmb_Attribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Attribute.FormattingEnabled = true;
            this.cmb_Attribute.Location = new System.Drawing.Point(110, 65);
            this.cmb_Attribute.Name = "cmb_Attribute";
            this.cmb_Attribute.Size = new System.Drawing.Size(121, 20);
            this.cmb_Attribute.TabIndex = 10;
            this.cmb_Attribute.SelectedIndexChanged += new System.EventHandler(this.cmb_Attribute_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "作用范围：";
            // 
            // check_Array
            // 
            this.check_Array.AutoSize = true;
            this.check_Array.Location = new System.Drawing.Point(354, 111);
            this.check_Array.Name = "check_Array";
            this.check_Array.Size = new System.Drawing.Size(60, 16);
            this.check_Array.TabIndex = 8;
            this.check_Array.Text = "数组形";
            this.check_Array.UseVisualStyleBackColor = true;
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(109, 109);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(121, 20);
            this.cmb_DataType.TabIndex = 7;
            this.cmb_DataType.SelectedIndexChanged += new System.EventHandler(this.cmb_DataType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "变量类型：";
            // 
            // txt_Tip
            // 
            this.txt_Tip.Location = new System.Drawing.Point(423, 65);
            this.txt_Tip.Name = "txt_Tip";
            this.txt_Tip.Size = new System.Drawing.Size(133, 21);
            this.txt_Tip.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "变量备注：";
            // 
            // txt_InitValue
            // 
            this.txt_InitValue.Location = new System.Drawing.Point(423, 20);
            this.txt_InitValue.Name = "txt_InitValue";
            this.txt_InitValue.Size = new System.Drawing.Size(133, 21);
            this.txt_InitValue.TabIndex = 3;
            this.txt_InitValue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "变量初值：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(110, 21);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(133, 21);
            this.txt_Name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "变量名称：";
            // 
            // dgv_VaviableList
            // 
            this.dgv_VaviableList.AllowUserToAddRows = false;
            this.dgv_VaviableList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_VaviableList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_VaviableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_VaviableList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_Data_Name,
            this.m_Data_Type,
            this.m_Data_InitValue,
            this.m_Data_Group,
            this.m_Data_Atrr,
            this.m_DataTip,
            this.m_Data_CellID,
            this.mUserDefined,
            this.Value,
            this.m_Data_Num});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_VaviableList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_VaviableList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_VaviableList.Location = new System.Drawing.Point(0, 195);
            this.dgv_VaviableList.MultiSelect = false;
            this.dgv_VaviableList.Name = "dgv_VaviableList";
            this.dgv_VaviableList.ReadOnly = true;
            this.dgv_VaviableList.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_VaviableList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_VaviableList.RowTemplate.Height = 23;
            this.dgv_VaviableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_VaviableList.Size = new System.Drawing.Size(661, 295);
            this.dgv_VaviableList.TabIndex = 19;
            this.dgv_VaviableList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_VaviableList_CellClick);
            // 
            // m_Data_Name
            // 
            this.m_Data_Name.DataPropertyName = "m_Data_Name";
            this.m_Data_Name.Frozen = true;
            this.m_Data_Name.HeaderText = "名称";
            this.m_Data_Name.Name = "m_Data_Name";
            this.m_Data_Name.ReadOnly = true;
            this.m_Data_Name.Width = 110;
            // 
            // m_Data_Type
            // 
            this.m_Data_Type.DataPropertyName = "m_Data_Type";
            this.m_Data_Type.Frozen = true;
            this.m_Data_Type.HeaderText = "类型";
            this.m_Data_Type.Name = "m_Data_Type";
            this.m_Data_Type.ReadOnly = true;
            this.m_Data_Type.Width = 110;
            // 
            // m_Data_InitValue
            // 
            this.m_Data_InitValue.DataPropertyName = "m_Data_InitValue";
            this.m_Data_InitValue.Frozen = true;
            this.m_Data_InitValue.HeaderText = "初始值";
            this.m_Data_InitValue.Name = "m_Data_InitValue";
            this.m_Data_InitValue.ReadOnly = true;
            this.m_Data_InitValue.Width = 110;
            // 
            // m_Data_Group
            // 
            this.m_Data_Group.DataPropertyName = "m_Data_Group";
            this.m_Data_Group.Frozen = true;
            this.m_Data_Group.HeaderText = "组合类型";
            this.m_Data_Group.Name = "m_Data_Group";
            this.m_Data_Group.ReadOnly = true;
            this.m_Data_Group.Width = 110;
            // 
            // m_Data_Atrr
            // 
            this.m_Data_Atrr.DataPropertyName = "m_Data_Atrr";
            this.m_Data_Atrr.Frozen = true;
            this.m_Data_Atrr.HeaderText = "作用范围";
            this.m_Data_Atrr.Name = "m_Data_Atrr";
            this.m_Data_Atrr.ReadOnly = true;
            this.m_Data_Atrr.Width = 110;
            // 
            // m_DataTip
            // 
            this.m_DataTip.DataPropertyName = "m_DataTip";
            this.m_DataTip.Frozen = true;
            this.m_DataTip.HeaderText = "备注";
            this.m_DataTip.Name = "m_DataTip";
            this.m_DataTip.ReadOnly = true;
            // 
            // m_Data_CellID
            // 
            this.m_Data_CellID.DataPropertyName = "m_Data_CellID";
            this.m_Data_CellID.Frozen = true;
            this.m_Data_CellID.HeaderText = "单元ID";
            this.m_Data_CellID.Name = "m_Data_CellID";
            this.m_Data_CellID.ReadOnly = true;
            // 
            // mUserDefined
            // 
            this.mUserDefined.DataPropertyName = "m_bUserDefineVariable";
            this.mUserDefined.Frozen = true;
            this.mUserDefined.HeaderText = "用户自定义";
            this.mUserDefined.Name = "mUserDefined";
            this.mUserDefined.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "m_Data_Value";
            this.Value.Frozen = true;
            this.Value.HeaderText = "值";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // m_Data_Num
            // 
            this.m_Data_Num.DataPropertyName = "m_Data_Num";
            this.m_Data_Num.Frozen = true;
            this.m_Data_Num.HeaderText = "变量个数";
            this.m_Data_Num.Name = "m_Data_Num";
            this.m_Data_Num.ReadOnly = true;
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(397, 157);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 23;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(284, 157);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 22;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(168, 157);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 34);
            this.bt_Edit.TabIndex = 21;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(49, 157);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 34);
            this.bt_Add.TabIndex = 20;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // frm_VariableSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 490);
            this.Controls.Add(this.bt_DeleteAll);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.dgv_VaviableList);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(200, 100);
            this.MaximizeBox = false;
            this.Name = "frm_VariableSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "变量设定[U0000]";
            this.Load += new System.EventHandler(this.frm_VariableSettingcs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_VaviableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox check_Array;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Tip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_InitValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Attribute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_VaviableList;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_InitValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Atrr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_CellID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mUserDefined;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Data_Num;
    }
}