namespace MeasureFrame.IUI
{
    partial class frm_Unit_ImageAreaReg
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Device = new System.Windows.Forms.ComboBox();
            this.cmb_OutImage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_DisImage = new System.Windows.Forms.Button();
            this.cmb_TriggerSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_ClearRoi = new System.Windows.Forms.Button();
            this.bt_Color2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Draw2 = new System.Windows.Forms.Button();
            this.cmb_Shape2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_imgAdjust = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ExposureTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tab_IMGSetting = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_RegisterImg = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_DistortionCalib = new System.Windows.Forms.ComboBox();
            this.lebal20 = new System.Windows.Forms.Label();
            this.cmb_hom2D = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkAcqAuto = new System.Windows.Forms.CheckBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab_IMGSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(5);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tab_IMGSetting);
            this.tab_Main.Controls.SetChildIndex(this.tab_IMGSetting, 0);
            this.tab_Main.Controls.SetChildIndex(this.tabP_baseSetting, 0);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.chkAcqAuto);
            this.gb_main.Controls.Add(this.txt_ExposureTime);
            this.gb_main.Controls.Add(this.label9);
            this.gb_main.Controls.Add(this.cmb_imgAdjust);
            this.gb_main.Controls.Add(this.label8);
            this.gb_main.Controls.Add(this.groupBox2);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.cmb_TriggerSource);
            this.gb_main.Controls.Add(this.label5);
            this.gb_main.Controls.Add(this.bt_DisImage);
            this.gb_main.Controls.Add(this.cmb_OutImage);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.cmb_Device);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Size = new System.Drawing.Size(846, 411);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 25);
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5);
            this.tabP_baseSetting.Size = new System.Drawing.Size(856, 421);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备列表：";
            // 
            // cmb_Device
            // 
            this.cmb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Device.FormattingEnabled = true;
            this.cmb_Device.Location = new System.Drawing.Point(172, 54);
            this.cmb_Device.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Size = new System.Drawing.Size(160, 23);
            this.cmb_Device.TabIndex = 1;
            this.cmb_Device.SelectedIndexChanged += new System.EventHandler(this.cmb_IndexChange);
            // 
            // cmb_OutImage
            // 
            this.cmb_OutImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OutImage.FormattingEnabled = true;
            this.cmb_OutImage.Location = new System.Drawing.Point(172, 184);
            this.cmb_OutImage.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_OutImage.Name = "cmb_OutImage";
            this.cmb_OutImage.Size = new System.Drawing.Size(160, 23);
            this.cmb_OutImage.TabIndex = 3;
            this.cmb_OutImage.SelectedIndexChanged += new System.EventHandler(this.cmb_OutImage_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出图像：";
            // 
            // bt_DisImage
            // 
            this.bt_DisImage.Location = new System.Drawing.Point(542, 229);
            this.bt_DisImage.Margin = new System.Windows.Forms.Padding(4);
            this.bt_DisImage.Name = "bt_DisImage";
            this.bt_DisImage.Size = new System.Drawing.Size(100, 29);
            this.bt_DisImage.TabIndex = 4;
            this.bt_DisImage.Text = "采集图像";
            this.bt_DisImage.UseVisualStyleBackColor = true;
            this.bt_DisImage.Click += new System.EventHandler(this.bt_DisImage_Click);
            // 
            // cmb_TriggerSource
            // 
            this.cmb_TriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TriggerSource.FormattingEnabled = true;
            this.cmb_TriggerSource.Location = new System.Drawing.Point(519, 58);
            this.cmb_TriggerSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_TriggerSource.Name = "cmb_TriggerSource";
            this.cmb_TriggerSource.Size = new System.Drawing.Size(160, 23);
            this.cmb_TriggerSource.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "触发源：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(688, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "(软触发时有效)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_ClearRoi);
            this.groupBox2.Controls.Add(this.bt_Color2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bt_Draw2);
            this.groupBox2.Controls.Add(this.cmb_Shape2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(4, 266);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(838, 141);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品区域";
            // 
            // bt_ClearRoi
            // 
            this.bt_ClearRoi.Location = new System.Drawing.Point(636, 101);
            this.bt_ClearRoi.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ClearRoi.Name = "bt_ClearRoi";
            this.bt_ClearRoi.Size = new System.Drawing.Size(100, 29);
            this.bt_ClearRoi.TabIndex = 18;
            this.bt_ClearRoi.Text = "清除";
            this.bt_ClearRoi.UseVisualStyleBackColor = true;
            this.bt_ClearRoi.Click += new System.EventHandler(this.bt_ClearRoi_Click);
            // 
            // bt_Color2
            // 
            this.bt_Color2.BackColor = System.Drawing.Color.Lime;
            this.bt_Color2.ForeColor = System.Drawing.Color.White;
            this.bt_Color2.Location = new System.Drawing.Point(505, 39);
            this.bt_Color2.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Color2.Name = "bt_Color2";
            this.bt_Color2.Size = new System.Drawing.Size(133, 36);
            this.bt_Color2.TabIndex = 17;
            this.bt_Color2.UseVisualStyleBackColor = false;
            this.bt_Color2.Click += new System.EventHandler(this.bt_Color2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "颜色：";
            // 
            // bt_Draw2
            // 
            this.bt_Draw2.Location = new System.Drawing.Point(528, 101);
            this.bt_Draw2.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Draw2.Name = "bt_Draw2";
            this.bt_Draw2.Size = new System.Drawing.Size(100, 29);
            this.bt_Draw2.TabIndex = 2;
            this.bt_Draw2.Text = "绘制";
            this.bt_Draw2.UseVisualStyleBackColor = true;
            this.bt_Draw2.Click += new System.EventHandler(this.bt_Draw2_Click);
            // 
            // cmb_Shape2
            // 
            this.cmb_Shape2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Shape2.FormattingEnabled = true;
            this.cmb_Shape2.Items.AddRange(new object[] {
            "普通矩形",
            "旋转矩形",
            "圆",
            "椭圆"});
            this.cmb_Shape2.Location = new System.Drawing.Point(139, 45);
            this.cmb_Shape2.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Shape2.Name = "cmb_Shape2";
            this.cmb_Shape2.Size = new System.Drawing.Size(160, 23);
            this.cmb_Shape2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "区域形状：";
            // 
            // cmb_imgAdjust
            // 
            this.cmb_imgAdjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_imgAdjust.FormattingEnabled = true;
            this.cmb_imgAdjust.Location = new System.Drawing.Point(172, 116);
            this.cmb_imgAdjust.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_imgAdjust.Name = "cmb_imgAdjust";
            this.cmb_imgAdjust.Size = new System.Drawing.Size(160, 23);
            this.cmb_imgAdjust.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 120);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "图像调整：";
            // 
            // txt_ExposureTime
            // 
            this.txt_ExposureTime.Location = new System.Drawing.Point(545, 116);
            this.txt_ExposureTime.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ExposureTime.Name = "txt_ExposureTime";
            this.txt_ExposureTime.Size = new System.Drawing.Size(132, 25);
            this.txt_ExposureTime.TabIndex = 14;
            this.txt_ExposureTime.Text = "2000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(427, 120);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "曝光时间(us):";
            // 
            // tab_IMGSetting
            // 
            this.tab_IMGSetting.Controls.Add(this.label11);
            this.tab_IMGSetting.Controls.Add(this.cmb_RegisterImg);
            this.tab_IMGSetting.Controls.Add(this.label10);
            this.tab_IMGSetting.Controls.Add(this.cmb_DistortionCalib);
            this.tab_IMGSetting.Controls.Add(this.lebal20);
            this.tab_IMGSetting.Controls.Add(this.cmb_hom2D);
            this.tab_IMGSetting.Location = new System.Drawing.Point(4, 25);
            this.tab_IMGSetting.Margin = new System.Windows.Forms.Padding(4);
            this.tab_IMGSetting.Name = "tab_IMGSetting";
            this.tab_IMGSetting.Padding = new System.Windows.Forms.Padding(4);
            this.tab_IMGSetting.Size = new System.Drawing.Size(856, 421);
            this.tab_IMGSetting.TabIndex = 1;
            this.tab_IMGSetting.Text = "图像设定";
            this.tab_IMGSetting.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 64);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "注册图像：";
            // 
            // cmb_RegisterImg
            // 
            this.cmb_RegisterImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RegisterImg.FormattingEnabled = true;
            this.cmb_RegisterImg.Location = new System.Drawing.Point(598, 61);
            this.cmb_RegisterImg.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_RegisterImg.Name = "cmb_RegisterImg";
            this.cmb_RegisterImg.Size = new System.Drawing.Size(140, 23);
            this.cmb_RegisterImg.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 61);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "畸变校正：";
            // 
            // cmb_DistortionCalib
            // 
            this.cmb_DistortionCalib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DistortionCalib.FormattingEnabled = true;
            this.cmb_DistortionCalib.Location = new System.Drawing.Point(220, 61);
            this.cmb_DistortionCalib.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DistortionCalib.Name = "cmb_DistortionCalib";
            this.cmb_DistortionCalib.Size = new System.Drawing.Size(140, 23);
            this.cmb_DistortionCalib.TabIndex = 30;
            // 
            // lebal20
            // 
            this.lebal20.AutoSize = true;
            this.lebal20.Location = new System.Drawing.Point(75, 155);
            this.lebal20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lebal20.Name = "lebal20";
            this.lebal20.Size = new System.Drawing.Size(112, 15);
            this.lebal20.TabIndex = 29;
            this.lebal20.Text = "机械坐标校正：";
            // 
            // cmb_hom2D
            // 
            this.cmb_hom2D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_hom2D.FormattingEnabled = true;
            this.cmb_hom2D.Location = new System.Drawing.Point(220, 151);
            this.cmb_hom2D.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_hom2D.Name = "cmb_hom2D";
            this.cmb_hom2D.Size = new System.Drawing.Size(140, 23);
            this.cmb_hom2D.TabIndex = 28;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkAcqAuto
            // 
            this.chkAcqAuto.AutoSize = true;
            this.chkAcqAuto.Location = new System.Drawing.Point(519, 170);
            this.chkAcqAuto.Name = "chkAcqAuto";
            this.chkAcqAuto.Size = new System.Drawing.Size(119, 19);
            this.chkAcqAuto.TabIndex = 15;
            this.chkAcqAuto.Text = "运行自动采集";
            this.chkAcqAuto.UseVisualStyleBackColor = true;
            // 
            // frm_Unit_ImageAreaReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(864, 584);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_Unit_ImageAreaReg";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_ImageAreaReg_FormClosing);
            this.Load += new System.EventHandler(this.frm_Unit_ImageReg_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tab_IMGSetting.ResumeLayout(false);
            this.tab_IMGSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_OutImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_DisImage;
        private System.Windows.Forms.ComboBox cmb_TriggerSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Color2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Draw2;
        private System.Windows.Forms.ComboBox cmb_Shape2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_imgAdjust;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ExposureTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tab_IMGSetting;
        private System.Windows.Forms.Label lebal20;
        protected System.Windows.Forms.ComboBox cmb_hom2D;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ComboBox cmb_DistortionCalib;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.ComboBox cmb_RegisterImg;
        private System.Windows.Forms.Button bt_ClearRoi;
        private System.Windows.Forms.CheckBox chkAcqAuto;
    }
}
