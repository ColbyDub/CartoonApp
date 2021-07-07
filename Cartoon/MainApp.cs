//Author:       Colby Wall
//Filename:     MainApp.cs
//Purpose:      Starting GUI and handels cartoon algorithim

using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using Accord.Math;
using Accord.MachineLearning;
using Accord.Math.Distances;
using Accord.Imaging.Converters;

namespace Cartoon
{
    public partial class App : Form
    {
        //Settings values
        int MASKVAL = 3;
        int KMEANSVAL = 10;
        int MAXBOX = 12;
        int HUERANGE = 8;
        int SATRANGE = 15;
        int VALRANGE = 15;
        Hsv BackgroundColor = new Hsv(0, 1, 1);

        //Buckets
        ColorScheme currentScheme;

        //Flags
        Boolean CustomBackground = false;
        Boolean MaskGuass = true;

        //Bitmap images
        Bitmap imgOrig;
        Bitmap bmpCopy;                     //Needed for solid color creation
        Bitmap bmp;
        Image<Hsv, Byte> emguCopy;
        Image<Hsv, Byte> origCopy;          //Needed for pixel selection
        Image<Bgr, Byte> layerResult;
        Image<Gray, Byte> mask;
        Image<Bgr, Byte> maskResult;
        Image<Bgr, Byte> imageResult;
        Image<Bgr, Byte> kmeansResult;
        Image<Bgr, Byte> x;
        //Scale dimensions
        float width = 600;
        float height = 600;

        public App()
        {
            InitializeComponent();
            //ColorScheme object
            currentScheme = new ColorScheme();
        }

        //Updates UI for color at the Mouse click
        //Will put the color selected in the ColorScheme if select colors is selected
        private void pbxDisplayImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (imgOrig!=null)
            {
                //Variables for GUI updates
                Color pxlcolor;
                double hue, saturation, value;


                if (((PictureBox)sender).Name == "pbxOrigImg")
                    pxlcolor = imgOrig.GetPixel(e.X, e.Y);
                else if (pbxRsltImg != null)                //User can click the result image for colors there
                {
                    pxlcolor = bmp.GetPixel(e.X, e.Y);
                }
                else
                    return;         //result image click is null

                toolSSHSVColor.BackColor = pxlcolor;
                ColorToHSV(pxlcolor, out hue, out saturation, out value);
                string colortxt = "HSV:    [" + (Math.Round(hue, 2)/2) + "," + Math.Round(saturation, 2) + "," + Math.Round(value, 2) + "]";
                toolSSColorTag.Text = colortxt;

                if (pbxOrigImg.Image != null && cbxToggleSelection.Checked)
                {
                    if (currentScheme.BucketCount() < MAXBOX)
                    {
                        //Differentiate will give a narrower bucket for more accurate selection
                        int boxnum = currentScheme.AddColor(hue, saturation, value, cbxDifferentiate.Checked);
                       
                        switch (boxnum)     //if boxnum==0 then the max number of colors has been reached
                        {
                            case 1:
                                pbxColor1.BackColor = pxlcolor;
                                break;
                            case 2:
                                pbxColor2.BackColor = pxlcolor;
                                break;
                            case 3:
                                pbxColor3.BackColor = pxlcolor;
                                break;
                            case 4:
                                pbxColor4.BackColor = pxlcolor;
                                break;
                            case 5:
                                pbxColor5.BackColor = pxlcolor;
                                break;
                            case 6:
                                pbxColor6.BackColor = pxlcolor;
                                break;
                            case 7:
                                pbxColor7.BackColor = pxlcolor;
                                break;
                            case 8:
                                pbxColor8.BackColor = pxlcolor;
                                break;
                            case 9:
                                pbxColor9.BackColor = pxlcolor;
                                break;
                            case 10:
                                pbxColor10.BackColor = pxlcolor;
                                break;
                            case 11:
                                pbxColor11.BackColor = pxlcolor;
                                break;
                            case 12:
                                pbxColor12.BackColor = pxlcolor;
                                break;
                        }
                    }
                }
            }
        }

        //Apply_Click is the main bucket algorithim
        //Takes each bucket and applies its range to the original image to obtain a mask of what is in range
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (currentScheme.BucketCount() > 0)
            {

                int red, green, blue, i, n = currentScheme.BucketCount();
                Boolean extrared = false;
                MCvScalar upper;
                MCvScalar lower;

                x = new Image<Bgr, Byte>(imgOrig.Width, imgOrig.Height);
                imageResult = new Image<Bgr, Byte>(imgOrig.Width, imgOrig.Height);
                layerResult = new Image<Bgr, Byte>(imgOrig.Width, imgOrig.Height);
                maskResult = new Image<Bgr, Byte>(imgOrig.Width, imgOrig.Height);
                mask = new Image<Gray, Byte>(imgOrig.Width, imgOrig.Height);
                bmp = new Bitmap(imgOrig.Width, imgOrig.Height);

                if (currentScheme.redup.V2!=0)
                {
                    n += 1;
                    extrared = true;
                }

                for (i = 0; i < n; i++)
                {
                    if (extrared && i == n - 1)         //Accounts for Red range missed
                    {
                        Hsv hsv = currentScheme.redhsv;
                        HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out red, out green, out blue);
                        lower = currentScheme.reddown;
                        upper = currentScheme.redup;
                    }
                    else                                //Get HSV color and limits
                    {
                        Hsv hsv = currentScheme.GetBucket(i).GetHsv();
                        HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out red, out green, out blue);
                        upper = currentScheme.GetBucket(i).GetUpper();
                        lower = currentScheme.GetBucket(i).GetLower();
                    }
                    //Apply HSV color for a solid color
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.FromArgb(red, green, blue));
                    x = bmp.ToImage<Bgr, Byte>();

                    //find mask for range
                    CvInvoke.InRange(imgOrig.ToImage<Hsv,Byte>(), new ScalarArray(lower), new ScalarArray(upper), mask);

                    //Blur is applied to mask to reduce noise
                    if (!MaskGuass)
                    {
                        Mat src = mask.Mat;
                        Mat dst = new Mat();
                        CvInvoke.MedianBlur(src, dst, MASKVAL);
                        mask = dst.ToImage<Gray, Byte>();
                    }
                    else
                    {
                        mask.SmoothGaussian(MASKVAL);
                    }

                    //Layer is taken from the solid color combined with mask
                    CvInvoke.BitwiseAnd(x, x, layerResult, mask);
                    imageResult.SetValue(new Bgr(0, 0, 0), mask);
                    layerResult.SetValue(new Bgr(0, 0, 0), mask.Not());         //Turn correct areas transparent

                    //Add the layer to the final result
                    imageResult._Or(layerResult);

                    //Aggregate the masks for "missed" ranges in background
                    maskResult.SetValue(new Bgr(0,0,0), mask);
                    maskResult._Or(mask.Convert<Bgr,Byte>());
                }


                Image<Gray, Byte> grayConvert = maskResult.Convert<Gray, Byte>();       //Grascale the mask result

                //BACKGROUND KMEANS WORK
                if (!CustomBackground)              //No Custom Color -> Kmeans
                {
                    mainAlgoKmeans();
                    kmeansResult.SetValue(new Bgr(0, 0, 0), grayConvert);
                    maskResult.SetValue(new Bgr(0, 0, 0), grayConvert.Not());           //Wherever Mask is not, we want to be transparent
                    kmeansResult.Or(maskResult);


                    imageResult.SetValue(new Bgr(0, 0, 0), grayConvert.Not());
                    kmeansResult.SetValue(new Bgr(0, 0, 0), grayConvert);               //Make correct areas Transparent
                    kmeansResult._Or(imageResult);

                    pbxRsltImg.Image = kmeansResult.ToBitmap();

                    //Copies 
                    bmp = kmeansResult.ToBitmap();
                    emguCopy = bmp.ToImage<Hsv, Byte>();
                }
                else                              //No KMeans -> Custom color
                {
                    HsvToRgb(BackgroundColor.Hue, BackgroundColor.Satuation, BackgroundColor.Value, out red, out green, out blue);
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.FromArgb(red,green,blue));
                    x = bmp.ToImage<Bgr, Byte>();                   //x is the color bitmap and is reused here

                    x.SetValue(new Bgr(0, 0, 0), grayConvert);
                    maskResult.SetValue(new Bgr(0, 0, 0), grayConvert.Not());
                    x.Or(maskResult);

                    imageResult.SetValue(new Bgr(0, 0, 0), grayConvert.Not());
                    x.SetValue(new Bgr(0, 0, 0), grayConvert);
                    x._Or(imageResult);

                    pbxRsltImg.Image = x.ToBitmap();

                    //Copies
                    bmp = x.ToBitmap();
                    emguCopy = bmp.ToImage<Hsv, Byte>();
                }
            }
        }

        //Saves the image rendered
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String File;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File = dialog.FileName;
                    bmp.Save(File, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Opens a file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String File;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File = dialog.FileName;
                try
                {
                    imgOrig = new Bitmap(dialog.FileName);
                    if (imgOrig.Width > 700 || imgOrig.Height > 700)                          //Rescale large images
                    {
                        float scale = Math.Min(width / imgOrig.Width, height / imgOrig.Height);
                        int scaleHeight = (int)(imgOrig.Height * scale);
                        int scaleWidth = (int)(imgOrig.Width * scale);
                        imgOrig = new Bitmap(imgOrig, new Size(scaleWidth, scaleHeight));
                    }

                    pbxOrigImg.Image = imgOrig;
                    origCopy = imgOrig.ToImage<Hsv, Byte>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Opens the settings form 
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(CustomBackground, MaskGuass, BackgroundColor, MASKVAL, KMEANSVAL, HUERANGE, SATRANGE, VALRANGE);
            settings.ShowDialog();

            if (settings.DialogResult.Equals(DialogResult.OK))
            {
                CustomBackground = settings.CustomBack;
                if (CustomBackground)                           //If custom background, update the BackgroundColor
                    BackgroundColor = settings.currentHsv;
                //Update settings
                MASKVAL = settings.MKVal;
                KMEANSVAL = settings.KMKVal;
                MaskGuass = settings.MaskGuassBack;
                HUERANGE = settings.HueRange;
                SATRANGE = settings.SatRange;
                VALRANGE = settings.ValRange;

                //KVal must be odd
                if (MASKVAL % 2 == 0)
                    MASKVAL += 1;
            }
        }

        //Change the main app size to allow the picture to be seen
        private void pbxDisplayImage_ClientSizeChanged(object sender, EventArgs e)
        {
            App.ActiveForm.Width = imgOrig.Width + 125;
            App.ActiveForm.Height = imgOrig.Height + 90;
            this.MainStatus.Location = new System.Drawing.Point(0, ClientSize.Height - 22);
            this.MainStatus.Size = new System.Drawing.Size(ClientSize.Width, 22);
            this.MainMenu.Size = new Size(ClientSize.Width, this.MainMenu.Height);
        }

        //Updates the UI after clearing out the color palette
        private void deleteColorPaletteBtn_Click(object sender, EventArgs e)
        {
            Color c = Color.Silver;
            for (int i = 1; i <= currentScheme.BucketCount(); i++)
            {
                switch (i)
                {
                    case 1:
                        pbxColor1.BackColor = c;
                        break;
                    case 2:
                        pbxColor2.BackColor = c;
                        break;
                    case 3:
                        pbxColor3.BackColor = c;
                        break;
                    case 4:
                        pbxColor4.BackColor = c;
                        break;
                    case 5:
                        pbxColor5.BackColor = c;
                        break;
                    case 6:
                        pbxColor6.BackColor = c;
                        break;
                    case 7:
                        pbxColor7.BackColor = c;
                        break;
                    case 8:
                        pbxColor8.BackColor = c;
                        break;
                    case 9:
                        pbxColor9.BackColor = c;
                        break;
                    case 10:
                        pbxColor10.BackColor = c;
                        break;
                    case 11:
                        pbxColor11.BackColor = c;
                        break;
                    case 12:
                        pbxColor12.BackColor = c;
                        break;
                }
            }
            currentScheme.Empty();
        }

        //Converts a System.Drawing Color to HSV
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));
            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        //KMeans takes the image and graphs the pixels present and finds centroids to the pixel colors
        //KVal determines how many clusters are present
        //Returns a KMeans rendered image
        //Snagged from http://accord-framework.net/docs/html/T_Accord_MachineLearning_KMeans.htm
        private Image<Bgr,Byte>  mainAlgoKmeans()
        {
            // Create converters to convert between Bitmap images and double[] arrays
            var imageToArray = new ImageToArray(min: -1, max: +1);
            var arrayToImage = new ArrayToImage(imgOrig.Width, imgOrig.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels; imageToArray.Convert(imgOrig, out pixels);
            // Create a K-Means algorithm using given k and a
            // square Euclidean distance as distance metric.
            KMeans kmeans = new KMeans(k: KMEANSVAL)
            {
                Distance = new SquareEuclidean(),

                // We will compute the K-Means algorithm until cluster centroids
                // change less than 0.5 between two iterations of the algorithm
                Tolerance = 0.05
            };
            // Learn the clusters from the data
            var clusters = kmeans.Learn(pixels);
            // Use clusters to decide class labels
            int[] labels = clusters.Decide(pixels);
            // Replace every pixel with its corresponding centroid
            double[][] replaced = pixels.Apply((x, i) => clusters.Centroids[labels[i]]);
            // Retrieve the resulting image (shown in a picture box)
            Bitmap result; arrayToImage.Convert(replaced, out result);
            kmeansResult = result.ToImage<Bgr, Byte>();
            bmp = result;
            return kmeansResult;
        }
        //Renders just a Kmeans Image and puts it to UI
        private void btnApplyKmeans_Click(object sender, EventArgs e)
        {

            // Create converters to convert between Bitmap images and double[] arrays
            var imageToArray = new ImageToArray(min: -1, max: +1);
            var arrayToImage = new ArrayToImage(imgOrig.Width, imgOrig.Height, min: -1, max: +1);

            // Transform the image into an array of pixel values
            double[][] pixels; imageToArray.Convert(imgOrig, out pixels);

            // Create a K-Means algorithm using given k and a
            //  square Euclidean distance as distance metric.
            KMeans kmeans = new KMeans(k: KMEANSVAL)
            {
                Distance = new SquareEuclidean(),

                // We will compute the K-Means algorithm until cluster centroids
                // change less than 0.5 between two iterations of the algorithm
                Tolerance = 0.05
            };


            // Learn the clusters from the data
            var clusters = kmeans.Learn(pixels);

            // Use clusters to decide class labels
            int[] labels = clusters.Decide(pixels);

            // Replace every pixel with its corresponding centroid
            double[][] replaced = pixels.Apply((x, i) => clusters.Centroids[labels[i]]);

            // Retrieve the resulting image (shown in a picture box)
            Bitmap result; arrayToImage.Convert(replaced, out result);
            bmp = result;
            pbxRsltImg.Image = result;
        }

        //Converts HSV color to RGB
        //Snagged from https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        //By Patrik Svensson
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h*2;
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

        //pbxColor_Click Event handeler
        //Handels Color changes, bucket changes, and deleting a color
        private void pbxColor_Click(object sender, EventArgs e)
        {
            ColorManuForm CMF;
            Hsv hsv;
            int r, g, b;
            string box = ((PictureBox)sender).Name;

            if (box.Length == 9)
            {
                switch ((box[8] - '1'))
                {
                    case 0:
                        if (currentScheme.BucketCount() >= 1)
                        {
                            pbxColor1.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(0).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(0).GetUpper(), currentScheme.GetBucket(0).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                MessageBox.Show("Bucket Change == true");
                                if (CMF.SetUpper)
                                {
                                    MessageBox.Show("In Form setting bucket to CMF.upper" + CMF.getUpper().V1 + "  " + CMF.getUpper().V2);
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(0).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(0).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 0);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor1.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(0).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(0).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 0);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))             //Yes to Deleting a color
                            {
                                if (0 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(0);
                                if (currentScheme.BucketCount() == 0)
                                {
                                    pbxColor1.BackColor = Color.Silver;
                                }
                                else
                                {
                                    ColorFix(0);
                                }
                            }
                            pbxColor1.BorderStyle = BorderStyle.FixedSingle;
                        }
                        break;
                    case 1:
                        if (currentScheme.BucketCount() >= 2)
                        {
                            pbxColor2.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(1).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(1).GetUpper(), currentScheme.GetBucket(1).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(1).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(1).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 1);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor2.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(1).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(1).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 1);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (1 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(1);
                                ColorFix(1);
                            }
                            pbxColor2.BorderStyle = BorderStyle.FixedSingle;
                        }
                        break;
                    case 2:
                        if (currentScheme.BucketCount() >= 3)
                        {
                            pbxColor3.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(2).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(2).GetUpper(), currentScheme.GetBucket(2).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(2).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(2).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 2);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor3.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(2).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(2).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 2);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (2 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(2);
                                ColorFix(2);
                            }
                            pbxColor3.BorderStyle = BorderStyle.FixedSingle;
                        }
                        break;
                    case 3:
                        if (currentScheme.BucketCount() >= 4)
                        {
                            pbxColor4.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(3).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(3).GetUpper(), currentScheme.GetBucket(3).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(3).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(3).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 3);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor4.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(3).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(3).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 3);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (3 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(3);
                                ColorFix(3);
                            }
                            pbxColor4.BorderStyle = BorderStyle.FixedSingle;
                        }
                        break;
                    case 4:
                        if (currentScheme.BucketCount() >= 5)
                        {
                            pbxColor5.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(4).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(4).GetUpper(), currentScheme.GetBucket(4).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(4).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(4).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 4);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor5.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(4).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(4).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 4);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (4 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(4);
                                ColorFix(4);
                            }
                            pbxColor5.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                    case 5:
                        if (currentScheme.BucketCount() >= 6)
                        {
                            pbxColor6.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(5).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(5).GetUpper(), currentScheme.GetBucket(5).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(5).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(5).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 5);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor6.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(5).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(5).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 5);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (5 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(5);
                                ColorFix(5);
                            }
                            pbxColor6.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                    case 6:
                        if (currentScheme.BucketCount() >= 7)
                        {
                            pbxColor7.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(6).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(6).GetUpper(), currentScheme.GetBucket(6).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(6).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(6).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 6);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor7.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(6).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(6).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 6);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (6 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(6);
                                ColorFix(6);
                            }
                            pbxColor7.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                    case 7:
                        if (currentScheme.BucketCount() >= 8)
                        {
                            pbxColor8.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(7).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(7).GetUpper(), currentScheme.GetBucket(7).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(7).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(7).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 7);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor8.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(7).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(7).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 7);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (7 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(7);
                                ColorFix(7);
                            }
                            pbxColor8.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                    case 8:
                        if (currentScheme.BucketCount() >= 9)
                        {
                            pbxColor9.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(8).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(8).GetUpper(), currentScheme.GetBucket(8).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(8).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(8).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 8);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor9.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(8).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(8).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 8);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (8 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(8);
                                ColorFix(8);
                            }
                            pbxColor9.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                }
            }
            else if (box.Length == 10)
            {             //If the box # is two digits then grab second digit and determine # off that
                switch (box[9] - '1')
                {
                    case -1:
                            if (currentScheme.BucketCount() >= 10)
                            {
                                pbxColor10.BorderStyle = BorderStyle.Fixed3D;
                                ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                                Hsv CMFhsv = currentScheme.GetBucket(9).GetHsv();
                                CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(9).GetUpper(), currentScheme.GetBucket(9).GetLower());
                                CMF.ShowDialog();
                                if (CMF.BucketChange)                                               //Change the bucket range
                                {
                                    if (CMF.SetUpper)
                                    {
                                        Montucket.SetUpper(CMF.getUpper());
                                    }
                                    else
                                    {
                                        Montucket.SetUpper(currentScheme.GetBucket(9).GetUpper());
                                    }
                                    if (CMF.SetLower)
                                    {
                                        Montucket.SetLower(CMF.getLower());
                                    }
                                    else
                                    {
                                        Montucket.SetLower(currentScheme.GetBucket(9).GetLower());
                                    }
                                    Montucket.SetHsv(CMFhsv);
                                    currentScheme.SetBucket(Montucket, 9);
                                }
                                if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                                {
                                    hsv = CMF.getHsv();
                                    HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                    pbxColor10.BackColor = Color.FromArgb(r, g, b);
                                    Montucket.SetUpper(currentScheme.GetBucket(9).GetUpper());
                                    Montucket.SetLower(currentScheme.GetBucket(9).GetLower());
                                    Montucket.SetHsv(hsv);
                                    currentScheme.SetBucket(Montucket, 9);
                                }
                                else if (CMF.DialogResult.Equals(DialogResult.Yes))
                                {
                                    if (9 == currentScheme.redloc)
                                    {
                                        currentScheme.ResetRed();
                                    }
                                    currentScheme.DeleteColor(9);
                                    ColorFix(9);
                                }
                                pbxColor10.BorderStyle = BorderStyle.FixedSingle;

                            }
                            break;
                    case 0:
                        if (currentScheme.BucketCount() >= 11)
                        {
                            pbxColor11.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(10).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(10).GetUpper(), currentScheme.GetBucket(10).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(10).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(10).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 10);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor11.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(10).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(10).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 10);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (10 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(10);
                                ColorFix(10);
                            }
                            pbxColor11.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                    case 1:
                        if (currentScheme.BucketCount() >= 12)
                        {
                            pbxColor12.BorderStyle = BorderStyle.Fixed3D;
                            ColorScheme.Bucket Montucket = new ColorScheme.Bucket();
                            Hsv CMFhsv = currentScheme.GetBucket(11).GetHsv();
                            CMF = new ColorManuForm(CMFhsv, currentScheme.GetBucket(11).GetUpper(), currentScheme.GetBucket(11).GetLower());
                            CMF.ShowDialog();
                            if (CMF.BucketChange)                                               //Change the bucket range
                            {
                                if (CMF.SetUpper)
                                {
                                    Montucket.SetUpper(CMF.getUpper());
                                }
                                else
                                {
                                    Montucket.SetUpper(currentScheme.GetBucket(11).GetUpper());
                                }
                                if (CMF.SetLower)
                                {
                                    Montucket.SetLower(CMF.getLower());
                                }
                                else
                                {
                                    Montucket.SetLower(currentScheme.GetBucket(11).GetLower());
                                }
                                Montucket.SetHsv(CMFhsv);
                                currentScheme.SetBucket(Montucket, 11);
                            }
                            if (CMF.DialogResult.Equals(DialogResult.OK))                   //Change the hsv color for that bucket
                            {
                                hsv = CMF.getHsv();
                                HsvToRgb(hsv.Hue, hsv.Satuation, hsv.Value, out r, out g, out b);
                                pbxColor12.BackColor = Color.FromArgb(r, g, b);
                                Montucket.SetUpper(currentScheme.GetBucket(11).GetUpper());
                                Montucket.SetLower(currentScheme.GetBucket(11).GetLower());
                                Montucket.SetHsv(hsv);
                                currentScheme.SetBucket(Montucket, 11);
                            }
                            else if (CMF.DialogResult.Equals(DialogResult.Yes))
                            {
                                if (11 == currentScheme.redloc)
                                {
                                    currentScheme.ResetRed();
                                }
                                currentScheme.DeleteColor(11);
                                ColorFix(11);
                            }
                            pbxColor12.BorderStyle = BorderStyle.FixedSingle;

                        }
                        break;
                }
            }
        }

        //Updates the UI
        //Shifts the colors up one starting at the color being deleted
        private void ColorFix(int start)
        {
            switch(start)
                {
                case 0:
                    pbxColor1.BackColor = pbxColor2.BackColor;
                    if (pbxColor3.BackColor == Color.Silver)
                    {
                        pbxColor2.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor2.BackColor = pbxColor3.BackColor;
                    if (pbxColor4.BackColor == Color.Silver)
                    {
                        pbxColor3.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor3.BackColor = pbxColor4.BackColor;
                    if (pbxColor5.BackColor == Color.Silver)
                    {
                        pbxColor4.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor4.BackColor = pbxColor5.BackColor;
                    if (pbxColor6.BackColor == Color.Silver)
                    {
                        pbxColor5.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor5.BackColor = pbxColor6.BackColor;
                    if (pbxColor7.BackColor == Color.Silver)
                    {
                        pbxColor6.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 1:
                    pbxColor2.BackColor = pbxColor3.BackColor;
                    if (pbxColor4.BackColor == Color.Silver)
                    {
                        pbxColor3.BackColor = Color.Silver;
                        return;
                    }
                    pbxColor3.BackColor = pbxColor4.BackColor;
                    if (pbxColor5.BackColor == Color.Silver)
                    {
                        pbxColor4.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor4.BackColor = pbxColor5.BackColor;
                    if (pbxColor6.BackColor == Color.Silver)
                    {
                        pbxColor5.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor5.BackColor = pbxColor6.BackColor;
                    if (pbxColor7.BackColor == Color.Silver)
                    {
                        pbxColor6.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 2:
                    pbxColor3.BackColor = pbxColor4.BackColor;
                    if (pbxColor5.BackColor == Color.Silver)
                    {
                        pbxColor4.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor4.BackColor = pbxColor5.BackColor;
                    if (pbxColor6.BackColor == Color.Silver)
                    {
                        pbxColor5.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor5.BackColor = pbxColor6.BackColor;
                    if (pbxColor7.BackColor == Color.Silver)
                    {
                        pbxColor6.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 3:
                    pbxColor4.BackColor = pbxColor5.BackColor;
                    if (pbxColor6.BackColor == Color.Silver)
                    {
                        pbxColor5.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor5.BackColor = pbxColor6.BackColor;
                    if (pbxColor7.BackColor == Color.Silver)
                    {
                        pbxColor6.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 4:
                    pbxColor5.BackColor = pbxColor6.BackColor;
                    if (pbxColor7.BackColor == Color.Silver)
                    {
                        pbxColor6.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 5:
                    pbxColor6.BackColor = pbxColor7.BackColor;
                    if (pbxColor8.BackColor == Color.Silver)
                    {
                        pbxColor7.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 6:
                    pbxColor7.BackColor = pbxColor8.BackColor;
                    if (pbxColor9.BackColor == Color.Silver)
                    {
                        pbxColor8.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 7:
                    pbxColor8.BackColor = pbxColor9.BackColor;
                    if (pbxColor10.BackColor == Color.Silver)
                    {
                        pbxColor9.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 8:
                    pbxColor9.BackColor = pbxColor10.BackColor;
                    if (pbxColor11.BackColor == Color.Silver)
                    {
                        pbxColor10.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 9:
                    pbxColor10.BackColor = pbxColor11.BackColor;
                    if (pbxColor12.BackColor == Color.Silver)
                    {
                        pbxColor11.BackColor = Color.Silver;
                        break;
                    }
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 10:
                    pbxColor11.BackColor = pbxColor12.BackColor;
                    pbxColor12.BackColor = Color.Silver;
                    break;
                case 11:
                    pbxColor12.BackColor = Color.Silver;
                    break;
            }
        }
    }
}