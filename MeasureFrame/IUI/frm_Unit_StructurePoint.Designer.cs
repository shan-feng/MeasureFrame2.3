namespace MeasureFrame.IUI
{
    partial class frm_Unit_StructurePoint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_SecondUnitID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_FirstUnitID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_GetPoint = new System.Windows.Forms.Button();
            this.rad_Cross = new System.Windows.Forms.RadioButton();
            this.rad_StructurePoint = new System.Windows.Forms.RadioButton();
            this.rad_Pedal = new System.Windows.Forms.RadioButton();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_CurrentImg
            // 
            this.cmb_CurrentImg.Location = new System.Drawing.Point(402, 21);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(331, 26);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(243, 21);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Size = new System.Drawing.Size(530, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Size = new System.Drawing.Size(530, 327);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.groupBox3);
            this.gb_main.Size = new System.Drawing.Size(514, 293);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(389, 21);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(522, 301);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_SecondUnitID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmb_FirstUnitID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算方式";
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
            this.label5.Location = new System.Drawing.Point(275, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "线数据：";
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
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "第一点/线数据：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_GetPoint);
            this.groupBox3.Controls.Add(this.rad_Cross);
            this.groupBox3.Controls.Add(this.rad_StructurePoint);
            this.groupBox3.Controls.Add(this.rad_Pedal);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(4, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 56);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模式";
            // 
            // bt_GetPoint
            // 
            this.bt_GetPoint.Location = new System.Drawing.Point(118, 19);
            this.bt_GetPoint.Name = "bt_GetPoint";
            this.bt_GetPoint.Size = new System.Drawing.Size(56, 28);
            this.bt_GetPoint.TabIndex = 8;
            this.bt_GetPoint.Text = "取点";
            this.bt_GetPoint.UseVisualStyleBackColor = true;
            this.bt_GetPoint.Click += new System.EventHandler(this.bt_GetPoint_Click);
            // 
            // rad_Cross
            // 
            this.rad_Cross.AutoSize = true;
            this.rad_Cross.Image = global::MeasureFrame.Properties.Resources.Cross;
            this.rad_Cross.Location = new System.Drawing.Point(334, 18);
            this.rad_Cross.Name = "rad_Cross";
            this.rad_Cross.Size = new System.Drawing.Size(81, 34);
            this.rad_Cross.TabIndex = 7;
            this.rad_Cross.Text = "交点";
            this.rad_Cross.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_Cross.UseVisualStyleBackColor = true;
            this.rad_Cross.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // rad_StructurePoint
            // 
            this.rad_StructurePoint.AutoSize = true;
            this.rad_StructurePoint.Checked = true;
            this.rad_StructurePoint.Image = global::MeasureFrame.Properties.Resources.DrawPoint;
            this.rad_StructurePoint.Location = new System.Drawing.Point(13, 16);
            this.rad_StructurePoint.Name = "rad_StructurePoint";
            this.rad_StructurePoint.Size = new System.Drawing.Size(93, 34);
            this.rad_StructurePoint.TabIndex = 5;
            this.rad_StructurePoint.TabStop = true;
            this.rad_StructurePoint.Text = "构造点";
            this.rad_StructurePoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_StructurePoint.UseVisualStyleBackColor = true;
            this.rad_StructurePoint.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // rad_Pedal
            // 
            this.rad_Pedal.AutoSize = true;
            this.rad_Pedal.Image = global::MeasureFrame.Properties.Resources.Point2Line;
            this.rad_Pedal.Location = new System.Drawing.Point(205, 20);
            this.rad_Pedal.Name = "rad_Pedal";
            this.rad_Pedal.Size = new System.Drawing.Size(81, 34);
            this.rad_Pedal.TabIndex = 4;
            this.rad_Pedal.Text = "垂足";
            this.rad_Pedal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rad_Pedal.UseVisualStyleBackColor = true;
            this.rad_Pedal.CheckedChanged += new System.EventHandler(this.rad_CheckedChanged);
            // 
            // frm_Unit_StructurePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 435);
            this.Name = "frm_Unit_StructurePoint";
            this.Text = "frm_StructurePoint";
            this.Load += new System.EventHandler(this.frm_Unit_StructurePoint_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_SecondUnitID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_FirstUnitID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_GetPoint;
        private System.Windows.Forms.RadioButton rad_Cross;
        private System.Windows.Forms.RadioButton rad_StructurePoint;
        private System.Windows.Forms.RadioButton rad_Pedal;
    }
}