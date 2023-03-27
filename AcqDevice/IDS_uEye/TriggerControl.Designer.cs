namespace AcqDevice
{
    partial class TriggerControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlSize = new System.Windows.Forms.TabControl();
            this.tabPageTrigger = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_TriggerOff = new System.Windows.Forms.RadioButton();
            this.bt_TriggerForce = new System.Windows.Forms.Button();
            this.rad_TriggerSoft = new System.Windows.Forms.RadioButton();
            this.rad_TriggerRE = new System.Windows.Forms.RadioButton();
            this.rad_TriggerFE = new System.Windows.Forms.RadioButton();
            this.rad_TriggerContinue = new System.Windows.Forms.RadioButton();
            this.tabControlSize.SuspendLayout();
            this.tabPageTrigger.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSize
            // 
            this.tabControlSize.Controls.Add(this.tabPageTrigger);
            this.tabControlSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSize.Location = new System.Drawing.Point(0, 0);
            this.tabControlSize.Name = "tabControlSize";
            this.tabControlSize.SelectedIndex = 0;
            this.tabControlSize.Size = new System.Drawing.Size(642, 374);
            this.tabControlSize.TabIndex = 1;
            // 
            // tabPageTrigger
            // 
            this.tabPageTrigger.Controls.Add(this.groupBox1);
            this.tabPageTrigger.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrigger.Name = "tabPageTrigger";
            this.tabPageTrigger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrigger.Size = new System.Drawing.Size(634, 348);
            this.tabPageTrigger.TabIndex = 0;
            this.tabPageTrigger.Text = "Trigger";
            this.tabPageTrigger.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_TriggerOff);
            this.groupBox1.Controls.Add(this.bt_TriggerForce);
            this.groupBox1.Controls.Add(this.rad_TriggerSoft);
            this.groupBox1.Controls.Add(this.rad_TriggerRE);
            this.groupBox1.Controls.Add(this.rad_TriggerFE);
            this.groupBox1.Controls.Add(this.rad_TriggerContinue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 342);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TriggerMode";
            // 
            // rad_TriggerOff
            // 
            this.rad_TriggerOff.AutoSize = true;
            this.rad_TriggerOff.Location = new System.Drawing.Point(49, 46);
            this.rad_TriggerOff.Name = "rad_TriggerOff";
            this.rad_TriggerOff.Size = new System.Drawing.Size(83, 16);
            this.rad_TriggerOff.TabIndex = 5;
            this.rad_TriggerOff.TabStop = true;
            this.rad_TriggerOff.Text = "TriggerOff";
            this.rad_TriggerOff.UseVisualStyleBackColor = true;
            this.rad_TriggerOff.Click += new System.EventHandler(this.radioTrigger_CheckedChanged);
            // 
            // bt_TriggerForce
            // 
            this.bt_TriggerForce.Location = new System.Drawing.Point(360, 75);
            this.bt_TriggerForce.Name = "bt_TriggerForce";
            this.bt_TriggerForce.Size = new System.Drawing.Size(94, 39);
            this.bt_TriggerForce.TabIndex = 4;
            this.bt_TriggerForce.Text = "SoftWare Trigger";
            this.bt_TriggerForce.UseVisualStyleBackColor = true;
            this.bt_TriggerForce.Click += new System.EventHandler(this.bt_TriggerForce_Click);
            // 
            // rad_TriggerSoft
            // 
            this.rad_TriggerSoft.AutoSize = true;
            this.rad_TriggerSoft.Location = new System.Drawing.Point(49, 258);
            this.rad_TriggerSoft.Name = "rad_TriggerSoft";
            this.rad_TriggerSoft.Size = new System.Drawing.Size(119, 16);
            this.rad_TriggerSoft.TabIndex = 3;
            this.rad_TriggerSoft.TabStop = true;
            this.rad_TriggerSoft.Text = "Software Trigger";
            this.rad_TriggerSoft.UseVisualStyleBackColor = true;
            this.rad_TriggerSoft.Click += new System.EventHandler(this.radioTrigger_CheckedChanged);
            // 
            // rad_TriggerRE
            // 
            this.rad_TriggerRE.AutoSize = true;
            this.rad_TriggerRE.Location = new System.Drawing.Point(49, 204);
            this.rad_TriggerRE.Name = "rad_TriggerRE";
            this.rad_TriggerRE.Size = new System.Drawing.Size(137, 16);
            this.rad_TriggerRE.TabIndex = 2;
            this.rad_TriggerRE.TabStop = true;
            this.rad_TriggerRE.Text = "Trigger Rising Edge";
            this.rad_TriggerRE.UseVisualStyleBackColor = true;
            this.rad_TriggerRE.Click += new System.EventHandler(this.radioTrigger_CheckedChanged);
            // 
            // rad_TriggerFE
            // 
            this.rad_TriggerFE.AutoSize = true;
            this.rad_TriggerFE.Location = new System.Drawing.Point(49, 146);
            this.rad_TriggerFE.Name = "rad_TriggerFE";
            this.rad_TriggerFE.Size = new System.Drawing.Size(143, 16);
            this.rad_TriggerFE.TabIndex = 1;
            this.rad_TriggerFE.TabStop = true;
            this.rad_TriggerFE.Text = "Trigger Falling Edge";
            this.rad_TriggerFE.UseVisualStyleBackColor = true;
            this.rad_TriggerFE.Click += new System.EventHandler(this.radioTrigger_CheckedChanged);
            // 
            // rad_TriggerContinue
            // 
            this.rad_TriggerContinue.AutoSize = true;
            this.rad_TriggerContinue.Location = new System.Drawing.Point(49, 94);
            this.rad_TriggerContinue.Name = "rad_TriggerContinue";
            this.rad_TriggerContinue.Size = new System.Drawing.Size(113, 16);
            this.rad_TriggerContinue.TabIndex = 0;
            this.rad_TriggerContinue.TabStop = true;
            this.rad_TriggerContinue.Text = "TriggerContinue";
            this.rad_TriggerContinue.UseVisualStyleBackColor = true;
            this.rad_TriggerContinue.Click += new System.EventHandler(this.radioTrigger_CheckedChanged);
            // 
            // TriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlSize);
            this.Name = "TriggerControl";
            this.Size = new System.Drawing.Size(642, 374);
            this.tabControlSize.ResumeLayout(false);
            this.tabPageTrigger.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSize;
        private System.Windows.Forms.TabPage tabPageTrigger;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_TriggerForce;
        private System.Windows.Forms.RadioButton rad_TriggerSoft;
        private System.Windows.Forms.RadioButton rad_TriggerRE;
        private System.Windows.Forms.RadioButton rad_TriggerFE;
        private System.Windows.Forms.RadioButton rad_TriggerContinue;
        private System.Windows.Forms.RadioButton rad_TriggerOff;
    }
}
