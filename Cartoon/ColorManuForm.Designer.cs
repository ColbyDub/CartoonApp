
namespace Cartoon
{
    partial class ColorManuForm
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
            this.lblValChange = new System.Windows.Forms.Label();
            this.trackBarHue = new System.Windows.Forms.TrackBar();
            this.trackBarSat = new System.Windows.Forms.TrackBar();
            this.trackBarVal = new System.Windows.Forms.TrackBar();
            this.lblSatChange = new System.Windows.Forms.Label();
            this.lblHueChange = new System.Windows.Forms.Label();
            this.pbxColorChange = new System.Windows.Forms.PictureBox();
            this.lblHsv = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(275, 236);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblValChange
            // 
            this.lblValChange.AutoSize = true;
            this.lblValChange.Location = new System.Drawing.Point(131, 13);
            this.lblValChange.Name = "lblValChange";
            this.lblValChange.Size = new System.Drawing.Size(44, 17);
            this.lblValChange.TabIndex = 16;
            this.lblValChange.Text = "Value";
            // 
            // trackBarHue
            // 
            this.trackBarHue.Location = new System.Drawing.Point(15, 174);
            this.trackBarHue.Maximum = 180;
            this.trackBarHue.Name = "trackBarHue";
            this.trackBarHue.Size = new System.Drawing.Size(509, 56);
            this.trackBarHue.TabIndex = 15;
            this.trackBarHue.TickFrequency = 2;
            this.trackBarHue.ValueChanged += new System.EventHandler(this.trackBarHue_ValueChanged);
            // 
            // trackBarSat
            // 
            this.trackBarSat.Location = new System.Drawing.Point(132, 112);
            this.trackBarSat.Maximum = 100;
            this.trackBarSat.Name = "trackBarSat";
            this.trackBarSat.Size = new System.Drawing.Size(392, 56);
            this.trackBarSat.TabIndex = 14;
            this.trackBarSat.TickFrequency = 2;
            this.trackBarSat.ValueChanged += new System.EventHandler(this.trackBarSat_ValueChanged);
            // 
            // trackBarVal
            // 
            this.trackBarVal.Location = new System.Drawing.Point(132, 33);
            this.trackBarVal.Maximum = 100;
            this.trackBarVal.Name = "trackBarVal";
            this.trackBarVal.Size = new System.Drawing.Size(392, 56);
            this.trackBarVal.TabIndex = 13;
            this.trackBarVal.TickFrequency = 2;
            this.trackBarVal.ValueChanged += new System.EventHandler(this.trackBarVal_ValueChanged);
            // 
            // lblSatChange
            // 
            this.lblSatChange.AutoSize = true;
            this.lblSatChange.Location = new System.Drawing.Point(131, 92);
            this.lblSatChange.Name = "lblSatChange";
            this.lblSatChange.Size = new System.Drawing.Size(73, 17);
            this.lblSatChange.TabIndex = 12;
            this.lblSatChange.Text = "Saturation";
            // 
            // lblHueChange
            // 
            this.lblHueChange.AutoSize = true;
            this.lblHueChange.Location = new System.Drawing.Point(15, 151);
            this.lblHueChange.Name = "lblHueChange";
            this.lblHueChange.Size = new System.Drawing.Size(34, 17);
            this.lblHueChange.TabIndex = 11;
            this.lblHueChange.Text = "Hue";
            // 
            // pbxColorChange
            // 
            this.pbxColorChange.Location = new System.Drawing.Point(15, 11);
            this.pbxColorChange.Name = "pbxColorChange";
            this.pbxColorChange.Size = new System.Drawing.Size(110, 108);
            this.pbxColorChange.TabIndex = 10;
            this.pbxColorChange.TabStop = false;
            // 
            // lblHsv
            // 
            this.lblHsv.AutoSize = true;
            this.lblHsv.Location = new System.Drawing.Point(15, 126);
            this.lblHsv.Name = "lblHsv";
            this.lblHsv.Size = new System.Drawing.Size(0, 17);
            this.lblHsv.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(356, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(437, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Location = new System.Drawing.Point(18, 236);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(86, 23);
            this.btnAdvanced.TabIndex = 23;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // ColorManuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 278);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblHsv);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblValChange);
            this.Controls.Add(this.trackBarHue);
            this.Controls.Add(this.trackBarSat);
            this.Controls.Add(this.trackBarVal);
            this.Controls.Add(this.lblSatChange);
            this.Controls.Add(this.lblHueChange);
            this.Controls.Add(this.pbxColorChange);
            this.Name = "ColorManuForm";
            this.Text = "Color Manipulation";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColorChange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblValChange;
        private System.Windows.Forms.TrackBar trackBarHue;
        private System.Windows.Forms.TrackBar trackBarSat;
        private System.Windows.Forms.TrackBar trackBarVal;
        private System.Windows.Forms.Label lblSatChange;
        private System.Windows.Forms.Label lblHueChange;
        private System.Windows.Forms.PictureBox pbxColorChange;
        private System.Windows.Forms.Label lblHsv;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdvanced;
    }
}