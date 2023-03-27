namespace MeasureFrame.IUI
{
    partial class MeasureControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxMeasureInfo = new System.Windows.Forms.GroupBox();
            this.num_MeasureDis = new System.Windows.Forms.NumericUpDown();
            this.num_Threshold = new System.Windows.Forms.NumericUpDown();
            this.num_Length2 = new System.Windows.Forms.NumericUpDown();
            this.num_Length1 = new System.Windows.Forms.NumericUpDown();
            this.cb_Select = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_Direction = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Transition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxMeasureInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MeasureDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMeasureInfo
            // 
            this.groupBoxMeasureInfo.Controls.Add(this.num_MeasureDis);
            this.groupBoxMeasureInfo.Controls.Add(this.num_Threshold);
            this.groupBoxMeasureInfo.Controls.Add(this.num_Length2);
            this.groupBoxMeasureInfo.Controls.Add(this.num_Length1);
            this.groupBoxMeasureInfo.Controls.Add(this.cb_Select);
            this.groupBoxMeasureInfo.Controls.Add(this.label10);
            this.groupBoxMeasureInfo.Controls.Add(this.cb_Direction);
            this.groupBoxMeasureInfo.Controls.Add(this.label9);
            this.groupBoxMeasureInfo.Controls.Add(this.cb_Transition);
            this.groupBoxMeasureInfo.Controls.Add(this.label8);
            this.groupBoxMeasureInfo.Controls.Add(this.label5);
            this.groupBoxMeasureInfo.Controls.Add(this.label3);
            this.groupBoxMeasureInfo.Controls.Add(this.label6);
            this.groupBoxMeasureInfo.Controls.Add(this.label7);
            this.groupBoxMeasureInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMeasureInfo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMeasureInfo.Name = "groupBoxMeasureInfo";
            this.groupBoxMeasureInfo.Size = new System.Drawing.Size(296, 360);
            this.groupBoxMeasureInfo.TabIndex = 0;
            this.groupBoxMeasureInfo.TabStop = false;
            this.groupBoxMeasureInfo.Text = "测量参数";
            // 
            // num_MeasureDis
            // 
            this.num_MeasureDis.Location = new System.Drawing.Point(131, 167);
            this.num_MeasureDis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_MeasureDis.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MeasureDis.Name = "num_MeasureDis";
            this.num_MeasureDis.Size = new System.Drawing.Size(133, 25);
            this.num_MeasureDis.TabIndex = 49;
            this.num_MeasureDis.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // num_Threshold
            // 
            this.num_Threshold.Location = new System.Drawing.Point(133, 119);
            this.num_Threshold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_Threshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Threshold.Name = "num_Threshold";
            this.num_Threshold.Size = new System.Drawing.Size(133, 25);
            this.num_Threshold.TabIndex = 48;
            this.num_Threshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // num_Length2
            // 
            this.num_Length2.Location = new System.Drawing.Point(133, 73);
            this.num_Length2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_Length2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Length2.Name = "num_Length2";
            this.num_Length2.Size = new System.Drawing.Size(133, 25);
            this.num_Length2.TabIndex = 47;
            this.num_Length2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // num_Length1
            // 
            this.num_Length1.Location = new System.Drawing.Point(133, 25);
            this.num_Length1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num_Length1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Length1.Name = "num_Length1";
            this.num_Length1.Size = new System.Drawing.Size(133, 25);
            this.num_Length1.TabIndex = 46;
            this.num_Length1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // cb_Select
            // 
            this.cb_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Select.FormattingEnabled = true;
            this.cb_Select.Items.AddRange(new object[] {
            "First",
            "Last",
            "All",
            "Strongest"});
            this.cb_Select.Location = new System.Drawing.Point(135, 306);
            this.cb_Select.Margin = new System.Windows.Forms.Padding(4);
            this.cb_Select.Name = "cb_Select";
            this.cb_Select.Size = new System.Drawing.Size(132, 23);
            this.cb_Select.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 311);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 44;
            this.label10.Text = "筛选  :";
            // 
            // cb_Direction
            // 
            this.cb_Direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Direction.FormattingEnabled = true;
            this.cb_Direction.Items.AddRange(new object[] {
            "默认值",
            "顺时针",
            "逆时针"});
            this.cb_Direction.Location = new System.Drawing.Point(134, 255);
            this.cb_Direction.Margin = new System.Windows.Forms.Padding(4);
            this.cb_Direction.Name = "cb_Direction";
            this.cb_Direction.Size = new System.Drawing.Size(132, 23);
            this.cb_Direction.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 260);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "方向  :";
            // 
            // cb_Transition
            // 
            this.cb_Transition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Transition.FormattingEnabled = true;
            this.cb_Transition.Items.AddRange(new object[] {
            "由白到黑",
            "由黑到白",
            "所有",
            "规格一致"});
            this.cb_Transition.Location = new System.Drawing.Point(133, 210);
            this.cb_Transition.Margin = new System.Windows.Forms.Padding(4);
            this.cb_Transition.Name = "cb_Transition";
            this.cb_Transition.Size = new System.Drawing.Size(132, 23);
            this.cb_Transition.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 215);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "模式  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "间隔 (pix) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "阈值  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "高度(pix) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "宽度(pix) :";
            // 
            // MeasureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxMeasureInfo);
            this.Name = "MeasureControl";
            this.Size = new System.Drawing.Size(296, 360);
            this.groupBoxMeasureInfo.ResumeLayout(false);
            this.groupBoxMeasureInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MeasureDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMeasureInfo;
        private System.Windows.Forms.NumericUpDown num_MeasureDis;
        private System.Windows.Forms.NumericUpDown num_Threshold;
        private System.Windows.Forms.NumericUpDown num_Length2;
        private System.Windows.Forms.NumericUpDown num_Length1;
        protected System.Windows.Forms.ComboBox cb_Select;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ComboBox cb_Direction;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.ComboBox cb_Transition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
