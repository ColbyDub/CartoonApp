//Author:       Colby Wall
//Filename:     ColorManuForm.cs
//Purpose:      Manipulate the color of choice via HSV

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
    public partial class ColorManuForm : Form
    {
        Hsv currentHsv;
        Hsv origHsv;

        //For Bucket Changes
        MCvScalar HsvUp;
        MCvScalar HsvLow;
        public Boolean SetUpper=false;
        public Boolean SetLower=false;
        public Boolean BucketChange = false;

        public ColorManuForm(Hsv hsv, MCvScalar upper, MCvScalar lower)
        {
            this.DialogResult = DialogResult.None;
            InitializeComponent();
            //Initilize color variables
            currentHsv = hsv;
            origHsv = hsv;
            HsvUp = upper;
            HsvLow = lower;
            trackBarHue.Value = (int)hsv.Hue;
            trackBarSat.Value = (int)(hsv.Satuation * 100);
            trackBarVal.Value = (int)(hsv.Value * 100);
            updateColor();
        }

        //Updates the color elements in the GUI 
        private void updateColor()
        {
            int r, g, b;
            HsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
            Color updatedColor = Color.FromArgb(r, g, b);
            pbxColorChange.BackColor = updatedColor;
            lblHsv.Text = "(" + Math.Round(currentHsv.Hue,2) + ", " + Math.Round(currentHsv.Satuation,2) + ", " + Math.Round(currentHsv.Value,2) + ")";
        }

        //Updates UI on value changed
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

        //Returns the HSV color currently on the track bars
        public Hsv getHsv()
        {
            return currentHsv;
        }

        //Returns the upper bucket range if there is one
        public MCvScalar getUpper()
        {
            if(!HsvUp.Equals(null))
                return HsvUp;
            return new MCvScalar();
        }

        //Returns the lower bucket range if there is one
        public MCvScalar getLower()
        {
            if (!HsvLow.Equals(null))
                return HsvLow;
            return new MCvScalar();
        }

        //Apply color change and close
        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Deletes the chosen color and closes
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        //Cancels and closes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Opens a bucket manipulation form and closes current form if bucket range is changed for less confusion
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            AdvancedBucketForm ABF = new AdvancedBucketForm(origHsv, HsvUp, HsvLow);
            ABF.ShowDialog();
            if (ABF.DialogResult == DialogResult.OK)
            {
                BucketChange = true;
                if (ABF.SetUpper)
                {
                    SetUpper = true;
                    HsvUp = ABF.HsvUp;
                }
                if (ABF.SetLower)
                {
                    SetLower = true;
                    HsvLow = ABF.HsvLow;
                }
                this.Close();
            }
        }

        //Changes HSV value to RGB
        //Snagged from https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        //By Patrik Svensson
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
