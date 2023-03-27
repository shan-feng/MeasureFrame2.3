namespace MeasureFrame.IUI
{
    partial class frm_ViewLog
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
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(0, 0);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(448, 441);
            this.txt_log.TabIndex = 0;
            this.txt_log.Text = "";
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(27, 385);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(112, 38);
            this.bt_Clear.TabIndex = 1;
            this.bt_Clear.Text = "清空记录";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(169, 385);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(112, 38);
            this.bt_Save.TabIndex = 2;
            this.bt_Save.Text = "保存记录";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(307, 385);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(112, 38);
            this.bt_Exit.TabIndex = 3;
            this.bt_Exit.Text = "退出";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // frm_ViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 441);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.bt_Clear);
            this.Location = new System.Drawing.Point(200, 100);
            this.Name = "frm_ViewLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "视觉日志";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_Exit;
    }
}