namespace MeasureFrame.IUI
{
    partial class frm_Unit_Calculate
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ErrorInfo = new System.Windows.Forms.TextBox();
            this.bt_Compile = new System.Windows.Forms.Button();
            this.bt_Run = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.gb_top.Size = new System.Drawing.Size(836, 62);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(5);
            this.tab_Main.Size = new System.Drawing.Size(836, 591);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.bt_Run);
            this.gb_main.Controls.Add(this.bt_Compile);
            this.gb_main.Controls.Add(this.tableLayoutPanel1);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Margin = new System.Windows.Forms.Padding(5);
            this.gb_main.Padding = new System.Windows.Forms.Padding(5);
            this.gb_main.Size = new System.Drawing.Size(818, 552);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(660, 25);
            this.bt_Exit.Margin = new System.Windows.Forms.Padding(5);
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 25);
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Size = new System.Drawing.Size(828, 562);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(800, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算公式";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ErrorInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 433);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(800, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "错误提示";
            // 
            // txt_ErrorInfo
            // 
            this.txt_ErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ErrorInfo.Location = new System.Drawing.Point(4, 22);
            this.txt_ErrorInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ErrorInfo.Multiline = true;
            this.txt_ErrorInfo.Name = "txt_ErrorInfo";
            this.txt_ErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ErrorInfo.Size = new System.Drawing.Size(792, 61);
            this.txt_ErrorInfo.TabIndex = 0;
            // 
            // bt_Compile
            // 
            this.bt_Compile.Location = new System.Drawing.Point(661, 2);
            this.bt_Compile.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Compile.Name = "bt_Compile";
            this.bt_Compile.Size = new System.Drawing.Size(141, 36);
            this.bt_Compile.TabIndex = 3;
            this.bt_Compile.Text = "编 译";
            this.bt_Compile.UseVisualStyleBackColor = true;
            this.bt_Compile.Click += new System.EventHandler(this.bt_Compile_Click);
            // 
            // bt_Run
            // 
            this.bt_Run.Location = new System.Drawing.Point(495, 2);
            this.bt_Run.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Run.Name = "bt_Run";
            this.bt_Run.Size = new System.Drawing.Size(131, 36);
            this.bt_Run.TabIndex = 4;
            this.bt_Run.Text = "运行";
            this.bt_Run.UseVisualStyleBackColor = true;
            this.bt_Run.Click += new System.EventHandler(this.bt_Run_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.87023F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.12977F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 524);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // frm_Unit_Calculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(836, 725);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_Unit_Calculate";
            this.Load += new System.EventHandler(this.frm_Unit_Calculate_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_ErrorInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Compile;
        private System.Windows.Forms.Button bt_Run;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
