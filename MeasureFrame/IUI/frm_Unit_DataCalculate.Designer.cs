namespace MeasureFrame.IUI
{
    partial class frm_Unit_DataCalculate
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
            this.cmb_Result = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_LimitDown = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_LimitUp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_B = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_K = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_VariableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.dgv_VariableList = new System.Windows.Forms.DataGridView();
            this.sVariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dLimitUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dLimitDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_RemoveAll = new System.Windows.Forms.Button();
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
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(543, 498);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Result);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_LimitDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_LimitUp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_B);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_K);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_VariableName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "存储设置";
            // 
            // cmb_Result
            // 
            this.cmb_Result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Result.FormattingEnabled = true;
            this.cmb_Result.Location = new System.Drawing.Point(338, 30);
            this.cmb_Result.Name = "cmb_Result";
            this.cmb_Result.Size = new System.Drawing.Size(121, 20);
            this.cmb_Result.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "输出判定结果：";
            // 
            // txt_LimitDown
            // 
            this.txt_LimitDown.Location = new System.Drawing.Point(322, 105);
            this.txt_LimitDown.Name = "txt_LimitDown";
            this.txt_LimitDown.Size = new System.Drawing.Size(100, 21);
            this.txt_LimitDown.TabIndex = 11;
            this.txt_LimitDown.Text = "-10000.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "判定下限：";
            // 
            // txt_LimitUp
            // 
            this.txt_LimitUp.Location = new System.Drawing.Point(88, 105);
            this.txt_LimitUp.Name = "txt_LimitUp";
            this.txt_LimitUp.Size = new System.Drawing.Size(100, 21);
            this.txt_LimitUp.TabIndex = 9;
            this.txt_LimitUp.Text = "10000.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "判定上限：";
            // 
            // txt_B
            // 
            this.txt_B.Location = new System.Drawing.Point(322, 67);
            this.txt_B.Name = "txt_B";
            this.txt_B.Size = new System.Drawing.Size(100, 21);
            this.txt_B.TabIndex = 7;
            this.txt_B.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "补偿B值：";
            // 
            // txt_K
            // 
            this.txt_K.Location = new System.Drawing.Point(88, 67);
            this.txt_K.Name = "txt_K";
            this.txt_K.Size = new System.Drawing.Size(100, 21);
            this.txt_K.TabIndex = 5;
            this.txt_K.Text = "1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "补偿K值：";
            // 
            // cmb_VariableName
            // 
            this.cmb_VariableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VariableName.FormattingEnabled = true;
            this.cmb_VariableName.Location = new System.Drawing.Point(88, 30);
            this.cmb_VariableName.Name = "cmb_VariableName";
            this.cmb_VariableName.Size = new System.Drawing.Size(121, 20);
            this.cmb_VariableName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "变量名称：";
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
            this.sVariableName,
            this.dK,
            this.dB,
            this.dLimitUp,
            this.dLimitDown});
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
            // sVariableName
            // 
            this.sVariableName.DataPropertyName = "sVariableName";
            this.sVariableName.HeaderText = "名称";
            this.sVariableName.Name = "sVariableName";
            this.sVariableName.ReadOnly = true;
            this.sVariableName.Width = 110;
            // 
            // dK
            // 
            this.dK.DataPropertyName = "dK";
            this.dK.HeaderText = "补偿K值";
            this.dK.Name = "dK";
            this.dK.ReadOnly = true;
            // 
            // dB
            // 
            this.dB.DataPropertyName = "dB";
            this.dB.HeaderText = "补偿B值";
            this.dB.Name = "dB";
            this.dB.ReadOnly = true;
            // 
            // dLimitUp
            // 
            this.dLimitUp.DataPropertyName = "dLimitUp";
            this.dLimitUp.HeaderText = "判定上限";
            this.dLimitUp.Name = "dLimitUp";
            this.dLimitUp.ReadOnly = true;
            // 
            // dLimitDown
            // 
            this.dLimitDown.DataPropertyName = "dLimitDown";
            this.dLimitDown.HeaderText = "判定下限";
            this.dLimitDown.Name = "dLimitDown";
            this.dLimitDown.ReadOnly = true;
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
            // frm_Unit_DataCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(551, 632);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_DataCalculate";
            this.Text = "数据判定";
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
        private System.Windows.Forms.DataGridView dgv_VariableList;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_RemoveAll;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.TextBox txt_LimitDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_LimitUp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_B;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_K;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sVariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dLimitUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dLimitDown;
        private System.Windows.Forms.ComboBox cmb_Result;
        private System.Windows.Forms.Label label7;
    }
}
