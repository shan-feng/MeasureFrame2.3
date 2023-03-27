namespace MeasureFrame.IUI
{
    partial class frm_Unit_MeasureEllipse
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
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_Phi = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.nudRadius2 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudRadius1 = new System.Windows.Forms.NumericUpDown();
            this.nudCenterY = new System.Windows.Forms.NumericUpDown();
            this.nudCenterX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Phi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(436, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(447, 401);
            this.groupBox2.Controls.SetChildIndex(this.cmb_PositionUnitID, 0);
            this.groupBox2.Controls.SetChildIndex(this.bt_draw, 0);
            this.groupBox2.Controls.SetChildIndex(this.groupBox3, 0);
            // 
            // bt_draw
            // 
            this.bt_draw.Click += new System.EventHandler(this.bt_draw_Click);
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // gb_top
            // 
            this.gb_top.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_top.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_top.Size = new System.Drawing.Size(912, 62);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tab_Main.Size = new System.Drawing.Size(912, 472);
            // 
            // gb_main
            // 
            this.gb_main.Location = new System.Drawing.Point(7, 6);
            this.gb_main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Size = new System.Drawing.Size(890, 431);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Size = new System.Drawing.Size(904, 443);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "Center X (pix) :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nud_Phi);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.nudRadius2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.nudRadius1);
            this.groupBox3.Controls.Add(this.nudCenterY);
            this.groupBox3.Controls.Add(this.nudCenterX);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(5, 168);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(437, 228);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "椭圆信息";
            // 
            // nud_Phi
            // 
            this.nud_Phi.DecimalPlaces = 3;
            this.nud_Phi.Location = new System.Drawing.Point(101, 178);
            this.nud_Phi.Margin = new System.Windows.Forms.Padding(4);
            this.nud_Phi.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_Phi.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_Phi.Name = "nud_Phi";
            this.nud_Phi.Size = new System.Drawing.Size(117, 25);
            this.nud_Phi.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 180);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 15);
            this.label17.TabIndex = 32;
            this.label17.Text = "角度:";
            // 
            // nudRadius2
            // 
            this.nudRadius2.DecimalPlaces = 3;
            this.nudRadius2.Location = new System.Drawing.Point(316, 112);
            this.nudRadius2.Margin = new System.Windows.Forms.Padding(4);
            this.nudRadius2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRadius2.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudRadius2.Name = "nudRadius2";
            this.nudRadius2.Size = new System.Drawing.Size(117, 25);
            this.nudRadius2.TabIndex = 31;
            this.nudRadius2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(223, 116);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "短半径(mm):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(218, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "椭圆心Y(mm):";
            // 
            // nudRadius1
            // 
            this.nudRadius1.DecimalPlaces = 3;
            this.nudRadius1.Location = new System.Drawing.Point(101, 112);
            this.nudRadius1.Margin = new System.Windows.Forms.Padding(4);
            this.nudRadius1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRadius1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudRadius1.Name = "nudRadius1";
            this.nudRadius1.Size = new System.Drawing.Size(117, 25);
            this.nudRadius1.TabIndex = 28;
            this.nudRadius1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudCenterY
            // 
            this.nudCenterY.DecimalPlaces = 3;
            this.nudCenterY.Location = new System.Drawing.Point(320, 43);
            this.nudCenterY.Margin = new System.Windows.Forms.Padding(4);
            this.nudCenterY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCenterY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudCenterY.Name = "nudCenterY";
            this.nudCenterY.Size = new System.Drawing.Size(117, 25);
            this.nudCenterY.TabIndex = 27;
            // 
            // nudCenterX
            // 
            this.nudCenterX.DecimalPlaces = 3;
            this.nudCenterX.Location = new System.Drawing.Point(101, 43);
            this.nudCenterX.Margin = new System.Windows.Forms.Padding(4);
            this.nudCenterX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCenterX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudCenterX.Name = "nudCenterX";
            this.nudCenterX.Size = new System.Drawing.Size(117, 25);
            this.nudCenterX.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 116);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "长半径(mm):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 48);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "椭圆心X(mm):";
            // 
            // frm_Unit_MeasureEllipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(912, 606);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frm_Unit_MeasureEllipse";
            this.Load += new System.EventHandler(this.frm_Unit_MeasureEllipse_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Phi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadius1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudRadius1;
        private System.Windows.Forms.NumericUpDown nudCenterY;
        private System.Windows.Forms.NumericUpDown nudCenterX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudRadius2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nud_Phi;
        private System.Windows.Forms.Label label17;
    }
}
