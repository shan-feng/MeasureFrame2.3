namespace MeasureFrame.IUI
{
    partial class frm_Unit
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
            this.gb_top = new System.Windows.Forms.GroupBox();
            this.txt_UnitDescrible = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_bottom = new System.Windows.Forms.GroupBox();
            this.chk_Shield = new System.Windows.Forms.CheckBox();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.tabP_baseSetting = new System.Windows.Forms.TabPage();
            this.gb_main = new System.Windows.Forms.GroupBox();
            this.gb_top.SuspendLayout();
            this.gb_bottom.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.txt_UnitDescrible);
            this.gb_top.Controls.Add(this.label2);
            this.gb_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_top.Location = new System.Drawing.Point(0, 0);
            this.gb_top.Name = "gb_top";
            this.gb_top.Size = new System.Drawing.Size(648, 50);
            this.gb_top.TabIndex = 0;
            this.gb_top.TabStop = false;
            this.gb_top.Text = "单元信息";
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Location = new System.Drawing.Point(113, 23);
            this.txt_UnitDescrible.Name = "txt_UnitDescrible";
            this.txt_UnitDescrible.Size = new System.Drawing.Size(162, 21);
            this.txt_UnitDescrible.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "单元描述：";
            // 
            // gb_bottom
            // 
            this.gb_bottom.Controls.Add(this.chk_Shield);
            this.gb_bottom.Controls.Add(this.bt_Exit);
            this.gb_bottom.Controls.Add(this.bt_Save);
            this.gb_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_bottom.Location = new System.Drawing.Point(0, 409);
            this.gb_bottom.Name = "gb_bottom";
            this.gb_bottom.Size = new System.Drawing.Size(648, 58);
            this.gb_bottom.TabIndex = 1;
            this.gb_bottom.TabStop = false;
            // 
            // chk_Shield
            // 
            this.chk_Shield.AutoSize = true;
            this.chk_Shield.Location = new System.Drawing.Point(23, 21);
            this.chk_Shield.Name = "chk_Shield";
            this.chk_Shield.Size = new System.Drawing.Size(72, 16);
            this.chk_Shield.TabIndex = 4;
            this.chk_Shield.Text = "是否屏蔽";
            this.chk_Shield.UseVisualStyleBackColor = true;
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(482, 21);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(78, 31);
            this.bt_Exit.TabIndex = 1;
            this.bt_Exit.Text = "关闭";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(321, 21);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 31);
            this.bt_Save.TabIndex = 0;
            this.bt_Save.Text = "确认";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabP_baseSetting);
            this.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Main.Location = new System.Drawing.Point(0, 50);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(648, 359);
            this.tab_Main.TabIndex = 4;
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Controls.Add(this.gb_main);
            this.tabP_baseSetting.Location = new System.Drawing.Point(4, 22);
            this.tabP_baseSetting.Name = "tabP_baseSetting";
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_baseSetting.Size = new System.Drawing.Size(640, 333);
            this.tabP_baseSetting.TabIndex = 0;
            this.tabP_baseSetting.Text = "基本设置";
            this.tabP_baseSetting.UseVisualStyleBackColor = true;
            // 
            // gb_main
            // 
            this.gb_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_main.Location = new System.Drawing.Point(3, 3);
            this.gb_main.Name = "gb_main";
            this.gb_main.Size = new System.Drawing.Size(634, 327);
            this.gb_main.TabIndex = 3;
            this.gb_main.TabStop = false;
            // 
            // frm_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 467);
            this.Controls.Add(this.tab_Main);
            this.Controls.Add(this.gb_bottom);
            this.Controls.Add(this.gb_top);
            this.Location = new System.Drawing.Point(200, 100);
            this.MaximizeBox = false;
            this.Name = "frm_Unit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_Unit";
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.gb_bottom.ResumeLayout(false);
            this.gb_bottom.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_bottom;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txt_UnitDescrible;
        protected System.Windows.Forms.Button bt_Save;
        protected System.Windows.Forms.GroupBox gb_top;
        protected System.Windows.Forms.TabControl tab_Main;
        protected System.Windows.Forms.GroupBox gb_main;
        protected System.Windows.Forms.Button bt_Exit;
        protected System.Windows.Forms.TabPage tabP_baseSetting;
        private System.Windows.Forms.CheckBox chk_Shield;
    }
}