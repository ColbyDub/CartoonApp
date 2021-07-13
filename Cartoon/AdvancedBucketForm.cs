//Author:       Colby Wall
//Filename:     AdvancedBucketForm.cs
//Purpose:      Manipulate bucket ranges via HSV

using Emgu.CV.Structure;
using System;
using System.Drawing;
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
            Utilities.hsvToRgb(HsvUp.V0, HsvUp.V1/255, HsvUp.V2/255, out r, out g, out b);
            pbxUpper.BackColor = Color.FromArgb(r, g, b);
            lblLower.Text = "(" + Math.Round(HsvLow.V0, 2) + ", " + Math.Round(HsvLow.V1/255, 2) + ", " + Math.Round(HsvLow.V2 / 255, 2) + ")";

            Utilities.hsvToRgb(HsvLow.V0, HsvLow.V1/255, HsvLow.V2/255, out r, out g, out b);
            pbxLower.BackColor = Color.FromArgb(r, g, b);
            lblUpper.Text = "(" + Math.Round(HsvUp.V0, 2) + ", " + Math.Round(HsvUp.V1 / 255, 2) + ", " + Math.Round(HsvUp.V2 / 255, 2) + ")";
            updateColor();
        }

        //updates UI elements
        private void updateColor()
        {
            int r, g, b;
            Utilities.hsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
            Color updatedColor = Color.FromArgb(r, g, b);
            pbxColorChange.BackColor = updatedColor;
            lblHsv.Text = "(" + Math.Round(currentHsv.Hue, 2) + ", " + Math.Round(currentHsv.Satuation, 2) + ", " + Math.Round(currentHsv.Value, 2) + ")";
        }

        //Sets upper bucket limit
        private void btnSetUpper_Click(object sender, EventArgs e)
        {
            int r, g, b;
            SetUpper = true;
            Utilities.hsvToRgb(currentHsv.Hue,currentHsv.Satuation,currentHsv.Value, out r, out g, out b);
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
            Utilities.hsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
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
    }
}
