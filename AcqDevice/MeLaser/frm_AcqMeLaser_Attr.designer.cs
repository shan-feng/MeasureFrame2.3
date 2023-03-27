namespace AcqDevice
{
    partial class frm_AcqMeLaser_Attr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AcqMeLaser_Attr));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_miyiScan = new System.Windows.Forms.TabPage();
            this.pic_singleProfile = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_mCaliAngle = new System.Windows.Forms.CheckBox();
            this.txt_xielv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_allowAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Comfirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_FrameRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ExposeTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_EncoderStep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_MeasureFeild = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_MeasureFeild = new System.Windows.Forms.TextBox();
            this.txt_EncoderOneStepUm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Resolutions = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_TriggerMode = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tab_miyiScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_singleProfile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_miyiScan);
            this.tabControl1.Location = new System.Drawing.Point(12, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_miyiScan
            // 
            this.tab_miyiScan.Controls.Add(this.pic_singleProfile);
            this.tab_miyiScan.Controls.Add(this.groupBox1);
            this.tab_miyiScan.Location = new System.Drawing.Point(4, 22);
            this.tab_miyiScan.Name = "tab_miyiScan";
            this.tab_miyiScan.Padding = new System.Windows.Forms.Padding(3);
            this.tab_miyiScan.Size = new System.Drawing.Size(1079, 532);
            this.tab_miyiScan.TabIndex = 0;
            this.tab_miyiScan.Text = "MiyiScan";
            this.tab_miyiScan.UseVisualStyleBackColor = true;
            // 
            // pic_singleProfile
            // 
            this.pic_singleProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_singleProfile.Image = ((System.Drawing.Image)(resources.GetObject("pic_singleProfile.Image")));
            this.pic_singleProfile.Location = new System.Drawing.Point(416, 9);
            this.pic_singleProfile.Name = "pic_singleProfile";
            this.pic_singleProfile.Size = new System.Drawing.Size(660, 520);
            this.pic_singleProfile.TabIndex = 3;
            this.pic_singleProfile.TabStop = false;
            this.pic_singleProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_singleProfile_MouseDown);
            this.pic_singleProfile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_singleProfile_MouseMove);
            this.pic_singleProfile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_singleProfile_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.check_mCaliAngle);
            this.groupBox1.Controls.Add(this.txt_xielv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_allowAngle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 520);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmb_TriggerMode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmb_Resolutions);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_EncoderOneStepUm);
            this.groupBox2.Controls.Add(this.txt_MeasureFeild);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmb_MeasureFeild);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_EncoderStep);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_ExposeTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_FrameRate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 308);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "profile";
            // 
            // check_mCaliAngle
            // 
            this.check_mCaliAngle.AutoSize = true;
            this.check_mCaliAngle.Location = new System.Drawing.Point(253, 121);
            this.check_mCaliAngle.Name = "check_mCaliAngle";
            this.check_mCaliAngle.Size = new System.Drawing.Size(15, 14);
            this.check_mCaliAngle.TabIndex = 7;
            this.check_mCaliAngle.UseVisualStyleBackColor = true;
            // 
            // txt_xielv
            // 
            this.txt_xielv.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_xielv.ForeColor = System.Drawing.Color.Red;
            this.txt_xielv.Location = new System.Drawing.Point(100, 42);
            this.txt_xielv.Multiline = true;
            this.txt_xielv.Name = "txt_xielv";
            this.txt_xielv.ReadOnly = true;
            this.txt_xielv.Size = new System.Drawing.Size(168, 46);
            this.txt_xielv.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "倾斜角度：";
            // 
            // txt_allowAngle
            // 
            this.txt_allowAngle.Location = new System.Drawing.Point(100, 118);
            this.txt_allowAngle.Name = "txt_allowAngle";
            this.txt_allowAngle.Size = new System.Drawing.Size(120, 21);
            this.txt_allowAngle.TabIndex = 3;
            this.txt_allowAngle.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "补正角度：";
            // 
            // bt_Comfirm
            // 
            this.bt_Comfirm.Location = new System.Drawing.Point(688, 587);
            this.bt_Comfirm.Name = "bt_Comfirm";
            this.bt_Comfirm.Size = new System.Drawing.Size(95, 38);
            this.bt_Comfirm.TabIndex = 1;
            this.bt_Comfirm.Text = "确认";
            this.bt_Comfirm.UseVisualStyleBackColor = true;
            this.bt_Comfirm.Click += new System.EventHandler(this.bt_Comfirm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "ms";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(364, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "um";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "帧率：";
            // 
            // txt_FrameRate
            // 
            this.txt_FrameRate.Location = new System.Drawing.Point(86, 71);
            this.txt_FrameRate.Name = "txt_FrameRate";
            this.txt_FrameRate.Size = new System.Drawing.Size(76, 21);
            this.txt_FrameRate.TabIndex = 10;
            this.txt_FrameRate.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "曝光时间：";
            // 
            // txt_ExposeTime
            // 
            this.txt_ExposeTime.Location = new System.Drawing.Point(272, 71);
            this.txt_ExposeTime.Name = "txt_ExposeTime";
            this.txt_ExposeTime.Size = new System.Drawing.Size(76, 21);
            this.txt_ExposeTime.TabIndex = 12;
            this.txt_ExposeTime.Text = "0.5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "采样步长：";
            // 
            // txt_EncoderStep
            // 
            this.txt_EncoderStep.Location = new System.Drawing.Point(86, 197);
            this.txt_EncoderStep.Name = "txt_EncoderStep";
            this.txt_EncoderStep.Size = new System.Drawing.Size(76, 21);
            this.txt_EncoderStep.TabIndex = 22;
            this.txt_EncoderStep.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "测量区域：";
            // 
            // cmb_MeasureFeild
            // 
            this.cmb_MeasureFeild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MeasureFeild.FormattingEnabled = true;
            this.cmb_MeasureFeild.Items.AddRange(new object[] {
            "small",
            "starand",
            "large",
            "custom..."});
            this.cmb_MeasureFeild.Location = new System.Drawing.Point(86, 109);
            this.cmb_MeasureFeild.Name = "cmb_MeasureFeild";
            this.cmb_MeasureFeild.Size = new System.Drawing.Size(121, 20);
            this.cmb_MeasureFeild.TabIndex = 15;
            this.cmb_MeasureFeild.SelectedIndexChanged += new System.EventHandler(this.cmb_MeasureFeild_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "采样分辨率：";
            // 
            // txt_MeasureFeild
            // 
            this.txt_MeasureFeild.Location = new System.Drawing.Point(213, 109);
            this.txt_MeasureFeild.Name = "txt_MeasureFeild";
            this.txt_MeasureFeild.Size = new System.Drawing.Size(76, 21);
            this.txt_MeasureFeild.TabIndex = 16;
            this.txt_MeasureFeild.Text = "99";
            // 
            // txt_EncoderOneStepUm
            // 
            this.txt_EncoderOneStepUm.Location = new System.Drawing.Point(282, 197);
            this.txt_EncoderOneStepUm.Name = "txt_EncoderOneStepUm";
            this.txt_EncoderOneStepUm.Size = new System.Drawing.Size(76, 21);
            this.txt_EncoderOneStepUm.TabIndex = 24;
            this.txt_EncoderOneStepUm.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "分辨率：";
            // 
            // cmb_Resolutions
            // 
            this.cmb_Resolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Resolutions.FormattingEnabled = true;
            this.cmb_Resolutions.Items.AddRange(new object[] {
            "160",
            "320",
            "640",
            "1280"});
            this.cmb_Resolutions.Location = new System.Drawing.Point(86, 150);
            this.cmb_Resolutions.Name = "cmb_Resolutions";
            this.cmb_Resolutions.Size = new System.Drawing.Size(121, 20);
            this.cmb_Resolutions.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(168, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "um";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "触发模式：";
            // 
            // cmb_TriggerMode
            // 
            this.cmb_TriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TriggerMode.FormattingEnabled = true;
            this.cmb_TriggerMode.Items.AddRange(new object[] {
            "内触发",
            "编码器"});
            this.cmb_TriggerMode.Location = new System.Drawing.Point(86, 31);
            this.cmb_TriggerMode.Name = "cmb_TriggerMode";
            this.cmb_TriggerMode.Size = new System.Drawing.Size(121, 20);
            this.cmb_TriggerMode.TabIndex = 9;
            this.cmb_TriggerMode.SelectedIndexChanged += new System.EventHandler(this.cmb_TriggerMode_SelectedIndexChanged);
            // 
            // frm_AcqMeLaser_Attr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 637);
            this.Controls.Add(this.bt_Comfirm);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_AcqMeLaser_Attr";
            this.Text = "激光设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AcqMeLaser_Attr_FormClosing);
            this.Load += new System.EventHandler(this.frm_CorrectLaser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_miyiScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_singleProfile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_miyiScan;
        private System.Windows.Forms.Button bt_Comfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_allowAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_singleProfile;
        private System.Windows.Forms.TextBox txt_xielv;
        private System.Windows.Forms.CheckBox check_mCaliAngle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_TriggerMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_Resolutions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_EncoderOneStepUm;
        private System.Windows.Forms.TextBox txt_MeasureFeild;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_MeasureFeild;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_EncoderStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_ExposeTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_FrameRate;
        private System.Windows.Forms.Label label4;
    }
}