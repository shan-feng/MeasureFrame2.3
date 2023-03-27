namespace MeasureFrame.IUI
{
    partial class frm_Unit_DistortionCalib
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_registerImg = new System.Windows.Forms.ComboBox();
            this.cmb_BoardType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bt_ROI = new System.Windows.Forms.Button();
            this.bt_disableRegion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lScaleY = new System.Windows.Forms.Label();
            this.lScaleX = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.label5);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            this.gb_top.Controls.SetChildIndex(this.label5, 0);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.bt_disableRegion);
            this.gb_main.Controls.Add(this.bt_ROI);
            this.gb_main.Controls.Add(this.numericUpDown);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.cmb_BoardType);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.cmb_registerImg);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Size = new System.Drawing.Size(846, 411);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
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
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册图像：";
            // 
            // cmb_registerImg
            // 
            this.cmb_registerImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_registerImg.FormattingEnabled = true;
            this.cmb_registerImg.Location = new System.Drawing.Point(163, 42);
            this.cmb_registerImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_registerImg.Name = "cmb_registerImg";
            this.cmb_registerImg.Size = new System.Drawing.Size(160, 23);
            this.cmb_registerImg.TabIndex = 4;
            this.cmb_registerImg.SelectedIndexChanged += new System.EventHandler(this.cmb_registerImg_SelectedIndexChanged);
            // 
            // cmb_BoardType
            // 
            this.cmb_BoardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BoardType.FormattingEnabled = true;
            this.cmb_BoardType.Items.AddRange(new object[] {
            "孔板",
            "棋盘格"});
            this.cmb_BoardType.Location = new System.Drawing.Point(163, 112);
            this.cmb_BoardType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_BoardType.Name = "cmb_BoardType";
            this.cmb_BoardType.Size = new System.Drawing.Size(160, 23);
            this.cmb_BoardType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "标定板类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "物理间距(mm)：";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(164, 179);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(160, 25);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // bt_ROI
            // 
            this.bt_ROI.Location = new System.Drawing.Point(224, 232);
            this.bt_ROI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_ROI.Name = "bt_ROI";
            this.bt_ROI.Size = new System.Drawing.Size(100, 31);
            this.bt_ROI.TabIndex = 9;
            this.bt_ROI.Text = "兴趣区域";
            this.bt_ROI.UseVisualStyleBackColor = true;
            this.bt_ROI.Click += new System.EventHandler(this.bt_ROI_Click);
            // 
            // bt_disableRegion
            // 
            this.bt_disableRegion.Location = new System.Drawing.Point(224, 286);
            this.bt_disableRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_disableRegion.Name = "bt_disableRegion";
            this.bt_disableRegion.Size = new System.Drawing.Size(100, 31);
            this.bt_disableRegion.TabIndex = 10;
            this.bt_disableRegion.Text = "屏蔽区域";
            this.bt_disableRegion.UseVisualStyleBackColor = true;
            this.bt_disableRegion.Click += new System.EventHandler(this.bt_disableRegion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lScaleY);
            this.groupBox1.Controls.Add(this.lScaleX);
            this.groupBox1.Location = new System.Drawing.Point(467, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(283, 172);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标定结果";
            // 
            // lScaleY
            // 
            this.lScaleY.AutoSize = true;
            this.lScaleY.Location = new System.Drawing.Point(45, 100);
            this.lScaleY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScaleY.Name = "lScaleY";
            this.lScaleY.Size = new System.Drawing.Size(23, 15);
            this.lScaleY.TabIndex = 1;
            this.lScaleY.Text = "Y=";
            // 
            // lScaleX
            // 
            this.lScaleX.AutoSize = true;
            this.lScaleX.Location = new System.Drawing.Point(45, 50);
            this.lScaleX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScaleX.Name = "lScaleX";
            this.lScaleX.Size = new System.Drawing.Size(23, 15);
            this.lScaleX.TabIndex = 0;
            this.lScaleX.Text = "X=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(721, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "不要有孤立点";
            // 
            // frm_Unit_DistortionCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 584);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Unit_DistortionCalib";
            this.Text = "frm_DistortionCalib";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_DistortionCalib_FormClosing);
            this.Load += new System.EventHandler(this.frm_DistortionCalib_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_BoardType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_registerImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_disableRegion;
        private System.Windows.Forms.Button bt_ROI;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lScaleY;
        private System.Windows.Forms.Label lScaleX;
        private System.Windows.Forms.Label label5;
    }
}