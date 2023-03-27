namespace MeasureFrame.IUI
{
    partial class frm_Unit_RoteCenterCalib
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
            this.dgv_Points = new System.Windows.Forms.DataGridView();
            this.cmb_Device = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_DisImage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_GetMark = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_MachineY = new System.Windows.Forms.NumericUpDown();
            this.nud_MachineX = new System.Windows.Forms.NumericUpDown();
            this.txt_WordX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_WordY = new System.Windows.Forms.TextBox();
            this.cmb_CalibCoordID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.measureControl1 = new MeasureFrame.IUI.MeasureControl();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Points)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MachineY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MachineX)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.label1);
            this.gb_top.Controls.Add(this.cmb_Device);
            this.gb_top.Controls.Add(this.bt_DisImage);
            this.gb_top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_top.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_top.Size = new System.Drawing.Size(865, 50);
            this.gb_top.Controls.SetChildIndex(this.bt_DisImage, 0);
            this.gb_top.Controls.SetChildIndex(this.cmb_Device, 0);
            this.gb_top.Controls.SetChildIndex(this.label1, 0);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab_Main.Size = new System.Drawing.Size(865, 359);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.measureControl1);
            this.gb_main.Controls.Add(this.cmb_CalibCoordID);
            this.gb_main.Controls.Add(this.label8);
            this.gb_main.Controls.Add(this.groupBox1);
            this.gb_main.Controls.Add(this.label7);
            this.gb_main.Controls.Add(this.bt_GetMark);
            this.gb_main.Controls.Add(this.dgv_Points);
            this.gb_main.Location = new System.Drawing.Point(4, 4);
            this.gb_main.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_main.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gb_main.Size = new System.Drawing.Size(849, 325);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Size = new System.Drawing.Size(857, 333);
            // 
            // dgv_Points
            // 
            this.dgv_Points.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Points.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_Points.Location = new System.Drawing.Point(2, 16);
            this.dgv_Points.Name = "dgv_Points";
            this.dgv_Points.RowTemplate.Height = 23;
            this.dgv_Points.Size = new System.Drawing.Size(297, 307);
            this.dgv_Points.TabIndex = 6;
            this.dgv_Points.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Points_CellValueChanged);
            // 
            // cmb_Device
            // 
            this.cmb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Device.FormattingEnabled = true;
            this.cmb_Device.Location = new System.Drawing.Point(577, 23);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Size = new System.Drawing.Size(92, 20);
            this.cmb_Device.TabIndex = 8;
            this.cmb_Device.SelectedIndexChanged += new System.EventHandler(this.cmb_Device_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "采集工具：";
            // 
            // bt_DisImage
            // 
            this.bt_DisImage.Location = new System.Drawing.Point(704, 22);
            this.bt_DisImage.Name = "bt_DisImage";
            this.bt_DisImage.Size = new System.Drawing.Size(75, 23);
            this.bt_DisImage.TabIndex = 9;
            this.bt_DisImage.Text = "采集图像";
            this.bt_DisImage.UseVisualStyleBackColor = true;
            this.bt_DisImage.Click += new System.EventHandler(this.bt_DisImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "(拾取仅限圆Mark点)";
            // 
            // bt_GetMark
            // 
            this.bt_GetMark.Location = new System.Drawing.Point(522, 85);
            this.bt_GetMark.Name = "bt_GetMark";
            this.bt_GetMark.Size = new System.Drawing.Size(75, 33);
            this.bt_GetMark.TabIndex = 21;
            this.bt_GetMark.Text = "拾取Mark点";
            this.bt_GetMark.UseVisualStyleBackColor = true;
            this.bt_GetMark.Click += new System.EventHandler(this.bt_FindCircle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_MachineY);
            this.groupBox1.Controls.Add(this.nud_MachineX);
            this.groupBox1.Controls.Add(this.txt_WordX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_WordY);
            this.groupBox1.Location = new System.Drawing.Point(315, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 114);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标信息";
            // 
            // nud_MachineY
            // 
            this.nud_MachineY.DecimalPlaces = 3;
            this.nud_MachineY.Location = new System.Drawing.Point(226, 29);
            this.nud_MachineY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_MachineY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_MachineY.Name = "nud_MachineY";
            this.nud_MachineY.Size = new System.Drawing.Size(75, 21);
            this.nud_MachineY.TabIndex = 37;
            // 
            // nud_MachineX
            // 
            this.nud_MachineX.DecimalPlaces = 3;
            this.nud_MachineX.Location = new System.Drawing.Point(73, 29);
            this.nud_MachineX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_MachineX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_MachineX.Name = "nud_MachineX";
            this.nud_MachineX.Size = new System.Drawing.Size(75, 21);
            this.nud_MachineX.TabIndex = 36;
            // 
            // txt_WordX
            // 
            this.txt_WordX.Location = new System.Drawing.Point(71, 65);
            this.txt_WordX.Name = "txt_WordX";
            this.txt_WordX.ReadOnly = true;
            this.txt_WordX.Size = new System.Drawing.Size(73, 21);
            this.txt_WordX.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "世界坐标X：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "机械坐标Y：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "机械坐标X：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "世界坐标Y:";
            // 
            // txt_WordY
            // 
            this.txt_WordY.Location = new System.Drawing.Point(226, 65);
            this.txt_WordY.Name = "txt_WordY";
            this.txt_WordY.ReadOnly = true;
            this.txt_WordY.Size = new System.Drawing.Size(73, 21);
            this.txt_WordY.TabIndex = 27;
            // 
            // cmb_CalibCoordID
            // 
            this.cmb_CalibCoordID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CalibCoordID.FormattingEnabled = true;
            this.cmb_CalibCoordID.Location = new System.Drawing.Point(500, 157);
            this.cmb_CalibCoordID.Name = "cmb_CalibCoordID";
            this.cmb_CalibCoordID.Size = new System.Drawing.Size(92, 20);
            this.cmb_CalibCoordID.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "9点标定单元：";
            // 
            // measureControl1
            // 
            this.measureControl1.Location = new System.Drawing.Point(623, 31);
            this.measureControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.measureControl1.Name = "measureControl1";
            this.measureControl1.Size = new System.Drawing.Size(222, 288);
            this.measureControl1.TabIndex = 31;
            // 
            // frm_Unit_RoteCenterCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 467);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_Unit_RoteCenterCalib";
            this.Text = "frm_Unit_TurnCenterCalib";
            this.Load += new System.EventHandler(this.frm_Unit_RoteCenterCalib_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Points)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MachineY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MachineX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Points;
        private System.Windows.Forms.ComboBox cmb_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_DisImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_GetMark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_WordY;
        private System.Windows.Forms.TextBox txt_WordX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_CalibCoordID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_MachineY;
        private System.Windows.Forms.NumericUpDown nud_MachineX;
        private MeasureControl measureControl1;
    }
}