namespace MeasureFrame.IUI
{
    partial class frm_Unit_Delay
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
            this.nupDelayTimeMs = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDelayTimeMs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(5);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(433, 25);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(5);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Margin = new System.Windows.Forms.Padding(5);
            this.gb_top.Padding = new System.Windows.Forms.Padding(5);
            this.gb_top.Size = new System.Drawing.Size(840, 62);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(5);
            this.tab_Main.Size = new System.Drawing.Size(840, 591);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Margin = new System.Windows.Forms.Padding(5);
            this.gb_main.Padding = new System.Windows.Forms.Padding(5);
            this.gb_main.Size = new System.Drawing.Size(822, 552);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(660, 25);
            this.bt_Exit.Margin = new System.Windows.Forms.Padding(5);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 25);
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Size = new System.Drawing.Size(832, 562);
            // 
            // nupDelayTimeMs
            // 
            this.nupDelayTimeMs.Location = new System.Drawing.Point(221, 43);
            this.nupDelayTimeMs.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupDelayTimeMs.Name = "nupDelayTimeMs";
            this.nupDelayTimeMs.Size = new System.Drawing.Size(159, 25);
            this.nupDelayTimeMs.TabIndex = 1;
            this.nupDelayTimeMs.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nupDelayTimeMs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 524);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "延时时间(ms)";
            // 
            // frm_Unit_Delay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(840, 725);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_Unit_Delay";
            this.Load += new System.EventHandler(this.frm_Unit_Calculate_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupDelayTimeMs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupDelayTimeMs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}
