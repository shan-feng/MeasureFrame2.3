namespace MeasureFrame.IUI
{
    partial class frm_ResultView2
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
            this.mCtrl_HWindow = new HalconDotNet.HWindowControl();
            this.SuspendLayout();
            // 
            // mCtrl_HWindow
            // 
            this.mCtrl_HWindow.BackColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.BorderColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mCtrl_HWindow.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.mCtrl_HWindow.Location = new System.Drawing.Point(0, 0);
            this.mCtrl_HWindow.Margin = new System.Windows.Forms.Padding(0);
            this.mCtrl_HWindow.Name = "mCtrl_HWindow";
            this.mCtrl_HWindow.Size = new System.Drawing.Size(681, 389);
            this.mCtrl_HWindow.TabIndex = 1;
            this.mCtrl_HWindow.WindowSize = new System.Drawing.Size(681, 389);
            // 
            // frm_ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(681, 389);
            this.Controls.Add(this.mCtrl_HWindow);
            this.MaximizeBox = false;
            this.Name = "frm_ResultView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_ResultView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ResultView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ResultView_FormClosed);
            this.Load += new System.EventHandler(this.frm_ResultView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HalconDotNet.HWindowControl mCtrl_HWindow;
    }
}