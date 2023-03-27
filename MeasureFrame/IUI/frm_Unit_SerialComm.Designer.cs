namespace MeasureFrame.IUI
{
    partial class frm_Unit_SerialComm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabP_CommSetting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_Send = new System.Windows.Forms.Button();
            this.txt_SendData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_RecieveData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_DataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_StopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Parity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_PortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Close = new System.Windows.Forms.Button();
            this.bt_Open = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmb_UnitList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_EndStr = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_SpiltStr = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_dataName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_dataType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_EndPointList = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgv_ResultViewList = new System.Windows.Forms.DataGridView();
            this.m_DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_SpiltStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_NgColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_DeleteAll = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.gb_main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.tabP_CommSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultViewList)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Save
            // 
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // gb_top
            // 
            this.gb_top.Size = new System.Drawing.Size(602, 50);
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabP_CommSetting);
            this.tab_Main.Size = new System.Drawing.Size(602, 504);
            this.tab_Main.Controls.SetChildIndex(this.tabP_CommSetting, 0);
            this.tab_Main.Controls.SetChildIndex(this.tabP_baseSetting, 0);
            // 
            // gb_main
            // 
            this.gb_main.Controls.Add(this.dgv_ResultViewList);
            this.gb_main.Controls.Add(this.bt_DeleteAll);
            this.gb_main.Controls.Add(this.bt_Delete);
            this.gb_main.Controls.Add(this.bt_Edit);
            this.gb_main.Controls.Add(this.bt_Add);
            this.gb_main.Controls.Add(this.groupBox4);
            this.gb_main.Size = new System.Drawing.Size(588, 472);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Size = new System.Drawing.Size(594, 478);
            // 
            // tabP_CommSetting
            // 
            this.tabP_CommSetting.Controls.Add(this.groupBox3);
            this.tabP_CommSetting.Controls.Add(this.groupBox2);
            this.tabP_CommSetting.Controls.Add(this.groupBox1);
            this.tabP_CommSetting.Location = new System.Drawing.Point(4, 22);
            this.tabP_CommSetting.Name = "tabP_CommSetting";
            this.tabP_CommSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_CommSetting.Size = new System.Drawing.Size(594, 478);
            this.tabP_CommSetting.TabIndex = 1;
            this.tabP_CommSetting.Text = "串口设置";
            this.tabP_CommSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_Send);
            this.groupBox3.Controls.Add(this.txt_SendData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(317, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 203);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据";
            // 
            // bt_Send
            // 
            this.bt_Send.Location = new System.Drawing.Point(198, 154);
            this.bt_Send.Name = "bt_Send";
            this.bt_Send.Size = new System.Drawing.Size(75, 31);
            this.bt_Send.TabIndex = 27;
            this.bt_Send.Text = "发送";
            this.bt_Send.UseVisualStyleBackColor = true;
            this.bt_Send.Click += new System.EventHandler(this.bt_Send_Click);
            // 
            // txt_SendData
            // 
            this.txt_SendData.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_SendData.Location = new System.Drawing.Point(3, 17);
            this.txt_SendData.Multiline = true;
            this.txt_SendData.Name = "txt_SendData";
            this.txt_SendData.Size = new System.Drawing.Size(268, 120);
            this.txt_SendData.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_RecieveData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(317, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 269);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // txt_RecieveData
            // 
            this.txt_RecieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RecieveData.Location = new System.Drawing.Point(3, 17);
            this.txt_RecieveData.Multiline = true;
            this.txt_RecieveData.Name = "txt_RecieveData";
            this.txt_RecieveData.ReadOnly = true;
            this.txt_RecieveData.Size = new System.Drawing.Size(268, 249);
            this.txt_RecieveData.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.bt_Close);
            this.groupBox1.Controls.Add(this.bt_Open);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 472);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cmb_DataBits);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.cmb_StopBits);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cmb_Parity);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.cmb_BaudRate);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.cmb_PortName);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(308, 389);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "NULL"});
            this.comboBox6.Location = new System.Drawing.Point(123, 334);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 20);
            this.comboBox6.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "控制流：";
            // 
            // cmb_DataBits
            // 
            this.cmb_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DataBits.FormattingEnabled = true;
            this.cmb_DataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cmb_DataBits.Location = new System.Drawing.Point(123, 274);
            this.cmb_DataBits.Name = "cmb_DataBits";
            this.cmb_DataBits.Size = new System.Drawing.Size(121, 20);
            this.cmb_DataBits.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "数据位：";
            // 
            // cmb_StopBits
            // 
            this.cmb_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBits.FormattingEnabled = true;
            this.cmb_StopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.cmb_StopBits.Location = new System.Drawing.Point(123, 214);
            this.cmb_StopBits.Name = "cmb_StopBits";
            this.cmb_StopBits.Size = new System.Drawing.Size(121, 20);
            this.cmb_StopBits.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "停止位：";
            // 
            // cmb_Parity
            // 
            this.cmb_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Parity.FormattingEnabled = true;
            this.cmb_Parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cmb_Parity.Location = new System.Drawing.Point(123, 154);
            this.cmb_Parity.Name = "cmb_Parity";
            this.cmb_Parity.Size = new System.Drawing.Size(121, 20);
            this.cmb_Parity.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "校  检：";
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cmb_BaudRate.Location = new System.Drawing.Point(123, 94);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(121, 20);
            this.cmb_BaudRate.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "波特率：";
            // 
            // cmb_PortName
            // 
            this.cmb_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PortName.FormattingEnabled = true;
            this.cmb_PortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11"});
            this.cmb_PortName.Location = new System.Drawing.Point(123, 34);
            this.cmb_PortName.Name = "cmb_PortName";
            this.cmb_PortName.Size = new System.Drawing.Size(121, 20);
            this.cmb_PortName.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "串口号：";
            // 
            // bt_Close
            // 
            this.bt_Close.Location = new System.Drawing.Point(175, 423);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(75, 31);
            this.bt_Close.TabIndex = 27;
            this.bt_Close.Text = "关闭";
            this.bt_Close.UseVisualStyleBackColor = true;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // bt_Open
            // 
            this.bt_Open.Location = new System.Drawing.Point(72, 423);
            this.bt_Open.Name = "bt_Open";
            this.bt_Open.Size = new System.Drawing.Size(75, 31);
            this.bt_Open.TabIndex = 26;
            this.bt_Open.Text = "打开";
            this.bt_Open.UseVisualStyleBackColor = true;
            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmb_UnitList);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cmb_EndStr);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cmb_SpiltStr);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cmb_dataName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.cmb_dataType);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cmb_EndPointList);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(582, 135);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "通讯设置";
            // 
            // cmb_UnitList
            // 
            this.cmb_UnitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnitList.FormattingEnabled = true;
            this.cmb_UnitList.Location = new System.Drawing.Point(86, 63);
            this.cmb_UnitList.Name = "cmb_UnitList";
            this.cmb_UnitList.Size = new System.Drawing.Size(137, 20);
            this.cmb_UnitList.TabIndex = 11;
            this.cmb_UnitList.SelectedIndexChanged += new System.EventHandler(this.cmb_Data_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "变量单元:";
            // 
            // cmb_EndStr
            // 
            this.cmb_EndStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EndStr.FormattingEnabled = true;
            this.cmb_EndStr.Location = new System.Drawing.Point(371, 102);
            this.cmb_EndStr.Name = "cmb_EndStr";
            this.cmb_EndStr.Size = new System.Drawing.Size(137, 20);
            this.cmb_EndStr.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "终结符:";
            // 
            // cmb_SpiltStr
            // 
            this.cmb_SpiltStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SpiltStr.FormattingEnabled = true;
            this.cmb_SpiltStr.Location = new System.Drawing.Point(86, 102);
            this.cmb_SpiltStr.Name = "cmb_SpiltStr";
            this.cmb_SpiltStr.Size = new System.Drawing.Size(137, 20);
            this.cmb_SpiltStr.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "分隔符:";
            // 
            // cmb_dataName
            // 
            this.cmb_dataName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dataName.FormattingEnabled = true;
            this.cmb_dataName.Location = new System.Drawing.Point(371, 63);
            this.cmb_dataName.Name = "cmb_dataName";
            this.cmb_dataName.Size = new System.Drawing.Size(137, 20);
            this.cmb_dataName.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(304, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "变量名称:";
            // 
            // cmb_dataType
            // 
            this.cmb_dataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dataType.FormattingEnabled = true;
            this.cmb_dataType.Location = new System.Drawing.Point(371, 31);
            this.cmb_dataType.Name = "cmb_dataType";
            this.cmb_dataType.Size = new System.Drawing.Size(137, 20);
            this.cmb_dataType.TabIndex = 3;
            this.cmb_dataType.SelectedIndexChanged += new System.EventHandler(this.cmb_Data_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "变量类型:";
            // 
            // cmb_EndPointList
            // 
            this.cmb_EndPointList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EndPointList.Enabled = false;
            this.cmb_EndPointList.FormattingEnabled = true;
            this.cmb_EndPointList.Items.AddRange(new object[] {
            "默认"});
            this.cmb_EndPointList.Location = new System.Drawing.Point(86, 28);
            this.cmb_EndPointList.Name = "cmb_EndPointList";
            this.cmb_EndPointList.Size = new System.Drawing.Size(137, 20);
            this.cmb_EndPointList.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(19, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "端口:";
            // 
            // dgv_ResultViewList
            // 
            this.dgv_ResultViewList.AllowUserToAddRows = false;
            this.dgv_ResultViewList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ResultViewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ResultViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ResultViewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_DataType,
            this.m_VariableName,
            this.m_SpiltStr,
            this.m_NgColor});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ResultViewList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_ResultViewList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ResultViewList.Location = new System.Drawing.Point(3, 204);
            this.dgv_ResultViewList.Name = "dgv_ResultViewList";
            this.dgv_ResultViewList.ReadOnly = true;
            this.dgv_ResultViewList.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_ResultViewList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_ResultViewList.RowTemplate.Height = 23;
            this.dgv_ResultViewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ResultViewList.Size = new System.Drawing.Size(582, 265);
            this.dgv_ResultViewList.TabIndex = 38;
            this.dgv_ResultViewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ResultViewList_CellClick);
            // 
            // m_DataType
            // 
            this.m_DataType.DataPropertyName = "m_DataType";
            this.m_DataType.Frozen = true;
            this.m_DataType.HeaderText = "变量类型";
            this.m_DataType.Name = "m_DataType";
            this.m_DataType.ReadOnly = true;
            this.m_DataType.Width = 130;
            // 
            // m_VariableName
            // 
            this.m_VariableName.DataPropertyName = "m_VariableName";
            this.m_VariableName.Frozen = true;
            this.m_VariableName.HeaderText = "变量名称";
            this.m_VariableName.Name = "m_VariableName";
            this.m_VariableName.ReadOnly = true;
            this.m_VariableName.Width = 130;
            // 
            // m_SpiltStr
            // 
            this.m_SpiltStr.DataPropertyName = "m_SpiltStr";
            this.m_SpiltStr.Frozen = true;
            this.m_SpiltStr.HeaderText = "分隔符";
            this.m_SpiltStr.Name = "m_SpiltStr";
            this.m_SpiltStr.ReadOnly = true;
            this.m_SpiltStr.Width = 130;
            // 
            // m_NgColor
            // 
            this.m_NgColor.DataPropertyName = "m_EndStr";
            this.m_NgColor.Frozen = true;
            this.m_NgColor.HeaderText = "终结符";
            this.m_NgColor.Name = "m_NgColor";
            this.m_NgColor.ReadOnly = true;
            this.m_NgColor.Width = 130;
            // 
            // bt_DeleteAll
            // 
            this.bt_DeleteAll.Location = new System.Drawing.Point(436, 158);
            this.bt_DeleteAll.Name = "bt_DeleteAll";
            this.bt_DeleteAll.Size = new System.Drawing.Size(75, 34);
            this.bt_DeleteAll.TabIndex = 37;
            this.bt_DeleteAll.Text = "全部删除";
            this.bt_DeleteAll.UseVisualStyleBackColor = true;
            this.bt_DeleteAll.Click += new System.EventHandler(this.bt_DeleteAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(323, 158);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 34);
            this.bt_Delete.TabIndex = 36;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(207, 158);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 34);
            this.bt_Edit.TabIndex = 35;
            this.bt_Edit.Text = "修改";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(88, 158);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 34);
            this.bt_Add.TabIndex = 34;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // frm_Unit_SerialComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 612);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frm_Unit_SerialComm";
            this.Text = "frm_Unit_SerialComm";
            this.Load += new System.EventHandler(this.frm_Unit_SerialComm_Load);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.gb_main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.tabP_CommSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultViewList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabP_CommSetting;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_Send;
        private System.Windows.Forms.TextBox txt_SendData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_RecieveData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.Button bt_Open;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmb_UnitList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_EndStr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_SpiltStr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_dataName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_dataType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_EndPointList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgv_ResultViewList;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_VariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_SpiltStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_NgColor;
        private System.Windows.Forms.Button bt_DeleteAll;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_DataBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_StopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Parity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_PortName;
        private System.Windows.Forms.Label label1;
    }
}