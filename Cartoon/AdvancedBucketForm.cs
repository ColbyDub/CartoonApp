//Author:       Colby Wall
//Filename:     AdvancedBucketForm.cs
//Purpose:      Manipulate bucket ranges via HSV

using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartoon
{
    public partial class AdvancedBucketForm : Form
    {
        Hsv currentHsv;
        public Boolean SetUpper;
        public Boolean SetLower;
        public MCvScalar HsvUp;
        public MCvScalar HsvLow;
        public AdvancedBucketForm(Hsv hsv,MCvScalar up, MCvScalar down)
        {
            InitializeComponent();
            int r, g, b;
            currentHsv = hsv;

            //Initialize bucket and main HSV values
            HsvUp = up;
            HsvLow = down;
            trackBarHue.Value = (int)hsv.Hue;
            trackBarSat.Value = (int)(hsv.Satuation * 100);
            trackBarVal.Value = (int)(hsv.Value * 100);

            //UI updates
            HsvToRgb(HsvUp.V0, HsvUp.V1/255, HsvUp.V2/255, out r, out g, out b);
            pbxUpper.BackColor = Color.FromArgb(r, g, b);
            lblLower.Text = "(" + Math.Round(HsvLow.V0, 2) + ", " + Math.Round(HsvLow.V1/255, 2) + ", " + Math.Round(HsvLow.V2 / 255, 2) + ")";

            HsvToRgb(HsvLow.V0, HsvLow.V1/255, HsvLow.V2/255, out r, out g, out b);
            pbxLower.BackColor = Color.FromArgb(r, g, b);
            lblUpper.Text = "(" + Math.Round(HsvUp.V0, 2) + ", " + Math.Round(HsvUp.V1 / 255, 2) + ", " + Math.Round(HsvUp.V2 / 255, 2) + ")";
            updateColor();
        }

        //updates UI elements
        private void updateColor()
        {
            int r, g, b;
            HsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
            Color updatedColor = Color.FromArgb(r, g, b);
            pbxColorChange.BackColor = updatedColor;
            lblHsv.Text = "(" + Math.Round(currentHsv.Hue, 2) + ", " + Math.Round(currentHsv.Satuation, 2) + ", " + Math.Round(currentHsv.Value, 2) + ")";
        }

        //Sets upper bucket limit
        private void btnSetUpper_Click(object sender, EventArgs e)
        {
            int r, g, b;
            SetUpper = true;
            HsvToRgb(currentHsv.Hue,currentHsv.Satuation,currentHsv.Value, out r, out g, out b);
            pbxUpper.BackColor = Color.FromArgb(r, g, b);
            lblUpper.Text = "(" + Math.Round(currentHsv.Hue, 2) + ", " + Math.Round(currentHsv.Satuation, 2) + ", " + Math.Round(currentHsv.Value, 2) + ")";
            HsvUp = new MCvScalar(currentHsv.Hue, currentHsv.Satuation*255, currentHsv.Value*255);
            MessageBox.Show("Upper limit has been changed! Hit Apply to keep changes.");
        }

        //Sets the lower bucket limit
        private void btnSetLower_Click(object sender, EventArgs e)
        {
            int r, g, b;
            SetLower = true;
            HsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
            pbxLower.BackColor = Color.FromArgb(r, g, b);
            lblLower.Text = "(" + Math.Round(currentHsv.Hue, 2) + ", " + Math.Round(currentHsv.Satuation, 2) + ", " + Math.Round(currentHsv.Value, 2) + ")";
            HsvLow = new MCvScalar(currentHsv.Hue, currentHsv.Satuation*255, currentHsv.Value*255);
            MessageBox.Show("Lower limit has been changed! Hit Apply to keep changes.");
        }


        //updates UI on value change
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

        //Sets result to OK and closes form
        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        //Cancels and upper and lower set bounds and closes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetUpper = false;
            SetLower = false;
            this.Close();
        }

        //Snagged from https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        //By Patrik Svensson
        //Converts HSV to RGB
        public void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
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
