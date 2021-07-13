//Author:       Colby Wall
//Filename:     ColorManuForm.cs
//Purpose:      Manipulate the color of choice via HSV

using Emgu.CV.Structure;
using System;
using System.Drawing;
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
            Utilities.hsvToRgb(currentHsv.Hue, currentHsv.Satuation, currentHsv.Value, out r, out g, out b);
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
    }
}
