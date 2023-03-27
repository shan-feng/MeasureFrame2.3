namespace MeasureFrame.IUI
{
    partial class frm_Unit_MeasureLine
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
            this.nud_EndY = new System.Windows.Forms.NumericUpDown();
            this.nud_EndX = new System.Windows.Forms.NumericUpDown();
            this.nud_StartY = new System.Windows.Forms.NumericUpDown();
            this.nudStartX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(418, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(449, 405);
            this.groupBox2.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox2.Controls.SetChildIndex(this.cmb_PositionUnitID, 0);
            this.groupBox2.Controls.SetChildIndex(this.bt_draw, 0);
            // 
            // bt_draw
            // 
            this.bt_draw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_draw.Click += new System.EventHandler(this.bt_draw_Click);
            // 
            // cmb_PositionUnitID
            // 
            this.cmb_PositionUnitID.Location = new System.Drawing.Point(127, 77);
            this.cmb_PositionUnitID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_PositionUnitID.Size = new System.Drawing.Size(112, 23);
            // 
            // gb_top
            // 
            this.gb_top.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_top.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_top.Size = new System.Drawing.Size(896, 62);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tab_Main.Size = new System.Drawing.Size(896, 476);
            // 
            // gb_main
            // 
            this.gb_main.Location = new System.Drawing.Point(7, 6);
            this.gb_main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.gb_main.Size = new System.Drawing.Size(874, 435);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabP_baseSetting.Size = new System.Drawing.Size(888, 447);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "X (pix) :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nud_EndY);
            this.groupBox3.Controls.Add(this.nud_EndX);
            this.groupBox3.Controls.Add(this.nud_StartY);
            this.groupBox3.Controls.Add(this.nudStartX);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(5, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(439, 234);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "直线信息";
            // 
            // nud_EndY
            // 
            this.nud_EndY.DecimalPlaces = 3;
            this.nud_EndY.Location = new System.Drawing.Point(299, 150);
            this.nud_EndY.Margin = new System.Windows.Forms.Padding(4);
            this.nud_EndY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_EndY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_EndY.Name = "nud_EndY";
            this.nud_EndY.Size = new System.Drawing.Size(117, 25);
            this.nud_EndY.TabIndex = 17;
            this.nud_EndY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_EndX
            // 
            this.nud_EndX.DecimalPlaces = 3;
            this.nud_EndX.Location = new System.Drawing.Point(132, 150);
            this.nud_EndX.Margin = new System.Windows.Forms.Padding(4);
            this.nud_EndX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_EndX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_EndX.Name = "nud_EndX";
            this.nud_EndX.Size = new System.Drawing.Size(117, 25);
            this.nud_EndX.TabIndex = 16;
            this.nud_EndX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_StartY
            // 
            this.nud_StartY.DecimalPlaces = 3;
            this.nud_StartY.Location = new System.Drawing.Point(299, 58);
            this.nud_StartY.Margin = new System.Windows.Forms.Padding(4);
            this.nud_StartY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_StartY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_StartY.Name = "nud_StartY";
            this.nud_StartY.Size = new System.Drawing.Size(117, 25);
            this.nud_StartY.TabIndex = 15;
            this.nud_StartY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // nudStartX
            // 
            this.nudStartX.DecimalPlaces = 3;
            this.nudStartX.Location = new System.Drawing.Point(132, 58);
            this.nudStartX.Margin = new System.Windows.Forms.Padding(4);
            this.nudStartX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudStartX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudStartX.Name = "nudStartX";
            this.nudStartX.Size = new System.Drawing.Size(117, 25);
            this.nudStartX.TabIndex = 14;
            this.nudStartX.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 154);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "终点（mm）：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 60);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "起点（mm）：";
            // 
            // frm_Unit_MeasureLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(896, 610);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frm_Unit_MeasureLine";
            this.Load += new System.EventHandler(this.frm_Unit_MeasureLine_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EndX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_StartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_EndY;
        private System.Windows.Forms.NumericUpDown nud_EndX;
        private System.Windows.Forms.NumericUpDown nud_StartY;
        private System.Windows.Forms.NumericUpDown nudStartX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}
