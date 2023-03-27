namespace MeasureFrame.IUI
{
    partial class frm_Unit_CorrectPosition
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_disableAngle = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_ModelType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_EndPhi = new System.Windows.Forms.NumericUpDown();
            this.nud_StartPhi = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Color1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_Paint = new System.Windows.Forms.Button();
            this.bt_Draw1 = new System.Windows.Forms.Button();
            this.cmb_Shape1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Shape2 = new System.Windows.Forms.ComboBox();
            this.bt_Draw2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Color2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartPhi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_CurrentImg
            // 
            this.cmb_CurrentImg.SelectedIndexChanged += new System.EventHandler(this.cmb_CurrentImg_SelectedIndexChanged);
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Size = new System.Drawing.Size(618, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tab_Main.Size = new System.Drawing.Size(618, 327);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.groupBox3);
            this.gb_main.Controls.Add(this.groupBox2);
            this.gb_main.Location = new System.Drawing.Point(3, 3);
            this.gb_main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Size = new System.Drawing.Size(604, 295);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabP_baseSetting.Size = new System.Drawing.Size(610, 301);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_disableAngle);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.cmb_ModelType);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(5, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(594, 38);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模板类型";
            // 
            // chk_disableAngle
            // 
            this.chk_disableAngle.AutoSize = true;
            this.chk_disableAngle.Location = new System.Drawing.Point(324, 11);
            this.chk_disableAngle.Name = "chk_disableAngle";
            this.chk_disableAngle.Size = new System.Drawing.Size(120, 16);
            this.chk_disableAngle.TabIndex = 10;
            this.chk_disableAngle.Text = "屏蔽角度角度变化";
            this.chk_disableAngle.UseVisualStyleBackColor = true;
            this.chk_disableAngle.CheckedChanged += new System.EventHandler(this.chk_disableAngle_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "绘制";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmb_ModelType
            // 
            this.cmb_ModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ModelType.FormattingEnabled = true;
            this.cmb_ModelType.Items.AddRange(new object[] {
            "形状模板",
            "灰度模板"});
            this.cmb_ModelType.Location = new System.Drawing.Point(104, 8);
            this.cmb_ModelType.Name = "cmb_ModelType";
            this.cmb_ModelType.Size = new System.Drawing.Size(121, 20);
            this.cmb_ModelType.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_EndPhi);
            this.groupBox1.Controls.Add(this.nud_StartPhi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bt_Color1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.bt_Paint);
            this.groupBox1.Controls.Add(this.bt_Draw1);
            this.groupBox1.Controls.Add(this.cmb_Shape1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 137);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板区域";
            // 
            // nud_EndPhi
            // 
            this.nud_EndPhi.DecimalPlaces = 1;
            this.nud_EndPhi.Location = new System.Drawing.Point(381, 21);
            this.nud_EndPhi.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nud_EndPhi.Name = "nud_EndPhi";
            this.nud_EndPhi.Size = new System.Drawing.Size(120, 21);
            this.nud_EndPhi.TabIndex = 19;
            // 
            // nud_StartPhi
            // 
            this.nud_StartPhi.DecimalPlaces = 1;
            this.nud_StartPhi.Location = new System.Drawing.Point(105, 21);
            this.nud_StartPhi.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_StartPhi.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nud_StartPhi.Name = "nud_StartPhi";
            this.nud_StartPhi.Size = new System.Drawing.Size(120, 21);
            this.nud_StartPhi.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "结束角度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "开始角度：";
            // 
            // bt_Color1
            // 
            this.bt_Color1.BackColor = System.Drawing.Color.Lime;
            this.bt_Color1.ForeColor = System.Drawing.Color.White;
            this.bt_Color1.Location = new System.Drawing.Point(379, 57);
            this.bt_Color1.Name = "bt_Color1";
            this.bt_Color1.Size = new System.Drawing.Size(100, 29);
            this.bt_Color1.TabIndex = 15;
            this.bt_Color1.UseVisualStyleBackColor = false;
            this.bt_Color1.Click += new System.EventHandler(this.bt_Color1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "颜色：";
            // 
            // bt_Paint
            // 
            this.bt_Paint.Location = new System.Drawing.Point(500, 98);
            this.bt_Paint.Name = "bt_Paint";
            this.bt_Paint.Size = new System.Drawing.Size(75, 23);
            this.bt_Paint.TabIndex = 2;
            this.bt_Paint.Text = "涂抹绘制";
            this.bt_Paint.UseVisualStyleBackColor = true;
            this.bt_Paint.Click += new System.EventHandler(this.bt_Paint_Click);
            // 
            // bt_Draw1
            // 
            this.bt_Draw1.Location = new System.Drawing.Point(381, 98);
            this.bt_Draw1.Name = "bt_Draw1";
            this.bt_Draw1.Size = new System.Drawing.Size(75, 23);
            this.bt_Draw1.TabIndex = 2;
            this.bt_Draw1.Text = "绘制";
            this.bt_Draw1.UseVisualStyleBackColor = true;
            this.bt_Draw1.Click += new System.EventHandler(this.bt_Draw1_Click);
            // 
            // cmb_Shape1
            // 
            this.cmb_Shape1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Shape1.FormattingEnabled = true;
            this.cmb_Shape1.Items.AddRange(new object[] {
            "普通矩形",
            "旋转矩形",
            "圆",
            "椭圆",
            "涂抹区域"});
            this.cmb_Shape1.Location = new System.Drawing.Point(104, 57);
            this.cmb_Shape1.Name = "cmb_Shape1";
            this.cmb_Shape1.Size = new System.Drawing.Size(121, 20);
            this.cmb_Shape1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "区域形状：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "区域形状：";
            // 
            // cmb_Shape2
            // 
            this.cmb_Shape2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Shape2.FormattingEnabled = true;
            this.cmb_Shape2.Items.AddRange(new object[] {
            "普通矩形",
            "旋转矩形",
            "圆",
            "椭圆"});
            this.cmb_Shape2.Location = new System.Drawing.Point(104, 30);
            this.cmb_Shape2.Name = "cmb_Shape2";
            this.cmb_Shape2.Size = new System.Drawing.Size(121, 20);
            this.cmb_Shape2.TabIndex = 1;
            // 
            // bt_Draw2
            // 
            this.bt_Draw2.Location = new System.Drawing.Point(396, 63);
            this.bt_Draw2.Name = "bt_Draw2";
            this.bt_Draw2.Size = new System.Drawing.Size(75, 23);
            this.bt_Draw2.TabIndex = 2;
            this.bt_Draw2.Text = "绘制";
            this.bt_Draw2.UseVisualStyleBackColor = true;
            this.bt_Draw2.Click += new System.EventHandler(this.bt_Draw2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "颜色：";
            // 
            // bt_Color2
            // 
            this.bt_Color2.BackColor = System.Drawing.Color.Red;
            this.bt_Color2.ForeColor = System.Drawing.Color.White;
            this.bt_Color2.Location = new System.Drawing.Point(379, 25);
            this.bt_Color2.Name = "bt_Color2";
            this.bt_Color2.Size = new System.Drawing.Size(100, 29);
            this.bt_Color2.TabIndex = 17;
            this.bt_Color2.UseVisualStyleBackColor = false;
            this.bt_Color2.Click += new System.EventHandler(this.bt_Color2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_Color2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bt_Draw2);
            this.groupBox2.Controls.Add(this.cmb_Shape2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(5, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索区域";
            // 
            // frm_Unit_CorrectPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(618, 435);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Unit_CorrectPosition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_CorrectPosition_FormClosing);
            this.Load += new System.EventHandler(this.frm_Unit_CorrectPosition_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartPhi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Color1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_Draw1;
        private System.Windows.Forms.ComboBox cmb_Shape1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_ModelType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Color2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Draw2;
        private System.Windows.Forms.ComboBox cmb_Shape2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_disableAngle;
        private System.Windows.Forms.Button bt_Paint;
        private System.Windows.Forms.NumericUpDown nud_EndPhi;
        private System.Windows.Forms.NumericUpDown nud_StartPhi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}
