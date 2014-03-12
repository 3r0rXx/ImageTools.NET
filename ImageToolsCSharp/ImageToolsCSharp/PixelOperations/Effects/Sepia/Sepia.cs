using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageToolsCSharp.PixelOperations.Effects.Sepia
{
    public class Sepia
    {

                public Bitmap SourceImage; 
        public Bitmap ConvertedImage;

        LockBits.LockBitsClass LockBits;
        public Sepia(Bitmap Image)
        {
            //9123
            int gr, gg, gb = 0;

            SourceImage = Image;
            //Processing here
            LockBits = new LockBits.LockBitsClass(SourceImage);
            LockBits.LockBits();
            for (int x = 0; x <= SourceImage.Width - 1; x++)
            {
                for (int y = 0; y <= SourceImage.Height - 1; y++)
                {
                    gr = (int)(LockBits.GetPixel(x, y).R * 0.9);
                    gg = (int)(LockBits.GetPixel(x, y).G * 0.988);
                    gb = (int)(LockBits.GetPixel(x, y).B * 0.01);
                    LockBits.SetPixel(x, y, Color.FromArgb(255, gr, gg, gb));
                }
            }
            LockBits.UnlockBits();
            ConvertedImage = SourceImage;

        }
    }
}
