namespace MeasureFrame.IUI
{
    partial class frm_Unit_CalibCoord
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
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label_sx = new System.Windows.Forms.Label();
            this.Label_sy = new System.Windows.Forms.Label();
            this.Label_phi = new System.Windows.Forms.Label();
            this.Label_theta = new System.Windows.Forms.Label();
            this.Label_tx = new System.Windows.Forms.Label();
            this.Label_ty = new System.Windows.Forms.Label();
            this.bt_FindCircle = new System.Windows.Forms.Button();
            this.txt_Row = new System.Windows.Forms.TextBox();
            this.txt_Col = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_currPosi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_AddData = new System.Windows.Forms.Button();
            this.tabP_SingleAxis = new System.Windows.Forms.TabPage();
            this.measureControlOneAxis = new MeasureFrame.IUI.MeasureControl();
            this.bt_addRow = new System.Windows.Forms.Button();
            this.chk_axisX = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_colS = new System.Windows.Forms.TextBox();
            this.txt_rowS = new System.Windows.Forms.TextBox();
            this.bt_MarkS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CameraAxisPhi = new System.Windows.Forms.TextBox();
            this.dgv_SingleData = new System.Windows.Forms.DataGridView();
            this.cmb_AxisCount = new System.Windows.Forms.ComboBox();
            this.cmb_Device = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bt_DisImage = new System.Windows.Forms.Button();
            this.measureControlXY = new MeasureFrame.IUI.MeasureControl();
            this.chkRbootMode = new System.Windows.Forms.CheckBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Points)).BeginInit();
            this.GroupBox9.SuspendLayout();
            this.TableLayoutPanel6.SuspendLayout();
            this.tabP_SingleAxis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SingleData)).BeginInit();
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
            this.gb_top.Controls.Add(this.bt_DisImage);
            this.gb_top.Controls.Add(this.cmb_Device);
            this.gb_top.Controls.Add(this.label10);
            this.gb_top.Controls.Add(this.cmb_AxisCount);
            this.gb_top.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_top.Size = new System.Drawing.Size(1253, 62);
            this.gb_top.Controls.SetChildIndex(this.cmb_AxisCount, 0);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            this.gb_top.Controls.SetChildIndex(this.label10, 0);
            this.gb_top.Controls.SetChildIndex(this.cmb_Device, 0);
            this.gb_top.Controls.SetChildIndex(this.bt_DisImage, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabP_SingleAxis);
            this.tab_Main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tab_Main.Size = new System.Drawing.Size(1253, 600);
            this.tab_Main.Controls.SetChildIndex(this.tabP_baseSetting, 0);
            this.tab_Main.Controls.SetChildIndex(this.tabP_SingleAxis, 0);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.chkRbootMode);
            this.gb_main.Controls.Add(this.measureControlXY);
            this.gb_main.Controls.Add(this.bt_AddData);
            this.gb_main.Controls.Add(this.label5);
            this.gb_main.Controls.Add(this.txt_currPosi);
            this.gb_main.Controls.Add(this.label4);
            this.gb_main.Controls.Add(this.label3);
            this.gb_main.Controls.Add(this.label1);
            this.gb_main.Controls.Add(this.txt_Col);
            this.gb_main.Controls.Add(this.txt_Row);
            this.gb_main.Controls.Add(this.bt_FindCircle);
            this.gb_main.Controls.Add(this.GroupBox9);
            this.gb_main.Controls.Add(this.dgv_Points);
            this.gb_main.Location = new System.Drawing.Point(5, 5);
            this.gb_main.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gb_main.Size = new System.Drawing.Size(1235, 561);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 25);
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabP_baseSetting.Size = new System.Drawing.Size(1245, 571);
            this.tabP_baseSetting.Text = "XY轴标定";
            // 
            // dgv_Points
            // 
            this.dgv_Points.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Points.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_Points.Location = new System.Drawing.Point(5, 23);
            this.dgv_Points.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_Points.Name = "dgv_Points";
            this.dgv_Points.RowTemplate.Height = 23;
            this.dgv_Points.Size = new System.Drawing.Size(555, 533);
            this.dgv_Points.TabIndex = 0;
            this.dgv_Points.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Points_CellValueChanged);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.TableLayoutPanel6);
            this.GroupBox9.Location = new System.Drawing.Point(904, 25);
            this.GroupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox9.Size = new System.Drawing.Size(324, 220);
            this.GroupBox9.TabIndex = 8;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "标定结果";
            // 
            // TableLayoutPanel6
            // 
            this.TableLayoutPanel6.ColumnCount = 2;
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.53556F));
            this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.46444F));
            this.TableLayoutPanel6.Controls.Add(this.Label18, 0, 0);
            this.TableLayoutPanel6.Controls.Add(this.Label19, 0, 1);
            this.TableLayoutPanel6.Controls.Add(this.Label20, 0, 2);
            this.TableLayoutPanel6.Controls.Add(this.Label21, 0, 3);
            this.TableLayoutPanel6.Controls.Add(this.Label22, 0, 4);
            this.TableLayoutPanel6.Controls.Add(this.Label23, 0, 5);
            this.TableLayoutPanel6.Controls.Add(this.Label_sx, 1, 0);
            this.TableLayoutPanel6.Controls.Add(this.Label_sy, 1, 1);
            this.TableLayoutPanel6.Controls.Add(this.Label_phi, 1, 2);
            this.TableLayoutPanel6.Controls.Add(this.Label_theta, 1, 3);
            this.TableLayoutPanel6.Controls.Add(this.Label_tx, 1, 4);
            this.TableLayoutPanel6.Controls.Add(this.Label_ty, 1, 5);
            this.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel6.Location = new System.Drawing.Point(3, 20);
            this.TableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TableLayoutPanel6.Name = "TableLayoutPanel6";
            this.TableLayoutPanel6.RowCount = 6;
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.TableLayoutPanel6.Size = new System.Drawing.Size(318, 198);
            this.TableLayoutPanel6.TabIndex = 4;
            // 
            // Label18
            // 
            this.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label18.Location = new System.Drawing.Point(4, 0);
            this.Label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(146, 32);
            this.Label18.TabIndex = 0;
            this.Label18.Text = "x轴像素当量";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label19
            // 
            this.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label19.Location = new System.Drawing.Point(4, 32);
            this.Label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(146, 32);
            this.Label19.TabIndex = 0;
            this.Label19.Text = "y轴像素当量";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label20
            // 
            this.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label20.Location = new System.Drawing.Point(4, 64);
            this.Label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(146, 32);
            this.Label20.TabIndex = 0;
            this.Label20.Text = "坐标系角度差(°)";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label21
            // 
            this.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label21.Location = new System.Drawing.Point(4, 96);
            this.Label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(146, 32);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "垂直角度差(°)";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label22
            // 
            this.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label22.Location = new System.Drawing.Point(4, 128);
            this.Label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(146, 32);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "x轴偏移";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label23
            // 
            this.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label23.Location = new System.Drawing.Point(4, 160);
            this.Label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(146, 38);
            this.Label23.TabIndex = 0;
            this.Label23.Text = "y轴偏移";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_sx
            // 
            this.Label_sx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_sx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_sx.Location = new System.Drawing.Point(158, 0);
            this.Label_sx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_sx.Name = "Label_sx";
            this.Label_sx.Size = new System.Drawing.Size(156, 32);
            this.Label_sx.TabIndex = 0;
            this.Label_sx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_sy
            // 
            this.Label_sy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_sy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_sy.Location = new System.Drawing.Point(158, 32);
            this.Label_sy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_sy.Name = "Label_sy";
            this.Label_sy.Size = new System.Drawing.Size(156, 32);
            this.Label_sy.TabIndex = 0;
            this.Label_sy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_phi
            // 
            this.Label_phi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_phi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_phi.Location = new System.Drawing.Point(158, 64);
            this.Label_phi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_phi.Name = "Label_phi";
            this.Label_phi.Size = new System.Drawing.Size(156, 32);
            this.Label_phi.TabIndex = 0;
            this.Label_phi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_theta
            // 
            this.Label_theta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_theta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_theta.Location = new System.Drawing.Point(158, 96);
            this.Label_theta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_theta.Name = "Label_theta";
            this.Label_theta.Size = new System.Drawing.Size(156, 32);
            this.Label_theta.TabIndex = 0;
            this.Label_theta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_tx
            // 
            this.Label_tx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_tx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_tx.Location = new System.Drawing.Point(158, 128);
            this.Label_tx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_tx.Name = "Label_tx";
            this.Label_tx.Size = new System.Drawing.Size(156, 32);
            this.Label_tx.TabIndex = 0;
            this.Label_tx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_ty
            // 
            this.Label_ty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_ty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_ty.Location = new System.Drawing.Point(158, 160);
            this.Label_ty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_ty.Name = "Label_ty";
            this.Label_ty.Size = new System.Drawing.Size(156, 38);
            this.Label_ty.TabIndex = 0;
            this.Label_ty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_FindCircle
            // 
            this.bt_FindCircle.Location = new System.Drawing.Point(904, 481);
            this.bt_FindCircle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_FindCircle.Name = "bt_FindCircle";
            this.bt_FindCircle.Size = new System.Drawing.Size(100, 41);
            this.bt_FindCircle.TabIndex = 9;
            this.bt_FindCircle.Text = "拾取Mark点";
            this.bt_FindCircle.UseVisualStyleBackColor = true;
            this.bt_FindCircle.Click += new System.EventHandler(this.bt_FindCircle_Click);
            // 
            // txt_Row
            // 
            this.txt_Row.Location = new System.Drawing.Point(604, 86);
            this.txt_Row.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Row.Name = "txt_Row";
            this.txt_Row.Size = new System.Drawing.Size(96, 25);
            this.txt_Row.TabIndex = 10;
            // 
            // txt_Col
            // 
            this.txt_Col.Location = new System.Drawing.Point(756, 86);
            this.txt_Col.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Col.Name = "txt_Col";
            this.txt_Col.Size = new System.Drawing.Size(96, 25);
            this.txt_Col.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "row:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "col:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "(拾取仅限圆Mark点)";
            // 
            // txt_currPosi
            // 
            this.txt_currPosi.Location = new System.Drawing.Point(629, 141);
            this.txt_currPosi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_currPosi.Name = "txt_currPosi";
            this.txt_currPosi.ReadOnly = true;
            this.txt_currPosi.Size = new System.Drawing.Size(171, 25);
            this.txt_currPosi.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "X,Y,Z:";
            // 
            // bt_AddData
            // 
            this.bt_AddData.Location = new System.Drawing.Point(809, 132);
            this.bt_AddData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_AddData.Name = "bt_AddData";
            this.bt_AddData.Size = new System.Drawing.Size(85, 41);
            this.bt_AddData.TabIndex = 17;
            this.bt_AddData.Text = "<<  添加";
            this.bt_AddData.UseVisualStyleBackColor = true;
            this.bt_AddData.Click += new System.EventHandler(this.bt_getCurrPosi_Click);
            // 
            // tabP_SingleAxis
            // 
            this.tabP_SingleAxis.Controls.Add(this.measureControlOneAxis);
            this.tabP_SingleAxis.Controls.Add(this.bt_addRow);
            this.tabP_SingleAxis.Controls.Add(this.chk_axisX);
            this.tabP_SingleAxis.Controls.Add(this.label7);
            this.tabP_SingleAxis.Controls.Add(this.label8);
            this.tabP_SingleAxis.Controls.Add(this.label9);
            this.tabP_SingleAxis.Controls.Add(this.txt_colS);
            this.tabP_SingleAxis.Controls.Add(this.txt_rowS);
            this.tabP_SingleAxis.Controls.Add(this.bt_MarkS);
            this.tabP_SingleAxis.Controls.Add(this.label6);
            this.tabP_SingleAxis.Controls.Add(this.txt_CameraAxisPhi);
            this.tabP_SingleAxis.Controls.Add(this.dgv_SingleData);
            this.tabP_SingleAxis.Location = new System.Drawing.Point(4, 25);
            this.tabP_SingleAxis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_SingleAxis.Name = "tabP_SingleAxis";
            this.tabP_SingleAxis.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_SingleAxis.Size = new System.Drawing.Size(1245, 571);
            this.tabP_SingleAxis.TabIndex = 1;
            this.tabP_SingleAxis.Text = "单轴标定";
            this.tabP_SingleAxis.UseVisualStyleBackColor = true;
            // 
            // measureControlOneAxis
            // 
            this.measureControlOneAxis.Location = new System.Drawing.Point(831, 30);
            this.measureControlOneAxis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.measureControlOneAxis.Name = "measureControlOneAxis";
            this.measureControlOneAxis.Size = new System.Drawing.Size(296, 360);
            this.measureControlOneAxis.TabIndex = 23;
            // 
            // bt_addRow
            // 
            this.bt_addRow.Location = new System.Drawing.Point(695, 256);
            this.bt_addRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_addRow.Name = "bt_addRow";
            this.bt_addRow.Size = new System.Drawing.Size(100, 41);
            this.bt_addRow.TabIndex = 22;
            this.bt_addRow.Text = "<<  添加";
            this.bt_addRow.UseVisualStyleBackColor = true;
            this.bt_addRow.Click += new System.EventHandler(this.bt_addRow_Click);
            // 
            // chk_axisX
            // 
            this.chk_axisX.AutoSize = true;
            this.chk_axisX.Location = new System.Drawing.Point(545, 268);
            this.chk_axisX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_axisX.Name = "chk_axisX";
            this.chk_axisX.Size = new System.Drawing.Size(82, 19);
            this.chk_axisX.TabIndex = 21;
            this.chk_axisX.Text = "X轴移动";
            this.chk_axisX.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "(拾取仅限圆Mark点)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(660, 196);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "col:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(507, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "row:";
            // 
            // txt_colS
            // 
            this.txt_colS.Location = new System.Drawing.Point(697, 192);
            this.txt_colS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_colS.Name = "txt_colS";
            this.txt_colS.Size = new System.Drawing.Size(96, 25);
            this.txt_colS.TabIndex = 17;
            // 
            // txt_rowS
            // 
            this.txt_rowS.Location = new System.Drawing.Point(545, 192);
            this.txt_rowS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_rowS.Name = "txt_rowS";
            this.txt_rowS.Size = new System.Drawing.Size(96, 25);
            this.txt_rowS.TabIndex = 16;
            // 
            // bt_MarkS
            // 
            this.bt_MarkS.Location = new System.Drawing.Point(691, 132);
            this.bt_MarkS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_MarkS.Name = "bt_MarkS";
            this.bt_MarkS.Size = new System.Drawing.Size(100, 41);
            this.bt_MarkS.TabIndex = 15;
            this.bt_MarkS.Text = "拾取Mark点";
            this.bt_MarkS.UseVisualStyleBackColor = true;
            this.bt_MarkS.Click += new System.EventHandler(this.bt_MarkS_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "相机和轴夹角：";
            // 
            // txt_CameraAxisPhi
            // 
            this.txt_CameraAxisPhi.Location = new System.Drawing.Point(655, 65);
            this.txt_CameraAxisPhi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CameraAxisPhi.Name = "txt_CameraAxisPhi";
            this.txt_CameraAxisPhi.ReadOnly = true;
            this.txt_CameraAxisPhi.Size = new System.Drawing.Size(135, 25);
            this.txt_CameraAxisPhi.TabIndex = 13;
            // 
            // dgv_SingleData
            // 
            this.dgv_SingleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SingleData.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_SingleData.Location = new System.Drawing.Point(4, 4);
            this.dgv_SingleData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_SingleData.Name = "dgv_SingleData";
            this.dgv_SingleData.RowTemplate.Height = 23;
            this.dgv_SingleData.Size = new System.Drawing.Size(436, 563);
            this.dgv_SingleData.TabIndex = 1;
            // 
            // cmb_AxisCount
            // 
            this.cmb_AxisCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AxisCount.FormattingEnabled = true;
            this.cmb_AxisCount.Items.AddRange(new object[] {
            "单轴标定",
            "双轴标定"});
            this.cmb_AxisCount.Location = new System.Drawing.Point(407, 25);
            this.cmb_AxisCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_AxisCount.Name = "cmb_AxisCount";
            this.cmb_AxisCount.Size = new System.Drawing.Size(160, 23);
            this.cmb_AxisCount.TabIndex = 4;
            this.cmb_AxisCount.SelectedIndexChanged += new System.EventHandler(this.cmb_AxisCount_SelectedIndexChanged);
            // 
            // cmb_Device
            // 
            this.cmb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Device.FormattingEnabled = true;
            this.cmb_Device.Location = new System.Drawing.Point(691, 28);
            this.cmb_Device.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Size = new System.Drawing.Size(100, 23);
            this.cmb_Device.TabIndex = 6;
            this.cmb_Device.SelectedIndexChanged += new System.EventHandler(this.cmb_Device_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(596, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "采集工具：";
            // 
            // bt_DisImage
            // 
            this.bt_DisImage.Location = new System.Drawing.Point(796, 25);
            this.bt_DisImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_DisImage.Name = "bt_DisImage";
            this.bt_DisImage.Size = new System.Drawing.Size(100, 29);
            this.bt_DisImage.TabIndex = 7;
            this.bt_DisImage.Text = "采集图像";
            this.bt_DisImage.UseVisualStyleBackColor = true;
            this.bt_DisImage.Click += new System.EventHandler(this.bt_DisImage_Click);
            // 
            // measureControlXY
            // 
            this.measureControlXY.Location = new System.Drawing.Point(579, 192);
            this.measureControlXY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.measureControlXY.Name = "measureControlXY";
            this.measureControlXY.Size = new System.Drawing.Size(296, 360);
            this.measureControlXY.TabIndex = 18;
            // 
            // chkRbootMode
            // 
            this.chkRbootMode.AutoSize = true;
            this.chkRbootMode.Location = new System.Drawing.Point(922, 282);
            this.chkRbootMode.Margin = new System.Windows.Forms.Padding(4);
            this.chkRbootMode.Name = "chkRbootMode";
            this.chkRbootMode.Size = new System.Drawing.Size(104, 19);
            this.chkRbootMode.TabIndex = 22;
            this.chkRbootMode.Text = "机械手标定";
            this.chkRbootMode.UseVisualStyleBackColor = true;
            // 
            // frm_Unit_CalibCoord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 734);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Unit_CalibCoord";
            this.Text = "相机和机械坐标标定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_CalibCoord_FormClosing);
            this.Load += new System.EventHandler(this.frm_Unit_CalibCoord_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.gb_main.PerformLayout();
            this.tabP_baseSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Points)).EndInit();
            this.GroupBox9.ResumeLayout(false);
            this.TableLayoutPanel6.ResumeLayout(false);
            this.tabP_SingleAxis.ResumeLayout(false);
            this.tabP_SingleAxis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SingleData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Points;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel6;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label_sx;
        internal System.Windows.Forms.Label Label_sy;
        internal System.Windows.Forms.Label Label_phi;
        internal System.Windows.Forms.Label Label_theta;
        internal System.Windows.Forms.Label Label_tx;
        internal System.Windows.Forms.Label Label_ty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Col;
        private System.Windows.Forms.TextBox txt_Row;
        private System.Windows.Forms.Button bt_FindCircle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_currPosi;
        private System.Windows.Forms.Button bt_AddData;
        private System.Windows.Forms.ComboBox cmb_AxisCount;
        private System.Windows.Forms.TabPage tabP_SingleAxis;
        private System.Windows.Forms.DataGridView dgv_SingleData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CameraAxisPhi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_colS;
        private System.Windows.Forms.TextBox txt_rowS;
        private System.Windows.Forms.Button bt_MarkS;
        private System.Windows.Forms.CheckBox chk_axisX;
        private System.Windows.Forms.Button bt_addRow;
        private System.Windows.Forms.ComboBox cmb_Device;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bt_DisImage;
        private MeasureControl measureControlOneAxis;
        private MeasureControl measureControlXY;
        private System.Windows.Forms.CheckBox chkRbootMode;
    }
}