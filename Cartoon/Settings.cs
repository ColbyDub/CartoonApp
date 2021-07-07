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
            HsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
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

        //Converts HSV color to RGB
        //Snagged from https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        //By Patrik Svensson
        private void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h * 2;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// Clamp a value to 0-255
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}
