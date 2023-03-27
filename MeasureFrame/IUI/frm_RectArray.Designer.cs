namespace MeasureFrame.IUI
{
    partial class frm_RectArray
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ColNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_RowNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Phi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Length2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Length1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_secondPointX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_firstPointX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_secondPointY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_firstPointY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_RectArray = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.dgv_RectInfo = new System.Windows.Forms.DataGridView();
            this.CenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenterY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RectInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ColNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_RowNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "阵列";
            // 
            // txt_ColNum
            // 
            this.txt_ColNum.Location = new System.Drawing.Point(297, 24);
            this.txt_ColNum.Name = "txt_ColNum";
            this.txt_ColNum.Size = new System.Drawing.Size(100, 21);
            this.txt_ColNum.TabIndex = 3;
            this.txt_ColNum.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "列数：";
            // 
            // txt_RowNum
            // 
            this.txt_RowNum.Location = new System.Drawing.Point(72, 24);
            this.txt_RowNum.Name = "txt_RowNum";
            this.txt_RowNum.Size = new System.Drawing.Size(100, 21);
            this.txt_RowNum.TabIndex = 1;
            this.txt_RowNum.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "行数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Phi);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_Length2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_Length1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_secondPointX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_firstPointX);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_secondPointY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_firstPointY);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 132);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "对角点";
            // 
            // txt_Phi
            // 
            this.txt_Phi.Location = new System.Drawing.Point(485, 97);
            this.txt_Phi.Name = "txt_Phi";
            this.txt_Phi.Size = new System.Drawing.Size(100, 21);
            this.txt_Phi.TabIndex = 19;
            this.txt_Phi.Text = "0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(438, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "角度：";
            // 
            // txt_Length2
            // 
            this.txt_Length2.Location = new System.Drawing.Point(308, 94);
            this.txt_Length2.Name = "txt_Length2";
            this.txt_Length2.Size = new System.Drawing.Size(100, 21);
            this.txt_Length2.TabIndex = 17;
            this.txt_Length2.Text = "2.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "高度：";
            // 
            // txt_Length1
            // 
            this.txt_Length1.Location = new System.Drawing.Point(83, 94);
            this.txt_Length1.Name = "txt_Length1";
            this.txt_Length1.Size = new System.Drawing.Size(100, 21);
            this.txt_Length1.TabIndex = 15;
            this.txt_Length1.Text = "2.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "宽度：";
            // 
            // txt_secondPointX
            // 
            this.txt_secondPointX.Location = new System.Drawing.Point(308, 21);
            this.txt_secondPointX.Name = "txt_secondPointX";
            this.txt_secondPointX.Size = new System.Drawing.Size(100, 21);
            this.txt_secondPointX.TabIndex = 7;
            this.txt_secondPointX.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y：";
            // 
            // txt_firstPointX
            // 
            this.txt_firstPointX.Location = new System.Drawing.Point(83, 21);
            this.txt_firstPointX.Name = "txt_firstPointX";
            this.txt_firstPointX.Size = new System.Drawing.Size(100, 21);
            this.txt_firstPointX.TabIndex = 5;
            this.txt_firstPointX.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Y：";
            // 
            // txt_secondPointY
            // 
            this.txt_secondPointY.Location = new System.Drawing.Point(308, 55);
            this.txt_secondPointY.Name = "txt_secondPointY";
            this.txt_secondPointY.Size = new System.Drawing.Size(100, 21);
            this.txt_secondPointY.TabIndex = 3;
            this.txt_secondPointY.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "第二角点X：";
            // 
            // txt_firstPointY
            // 
            this.txt_firstPointY.Location = new System.Drawing.Point(83, 55);
            this.txt_firstPointY.Name = "txt_firstPointY";
            this.txt_firstPointY.Size = new System.Drawing.Size(100, 21);
            this.txt_firstPointY.TabIndex = 1;
            this.txt_firstPointY.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "第一角点X：";
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(252, 196);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 20;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(138, 196);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 19;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_RectArray
            // 
            this.bt_RectArray.Location = new System.Drawing.Point(15, 196);
            this.bt_RectArray.Name = "bt_RectArray";
            this.bt_RectArray.Size = new System.Drawing.Size(75, 34);
            this.bt_RectArray.TabIndex = 18;
            this.bt_RectArray.Text = "阵列";
            this.bt_RectArray.UseVisualStyleBackColor = true;
            this.bt_RectArray.Click += new System.EventHandler(this.bt_RectArray_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(473, 196);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(75, 34);
            this.bt_Exit.TabIndex = 22;
            this.bt_Exit.Text = "退出";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(363, 196);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 34);
            this.bt_Save.TabIndex = 21;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // dgv_RectInfo
            // 
            this.dgv_RectInfo.AllowUserToAddRows = false;
            this.dgv_RectInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RectInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_RectInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RectInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CenterX,
            this.CenterY,
            this.Length1,
            this.Length2,
            this.Phi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RectInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_RectInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_RectInfo.Location = new System.Drawing.Point(0, 236);
            this.dgv_RectInfo.Name = "dgv_RectInfo";
            this.dgv_RectInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_RectInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_RectInfo.RowTemplate.Height = 23;
            this.dgv_RectInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RectInfo.Size = new System.Drawing.Size(591, 199);
            this.dgv_RectInfo.TabIndex = 23;
            this.dgv_RectInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RectInfo_RowPostPaint);
            // 
            // CenterX
            // 
            this.CenterX.DataPropertyName = "CenterX";
            this.CenterX.Frozen = true;
            this.CenterX.HeaderText = "中心X";
            this.CenterX.Name = "CenterX";
            this.CenterX.ReadOnly = true;
            this.CenterX.Width = 110;
            // 
            // CenterY
            // 
            this.CenterY.DataPropertyName = "CenterY";
            this.CenterY.Frozen = true;
            this.CenterY.HeaderText = "中心Y";
            this.CenterY.Name = "CenterY";
            this.CenterY.ReadOnly = true;
            this.CenterY.Width = 110;
            // 
            // Length1
            // 
            this.Length1.DataPropertyName = "Length1";
            this.Length1.Frozen = true;
            this.Length1.HeaderText = "宽";
            this.Length1.Name = "Length1";
            this.Length1.ReadOnly = true;
            this.Length1.Width = 110;
            // 
            // Length2
            // 
            this.Length2.DataPropertyName = "Length2";
            this.Length2.Frozen = true;
            this.Length2.HeaderText = "高";
            this.Length2.Name = "Length2";
            this.Length2.ReadOnly = true;
            this.Length2.Width = 110;
            // 
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.Frozen = true;
            this.Phi.HeaderText = "角度";
            this.Phi.Name = "Phi";
            this.Phi.ReadOnly = true;
            this.Phi.Width = 110;
            // 
            // frm_RectArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 435);
            this.Controls.Add(this.dgv_RectInfo);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.bt_DeleteAll);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_RectArray);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "frm_RectArray";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "区域阵列";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RectInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ColNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_RowNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_secondPointX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_firstPointX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_secondPointY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_firstPointY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_RectArray;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.DataGridView dgv_RectInfo;
        private System.Windows.Forms.TextBox txt_Length1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Length2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Phi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenterY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
    }
}