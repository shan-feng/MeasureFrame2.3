namespace MeasureFrame.IUI
{
    partial class frm_Unit_Measure
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.num_MeasureDis = new System.Windows.Forms.NumericUpDown();
            this.num_Threshold = new System.Windows.Forms.NumericUpDown();
            this.num_Length2 = new System.Windows.Forms.NumericUpDown();
            this.num_Length1 = new System.Windows.Forms.NumericUpDown();
            this.cb_Select = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Direction = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Transition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Color = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCorrect = new System.Windows.Forms.CheckBox();
            this.bt_Paint = new System.Windows.Forms.Button();
            this.bt_draw = new System.Windows.Forms.Button();
            this.cmb_PositionUnitID = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_CurrentImg = new System.Windows.Forms.ComboBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MeasureDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.label12);
            this.gb_top.Controls.Add(this.cmb_CurrentImg);
            this.gb_top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_top.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_top.Size = new System.Drawing.Size(661, 50);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            this.gb_top.Controls.SetChildIndex(this.cmb_CurrentImg, 0);
            this.gb_top.Controls.SetChildIndex(this.label12, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_Main.Size = new System.Drawing.Size(661, 379);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox2);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Location = new System.Drawing.Point(4, 4);
            this.gb_main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_main.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_main.Size = new System.Drawing.Size(645, 345);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Size = new System.Drawing.Size(653, 353);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.num_MeasureDis);
            this.groupBox1.Controls.Add(this.num_Threshold);
            this.groupBox1.Controls.Add(this.num_Length2);
            this.groupBox1.Controls.Add(this.num_Length1);
            this.groupBox1.Controls.Add(this.cb_Select);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cb_Direction);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_Transition);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bt_Color);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(4, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // num_MeasureDis
            // 
            this.num_MeasureDis.Location = new System.Drawing.Point(130, 178);
            this.num_MeasureDis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_MeasureDis.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MeasureDis.Name = "num_MeasureDis";
            this.num_MeasureDis.Size = new System.Drawing.Size(100, 21);
            this.num_MeasureDis.TabIndex = 35;
            this.num_MeasureDis.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // num_Threshold
            // 
            this.num_Threshold.Location = new System.Drawing.Point(131, 139);
            this.num_Threshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_Threshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Threshold.Name = "num_Threshold";
            this.num_Threshold.Size = new System.Drawing.Size(100, 21);
            this.num_Threshold.TabIndex = 34;
            this.num_Threshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // num_Length2
            // 
            this.num_Length2.Location = new System.Drawing.Point(131, 102);
            this.num_Length2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_Length2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Length2.Name = "num_Length2";
            this.num_Length2.Size = new System.Drawing.Size(100, 21);
            this.num_Length2.TabIndex = 33;
            this.num_Length2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // num_Length1
            // 
            this.num_Length1.Location = new System.Drawing.Point(131, 64);
            this.num_Length1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.num_Length1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Length1.Name = "num_Length1";
            this.num_Length1.Size = new System.Drawing.Size(100, 21);
            this.num_Length1.TabIndex = 32;
            this.num_Length1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // cb_Select
            // 
            this.cb_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Select.FormattingEnabled = true;
            this.cb_Select.Items.AddRange(new object[] {
            "First",
            "Last",
            "All",
            "Strongest"});
            this.cb_Select.Location = new System.Drawing.Point(133, 289);
            this.cb_Select.Name = "cb_Select";
            this.cb_Select.Size = new System.Drawing.Size(100, 20);
            this.cb_Select.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "筛选  :";
            // 
            // cb_Direction
            // 
            this.cb_Direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Direction.FormattingEnabled = true;
            this.cb_Direction.Items.AddRange(new object[] {
            "默认值",
            "顺时针",
            "逆时针"});
            this.cb_Direction.Location = new System.Drawing.Point(132, 248);
            this.cb_Direction.Name = "cb_Direction";
            this.cb_Direction.Size = new System.Drawing.Size(100, 20);
            this.cb_Direction.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "方向  :";
            // 
            // cb_Transition
            // 
            this.cb_Transition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Transition.FormattingEnabled = true;
            this.cb_Transition.Items.AddRange(new object[] {
            "由白到黑",
            "由黑到白",
            "所有",
            "规格一致"});
            this.cb_Transition.Location = new System.Drawing.Point(131, 212);
            this.cb_Transition.Name = "cb_Transition";
            this.cb_Transition.Size = new System.Drawing.Size(100, 20);
            this.cb_Transition.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "模式  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "间隔 (pix) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "阈值  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "高度(pix) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "宽度(pix) :";
            // 
            // bt_Color
            // 
            this.bt_Color.BackColor = System.Drawing.Color.Red;
            this.bt_Color.ForeColor = System.Drawing.Color.White;
            this.bt_Color.Location = new System.Drawing.Point(129, 20);
            this.bt_Color.Name = "bt_Color";
            this.bt_Color.Size = new System.Drawing.Size(100, 29);
            this.bt_Color.TabIndex = 13;
            this.bt_Color.UseVisualStyleBackColor = false;
            this.bt_Color.Click += new System.EventHandler(this.bt_Color_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "颜色：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCorrect);
            this.groupBox2.Controls.Add(this.bt_Paint);
            this.groupBox2.Controls.Add(this.bt_draw);
            this.groupBox2.Controls.Add(this.cmb_PositionUnitID);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(332, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 323);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // chkCorrect
            // 
            this.chkCorrect.AutoSize = true;
            this.chkCorrect.Location = new System.Drawing.Point(95, 108);
            this.chkCorrect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkCorrect.Name = "chkCorrect";
            this.chkCorrect.Size = new System.Drawing.Size(96, 16);
            this.chkCorrect.TabIndex = 44;
            this.chkCorrect.Text = "涂抹启用补正";
            this.chkCorrect.UseVisualStyleBackColor = true;
            // 
            // bt_Paint
            // 
            this.bt_Paint.Location = new System.Drawing.Point(198, 103);
            this.bt_Paint.Name = "bt_Paint";
            this.bt_Paint.Size = new System.Drawing.Size(84, 23);
            this.bt_Paint.TabIndex = 43;
            this.bt_Paint.Text = "涂抹绘制";
            this.bt_Paint.UseVisualStyleBackColor = true;
            this.bt_Paint.Click += new System.EventHandler(this.bt_DisableRegion_Click);
            // 
            // bt_draw
            // 
            this.bt_draw.Location = new System.Drawing.Point(198, 61);
            this.bt_draw.Name = "bt_draw";
            this.bt_draw.Size = new System.Drawing.Size(84, 23);
            this.bt_draw.TabIndex = 37;
            this.bt_draw.Text = "绘制";
            this.bt_draw.UseVisualStyleBackColor = true;
            // 
            // cmb_PositionUnitID
            // 
            this.cmb_PositionUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PositionUnitID.FormattingEnabled = true;
            this.cmb_PositionUnitID.Location = new System.Drawing.Point(95, 61);
            this.cmb_PositionUnitID.Name = "cmb_PositionUnitID";
            this.cmb_PositionUnitID.Size = new System.Drawing.Size(82, 20);
            this.cmb_PositionUnitID.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "参考位置 :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "当前图像：";
            // 
            // cmb_CurrentImg
            // 
            this.cmb_CurrentImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CurrentImg.FormattingEnabled = true;
            this.cmb_CurrentImg.Location = new System.Drawing.Point(527, 21);
            this.cmb_CurrentImg.Name = "cmb_CurrentImg";
            this.cmb_CurrentImg.Size = new System.Drawing.Size(106, 20);
            this.cmb_CurrentImg.TabIndex = 18;
            // 
            // frm_Unit_Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(661, 487);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_Unit_Measure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_Measure_FormClosing);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MeasureDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cb_Direction;
        protected System.Windows.Forms.ComboBox cb_Select;
        protected System.Windows.Forms.Button bt_draw;
        private System.Windows.Forms.Label label12;
        protected System.Windows.Forms.ComboBox cmb_CurrentImg;
        protected System.Windows.Forms.ComboBox cmb_PositionUnitID;
        protected System.Windows.Forms.Button bt_Color;
        private System.Windows.Forms.Button bt_Paint;
        private System.Windows.Forms.CheckBox chkCorrect;
        protected System.Windows.Forms.ComboBox cb_Transition;
        private System.Windows.Forms.NumericUpDown num_MeasureDis;
        private System.Windows.Forms.NumericUpDown num_Threshold;
        private System.Windows.Forms.NumericUpDown num_Length2;
        private System.Windows.Forms.NumericUpDown num_Length1;
    }
}
