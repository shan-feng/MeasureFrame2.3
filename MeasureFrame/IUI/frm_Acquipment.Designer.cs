namespace MeasureFrame.IUI
{
    partial class frm_Acquipment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Add2List = new System.Windows.Forms.Button();
            this.cmb_DeviceName = new System.Windows.Forms.ComboBox();
            this.cmb_DeviceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_DeviceList = new System.Windows.Forms.DataGridView();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.bt_Disconnect = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScaleX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScaleY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_UniqueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_DevDirExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeviceList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Add2List);
            this.groupBox1.Controls.Add(this.cmb_DeviceName);
            this.groupBox1.Controls.Add(this.cmb_DeviceType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备选择";
            // 
            // bt_Add2List
            // 
            this.bt_Add2List.Location = new System.Drawing.Point(441, 28);
            this.bt_Add2List.Name = "bt_Add2List";
            this.bt_Add2List.Size = new System.Drawing.Size(75, 23);
            this.bt_Add2List.TabIndex = 3;
            this.bt_Add2List.Text = "添加到列表";
            this.bt_Add2List.UseVisualStyleBackColor = true;
            this.bt_Add2List.Click += new System.EventHandler(this.bt_Add2List_Click);
            // 
            // cmb_DeviceName
            // 
            this.cmb_DeviceName.FormattingEnabled = true;
            this.cmb_DeviceName.Location = new System.Drawing.Point(267, 30);
            this.cmb_DeviceName.Name = "cmb_DeviceName";
            this.cmb_DeviceName.Size = new System.Drawing.Size(142, 20);
            this.cmb_DeviceName.TabIndex = 2;
            // 
            // cmb_DeviceType
            // 
            this.cmb_DeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DeviceType.FormattingEnabled = true;
            this.cmb_DeviceType.Location = new System.Drawing.Point(93, 30);
            this.cmb_DeviceType.Name = "cmb_DeviceType";
            this.cmb_DeviceType.Size = new System.Drawing.Size(142, 20);
            this.cmb_DeviceType.TabIndex = 1;
            this.cmb_DeviceType.SelectedIndexChanged += new System.EventHandler(this.cmb_DeviceType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备型号：";
            // 
            // dgv_DeviceList
            // 
            this.dgv_DeviceList.AllowUserToAddRows = false;
            this.dgv_DeviceList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DeviceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceID,
            this.DeviceType,
            this.DeviceStatus,
            this.SerialNO,
            this.ScaleX,
            this.ScaleY,
            this.m_UniqueName,
            this.m_DevDirExt});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DeviceList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DeviceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_DeviceList.Location = new System.Drawing.Point(0, 73);
            this.dgv_DeviceList.MultiSelect = false;
            this.dgv_DeviceList.Name = "dgv_DeviceList";
            this.dgv_DeviceList.ReadOnly = true;
            this.dgv_DeviceList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_DeviceList.RowTemplate.Height = 23;
            this.dgv_DeviceList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_DeviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DeviceList.Size = new System.Drawing.Size(573, 285);
            this.dgv_DeviceList.TabIndex = 1;
            this.dgv_DeviceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DeviceList_CellClick);
            this.dgv_DeviceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DeviceList_CellClick);
            this.dgv_DeviceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DeviceList_CellDoubleClick);
            // 
            // bt_Connect
            // 
            this.bt_Connect.Location = new System.Drawing.Point(15, 366);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(75, 36);
            this.bt_Connect.TabIndex = 2;
            this.bt_Connect.Text = "连接";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // bt_Disconnect
            // 
            this.bt_Disconnect.Location = new System.Drawing.Point(118, 366);
            this.bt_Disconnect.Name = "bt_Disconnect";
            this.bt_Disconnect.Size = new System.Drawing.Size(75, 36);
            this.bt_Disconnect.TabIndex = 3;
            this.bt_Disconnect.Text = "断开";
            this.bt_Disconnect.UseVisualStyleBackColor = true;
            this.bt_Disconnect.Click += new System.EventHandler(this.bt_Disconnect_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(219, 366);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 36);
            this.bt_Delete.TabIndex = 4;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(315, 366);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 36);
            this.bt_DeleteAll.TabIndex = 5;
            this.bt_DeleteAll.Text = "删除全部";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(414, 366);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 36);
            this.bt_Save.TabIndex = 6;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // DeviceID
            // 
            this.DeviceID.DataPropertyName = "m_DeviceID";
            this.DeviceID.Frozen = true;
            this.DeviceID.HeaderText = "设备ID";
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.ReadOnly = true;
            // 
            // DeviceType
            // 
            this.DeviceType.DataPropertyName = "m_DeviceType";
            this.DeviceType.Frozen = true;
            this.DeviceType.HeaderText = "设备类型";
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.ReadOnly = true;
            // 
            // DeviceStatus
            // 
            this.DeviceStatus.DataPropertyName = "m_bConnected";
            this.DeviceStatus.Frozen = true;
            this.DeviceStatus.HeaderText = "状态";
            this.DeviceStatus.Name = "DeviceStatus";
            this.DeviceStatus.ReadOnly = true;
            this.DeviceStatus.Width = 70;
            // 
            // SerialNO
            // 
            this.SerialNO.DataPropertyName = "m_SerialNo";
            this.SerialNO.Frozen = true;
            this.SerialNO.HeaderText = "序列号";
            this.SerialNO.Name = "SerialNO";
            this.SerialNO.ReadOnly = true;
            // 
            // ScaleX
            // 
            this.ScaleX.DataPropertyName = "ScaleX";
            this.ScaleX.Frozen = true;
            this.ScaleX.HeaderText = "X像素当量";
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.ReadOnly = true;
            // 
            // ScaleY
            // 
            this.ScaleY.DataPropertyName = "ScaleY";
            this.ScaleY.Frozen = true;
            this.ScaleY.HeaderText = "Y像素当量";
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.ReadOnly = true;
            // 
            // m_UniqueName
            // 
            this.m_UniqueName.DataPropertyName = "m_UniqueLabel";
            this.m_UniqueName.Frozen = true;
            this.m_UniqueName.HeaderText = "设备描述";
            this.m_UniqueName.Name = "m_UniqueName";
            this.m_UniqueName.ReadOnly = true;
            // 
            // m_DevDirExt
            // 
            this.m_DevDirExt.DataPropertyName = "m_DevDirExt";
            this.m_DevDirExt.Frozen = true;
            this.m_DevDirExt.HeaderText = "设备备注";
            this.m_DevDirExt.Name = "m_DevDirExt";
            this.m_DevDirExt.ReadOnly = true;
            // 
            // frm_Acquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 414);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.bt_DeleteAll);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Disconnect);
            this.Controls.Add(this.bt_Connect);
            this.Controls.Add(this.dgv_DeviceList);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(200, 100);
            this.MaximizeBox = false;
            this.Name = "frm_Acquipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "采集设备";
            this.Load += new System.EventHandler(this.frm_Acquipment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DeviceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Add2List;
        private System.Windows.Forms.ComboBox cmb_DeviceName;
        private System.Windows.Forms.ComboBox cmb_DeviceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_DeviceList;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.Button bt_Disconnect;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScaleX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScaleY;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_UniqueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DevDirExt;
    }
}