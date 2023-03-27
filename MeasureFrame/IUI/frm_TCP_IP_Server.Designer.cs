namespace MeasureFrame.IUI
{
    partial class frm_TCP_IP_Server
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tab_TCPServer = new System.Windows.Forms.TabControl();
            this.tabPage_Basic = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_testInfo = new System.Windows.Forms.TextBox();
            this.bt_Test = new System.Windows.Forms.Button();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.bt_Start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_IPaddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_delR = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_ErrorInfo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_Compile = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_Update = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab_TCPServer.SuspendLayout();
            this.tabPage_Basic.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage_delR.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Exit);
            this.groupBox1.Controls.Add(this.bt_Save);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(437, 445);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 27);
            this.bt_Exit.TabIndex = 13;
            this.bt_Exit.Text = "取消";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(292, 445);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 27);
            this.bt_Save.TabIndex = 12;
            this.bt_Save.Text = "确认";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tab_TCPServer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 422);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户的列表";
            // 
            // tab_TCPServer
            // 
            this.tab_TCPServer.Controls.Add(this.tabPage_Basic);
            this.tab_TCPServer.Controls.Add(this.tabPage_delR);
            this.tab_TCPServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_TCPServer.Location = new System.Drawing.Point(3, 17);
            this.tab_TCPServer.Name = "tab_TCPServer";
            this.tab_TCPServer.SelectedIndex = 0;
            this.tab_TCPServer.Size = new System.Drawing.Size(559, 402);
            this.tab_TCPServer.TabIndex = 0;
            // 
            // tabPage_Basic
            // 
            this.tabPage_Basic.Controls.Add(this.groupBox3);
            this.tabPage_Basic.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Basic.Name = "tabPage_Basic";
            this.tabPage_Basic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Basic.Size = new System.Drawing.Size(551, 376);
            this.tabPage_Basic.TabIndex = 0;
            this.tabPage_Basic.Text = "基本设置";
            this.tabPage_Basic.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_testInfo);
            this.groupBox3.Controls.Add(this.bt_Test);
            this.groupBox3.Controls.Add(this.bt_Stop);
            this.groupBox3.Controls.Add(this.txt_Port);
            this.groupBox3.Controls.Add(this.bt_Start);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_IPaddress);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 370);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器设置";
            // 
            // txt_testInfo
            // 
            this.txt_testInfo.Location = new System.Drawing.Point(115, 150);
            this.txt_testInfo.Name = "txt_testInfo";
            this.txt_testInfo.Size = new System.Drawing.Size(143, 21);
            this.txt_testInfo.TabIndex = 11;
            // 
            // bt_Test
            // 
            this.bt_Test.Location = new System.Drawing.Point(326, 150);
            this.bt_Test.Name = "bt_Test";
            this.bt_Test.Size = new System.Drawing.Size(75, 26);
            this.bt_Test.TabIndex = 10;
            this.bt_Test.Text = "在线测试";
            this.bt_Test.UseVisualStyleBackColor = true;
            this.bt_Test.Click += new System.EventHandler(this.bt_Test_Click);
            // 
            // bt_Stop
            // 
            this.bt_Stop.Location = new System.Drawing.Point(326, 237);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(75, 37);
            this.bt_Stop.TabIndex = 3;
            this.bt_Stop.Text = "断开";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(324, 58);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(77, 21);
            this.txt_Port.TabIndex = 9;
            // 
            // bt_Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(183, 237);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(75, 37);
            this.bt_Start.TabIndex = 2;
            this.bt_Start.Text = "启动";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "端口：";
            // 
            // txt_IPaddress
            // 
            this.txt_IPaddress.Location = new System.Drawing.Point(115, 58);
            this.txt_IPaddress.Name = "txt_IPaddress";
            this.txt_IPaddress.Size = new System.Drawing.Size(143, 21);
            this.txt_IPaddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "地址:";
            // 
            // tabPage_delR
            // 
            this.tabPage_delR.Controls.Add(this.groupBox5);
            this.tabPage_delR.Controls.Add(this.groupBox4);
            this.tabPage_delR.Location = new System.Drawing.Point(4, 22);
            this.tabPage_delR.Name = "tabPage_delR";
            this.tabPage_delR.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_delR.Size = new System.Drawing.Size(551, 376);
            this.tabPage_delR.TabIndex = 1;
            this.tabPage_delR.Text = "接收回调";
            this.tabPage_delR.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_ErrorInfo);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 277);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(545, 96);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "错误提示";
            // 
            // txt_ErrorInfo
            // 
            this.txt_ErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ErrorInfo.Location = new System.Drawing.Point(3, 17);
            this.txt_ErrorInfo.Multiline = true;
            this.txt_ErrorInfo.Name = "txt_ErrorInfo";
            this.txt_ErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ErrorInfo.Size = new System.Drawing.Size(539, 76);
            this.txt_ErrorInfo.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_Compile);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(545, 274);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "计算公式";
            // 
            // bt_Compile
            // 
            this.bt_Compile.Location = new System.Drawing.Point(467, 1);
            this.bt_Compile.Name = "bt_Compile";
            this.bt_Compile.Size = new System.Drawing.Size(75, 22);
            this.bt_Compile.TabIndex = 4;
            this.bt_Compile.Text = "编 译";
            this.bt_Compile.UseVisualStyleBackColor = true;
            this.bt_Compile.Click += new System.EventHandler(this.bt_Compile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(571, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "未启动服务";
            // 
            // timer_Update
            // 
            this.timer_Update.Enabled = true;
            this.timer_Update.Tick += new System.EventHandler(this.timer_Update_Tick);
            // 
            // frm_TCP_IP_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "frm_TCP_IP_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_TCP_IP_Server";
            this.Load += new System.EventHandler(this.frm_TCP_IP_Server_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tab_TCPServer.ResumeLayout(false);
            this.tabPage_Basic.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage_delR.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tab_TCPServer;
        private System.Windows.Forms.TabPage tabPage_Basic;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_Test;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_IPaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage_delR;
        private System.Windows.Forms.TextBox txt_testInfo;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_ErrorInfo;
        private System.Windows.Forms.Button bt_Compile;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Timer timer_Update;
    }
}