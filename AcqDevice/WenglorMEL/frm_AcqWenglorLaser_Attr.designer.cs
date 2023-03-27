namespace AcqDevice
{
    partial class frm_AcqWenglorLaser_Attr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AcqWenglorLaser_Attr));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_wenglorScan = new System.Windows.Forms.TabPage();
            this.pic_singleProfile = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_IPaddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonResetSettings = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSendRawCommand = new System.Windows.Forms.Button();
            this.textBoxSendRawCommand = new System.Windows.Forms.TextBox();
            this.bt_disconnet = new System.Windows.Forms.Button();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.txtEncoderStep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtROIOffsetZ = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtROIHeightZ = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTriggerSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFramrate = new System.Windows.Forms.TextBox();
            this.labelSetAcquisitionLineTime = new System.Windows.Forms.Label();
            this.txtExposureTime = new System.Windows.Forms.TextBox();
            this.labelSetExposureTime = new System.Windows.Forms.Label();
            this.check_mCaliAngle = new System.Windows.Forms.CheckBox();
            this.txt_xielv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_allowAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Comfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tab_wenglorScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_singleProfile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_wenglorScan);
            this.tabControl1.Location = new System.Drawing.Point(12, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_wenglorScan
            // 
            this.tab_wenglorScan.Controls.Add(this.pic_singleProfile);
            this.tab_wenglorScan.Controls.Add(this.groupBox1);
            this.tab_wenglorScan.Location = new System.Drawing.Point(4, 22);
            this.tab_wenglorScan.Name = "tab_wenglorScan";
            this.tab_wenglorScan.Padding = new System.Windows.Forms.Padding(3);
            this.tab_wenglorScan.Size = new System.Drawing.Size(1079, 532);
            this.tab_wenglorScan.TabIndex = 0;
            this.tab_wenglorScan.Text = "WenglorScan";
            this.tab_wenglorScan.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.txt_Port);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_IPaddress);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.buttonResetSettings);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.buttonSendRawCommand);
            this.groupBox2.Controls.Add(this.textBoxSendRawCommand);
            this.groupBox2.Controls.Add(this.bt_disconnet);
            this.groupBox2.Controls.Add(this.bt_Connect);
            this.groupBox2.Controls.Add(this.txtEncoderStep);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtROIOffsetZ);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtROIHeightZ);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTriggerSource);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFramrate);
            this.groupBox2.Controls.Add(this.labelSetAcquisitionLineTime);
            this.groupBox2.Controls.Add(this.txtExposureTime);
            this.groupBox2.Controls.Add(this.labelSetExposureTime);
            this.groupBox2.Location = new System.Drawing.Point(0, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 360);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "profile";
            // 
            // txt_Port
            // 
            this.txt_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Port.Location = new System.Drawing.Point(310, 39);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(70, 21);
            this.txt_Port.TabIndex = 204;
            this.txt_Port.Text = "32001";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 203;
            this.label5.Text = "端口:";
            // 
            // txt_IPaddress
            // 
            this.txt_IPaddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_IPaddress.Location = new System.Drawing.Point(69, 39);
            this.txt_IPaddress.Name = "txt_IPaddress";
            this.txt_IPaddress.Size = new System.Drawing.Size(112, 21);
            this.txt_IPaddress.TabIndex = 202;
            this.txt_IPaddress.Text = "192.168.100.1";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 201;
            this.label8.Text = "Ip地址:";
            // 
            // buttonResetSettings
            // 
            this.buttonResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetSettings.Location = new System.Drawing.Point(292, 299);
            this.buttonResetSettings.Name = "buttonResetSettings";
            this.buttonResetSettings.Size = new System.Drawing.Size(76, 40);
            this.buttonResetSettings.TabIndex = 200;
            this.buttonResetSettings.Text = "重置";
            this.buttonResetSettings.UseVisualStyleBackColor = true;
            this.buttonResetSettings.Click += new System.EventHandler(this.buttonResetSettings_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 199;
            this.label7.Text = "指令入口:";
            // 
            // buttonSendRawCommand
            // 
            this.buttonSendRawCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendRawCommand.Location = new System.Drawing.Point(330, 223);
            this.buttonSendRawCommand.Name = "buttonSendRawCommand";
            this.buttonSendRawCommand.Size = new System.Drawing.Size(38, 67);
            this.buttonSendRawCommand.TabIndex = 198;
            this.buttonSendRawCommand.Text = ">>";
            this.buttonSendRawCommand.UseVisualStyleBackColor = true;
            this.buttonSendRawCommand.Click += new System.EventHandler(this.buttonSendRawCommand_Click);
            // 
            // textBoxSendRawCommand
            // 
            this.textBoxSendRawCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSendRawCommand.Location = new System.Drawing.Point(105, 223);
            this.textBoxSendRawCommand.Multiline = true;
            this.textBoxSendRawCommand.Name = "textBoxSendRawCommand";
            this.textBoxSendRawCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSendRawCommand.Size = new System.Drawing.Size(219, 67);
            this.textBoxSendRawCommand.TabIndex = 197;
            // 
            // bt_disconnet
            // 
            this.bt_disconnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_disconnet.Location = new System.Drawing.Point(161, 299);
            this.bt_disconnet.Name = "bt_disconnet";
            this.bt_disconnet.Size = new System.Drawing.Size(76, 40);
            this.bt_disconnet.TabIndex = 196;
            this.bt_disconnet.Text = "断开";
            this.bt_disconnet.UseVisualStyleBackColor = true;
            this.bt_disconnet.Click += new System.EventHandler(this.buttonSetAcquisitionStop_Click);
            // 
            // bt_Connect
            // 
            this.bt_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Connect.Location = new System.Drawing.Point(35, 299);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(76, 40);
            this.bt_Connect.TabIndex = 195;
            this.bt_Connect.Text = "连接";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.buttonSsetAcquissitionStart_Click);
            // 
            // txtEncoderStep
            // 
            this.txtEncoderStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncoderStep.Location = new System.Drawing.Point(310, 133);
            this.txtEncoderStep.Name = "txtEncoderStep";
            this.txtEncoderStep.Size = new System.Drawing.Size(70, 21);
            this.txtEncoderStep.TabIndex = 192;
            this.txtEncoderStep.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 191;
            this.label6.Text = "设置脉冲间隔:";
            // 
            // txtROIOffsetZ
            // 
            this.txtROIOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtROIOffsetZ.Location = new System.Drawing.Point(310, 106);
            this.txtROIOffsetZ.Name = "txtROIOffsetZ";
            this.txtROIOffsetZ.Size = new System.Drawing.Size(70, 21);
            this.txtROIOffsetZ.TabIndex = 188;
            this.txtROIOffsetZ.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(211, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 12);
            this.label14.TabIndex = 187;
            this.label14.Text = "设置ROI高度偏移:";
            // 
            // txtROIHeightZ
            // 
            this.txtROIHeightZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtROIHeightZ.Location = new System.Drawing.Point(310, 76);
            this.txtROIHeightZ.Name = "txtROIHeightZ";
            this.txtROIHeightZ.Size = new System.Drawing.Size(70, 21);
            this.txtROIHeightZ.TabIndex = 184;
            this.txtROIHeightZ.Text = "1024";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 183;
            this.label11.Text = "设置ROI高度:";
            // 
            // txtTriggerSource
            // 
            this.txtTriggerSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTriggerSource.Location = new System.Drawing.Point(111, 76);
            this.txtTriggerSource.Name = "txtTriggerSource";
            this.txtTriggerSource.Size = new System.Drawing.Size(70, 21);
            this.txtTriggerSource.TabIndex = 180;
            this.txtTriggerSource.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 179;
            this.label3.Text = "触发模式:";
            // 
            // txtFramrate
            // 
            this.txtFramrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFramrate.Location = new System.Drawing.Point(111, 104);
            this.txtFramrate.Name = "txtFramrate";
            this.txtFramrate.Size = new System.Drawing.Size(70, 21);
            this.txtFramrate.TabIndex = 173;
            this.txtFramrate.Text = "5714";
            // 
            // labelSetAcquisitionLineTime
            // 
            this.labelSetAcquisitionLineTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSetAcquisitionLineTime.AutoSize = true;
            this.labelSetAcquisitionLineTime.Location = new System.Drawing.Point(12, 106);
            this.labelSetAcquisitionLineTime.Name = "labelSetAcquisitionLineTime";
            this.labelSetAcquisitionLineTime.Size = new System.Drawing.Size(59, 12);
            this.labelSetAcquisitionLineTime.TabIndex = 172;
            this.labelSetAcquisitionLineTime.Text = "采集频率:";
            // 
            // txtExposureTime
            // 
            this.txtExposureTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExposureTime.Location = new System.Drawing.Point(111, 131);
            this.txtExposureTime.Name = "txtExposureTime";
            this.txtExposureTime.Size = new System.Drawing.Size(70, 21);
            this.txtExposureTime.TabIndex = 170;
            this.txtExposureTime.Text = "200";
            // 
            // labelSetExposureTime
            // 
            this.labelSetExposureTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSetExposureTime.AutoSize = true;
            this.labelSetExposureTime.Location = new System.Drawing.Point(12, 134);
            this.labelSetExposureTime.Name = "labelSetExposureTime";
            this.labelSetExposureTime.Size = new System.Drawing.Size(89, 12);
            this.labelSetExposureTime.TabIndex = 169;
            this.labelSetExposureTime.Text = "曝光时间 [us]:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(10, 613);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 2;
            // 
            // frm_AcqWenglorLaser_Attr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 637);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_Comfirm);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_AcqWenglorLaser_Attr";
            this.Text = "激光设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_AcqMeLaser_Attr_FormClosing);
            this.Load += new System.EventHandler(this.frm_CorrectLaser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_wenglorScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_singleProfile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_wenglorScan;
        private System.Windows.Forms.Button bt_Comfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_allowAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_singleProfile;
        private System.Windows.Forms.TextBox txt_xielv;
        private System.Windows.Forms.CheckBox check_mCaliAngle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonResetSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSendRawCommand;
        private System.Windows.Forms.TextBox textBoxSendRawCommand;
        private System.Windows.Forms.Button bt_disconnet;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.TextBox txtEncoderStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtROIOffsetZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtROIHeightZ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTriggerSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFramrate;
        private System.Windows.Forms.Label labelSetAcquisitionLineTime;
        private System.Windows.Forms.TextBox txtExposureTime;
        private System.Windows.Forms.Label labelSetExposureTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_IPaddress;
        private System.Windows.Forms.Label label8;
    }
}