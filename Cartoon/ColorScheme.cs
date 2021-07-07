//Author:       Colby Wall
//Filename:     ColorScheme.cs
//Purpose:      Creating and holding color data

using Emgu.CV.Structure;
using System.Windows.Forms;
using System.Collections;
using System;

namespace Cartoon
{
    class ColorScheme
    {
        //Settings variables
        static int MAXNUM = 13;
        public int HueRange = 8;
        public int SatRange = 25;
        public int ValRange = 25;
        //Private
        private int numColor = 0;
        private double minVal = .2;
        private double minSat = .2;

        //ArrayList of buckets
        ArrayList colorbuckets = new ArrayList();

        //Red wrap-around issue solution and variables
        //Is basically a single bucket without the struct
        public MCvScalar redup;
        public MCvScalar reddown;
        public Hsv redhsv;
        public int redloc=-1;


        //Bucket struct holds only the main HSV color and the upper and lower bounds of that color
        public struct Bucket
        {
            Hsv HSVcolor;
            MCvScalar lower_bound;
            MCvScalar upper_bound;

            //Accessors
            public MCvScalar GetUpper()
            {
                return upper_bound;
            }
            public MCvScalar GetLower()
            {
                return lower_bound;
            }
            public Hsv GetHsv()
            {
                return HSVcolor;
            }
            public bool HasValue()
            {
                if (upper_bound.V2 != 0)
                {
                    return true;
                }
                return false;
            }

            //Mutators
            public void SetUpper(MCvScalar up)
            {
                upper_bound = up;
            }
            public void SetLower(MCvScalar down)
            {
                lower_bound = down;
            }
            public void SetHsv(Hsv hsv)
            {
                HSVcolor = hsv;
            }
        }


        //Class Accessors
        //Returns the bucket at pos box
        public Bucket GetBucket(int box)
        {
            if (box < colorbuckets.Count && box >= 0)
            {
                return (Bucket)colorbuckets[box];
            }
            return new Bucket();
        }
        
        //Returns the # of buckets present 
        public int BucketCount()
        {
            return colorbuckets.Count;
        }


        //Class Mutator
        //Sets the bucket to the given index if within range
        public void SetBucket(Bucket b, int index)
        {
            if (index >= 0 && index < BucketCount())
                colorbuckets[index] = b;
        }
        public void SetRanges(int HRange, int SRange, int VRange)
        {
            HueRange = HRange;
            SatRange = SRange;
            ValRange = VRange;
        }

        //Red wrap around issue crude solution
        //will set the location of the red bucket
        public void SetRedLoc(int r)
        {
            if(redloc<MAXNUM&&redloc>-2)
                redloc = r;
        }

        //Resets the red bucket
        public void ResetRed()
        {
            redup = new MCvScalar();
            reddown = new MCvScalar();
            redhsv = new Hsv();
        }

        //Summary: Builds buckets around the given HSV and stores them in the array list
        //Parameters: hue, saturation, value and the differentiate flag to have a narrower bucket
        public int AddColor(double hue, double sat, double val, Boolean differentiate)
        {
            MCvScalar down;
            MCvScalar up;
            
            numColor++;
            if (numColor != MAXNUM)
            {
                hue = hue / 2;          //Adjust for Emgu functions (0-180)
                Bucket b = new Bucket();
                if (!differentiate)
                {
                    if (val < minVal)       //Black color
                    {
                        up = new MCvScalar(180, 255, minVal * 255);
                        down = new MCvScalar(0, 0, 0);
                    }
                    else if (sat < minSat)   //If sataruation of color is below the min sat value 
                    {                        //Faded Shade, Probably a grayish color. Hue is relevant here (Hue > 100 == Dark Gray)
                        if (hue > 180 - HueRange)
                        {
                            up = new MCvScalar(180, minSat * 255, 255);
                        }
                        else
                        {
                            up = new MCvScalar(hue + HueRange, minSat * 255, 255);
                        }
                        if (hue < HueRange)
                        {
                            down = new MCvScalar(0, 0, minVal * 255);
                        }
                        else
                        {
                            down = new MCvScalar(hue - HueRange, 0, minVal * 255);
                        }
                    }
                    else    //else it's a Visible color
                    {
                        if (hue > 180 - HueRange)       //Range reaches single digits of hue
                        {
                            up = new MCvScalar(180, 255, 255);
                            if (redup.V2 == 0)
                            {
                                redup = new MCvScalar(HueRange, 255, 255);
                                reddown = new MCvScalar(0, (sat - .05) * 255, (val - .05) * 255);
                                redhsv = new Hsv(hue, sat, val);
                                redloc = numColor - 1;
                            }

                        }
                        else
                        {
                            up = new MCvScalar(hue + HueRange, 255, 255);
                        }
                        if (hue < HueRange)
                        {
                            down = new MCvScalar(0, minSat * 255, minVal * 255);
                            if (redup.V2 == 0)
                            {
                                redup = new MCvScalar(180, 255, 255);
                                reddown = new MCvScalar(180 - HueRange, (sat - .05) * 255, (val - .05) * 255);
                                redhsv = new Hsv(hue, sat, val);
                                redloc = numColor - 1;
                            }
                        }
                        else
                        {
                            down = new MCvScalar(hue - HueRange, minSat * 255, minVal * 255);
                        }
                    }
                }
                else          //else differentiate
                {
                 
                    if (hue > 180 - HueRange)       //Range reaches single digits of hue
                    {
                        up = new MCvScalar(180, sat*255+SatRange, val*255+ValRange);

                        if (redup.V2 == 0)          //If red bucket isnt already full
                        {
                            redup = new MCvScalar(HueRange, 255, 255);
                            reddown = new MCvScalar(0, sat * 255-SatRange, val * 255-ValRange);
                            redhsv = new Hsv(hue, sat, val);
                            redloc = numColor - 1;
                        }

                    }
                    else
                    {
                        up = new MCvScalar(hue + HueRange, sat * 255 + SatRange, val * 255 + ValRange);
                    }
                    if (hue < HueRange)                   //Hue is less than the range taken from in (Reaches into 180s)
                    {
                        down = new MCvScalar(0, sat * 255-SatRange, val* 255-ValRange);
                        if (redup.V2 == 0)
                        {
                            redup = new MCvScalar(180, 255, 255);
                            reddown = new MCvScalar(180 - HueRange, sat * 255 - SatRange, val * 255 - ValRange);
                            redhsv = new Hsv(hue, sat, val);
                            redloc = numColor - 1;
                        }
                    }
                    else
                    {
                        down = new MCvScalar(hue - HueRange, sat * 255 - SatRange, val * 255 - ValRange);
                    }
                    
                }
                b.SetHsv(new Hsv(hue, sat, val));
                b.SetUpper(up);
                b.SetLower(down);
                colorbuckets.Add(b);

                return numColor;
            }
            MessageBox.Show("Color palette full!");
            return 0;
        }

        //Deletes the color at index i
        public void DeleteColor(int i)
        {
            if (i < numColor && i>=0)
            {
                numColor--;
                colorbuckets.RemoveAt(i);
                if (redloc == i)                //if i was a red color with the red bucket then reset red bucket
                {
                    ResetRed();
                    redloc = -1;
                }

            }
        }

        //Empties the arraylist
        public void Empty()
        {
            colorbuckets.Clear();
            numColor = 0;
        }

    }
}
