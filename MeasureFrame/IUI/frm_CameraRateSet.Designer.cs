namespace MeasureFrame.IUI
{
    partial class frm_CameraRateSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ScaleX = new System.Windows.Forms.TextBox();
            this.txt_ScaleY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X像素当量（mm）";
            // 
            // txt_ScaleX
            // 
            this.txt_ScaleX.Location = new System.Drawing.Point(124, 33);
            this.txt_ScaleX.Name = "txt_ScaleX";
            this.txt_ScaleX.Size = new System.Drawing.Size(112, 21);
            this.txt_ScaleX.TabIndex = 1;
            // 
            // txt_ScaleY
            // 
            this.txt_ScaleY.Location = new System.Drawing.Point(376, 33);
            this.txt_ScaleY.Name = "txt_ScaleY";
            this.txt_ScaleY.Size = new System.Drawing.Size(119, 21);
            this.txt_ScaleY.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y像素当量（mm）";
            // 
            // bt_Save
            // 
            this.bt_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_Save.Location = new System.Drawing.Point(277, 89);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(93, 39);
            this.bt_Save.TabIndex = 4;
            this.bt_Save.Text = "保存";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // frm_CameraRateSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 132);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.txt_ScaleY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ScaleX);
            this.Controls.Add(this.label1);
            this.Name = "frm_CameraRateSet";
            this.Text = "相机像素当量设置";
            this.Load += new System.EventHandler(this.frm_CameraRateSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ScaleX;
        private System.Windows.Forms.TextBox txt_ScaleY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Save;
    }
}