namespace AcqDevice
{
    partial class frm_AcqSVS_hrAttr
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Basic = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtxt_Mask = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_IPAdress = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_solftTrigger = new System.Windows.Forms.Button();
            this.txt_Framerate = new System.Windows.Forms.TextBox();
            this.txt_ExposeTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_TrigerMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_IO = new System.Windows.Forms.TabPage();
            this.bt_Save = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage_Basic.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Basic);
            this.tabControl.Controls.Add(this.tabPage_IO);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(546, 373);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_Basic
            // 
            this.tabPage_Basic.Controls.Add(this.groupBox2);
            this.tabPage_Basic.Controls.Add(this.groupBox1);
            this.tabPage_Basic.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Basic.Name = "tabPage_Basic";
            this.tabPage_Basic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Basic.Size = new System.Drawing.Size(538, 347);
            this.tabPage_Basic.TabIndex = 1;
            this.tabPage_Basic.Text = "基本设置";
            this.tabPage_Basic.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mtxt_Mask);
            this.groupBox2.Controls.Add(this.mtxt_IPAdress);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IP设置";
            // 
            // mtxt_Mask
            // 
            this.mtxt_Mask.Location = new System.Drawing.Point(254, 30);
            this.mtxt_Mask.Name = "mtxt_Mask";
            this.mtxt_Mask.PromptChar = '.';
            this.mtxt_Mask.Size = new System.Drawing.Size(156, 21);
            this.mtxt_Mask.TabIndex = 1;
            // 
            // mtxt_IPAdress
            // 
            this.mtxt_IPAdress.Location = new System.Drawing.Point(53, 30);
            this.mtxt_IPAdress.Name = "mtxt_IPAdress";
            this.mtxt_IPAdress.PromptChar = '.';
            this.mtxt_IPAdress.Size = new System.Drawing.Size(156, 21);
            this.mtxt_IPAdress.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_solftTrigger);
            this.groupBox1.Controls.Add(this.txt_Framerate);
            this.groupBox1.Controls.Add(this.txt_ExposeTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_TrigerMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bt_solftTrigger
            // 
            this.bt_solftTrigger.Enabled = false;
            this.bt_solftTrigger.Location = new System.Drawing.Point(312, 68);
            this.bt_solftTrigger.Name = "bt_solftTrigger";
            this.bt_solftTrigger.Size = new System.Drawing.Size(75, 23);
            this.bt_solftTrigger.TabIndex = 18;
            this.bt_solftTrigger.Text = "软触发";
            this.bt_solftTrigger.UseVisualStyleBackColor = true;
            this.bt_solftTrigger.Click += new System.EventHandler(this.bt_solftTrigger_Click);
            // 
            // txt_Framerate
            // 
            this.txt_Framerate.Location = new System.Drawing.Point(377, 21);
            this.txt_Framerate.Name = "txt_Framerate";
            this.txt_Framerate.Size = new System.Drawing.Size(100, 21);
            this.txt_Framerate.TabIndex = 17;
            this.txt_Framerate.Text = "3";
            // 
            // txt_ExposeTime
            // 
            this.txt_ExposeTime.Location = new System.Drawing.Point(118, 21);
            this.txt_ExposeTime.Name = "txt_ExposeTime";
            this.txt_ExposeTime.Size = new System.Drawing.Size(100, 21);
            this.txt_ExposeTime.TabIndex = 16;
            this.txt_ExposeTime.Text = "49900";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "帧率:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "曝光时间[us]：";
            // 
            // cmb_TrigerMode
            // 
            this.cmb_TrigerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TrigerMode.FormattingEnabled = true;
            this.cmb_TrigerMode.Items.AddRange(new object[] {
            "内触发",
            "软件触发",
            "外触发内曝光",
            "外触发外曝光"});
            this.cmb_TrigerMode.Location = new System.Drawing.Point(118, 68);
            this.cmb_TrigerMode.Name = "cmb_TrigerMode";
            this.cmb_TrigerMode.Size = new System.Drawing.Size(121, 20);
            this.cmb_TrigerMode.TabIndex = 1;
            this.cmb_TrigerMode.SelectedIndexChanged += new System.EventHandler(this.cmb_TrigerMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "触发方式:";
            // 
            // tabPage_IO
            // 
            this.tabPage_IO.Location = new System.Drawing.Point(4, 22);
            this.tabPage_IO.Name = "tabPage_IO";
            this.tabPage_IO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_IO.Size = new System.Drawing.Size(538, 347);
            this.tabPage_IO.TabIndex = 2;
            this.tabPage_IO.Text = " IO 控制";
            this.tabPage_IO.UseVisualStyleBackColor = true;
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(319, 399);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Save.TabIndex = 1;
            this.bt_Save.Text = "确认";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(438, 399);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 23);
            this.bt_Exit.TabIndex = 2;
            this.bt_Exit.Text = "取消";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // frm_AcqSVS_hrAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 449);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.tabControl);
            this.Name = "frm_AcqSVS_hrAttr";
            this.Text = "frm_AcqAttribute";
            this.Load += new System.EventHandler(this.frm_AcqSVS_hrAttr_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage_Basic.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_Basic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_TrigerMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage_IO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox mtxt_Mask;
        private System.Windows.Forms.MaskedTextBox mtxt_IPAdress;
        private System.Windows.Forms.TextBox txt_Framerate;
        private System.Windows.Forms.TextBox txt_ExposeTime;
        private System.Windows.Forms.Button bt_solftTrigger;
    }
}