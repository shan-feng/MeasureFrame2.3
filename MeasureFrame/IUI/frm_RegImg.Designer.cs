namespace MeasureFrame.IUI
{
    partial class frm_RegImg
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
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.dgv_ImgList = new System.Windows.Forms.DataGridView();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_ReName = new System.Windows.Forms.Button();
            this.bt_SaveImg = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_ImageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgList)).BeginInit();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(610, 479);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(610, 479);
            // 
            // dgv_ImgList
            // 
            this.dgv_ImgList.AllowUserToAddRows = false;
            this.dgv_ImgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ImgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ImgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ImgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_ImageID,
            this.m_Type});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ImgList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ImgList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_ImgList.Location = new System.Drawing.Point(610, 0);
            this.dgv_ImgList.MultiSelect = false;
            this.dgv_ImgList.Name = "dgv_ImgList";
            this.dgv_ImgList.ReadOnly = true;
            this.dgv_ImgList.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ImgList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ImgList.RowTemplate.Height = 23;
            this.dgv_ImgList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_ImgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ImgList.Size = new System.Drawing.Size(236, 284);
            this.dgv_ImgList.TabIndex = 21;
            this.dgv_ImgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ImgList_CellClick);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(636, 340);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 43);
            this.bt_Add.TabIndex = 22;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(747, 340);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 43);
            this.bt_Delete.TabIndex = 23;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_ReName
            // 
            this.bt_ReName.Location = new System.Drawing.Point(636, 411);
            this.bt_ReName.Name = "bt_ReName";
            this.bt_ReName.Size = new System.Drawing.Size(75, 43);
            this.bt_ReName.TabIndex = 24;
            this.bt_ReName.Text = "重命名";
            this.bt_ReName.UseVisualStyleBackColor = true;
            this.bt_ReName.Click += new System.EventHandler(this.bt_ReName_Click);
            // 
            // bt_SaveImg
            // 
            this.bt_SaveImg.Location = new System.Drawing.Point(747, 411);
            this.bt_SaveImg.Name = "bt_SaveImg";
            this.bt_SaveImg.Size = new System.Drawing.Size(75, 43);
            this.bt_SaveImg.TabIndex = 25;
            this.bt_SaveImg.Text = "保存图片";
            this.bt_SaveImg.UseVisualStyleBackColor = true;
            this.bt_SaveImg.Click += new System.EventHandler(this.bt_SaveImg_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(704, 299);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(118, 21);
            this.txtName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "图片名称:";
            // 
            // m_ImageID
            // 
            this.m_ImageID.DataPropertyName = "m_ImageID";
            this.m_ImageID.HeaderText = "图片名称";
            this.m_ImageID.Name = "m_ImageID";
            this.m_ImageID.ReadOnly = true;
            this.m_ImageID.Width = 110;
            // 
            // m_Type
            // 
            this.m_Type.DataPropertyName = "m_Type";
            this.m_Type.HeaderText = "图片类型";
            this.m_Type.Name = "m_Type";
            this.m_Type.ReadOnly = true;
            // 
            // frm_RegImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.bt_SaveImg);
            this.Controls.Add(this.bt_ReName);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.dgv_ImgList);
            this.Controls.Add(this.hWindowControl1);
            this.MaximizeBox = false;
            this.Name = "frm_RegImg";
            this.Text = "注册图像";
            this.Load += new System.EventHandler(this.frm_RegImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.DataGridView dgv_ImgList;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_ReName;
        private System.Windows.Forms.Button bt_SaveImg;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ImageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_Type;
    }
}