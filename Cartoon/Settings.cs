//Author:       Colby Wall
//Filename:     Settings.cs
//Purpose:      Form to handel all the user settings

using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cartoon
{
    public partial class Settings : Form
    {
        //Public variables for easy main app access
        public Boolean CustomBack;
        public Boolean MaskGuassBack;
        public Hsv currentHsv;
        public int MKVal, KMKVal, ValRange, SatRange, HueRange;
        public Settings(Boolean Custom,Boolean MaskGuass,Hsv hsv,int MaskKval, int KmeansKval, int HRange, int SRange, int VRange)
        {
            InitializeComponent();
            //Update UI
            UpDownKmeansKVal.Value = KmeansKval;
            UpDownMaskKval.Value = MaskKval;
            UpDownHueRange.Value = HRange;
            UpDownSatRange.Value = SRange;
            UpDownValRange.Value = VRange;
            //Update Variables
            MKVal = MaskKval;
            KMKVal = KmeansKval;
            ValRange = VRange;
            SatRange = SRange;
            HueRange = HRange;
            if (Custom)                                                     //Custom background is in use
            {
                rbCustom.Checked = true;
                if (Custom)
                {
                    trackBarHue.Value = (int)hsv.Hue;
                    trackBarSat.Value = (int)(hsv.Satuation * 100);
                    trackBarVal.Value = (int)(hsv.Value * 100);
                    currentHsv = hsv;
                    updateColor();
                }
            }
            else                                                             //KMeans background is in use
            {
                foreach (Control ctrl in pnlCustom.Controls)                 //Disable the custom background options
                {
                    ctrl.Enabled = false;
                    ctrl.ForeColor = Color.LightGray;
                }
                lblKmeansKval.ForeColor = Color.LightGray;
                UpDownKmeansKVal.Enabled = false;

                rbKmeans.Checked = true;
            }

            if (MaskGuass)
            {
                rbGuassianBlur.Checked = true;
            }
            else
                rbMedianBlur.Checked = true;

        }

        //Updates the HSV color and updates the UI on value change
        private void trackBarVal_ValueChanged(object sender, EventArgs e)
        {
            currentHsv.Value = (double)trackBarVal.Value / 100;
            updateColor();
        }
        private void trackBarSat_ValueChanged(object sender, EventArgs e)
        {
            currentHsv.Satuation = (double)trackBarSat.Value / 100;
            updateColor();
        }
        private void trackBarHue_ValueChanged(object sender, EventArgs e)
        {
            currentHsv.Hue = trackBarHue.Value;
            updateColor();
        }

        //Updates the colors in UI for user to see the color they are manipulating
        private void updateColor()
        {
            int r, g, b;
            Utilities.hsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
            Color updatedColor = Color.FromArgb(r, g, b);
            pbxColorChange.BackColor = updatedColor;
            lblHsv.Text = "(" + Math.Round(currentHsv.Hue, 2) + ", " + Math.Round(currentHsv.Satuation, 2) + ", " + Math.Round(currentHsv.Value, 2) + ")";
        }


        //Updates UI to avoid confusion
        private void rbKmeans_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked==true)
            {
                foreach (Control ctrl in pnlCustom.Controls)
                {
                    ctrl.Enabled = true;
                    ctrl.ForeColor = Color.Black;
                }
                lblKmeansKval.ForeColor = Color.LightGray;
                UpDownKmeansKVal.Enabled = false;
                CustomBack = true;
            }
            else
            {
                foreach (Control ctrl in pnlCustom.Controls)
                {
                    ctrl.Enabled = false;
                    ctrl.ForeColor = Color.LightGray;
                }
                lblKmeansKval.ForeColor = Color.Black;
                UpDownKmeansKVal.Enabled = true;
                CustomBack = false;
            }
        }

        //Updates the Radio buttons and sets a flag for use in main app
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGuassianBlur.Checked)
            {
                rbMedianBlur.Checked = false;
                MaskGuassBack = true;
            }
            else if (rbMedianBlur.Checked)
            {
                rbGuassianBlur.Checked = false;
                MaskGuassBack = false;
            }
        }


        //Applys the settings chosen by the user
        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Updates the Ranges when changed
        private void UpDownValRange_ValueChanged(object sender, EventArgs e)
        {
            ValRange = (int)UpDownValRange.Value;
        }
        private void UpDownSatRange_ValueChanged(object sender, EventArgs e)
        {
            SatRange = (int)UpDownSatRange.Value;
        }
        private void UpDownHueRange_ValueChanged(object sender, EventArgs e)
        {
            HueRange = (int)UpDownHueRange.Value;
        }

        //Updates the Mask Kval when changed
        private void UpDownMaskKval_ValueChanged(object sender, EventArgs e)
        {
            MKVal = (int)UpDownMaskKval.Value;
        }

        //Updates the KMeans kval when changed
        private void UpDownKmeansKVal_ValueChanged(object sender, EventArgs e)
        {
            KMKVal = (int)UpDownKmeansKVal.Value;
        }
    }
}
