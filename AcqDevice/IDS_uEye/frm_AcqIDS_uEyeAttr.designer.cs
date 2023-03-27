namespace AcqDevice
{
    partial class frm_AcqIDS_uEyeAttr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AcqIDS_uEyeAttr));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.listViewSettings = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bt_Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_LoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_LoadRAM = new System.Windows.Forms.ToolStripMenuItem();
            this.保存配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_Save2File = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_Save2RAM = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.listViewSettings);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.bt_Save);
            this.splitContainerMain.Panel2.Controls.Add(this.panel1);
            this.splitContainerMain.Size = new System.Drawing.Size(663, 418);
            this.splitContainerMain.SplitterDistance = 146;
            this.splitContainerMain.TabIndex = 1;
            // 
            // listViewSettings
            // 
            this.listViewSettings.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSettings.Location = new System.Drawing.Point(0, 0);
            this.listViewSettings.MultiSelect = false;
            this.listViewSettings.Name = "listViewSettings";
            this.listViewSettings.Size = new System.Drawing.Size(146, 418);
            this.listViewSettings.SmallImageList = this.imageList;
            this.listViewSettings.TabIndex = 0;
            this.listViewSettings.UseCompatibleStateImageBehavior = false;
            this.listViewSettings.View = System.Windows.Forms.View.List;
            this.listViewSettings.SelectedIndexChanged += new System.EventHandler(this.listViewSettings_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "settingsCamera.png");
            this.imageList.Images.SetKeyName(1, "settingsImage.png");
            this.imageList.Images.SetKeyName(2, "settingsSize.png");
            this.imageList.Images.SetKeyName(3, "settingsFormat.png");
            this.imageList.Images.SetKeyName(4, "capture_trigger_single.png");
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(355, 351);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 37);
            this.bt_Save.TabIndex = 1;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 345);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(663, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Visible = false;
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取配置文件ToolStripMenuItem,
            this.保存配置文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 读取配置文件ToolStripMenuItem
            // 
            this.读取配置文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_LoadFile,
            this.tmi_LoadRAM});
            this.读取配置文件ToolStripMenuItem.Name = "读取配置文件ToolStripMenuItem";
            this.读取配置文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.读取配置文件ToolStripMenuItem.Text = "读取配置文件";
            // 
            // tmi_LoadFile
            // 
            this.tmi_LoadFile.Name = "tmi_LoadFile";
            this.tmi_LoadFile.Size = new System.Drawing.Size(128, 22);
            this.tmi_LoadFile.Text = "文件读取";
            this.tmi_LoadFile.Click += new System.EventHandler(this.tmi_LoadFile_Click);
            // 
            // tmi_LoadRAM
            // 
            this.tmi_LoadRAM.Name = "tmi_LoadRAM";
            this.tmi_LoadRAM.Size = new System.Drawing.Size(128, 22);
            this.tmi_LoadRAM.Text = "RAM读取";
            this.tmi_LoadRAM.Click += new System.EventHandler(this.tmi_LoadRAM_Click);
            // 
            // 保存配置文件ToolStripMenuItem
            // 
            this.保存配置文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_Save2File,
            this.tmi_Save2RAM});
            this.保存配置文件ToolStripMenuItem.Name = "保存配置文件ToolStripMenuItem";
            this.保存配置文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存配置文件ToolStripMenuItem.Text = "保存配置文件";
            // 
            // tmi_Save2File
            // 
            this.tmi_Save2File.Name = "tmi_Save2File";
            this.tmi_Save2File.Size = new System.Drawing.Size(128, 22);
            this.tmi_Save2File.Text = "文件保存";
            this.tmi_Save2File.Click += new System.EventHandler(this.tmi_Save2File_Click);
            // 
            // tmi_Save2RAM
            // 
            this.tmi_Save2RAM.Name = "tmi_Save2RAM";
            this.tmi_Save2RAM.Size = new System.Drawing.Size(128, 22);
            this.tmi_Save2RAM.Text = "RAM保存";
            this.tmi_Save2RAM.Click += new System.EventHandler(this.tmi_Save2RAM_Click);
            // 
            // frm_AcqIDS_uEyeAttr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 418);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AcqIDS_uEyeAttr";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ListView listViewSettings;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_LoadFile;
        private System.Windows.Forms.ToolStripMenuItem tmi_LoadRAM;
        private System.Windows.Forms.ToolStripMenuItem 保存配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_Save2File;
        private System.Windows.Forms.ToolStripMenuItem tmi_Save2RAM;
    }
}