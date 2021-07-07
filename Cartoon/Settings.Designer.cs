
namespace Cartoon
{
    partial class Settings
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
            this.btnApply = new System.Windows.Forms.Button();
            this.rbMedianBlur = new System.Windows.Forms.RadioButton();
            this.rbGuassianBlur = new System.Windows.Forms.RadioButton();
            this.MaskFilterlbl = new System.Windows.Forms.Label();
            this.pnlMainImageSettings = new System.Windows.Forms.Panel();
            this.lblKmeansKval = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.UpDownKmeansKVal = new System.Windows.Forms.NumericUpDown();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbKmeans = new System.Windows.Forms.RadioButton();
            this.pnlMaskFilterSettings = new System.Windows.Forms.Panel();
            this.lblMaskKVal = new System.Windows.Forms.Label();
            this.UpDownMaskKval = new System.Windows.Forms.NumericUpDown();
            this.pnlCustom = new System.Windows.Forms.Panel();
            this.lblHsv = new System.Windows.Forms.Label();
            this.lblValChange = new System.Windows.Forms.Label();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSat = new System.Windows.Forms.TrackBar();
            this.trackBarVal = new System.Windows.Forms.TrackBar();
            this.lblSatChange = new System.Windows.Forms.Label();
            this.lblHueChange = new System.Windows.Forms.Label();
            this.pbxColorChange = new System.Windows.Forms.PictureBox();
            this.pnlRanges = new System.Windows.Forms.Panel();
            this.lblRangeTitle = new System.Windows.Forms.Label();
            this.UpDownValRange = new System.Windows.Forms.NumericUpDown();
            this.UpDownSatRange = new System.Windows.Forms.NumericUpDown();
            this.UpDownHueRange = new System.Windows.Forms.NumericUpDown();
            this.lblSatRange = new System.Windows.Forms.Label();
            this.lblValRange = new System.Windows.Forms.Label();
            this.lblHueRange = new System.Windows.Forms.Label();
            this.pnlMainImageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownKmeansKVal)).BeginInit();
            this.pnlMaskFilterSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownMaskKval)).BeginInit();
            this.pnlCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).BeginInit();
            this.pnlRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownValRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSatRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownHueRange)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(505, 444);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // rbMedianBlur
            // 
            this.rbMedianBlur.AutoSize = true;
            this.rbMedianBlur.Checked = true;
            this.rbMedianBlur.Location = new System.Drawing.Point(3, 51);
            this.rbMedianBlur.Name = "rbMedianBlur";
            this.rbMedianBlur.Size = new System.Drawing.Size(104, 21);
            this.rbMedianBlur.TabIndex = 14;
            this.rbMedianBlur.TabStop = true;
            this.rbMedianBlur.Text = "Median Blur";
            this.rbMedianBlur.UseVisualStyleBackColor = true;
            this.rbMedianBlur.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbGuassianBlur
            // 
            this.rbGuassianBlur.AutoSize = true;
            this.rbGuassianBlur.Location = new System.Drawing.Point(3, 24);
            this.rbGuassianBlur.Name = "rbGuassianBlur";
            this.rbGuassianBlur.Size = new System.Drawing.Size(118, 21);
            this.rbGuassianBlur.TabIndex = 13;
            this.rbGuassianBlur.Text = "Gaussian Blur";
            this.rbGuassianBlur.UseVisualStyleBackColor = true;
            this.rbGuassianBlur.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // MaskFilterlbl
            // 
            this.MaskFilterlbl.AutoSize = true;
            this.MaskFilterlbl.Location = new System.Drawing.Point(3, 4);
            this.MaskFilterlbl.Name = "MaskFilterlbl";
            this.MaskFilterlbl.Size = new System.Drawing.Size(76, 17);
            this.MaskFilterlbl.TabIndex = 12;
            this.MaskFilterlbl.Text = "Mask Filter";
            // 
            // pnlMainImageSettings
            // 
            this.pnlMainImageSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMainImageSettings.Controls.Add(this.lblKmeansKval);
            this.pnlMainImageSettings.Controls.Add(this.lblBackground);
            this.pnlMainImageSettings.Controls.Add(this.UpDownKmeansKVal);
            this.pnlMainImageSettings.Controls.Add(this.rbCustom);
            this.pnlMainImageSettings.Controls.Add(this.rbKmeans);
            this.pnlMainImageSettings.Location = new System.Drawing.Point(12, 12);
            this.pnlMainImageSettings.Name = "pnlMainImageSettings";
            this.pnlMainImageSettings.Size = new System.Drawing.Size(200, 218);
            this.pnlMainImageSettings.TabIndex = 15;
            // 
            // lblKmeansKval
            // 
            this.lblKmeansKval.AutoSize = true;
            this.lblKmeansKval.Location = new System.Drawing.Point(6, 83);
            this.lblKmeansKval.Name = "lblKmeansKval";
            this.lblKmeansKval.Size = new System.Drawing.Size(37, 17);
            this.lblKmeansKval.TabIndex = 18;
            this.lblKmeansKval.Text = "KVal";
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(3, 4);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(84, 17);
            this.lblBackground.TabIndex = 17;
            this.lblBackground.Text = "Background";
            // 
            // UpDownKmeansKVal
            // 
            this.UpDownKmeansKVal.Location = new System.Drawing.Point(6, 106);
            this.UpDownKmeansKVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownKmeansKVal.Name = "UpDownKmeansKVal";
            this.UpDownKmeansKVal.Size = new System.Drawing.Size(120, 22);
            this.UpDownKmeansKVal.TabIndex = 17;
            this.UpDownKmeansKVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownKmeansKVal.ValueChanged += new System.EventHandler(this.UpDownKmeansKVal_ValueChanged);
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(3, 51);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(76, 21);
            this.rbCustom.TabIndex = 1;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbKmeans_CheckedChanged);
            // 
            // rbKmeans
            // 
            this.rbKmeans.AutoSize = true;
            this.rbKmeans.Location = new System.Drawing.Point(3, 24);
            this.rbKmeans.Name = "rbKmeans";
            this.rbKmeans.Size = new System.Drawing.Size(80, 21);
            this.rbKmeans.TabIndex = 0;
            this.rbKmeans.TabStop = true;
            this.rbKmeans.Text = "Kmeans";
            this.rbKmeans.UseVisualStyleBackColor = true;
            this.rbKmeans.CheckedChanged += new System.EventHandler(this.rbKmeans_CheckedChanged);
            // 
            // pnlMaskFilterSettings
            // 
            this.pnlMaskFilterSettings.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMaskFilterSettings.Controls.Add(this.lblMaskKVal);
            this.pnlMaskFilterSettings.Controls.Add(this.UpDownMaskKval);
            this.pnlMaskFilterSettings.Controls.Add(this.rbMedianBlur);
            this.pnlMaskFilterSettings.Controls.Add(this.MaskFilterlbl);
            this.pnlMaskFilterSettings.Controls.Add(this.rbGuassianBlur);
            this.pnlMaskFilterSettings.Location = new System.Drawing.Point(218, 12);
            this.pnlMaskFilterSettings.Name = "pnlMaskFilterSettings";
            this.pnlMaskFilterSettings.Size = new System.Drawing.Size(209, 218);
            this.pnlMaskFilterSettings.TabIndex = 16;
            // 
            // lblMaskKVal
            // 
            this.lblMaskKVal.AutoSize = true;
            this.lblMaskKVal.Location = new System.Drawing.Point(6, 83);
            this.lblMaskKVal.Name = "lblMaskKVal";
            this.lblMaskKVal.Size = new System.Drawing.Size(37, 17);
            this.lblMaskKVal.TabIndex = 16;
            this.lblMaskKVal.Text = "KVal";
            // 
            // UpDownMaskKval
            // 
            this.UpDownMaskKval.Location = new System.Drawing.Point(6, 106);
            this.UpDownMaskKval.Name = "UpDownMaskKval";
            this.UpDownMaskKval.Size = new System.Drawing.Size(120, 22);
            this.UpDownMaskKval.TabIndex = 15;
            this.UpDownMaskKval.ValueChanged += new System.EventHandler(this.UpDownMaskKval_ValueChanged);
            // 
            // pnlCustom
            // 
            this.pnlCustom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlCustom.Controls.Add(this.lblHsv);
            this.pnlCustom.Controls.Add(this.lblValChange);
            this.pnlCustom.Controls.Add(this.trackBarHue);
            this.pnlCustom.Controls.Add(this.trackBarSat);
            this.pnlCustom.Controls.Add(this.trackBarVal);
            this.pnlCustom.Controls.Add(this.lblSatChange);
            this.pnlCustom.Controls.Add(this.lblHueChange);
            this.pnlCustom.Controls.Add(this.pbxColorChange);
            this.pnlCustom.Location = new System.Drawing.Point(12, 236);
            this.pnlCustom.Name = "pnlCustom";
            this.pnlCustom.Size = new System.Drawing.Size(414, 235);
            this.pnlCustom.TabIndex = 17;
            // 
            // lblHsv
            // 
            this.lblHsv.AutoSize = true;
            this.lblHsv.Location = new System.Drawing.Point(9, 128);
            this.lblHsv.Name = "lblHsv";
            this.lblHsv.Size = new System.Drawing.Size(0, 17);
            this.lblHsv.TabIndex = 24;
            // 
            // lblValChange
            // 
            this.lblValChange.AutoSize = true;
            this.lblValChange.Location = new System.Drawing.Point(126, 14);
            this.lblValChange.Name = "lblValChange";
            this.lblValChange.Size = new System.Drawing.Size(44, 17);
            this.lblValChange.TabIndex = 23;
            this.lblValChange.Text = "Value";
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(10, 175);
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(401, 56);
            this.trackBarHue.TabIndex = 22;
            this.trackBarHue.TickFrequency = 2;
            this.trackBarHue.ValueChanged += new System.EventHandler(this.trackBarHue_ValueChanged);
            // 
            // trackBarSat
            // 
            this.trackBarSat.Location = new System.Drawing.Point(127, 113);
            this.trackBarSat.Maximum = 100;
            this.trackBarSat.Name = "trackBarSat";
            this.trackBarSat.Size = new System.Drawing.Size(284, 56);
            this.trackBarSat.TabIndex = 21;
            this.trackBarSat.TickFrequency = 2;
            this.trackBarSat.Value = 100;
            this.trackBarSat.ValueChanged += new System.EventHandler(this.trackBarSat_ValueChanged);
            // 
            // trackBarVal
            // 
            this.trackBarVal.Location = new System.Drawing.Point(127, 34);
            this.trackBarVal.Maximum = 100;
            this.trackBarVal.Name = "trackBarVal";
            this.trackBarVal.Size = new System.Drawing.Size(284, 56);
            this.trackBarVal.TabIndex = 20;
            this.trackBarVal.TickFrequency = 2;
            this.trackBarVal.Value = 100;
            this.trackBarVal.ValueChanged += new System.EventHandler(this.trackBarVal_ValueChanged);
            // 
            // lblSatChange
            // 
            this.lblSatChange.AutoSize = true;
            this.lblSatChange.Location = new System.Drawing.Point(126, 93);
            this.lblSatChange.Name = "lblSatChange";
            this.lblSatChange.Size = new System.Drawing.Size(73, 17);
            this.lblSatChange.TabIndex = 19;
            this.lblSatChange.Text = "Saturation";
            // 
            // lblHueChange
            // 
            this.lblHueChange.AutoSize = true;
            this.lblHueChange.Location = new System.Drawing.Point(10, 152);
            this.lblHueChange.Name = "lblHueChange";
            this.lblHueChange.Size = new System.Drawing.Size(34, 17);
            this.lblHueChange.TabIndex = 18;
            this.lblHueChange.Text = "Hue";
            // 
            // pbxColorChange
            // 
            this.pbxColorChange.Location = new System.Drawing.Point(9, 13);
            this.pbxColorChange.Name = "pbxColorChange";
            this.pbxColorChange.Size = new System.Drawing.Size(111, 108);
            this.pbxColorChange.TabIndex = 17;
            this.pbxColorChange.TabStop = false;
            // 
            // pnlRanges
            // 
            this.pnlRanges.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlRanges.Controls.Add(this.lblRangeTitle);
            this.pnlRanges.Controls.Add(this.UpDownValRange);
            this.pnlRanges.Controls.Add(this.UpDownSatRange);
            this.pnlRanges.Controls.Add(this.UpDownHueRange);
            this.pnlRanges.Controls.Add(this.lblSatRange);
            this.pnlRanges.Controls.Add(this.lblValRange);
            this.pnlRanges.Controls.Add(this.lblHueRange);
            this.pnlRanges.Location = new System.Drawing.Point(433, 12);
            this.pnlRanges.Name = "pnlRanges";
            this.pnlRanges.Size = new System.Drawing.Size(147, 218);
            this.pnlRanges.TabIndex = 18;
            // 
            // lblRangeTitle
            // 
            this.lblRangeTitle.AutoSize = true;
            this.lblRangeTitle.Location = new System.Drawing.Point(4, 4);
            this.lblRangeTitle.Name = "lblRangeTitle";
            this.lblRangeTitle.Size = new System.Drawing.Size(119, 17);
            this.lblRangeTitle.TabIndex = 20;
            this.lblRangeTitle.Text = "Selection Ranges";
            // 
            // UpDownValRange
            // 
            this.UpDownValRange.Location = new System.Drawing.Point(15, 177);
            this.UpDownValRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownValRange.Name = "UpDownValRange";
            this.UpDownValRange.Size = new System.Drawing.Size(77, 22);
            this.UpDownValRange.TabIndex = 19;
            this.UpDownValRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownValRange.ValueChanged += new System.EventHandler(this.UpDownValRange_ValueChanged);
            // 
            // UpDownSatRange
            // 
            this.UpDownSatRange.Location = new System.Drawing.Point(15, 117);
            this.UpDownSatRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownSatRange.Name = "UpDownSatRange";
            this.UpDownSatRange.Size = new System.Drawing.Size(77, 22);
            this.UpDownSatRange.TabIndex = 18;
            this.UpDownSatRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownSatRange.ValueChanged += new System.EventHandler(this.UpDownSatRange_ValueChanged);
            // 
            // UpDownHueRange
            // 
            this.UpDownHueRange.Location = new System.Drawing.Point(15, 58);
            this.UpDownHueRange.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.UpDownHueRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownHueRange.Name = "UpDownHueRange";
            this.UpDownHueRange.Size = new System.Drawing.Size(77, 22);
            this.UpDownHueRange.TabIndex = 17;
            this.UpDownHueRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownHueRange.ValueChanged += new System.EventHandler(this.UpDownHueRange_ValueChanged);
            // 
            // lblSatRange
            // 
            this.lblSatRange.AutoSize = true;
            this.lblSatRange.Location = new System.Drawing.Point(12, 97);
            this.lblSatRange.Name = "lblSatRange";
            this.lblSatRange.Size = new System.Drawing.Size(119, 17);
            this.lblSatRange.TabIndex = 2;
            this.lblSatRange.Text = "Saturation Range";
            // 
            // lblValRange
            // 
            this.lblValRange.AutoSize = true;
            this.lblValRange.Location = new System.Drawing.Point(12, 157);
            this.lblValRange.Name = "lblValRange";
            this.lblValRange.Size = new System.Drawing.Size(90, 17);
            this.lblValRange.TabIndex = 1;
            this.lblValRange.Text = "Value Range";
            // 
            // lblHueRange
            // 
            this.lblHueRange.AutoSize = true;
            this.lblHueRange.Location = new System.Drawing.Point(12, 38);
            this.lblHueRange.Name = "lblHueRange";
            this.lblHueRange.Size = new System.Drawing.Size(80, 17);
            this.lblHueRange.TabIndex = 0;
            this.lblHueRange.Text = "Hue Range";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 481);
            this.Controls.Add(this.pnlRanges);
            this.Controls.Add(this.pnlCustom);
            this.Controls.Add(this.pnlMaskFilterSettings);
            this.Controls.Add(this.pnlMainImageSettings);
            this.Controls.Add(this.btnApply);
            this.Name = "Settings";
            this.Text = "Settings";
            this.pnlMainImageSettings.ResumeLayout(false);
            this.pnlMainImageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownKmeansKVal)).EndInit();
            this.pnlMaskFilterSettings.ResumeLayout(false);
            this.pnlMaskFilterSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownMaskKval)).EndInit();
            this.pnlCustom.ResumeLayout(false);
            this.pnlCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).EndInit();
            this.pnlRanges.ResumeLayout(false);
            this.pnlRanges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownValRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownSatRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownHueRange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.RadioButton rbMedianBlur;
        private System.Windows.Forms.RadioButton rbGuassianBlur;
        private System.Windows.Forms.Label MaskFilterlbl;
        private System.Windows.Forms.Panel pnlMainImageSettings;
        private System.Windows.Forms.Panel pnlMaskFilterSettings;
        private System.Windows.Forms.Label lblMaskKVal;
        private System.Windows.Forms.NumericUpDown UpDownMaskKval;
        private System.Windows.Forms.Panel pnlCustom;
        private System.Windows.Forms.Label lblValChange;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSat;
        private System.Windows.Forms.TrackBar trackBarVal;
        private System.Windows.Forms.Label lblSatChange;
        private System.Windows.Forms.Label lblHueChange;
        private System.Windows.Forms.PictureBox pbxColorChange;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbKmeans;
        private System.Windows.Forms.Label lblHsv;
        private System.Windows.Forms.Label lblKmeansKval;
        private System.Windows.Forms.NumericUpDown UpDownKmeansKVal;
        private System.Windows.Forms.Panel pnlRanges;
        private System.Windows.Forms.Label lblRangeTitle;
        private System.Windows.Forms.NumericUpDown UpDownValRange;
        private System.Windows.Forms.NumericUpDown UpDownSatRange;
        private System.Windows.Forms.NumericUpDown UpDownHueRange;
        private System.Windows.Forms.Label lblSatRange;
        private System.Windows.Forms.Label lblValRange;
        private System.Windows.Forms.Label lblHueRange;
    }
}