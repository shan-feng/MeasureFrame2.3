namespace MeasureFrame.IUI
{
    partial class frm_AutoRun
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
            this.txtbox_showLog = new System.Windows.Forms.RichTextBox();
            this.hWindow_HE1 = new ChoiceTech.Halcon.Control.HWindow_HE();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBothTest = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hWindow_HE2 = new ChoiceTech.Halcon.Control.HWindow_HE();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbox_showLog
            // 
            this.txtbox_showLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbox_showLog.Font = new System.Drawing.Font("宋体", 9F);
            this.txtbox_showLog.Location = new System.Drawing.Point(510, 362);
            this.txtbox_showLog.Name = "txtbox_showLog";
            this.txtbox_showLog.ReadOnly = true;
            this.txtbox_showLog.Size = new System.Drawing.Size(501, 135);
            this.txtbox_showLog.TabIndex = 808;
            this.txtbox_showLog.Text = "";
            // 
            // hWindow_HE1
            // 
            this.hWindow_HE1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_HE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_HE1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_HE1.DrawModel = false;
            this.hWindow_HE1.Image = null;
            this.hWindow_HE1.Location = new System.Drawing.Point(3, 3);
            this.hWindow_HE1.Name = "hWindow_HE1";
            this.hWindow_HE1.Size = new System.Drawing.Size(501, 353);
            this.hWindow_HE1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBothTest);
            this.panel1.Controls.Add(this.btnTest2);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 135);
            this.panel1.TabIndex = 8;
            // 
            // btnBothTest
            // 
            this.btnBothTest.Location = new System.Drawing.Point(52, 75);
            this.btnBothTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnBothTest.Name = "btnBothTest";
            this.btnBothTest.Size = new System.Drawing.Size(129, 35);
            this.btnBothTest.TabIndex = 8;
            this.btnBothTest.Text = "双线程运行";
            this.btnBothTest.UseVisualStyleBackColor = true;
            this.btnBothTest.Click += new System.EventHandler(this.btnBothTest_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(229, 23);
            this.btnTest2.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(129, 35);
            this.btnTest2.TabIndex = 7;
            this.btnTest2.Text = "测试工程2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(229, 75);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(129, 35);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止运行";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(52, 23);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 35);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "测试工程1";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtbox_showLog, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.hWindow_HE1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.hWindow_HE2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.90083F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.09917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1014, 500);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // hWindow_HE2
            // 
            this.hWindow_HE2.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_HE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_HE2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_HE2.DrawModel = false;
            this.hWindow_HE2.Image = null;
            this.hWindow_HE2.Location = new System.Drawing.Point(510, 3);
            this.hWindow_HE2.Name = "hWindow_HE2";
            this.hWindow_HE2.Size = new System.Drawing.Size(501, 353);
            this.hWindow_HE2.TabIndex = 809;
            // 
            // frm_AutoRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HideOnClose = true;
            this.Name = "frm_AutoRun";
            this.Text = "自动运行";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AutoRun_FormClosing);
            this.Load += new System.EventHandler(this.frm_AutoRun_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.RichTextBox txtbox_showLog;
        private ChoiceTech.Halcon.Control.HWindow_HE hWindow_HE1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnBothTest;
        internal System.Windows.Forms.Button btnTest2;
        internal System.Windows.Forms.Button btnStop;
        internal System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ChoiceTech.Halcon.Control.HWindow_HE hWindow_HE2;
    }
}