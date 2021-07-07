
namespace Cartoon
{
    partial class AdvancedBucketForm
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
            this.btnSetUpper = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetLower = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxLower = new System.Windows.Forms.PictureBox();
            this.pbxUpper = new System.Windows.Forms.PictureBox();
            this.lblLower = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLowerTitle = new System.Windows.Forms.Label();
            this.lblUpper = new System.Windows.Forms.Label();
            this.lblUpperTitle = new System.Windows.Forms.Label();
            this.lblValChange = new System.Windows.Forms.Label();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSat = new System.Windows.Forms.TrackBar();
            this.trackBarVal = new System.Windows.Forms.TrackBar();
            this.lblSatChange = new System.Windows.Forms.Label();
            this.lblHueChange = new System.Windows.Forms.Label();
            this.pbxColorChange = new System.Windows.Forms.PictureBox();
            this.lblBucketBoundsTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblHsv = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetUpper
            // 
            this.btnSetUpper.Location = new System.Drawing.Point(223, 5);
            this.btnSetUpper.Name = "btnSetUpper";
            this.btnSetUpper.Size = new System.Drawing.Size(75, 23);
            this.btnSetUpper.TabIndex = 22;
            this.btnSetUpper.Text = "Upper";
            this.btnSetUpper.UseVisualStyleBackColor = true;
            this.btnSetUpper.Click += new System.EventHandler(this.btnSetUpper_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set bucket bounds";
            // 
            // btnSetLower
            // 
            this.btnSetLower.Location = new System.Drawing.Point(223, 40);
            this.btnSetLower.Name = "btnSetLower";
            this.btnSetLower.Size = new System.Drawing.Size(75, 23);
            this.btnSetLower.TabIndex = 0;
            this.btnSetLower.Text = "Lower";
            this.btnSetLower.UseVisualStyleBackColor = true;
            this.btnSetLower.Click += new System.EventHandler(this.btnSetLower_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pbxLower);
            this.panel1.Controls.Add(this.pbxUpper);
            this.panel1.Controls.Add(this.lblLower);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSetUpper);
            this.panel1.Controls.Add(this.lblLowerTitle);
            this.panel1.Controls.Add(this.lblUpper);
            this.panel1.Controls.Add(this.btnSetLower);
            this.panel1.Controls.Add(this.lblUpperTitle);
            this.panel1.Location = new System.Drawing.Point(7, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 86);
            this.panel1.TabIndex = 29;
            // 
            // pbxLower
            // 
            this.pbxLower.Location = new System.Drawing.Point(4, 40);
            this.pbxLower.Name = "pbxLower";
            this.pbxLower.Size = new System.Drawing.Size(25, 23);
            this.pbxLower.TabIndex = 39;
            this.pbxLower.TabStop = false;
            // 
            // pbxUpper
            // 
            this.pbxUpper.Location = new System.Drawing.Point(4, 5);
            this.pbxUpper.Name = "pbxUpper";
            this.pbxUpper.Size = new System.Drawing.Size(25, 23);
            this.pbxUpper.TabIndex = 38;
            this.pbxUpper.TabStop = false;
            // 
            // lblLower
            // 
            this.lblLower.AutoSize = true;
            this.lblLower.Location = new System.Drawing.Point(29, 57);
            this.lblLower.Name = "lblLower";
            this.lblLower.Size = new System.Drawing.Size(0, 17);
            this.lblLower.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 36;
            // 
            // lblLowerTitle
            // 
            this.lblLowerTitle.AutoSize = true;
            this.lblLowerTitle.Location = new System.Drawing.Point(29, 40);
            this.lblLowerTitle.Name = "lblLowerTitle";
            this.lblLowerTitle.Size = new System.Drawing.Size(46, 17);
            this.lblLowerTitle.TabIndex = 35;
            this.lblLowerTitle.Text = "Lower";
            // 
            // lblUpper
            // 
            this.lblUpper.AutoSize = true;
            this.lblUpper.Location = new System.Drawing.Point(29, 20);
            this.lblUpper.Name = "lblUpper";
            this.lblUpper.Size = new System.Drawing.Size(0, 17);
            this.lblUpper.TabIndex = 34;
            // 
            // lblUpperTitle
            // 
            this.lblUpperTitle.AutoSize = true;
            this.lblUpperTitle.Location = new System.Drawing.Point(29, 3);
            this.lblUpperTitle.Name = "lblUpperTitle";
            this.lblUpperTitle.Size = new System.Drawing.Size(47, 17);
            this.lblUpperTitle.TabIndex = 33;
            this.lblUpperTitle.Text = "Upper";
            // 
            // lblValChange
            // 
            this.lblValChange.AutoSize = true;
            this.lblValChange.Location = new System.Drawing.Point(126, 11);
            this.lblValChange.Name = "lblValChange";
            this.lblValChange.Size = new System.Drawing.Size(44, 17);
            this.lblValChange.TabIndex = 28;
            this.lblValChange.Text = "Value";
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(10, 172);
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(509, 56);
            this.trackBarHue.TabIndex = 27;
            this.trackBarHue.TickFrequency = 2;
            this.trackBarHue.ValueChanged += new System.EventHandler(this.trackBarHue_ValueChanged);
            // 
            // trackBarSat
            // 
            this.trackBarSat.Location = new System.Drawing.Point(127, 110);
            this.trackBarSat.Maximum = 100;
            this.trackBarSat.Name = "trackBarSat";
            this.trackBarSat.Size = new System.Drawing.Size(392, 56);
            this.trackBarSat.TabIndex = 26;
            this.trackBarSat.TickFrequency = 2;
            this.trackBarSat.ValueChanged += new System.EventHandler(this.trackBarSat_ValueChanged);
            // 
            // trackBarVal
            // 
            this.trackBarVal.Location = new System.Drawing.Point(127, 31);
            this.trackBarVal.Maximum = 100;
            this.trackBarVal.Name = "trackBarVal";
            this.trackBarVal.Size = new System.Drawing.Size(392, 56);
            this.trackBarVal.TabIndex = 25;
            this.trackBarVal.TickFrequency = 2;
            this.trackBarVal.ValueChanged += new System.EventHandler(this.trackBarVal_ValueChanged);
            // 
            // lblSatChange
            // 
            this.lblSatChange.AutoSize = true;
            this.lblSatChange.Location = new System.Drawing.Point(126, 90);
            this.lblSatChange.Name = "lblSatChange";
            this.lblSatChange.Size = new System.Drawing.Size(73, 17);
            this.lblSatChange.TabIndex = 24;
            this.lblSatChange.Text = "Saturation";
            // 
            // lblHueChange
            // 
            this.lblHueChange.AutoSize = true;
            this.lblHueChange.Location = new System.Drawing.Point(10, 149);
            this.lblHueChange.Name = "lblHueChange";
            this.lblHueChange.Size = new System.Drawing.Size(34, 17);
            this.lblHueChange.TabIndex = 23;
            this.lblHueChange.Text = "Hue";
            // 
            // pbxColorChange
            // 
            this.pbxColorChange.Location = new System.Drawing.Point(10, 9);
            this.pbxColorChange.Name = "pbxColorChange";
            this.pbxColorChange.Size = new System.Drawing.Size(110, 108);
            this.pbxColorChange.TabIndex = 22;
            this.pbxColorChange.TabStop = false;
            // 
            // lblBucketBoundsTitle
            // 
            this.lblBucketBoundsTitle.AutoSize = true;
            this.lblBucketBoundsTitle.Location = new System.Drawing.Point(10, 214);
            this.lblBucketBoundsTitle.Name = "lblBucketBoundsTitle";
            this.lblBucketBoundsTitle.Size = new System.Drawing.Size(103, 17);
            this.lblBucketBoundsTitle.TabIndex = 0;
            this.lblBucketBoundsTitle.Text = "Bucket Bounds";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(437, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(356, 291);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 31;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblHsv
            // 
            this.lblHsv.AutoSize = true;
            this.lblHsv.Location = new System.Drawing.Point(10, 120);
            this.lblHsv.Name = "lblHsv";
            this.lblHsv.Size = new System.Drawing.Size(0, 17);
            this.lblHsv.TabIndex = 32;
            // 
            // AdvancedBucketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 332);
            this.Controls.Add(this.lblHsv);
            this.Controls.Add(this.lblBucketBoundsTitle);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValChange);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.trackBarSat);
            this.Controls.Add(this.trackBarVal);
            this.Controls.Add(this.lblSatChange);
            this.Controls.Add(this.lblHueChange);
            this.Controls.Add(this.pbxColorChange);
            this.Name = "AdvancedBucketForm";
            this.Text = "Bucket Manipulation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetLower;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblValChange;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSat;
        private System.Windows.Forms.TrackBar trackBarVal;
        private System.Windows.Forms.Label lblSatChange;
        private System.Windows.Forms.Label lblHueChange;
        private System.Windows.Forms.PictureBox pbxColorChange;
        private System.Windows.Forms.Label lblBucketBoundsTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblHsv;
        private System.Windows.Forms.Label lblUpper;
        private System.Windows.Forms.Label lblUpperTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLowerTitle;
        private System.Windows.Forms.Label lblLower;
        private System.Windows.Forms.PictureBox pbxUpper;
        private System.Windows.Forms.PictureBox pbxLower;
    }
}