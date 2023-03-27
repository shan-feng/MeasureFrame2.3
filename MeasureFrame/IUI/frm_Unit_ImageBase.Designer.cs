namespace MeasureFrame.IUI
{
    partial class frm_Unit_ImageBase
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_CurrentImg = new System.Windows.Forms.ComboBox();
            this.gb_top.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.tabP_baseSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UnitDescrible
            // 
            this.txt_UnitDescrible.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // gb_top
            // 
            this.gb_top.Controls.Add(this.label1);
            this.gb_top.Controls.Add(this.cmb_CurrentImg);
            this.gb_top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_top.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_top.Size = new System.Drawing.Size(646, 50);
            this.gb_top.Controls.SetChildIndex(this.cmb_CurrentImg, 0);
            this.gb_top.Controls.SetChildIndex(this.label1, 0);
            this.gb_top.Controls.SetChildIndex(this.txt_UnitDescrible, 0);
            // 
            // tab_Main
            // 
            this.tab_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tab_Main.Size = new System.Drawing.Size(646, 327);
            // 
            // gb_main
            // 
            this.gb_main.Location = new System.Drawing.Point(4, 4);
            this.gb_main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_main.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_main.Size = new System.Drawing.Size(630, 293);
            // 
            // tabP_baseSetting
            // 
            this.tabP_baseSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabP_baseSetting.Size = new System.Drawing.Size(638, 301);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "当前图像：";
            // 
            // cmb_CurrentImg
            // 
            this.cmb_CurrentImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CurrentImg.FormattingEnabled = true;
            this.cmb_CurrentImg.Location = new System.Drawing.Point(448, 22);
            this.cmb_CurrentImg.Name = "cmb_CurrentImg";
            this.cmb_CurrentImg.Size = new System.Drawing.Size(106, 20);
            this.cmb_CurrentImg.TabIndex = 18;
            // 
            // frm_Unit_ImageBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(646, 435);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_Unit_ImageBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Unit_ImageBase_FormClosing);
            this.gb_top.ResumeLayout(false);
            this.gb_top.PerformLayout();
            this.tab_Main.ResumeLayout(false);
            this.tabP_baseSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.ComboBox cmb_CurrentImg;
        protected System.Windows.Forms.Label label1;
    }
}
