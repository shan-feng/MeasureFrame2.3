namespace MeasureFrame.IUI
{
    partial class frm_Unit_ImageLineReg
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Device = new System.Windows.Forms.ComboBox();
            this.cmb_OutImage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_TriggerSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_NeedProfiles = new System.Windows.Forms.TextBox();
            this.cmb_EndTrigger = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_imgAdjust = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_OutImgMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_RegisterImg = new System.Windows.Forms.ComboBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(428, 25);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bt_Save.Size = new System.Drawing.Size(109, 40);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.label11);
            this.gb_main.Controls.Add(this.cmb_RegisterImg);
            this.gb_main.Controls.Add(this.cmb_OutImgMode);
            this.gb_main.Controls.Add(this.label7);
            this.gb_main.Controls.Add(this.cmb_imgAdjust);
            this.gb_main.Controls.Add(this.label8);
            this.gb_main.Controls.Add(this.cmb_EndTrigger);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.txt_NeedProfiles);
            this.gb_main.Controls.Add(this.label6);
            this.gb_main.Controls.Add(this.cmb_TriggerSource);
            this.gb_main.Controls.Add(this.label5);
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
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.cmb_Device.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Size = new System.Drawing.Size(160, 23);
            this.cmb_Device.TabIndex = 1;
            this.cmb_Device.SelectedIndexChanged += new System.EventHandler(this.cmb_IndexChange);
            // 
            // cmb_OutImage
            // 
            this.cmb_OutImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OutImage.FormattingEnabled = true;
            this.cmb_OutImage.Location = new System.Drawing.Point(172, 339);
            this.cmb_OutImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_OutImage.Name = "cmb_OutImage";
            this.cmb_OutImage.Size = new System.Drawing.Size(160, 23);
            this.cmb_OutImage.TabIndex = 3;
            this.cmb_OutImage.SelectedIndexChanged += new System.EventHandler(this.cmb_OutImage_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出图像：";
            // 
            // cmb_TriggerSource
            // 
            this.cmb_TriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TriggerSource.FormattingEnabled = true;
            this.cmb_TriggerSource.Location = new System.Drawing.Point(172, 130);
            this.cmb_TriggerSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_TriggerSource.Name = "cmb_TriggerSource";
            this.cmb_TriggerSource.Size = new System.Drawing.Size(160, 23);
            this.cmb_TriggerSource.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "开始信号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 215);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "采集帧数：";
            // 
            // txt_NeedProfiles
            // 
            this.txt_NeedProfiles.Location = new System.Drawing.Point(540, 206);
            this.txt_NeedProfiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_NeedProfiles.Name = "txt_NeedProfiles";
            this.txt_NeedProfiles.Size = new System.Drawing.Size(132, 25);
            this.txt_NeedProfiles.TabIndex = 11;
            this.txt_NeedProfiles.Text = "1000";
            // 
            // cmb_EndTrigger
            // 
            this.cmb_EndTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EndTrigger.FormattingEnabled = true;
            this.cmb_EndTrigger.Items.AddRange(new object[] {
            "",
            "EndTR1",
            "EndTR2",
            "EndTR3",
            "EndTR4"});
            this.cmb_EndTrigger.Location = new System.Drawing.Point(540, 130);
            this.cmb_EndTrigger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_EndTrigger.Name = "cmb_EndTrigger";
            this.cmb_EndTrigger.Size = new System.Drawing.Size(160, 23);
            this.cmb_EndTrigger.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "结束信号：";
            // 
            // cmb_imgAdjust
            // 
            this.cmb_imgAdjust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_imgAdjust.FormattingEnabled = true;
            this.cmb_imgAdjust.Location = new System.Drawing.Point(172, 208);
            this.cmb_imgAdjust.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_imgAdjust.Name = "cmb_imgAdjust";
            this.cmb_imgAdjust.Size = new System.Drawing.Size(160, 23);
            this.cmb_imgAdjust.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "图像调整：";
            // 
            // cmb_OutImgMode
            // 
            this.cmb_OutImgMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OutImgMode.FormattingEnabled = true;
            this.cmb_OutImgMode.Items.AddRange(new object[] {
            "双镭射图像",
            "第一个镭射图像",
            "第二个镭射图像"});
            this.cmb_OutImgMode.Location = new System.Drawing.Point(540, 54);
            this.cmb_OutImgMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_OutImgMode.Name = "cmb_OutImgMode";
            this.cmb_OutImgMode.Size = new System.Drawing.Size(160, 23);
            this.cmb_OutImgMode.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 58);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "图像模式：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 279);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 35;
            this.label11.Text = "注册图像：";
            // 
            // cmb_RegisterImg
            // 
            this.cmb_RegisterImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_RegisterImg.FormattingEnabled = true;
            this.cmb_RegisterImg.Location = new System.Drawing.Point(172, 279);
            this.cmb_RegisterImg.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_RegisterImg.Name = "cmb_RegisterImg";
            this.cmb_RegisterImg.Size = new System.Drawing.Size(160, 23);
            this.cmb_RegisterImg.TabIndex = 34;
            // 
            // frm_Unit_ImageLineReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.ClientSize = new System.Drawing.Size(864, 584);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Unit_ImageLineReg";
            this.Text = "";
            this.Load += new System.EventHandler(this.frm_Unit_ImageReg_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_OutImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_TriggerSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_NeedProfiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_EndTrigger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_OutImgMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_imgAdjust;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.ComboBox cmb_RegisterImg;
    }
}
