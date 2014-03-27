using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageToolsCSharp.PixelOperations;
namespace ImageToolsCSharp.PixelOperations.Effects.RedBlack
{
    public class RBPicture
    {

        public RBPicture(System.Drawing.Bitmap RBImage)
        {
            double a, b, c = 0;
            a = PixelHelper.GetColorAvailabilityInPercents(RBImage, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            b = PixelHelper.GetColorAvailabilityInPercents(RBImage, System.Drawing.Color.FromArgb(255, 255, 0, 0));
            c = a + b;

            if (c != 1)
            {
                throw new Exception("This image is not valid!");
            }
        }
    }
}
