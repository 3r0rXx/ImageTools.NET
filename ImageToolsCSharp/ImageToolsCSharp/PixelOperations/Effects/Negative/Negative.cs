using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageToolsCSharp.PixelOperations.Effects.Negative
{
    public class Negative
    {
        public Bitmap SourceImage; 
        public Bitmap ConvertedImage;

        LockBits.LockBitsClass LockBits;
        public Negative(Bitmap Image)
        {
            //9123

            SourceImage = Image;
            //Processing here
            LockBits = new LockBits.LockBitsClass(SourceImage);
            LockBits.LockBits();
            for (int x = 0; x <= SourceImage.Width - 1; x++)
            {
                for (int y = 0; y <= SourceImage.Height - 1; y++)
                {

                    LockBits.SetPixel(x, y, Color.FromArgb(255, Color.FromArgb(reversecolor(LockBits.GetPixel(x, y)).R, reversecolor(LockBits.GetPixel(x, y)).G, reversecolor(LockBits.GetPixel(x, y)).B)));
                }
            }
            LockBits.UnlockBits();
            ConvertedImage = SourceImage;
        }

        public Color reversecolor(Color x){

        return Color.FromArgb(x.A,
                              255 - x.R,
                              255 - x.G,
                              255 - x.B);
  
        }
    }

}
