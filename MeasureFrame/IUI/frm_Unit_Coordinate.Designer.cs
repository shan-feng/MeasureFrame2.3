namespace MeasureFrame.IUI
{
    partial class frm_Unit_Coordinate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Unit_Coordinate));
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_CurrentImg = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rad_PointLine = new System.Windows.Forms.RadioButton();
            this.rad_3Points = new System.Windows.Forms.RadioButton();
            this.rad_PassX = new System.Windows.Forms.RadioButton();
            this.rad_PassY = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_ThirdUnitID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_SecondUnitID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_FirstUnitID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(215, 13);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.label9);
            this.gb_top.Controls.Add(this.cmb_CurrentImg);
            this.gb_top.Size = new System.Drawing.Size(484, 50);
            this.gb_top.Controls.SetChildIndex(this.cmb_CurrentImg, 0);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            this.gb_top.Controls.SetChildIndex(this.label9, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(484, 255);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.groupBox3);
            this.gb_main.Size = new System.Drawing.Size(470, 223);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(376, 13);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(476, 229);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "显示图像：";
            // 
            // cmb_CurrentImg
            // 
            this.cmb_CurrentImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CurrentImg.FormattingEnabled = true;
            this.cmb_CurrentImg.Location = new System.Drawing.Point(348, 23);
            this.cmb_CurrentImg.Name = "cmb_CurrentImg";
            this.cmb_CurrentImg.Size = new System.Drawing.Size(106, 20);
            this.cmb_CurrentImg.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rad_PointLine);
            this.groupBox3.Controls.Add(this.rad_3Points);
            this.groupBox3.Controls.Add(this.rad_PassX);
            this.groupBox3.Controls.Add(this.rad_PassY);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模式";
            // 
            // rad_PointLine
            // 
            this.rad_PointLine.AutoSize = true;
            this.rad_PointLine.Image = global::MeasureFrame.Properties.Resources.cor003;
            this.rad_PointLine.Location = new System.Drawing.Point(247, 17);
            this.rad_PointLine.Name = "rad_PointLine";
            this.rad_PointLine.Size = new System.Drawing.Size(82, 35);
            this.rad_PointLine.TabIndex = 7;
            this.rad_PointLine.Text = "点线";
            this.rad_PointLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_PointLine.UseVisualStyleBackColor = true;
            this.rad_PointLine.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // rad_3Points
            // 
            this.rad_3Points.AutoSize = true;
            this.rad_3Points.Image = ((System.Drawing.Image)(resources.GetObject("rad_3Points.Image")));
            this.rad_3Points.Location = new System.Drawing.Point(356, 17);
            this.rad_3Points.Name = "rad_3Points";
            this.rad_3Points.Size = new System.Drawing.Size(76, 35);
            this.rad_3Points.TabIndex = 6;
            this.rad_3Points.Text = "3点";
            this.rad_3Points.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_3Points.UseVisualStyleBackColor = true;
            this.rad_3Points.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // rad_PassX
            // 
            this.rad_PassX.AutoSize = true;
            this.rad_PassX.Checked = true;
            this.rad_PassX.Image = global::MeasureFrame.Properties.Resources.cor001;
            this.rad_PassX.Location = new System.Drawing.Point(49, 18);
            this.rad_PassX.Name = "rad_PassX";
            this.rad_PassX.Size = new System.Drawing.Size(76, 32);
            this.rad_PassX.TabIndex = 5;
            this.rad_PassX.TabStop = true;
            this.rad_PassX.Text = "X轴";
            this.rad_PassX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_PassX.UseVisualStyleBackColor = true;
            this.rad_PassX.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // rad_PassY
            // 
            this.rad_PassY.AutoSize = true;
            this.rad_PassY.Image = global::MeasureFrame.Properties.Resources.cor002;
            this.rad_PassY.Location = new System.Drawing.Point(148, 19);
            this.rad_PassY.Name = "rad_PassY";
            this.rad_PassY.Size = new System.Drawing.Size(72, 31);
            this.rad_PassY.TabIndex = 4;
            this.rad_PassY.Text = "Y轴";
            this.rad_PassY.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_PassY.UseVisualStyleBackColor = true;
            this.rad_PassY.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_ThirdUnitID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_SecondUnitID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_FirstUnitID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 147);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算方式";
            // 
            // cmb_ThirdUnitID
            // 
            this.cmb_ThirdUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ThirdUnitID.FormattingEnabled = true;
            this.cmb_ThirdUnitID.Location = new System.Drawing.Point(99, 102);
            this.cmb_ThirdUnitID.Name = "cmb_ThirdUnitID";
            this.cmb_ThirdUnitID.Size = new System.Drawing.Size(121, 20);
            this.cmb_ThirdUnitID.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "第三点数据：";
            // 
            // cmb_SecondUnitID
            // 
            this.cmb_SecondUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SecondUnitID.FormattingEnabled = true;
            this.cmb_SecondUnitID.Location = new System.Drawing.Point(334, 63);
            this.cmb_SecondUnitID.Name = "cmb_SecondUnitID";
            this.cmb_SecondUnitID.Size = new System.Drawing.Size(121, 20);
            this.cmb_SecondUnitID.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "第二点数据：";
            // 
            // cmb_FirstUnitID
            // 
            this.cmb_FirstUnitID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FirstUnitID.FormattingEnabled = true;
            this.cmb_FirstUnitID.Location = new System.Drawing.Point(99, 60);
            this.cmb_FirstUnitID.Name = "cmb_FirstUnitID";
            this.cmb_FirstUnitID.Size = new System.Drawing.Size(121, 20);
            this.cmb_FirstUnitID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "第一点数据：";
            // 
            // frm_Unit_Coordinate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(484, 363);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_Coordinate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_Coordinate_FormClosing);
            this.Load += new System.EventHandler(this.frm_Unit_Coordinate_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_CurrentImg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rad_PassX;
        private System.Windows.Forms.RadioButton rad_PassY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_SecondUnitID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_FirstUnitID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_ThirdUnitID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rad_3Points;
        private System.Windows.Forms.RadioButton rad_PointLine;
    }
}
