namespace MeasureFrame.IUI
{
    partial class frm_Unit_MeasureCircle
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
            this.label13 = new System.Windows.Forms.Label();
            this.nudRadus = new System.Windows.Forms.NumericUpDown();
            this.nudCenterY = new System.Windows.Forms.NumericUpDown();
            this.nudCenterX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(417, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(435, 403);
            this.groupBox2.Controls.SetChildIndex(this.cmb_PositionUnitID, 0);
            this.groupBox2.Controls.SetChildIndex(this.bt_draw, 0);
            this.groupBox2.Controls.SetChildIndex(this.groupBox3, 0);
            // 
            // bt_draw
            // 
            this.bt_draw.Click += new System.EventHandler(this.bt_draw_Click);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tab_Main.Size = new System.Drawing.Size(881, 474);
            // 
            // gb_main
            // 
            this.gb_main.Location = new System.Drawing.Point(7, 6);
            this.gb_main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Size = new System.Drawing.Size(859, 433);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Size = new System.Drawing.Size(873, 445);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.nudRadus);
            this.groupBox3.Controls.Add(this.nudCenterY);
            this.groupBox3.Controls.Add(this.nudCenterX);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(5, 170);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(425, 228);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "圆信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 105);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "圆心Y（mm）：";
            // 
            // nudRadus
            // 
            this.nudRadus.DecimalPlaces = 3;
            this.nudRadus.Location = new System.Drawing.Point(126, 148);
            this.nudRadus.Margin = new System.Windows.Forms.Padding(4);
            this.nudRadus.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRadus.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudRadus.Name = "nudRadus";
            this.nudRadus.Size = new System.Drawing.Size(117, 25);
            this.nudRadus.TabIndex = 22;
            this.nudRadus.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudCenterY
            // 
            this.nudCenterY.DecimalPlaces = 3;
            this.nudCenterY.Location = new System.Drawing.Point(126, 100);
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
            this.nudCenterY.TabIndex = 21;
            // 
            // nudCenterX
            // 
            this.nudCenterX.DecimalPlaces = 3;
            this.nudCenterX.Location = new System.Drawing.Point(126, 56);
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
            this.nudCenterX.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 152);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "半径（mm）：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 58);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 15);
            this.label15.TabIndex = 18;
            this.label15.Text = "圆心X（mm）：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "Center X (pix) :";
            // 
            // frm_Unit_MeasureCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(881, 608);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frm_Unit_MeasureCircle";
            this.Load += new System.EventHandler(this.frm_Unit_MeasureCircle_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRadus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudRadus;
        private System.Windows.Forms.NumericUpDown nudCenterY;
        private System.Windows.Forms.NumericUpDown nudCenterX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
    }
}
