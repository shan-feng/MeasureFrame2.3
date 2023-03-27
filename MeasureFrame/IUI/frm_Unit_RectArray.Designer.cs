namespace MeasureFrame.IUI
{
    partial class frm_Unit_RectArray
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
            this.cmb_Filter = new System.Windows.Forms.ComboBox();
            this.cmb_refPosition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Color1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Phi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Length2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Length1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CenterY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CenterX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_RectArray = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.dgv_RectInfo = new System.Windows.Forms.DataGridView();
            this.CenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RectInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_top
            // 
            this.gb_top.Size = new System.Drawing.Size(607, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(607, 460);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.dgv_RectInfo);
            this.gb_main.Controls.Add(this.bt_DeleteAll);
            this.gb_main.Controls.Add(this.bt_Delete);
            this.gb_main.Controls.Add(this.bt_Edit);
            this.gb_main.Controls.Add(this.bt_Add);
            this.gb_main.Controls.Add(this.bt_RectArray);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.cmb_Filter);
            this.gb_main.Controls.Add(this.cmb_refPosition);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Size = new System.Drawing.Size(591, 426);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 22);
            this.tabP_baseSetting.Size = new System.Drawing.Size(599, 434);
            // 
            // cmb_Filter
            // 
            this.cmb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Filter.FormattingEnabled = true;
            this.cmb_Filter.Location = new System.Drawing.Point(452, 29);
            this.cmb_Filter.Name = "cmb_Filter";
            this.cmb_Filter.Size = new System.Drawing.Size(121, 20);
            this.cmb_Filter.TabIndex = 9;
            // 
            // cmb_refPosition
            // 
            this.cmb_refPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_refPosition.FormattingEnabled = true;
            this.cmb_refPosition.Location = new System.Drawing.Point(86, 29);
            this.cmb_refPosition.Name = "cmb_refPosition";
            this.cmb_refPosition.Size = new System.Drawing.Size(96, 20);
            this.cmb_refPosition.TabIndex = 8;
            this.cmb_refPosition.SelectedIndexChanged += new System.EventHandler(this.cmb_refPosition_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "参考位置：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "滤波方式：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Color1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txt_Phi);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_Length2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_Length1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_CenterY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_CenterX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 102);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区域信息";
            // 
            // bt_Color1
            // 
            this.bt_Color1.BackColor = System.Drawing.Color.Red;
            this.bt_Color1.ForeColor = System.Drawing.Color.White;
            this.bt_Color1.Location = new System.Drawing.Point(482, 20);
            this.bt_Color1.Name = "bt_Color1";
            this.bt_Color1.Size = new System.Drawing.Size(99, 29);
            this.bt_Color1.TabIndex = 19;
            this.bt_Color1.UseVisualStyleBackColor = false;
            this.bt_Color1.Click += new System.EventHandler(this.bt_Color1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(436, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "颜色：";
            // 
            // txt_Phi
            // 
            this.txt_Phi.Location = new System.Drawing.Point(482, 64);
            this.txt_Phi.Name = "txt_Phi";
            this.txt_Phi.Size = new System.Drawing.Size(100, 21);
            this.txt_Phi.TabIndex = 17;
            this.txt_Phi.Text = "0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "角度：";
            // 
            // txt_Length2
            // 
            this.txt_Length2.Location = new System.Drawing.Point(296, 64);
            this.txt_Length2.Name = "txt_Length2";
            this.txt_Length2.Size = new System.Drawing.Size(100, 21);
            this.txt_Length2.TabIndex = 15;
            this.txt_Length2.Text = "2.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "高度：";
            // 
            // txt_Length1
            // 
            this.txt_Length1.Location = new System.Drawing.Point(296, 22);
            this.txt_Length1.Name = "txt_Length1";
            this.txt_Length1.Size = new System.Drawing.Size(100, 21);
            this.txt_Length1.TabIndex = 13;
            this.txt_Length1.Text = "2.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "宽度：";
            // 
            // txt_CenterY
            // 
            this.txt_CenterY.Location = new System.Drawing.Point(105, 58);
            this.txt_CenterY.Name = "txt_CenterY";
            this.txt_CenterY.Size = new System.Drawing.Size(100, 21);
            this.txt_CenterY.TabIndex = 11;
            this.txt_CenterY.Text = "5.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "中心 X：";
            // 
            // txt_CenterX
            // 
            this.txt_CenterX.Location = new System.Drawing.Point(106, 22);
            this.txt_CenterX.Name = "txt_CenterX";
            this.txt_CenterX.Size = new System.Drawing.Size(100, 21);
            this.txt_CenterX.TabIndex = 9;
            this.txt_CenterX.Text = "5.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "中心 Y：";
            // 
            // bt_RectArray
            // 
            this.bt_RectArray.Location = new System.Drawing.Point(34, 178);
            this.bt_RectArray.Name = "bt_RectArray";
            this.bt_RectArray.Size = new System.Drawing.Size(75, 34);
            this.bt_RectArray.TabIndex = 13;
            this.bt_RectArray.Text = "区域阵列";
            this.bt_RectArray.UseVisualStyleBackColor = true;
            this.bt_RectArray.Click += new System.EventHandler(this.bt_RectArray_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(143, 178);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 34);
            this.bt_Add.TabIndex = 14;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(262, 178);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 34);
            this.bt_Edit.TabIndex = 15;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(378, 178);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 16;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(491, 178);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 17;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // dgv_RectInfo
            // 
            this.dgv_RectInfo.AllowUserToAddRows = false;
            this.dgv_RectInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RectInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_RectInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RectInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CenterX,
            this.CenterY,
            this.Length1,
            this.Length2,
            this.Phi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RectInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_RectInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_RectInfo.Location = new System.Drawing.Point(4, 215);
            this.dgv_RectInfo.Name = "dgv_RectInfo";
            this.dgv_RectInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_RectInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_RectInfo.RowTemplate.Height = 23;
            this.dgv_RectInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RectInfo.Size = new System.Drawing.Size(583, 207);
            this.dgv_RectInfo.TabIndex = 18;
            this.dgv_RectInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RectInfo_CellClick);
            this.dgv_RectInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RectInfo_RowPostPaint);
            // 
            // CenterX
            // 
            this.CenterX.DataPropertyName = "CenterX";
            this.CenterX.Frozen = true;
            this.CenterX.HeaderText = "中心X";
            this.CenterX.Name = "CenterX";
            this.CenterX.ReadOnly = true;
            this.CenterX.Width = 110;
            // 
            // CenterY
            // 
            this.CenterY.DataPropertyName = "CenterY";
            this.CenterY.Frozen = true;
            this.CenterY.HeaderText = "中心Y";
            this.CenterY.Name = "CenterY";
            this.CenterY.ReadOnly = true;
            this.CenterY.Width = 110;
            // 
            // Length1
            // 
            this.Length1.DataPropertyName = "Length1";
            this.Length1.Frozen = true;
            this.Length1.HeaderText = "宽";
            this.Length1.Name = "Length1";
            this.Length1.ReadOnly = true;
            this.Length1.Width = 110;
            // 
            // Length2
            // 
            this.Length2.DataPropertyName = "Length2";
            this.Length2.Frozen = true;
            this.Length2.HeaderText = "高";
            this.Length2.Name = "Length2";
            this.Length2.ReadOnly = true;
            this.Length2.Width = 110;
            // 
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.Frozen = true;
            this.Phi.HeaderText = "角度";
            this.Phi.Name = "Phi";
            this.Phi.ReadOnly = true;
            this.Phi.Width = 110;
            // 
            // frm_Unit_RectArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(607, 568);
            this.Name = "frm_Unit_RectArray";
            this.Load += new System.EventHandler(this.frm_Unit_RectArray_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RectInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Phi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Length2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Length1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_CenterY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CenterX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Filter;
        private System.Windows.Forms.ComboBox cmb_refPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_RectInfo;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_RectArray;
        private System.Windows.Forms.Button bt_Color1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
    }
}
