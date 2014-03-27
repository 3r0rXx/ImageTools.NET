using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageToolsCSharp.PixelOperations.Effects.GrayScale
{
    public class GrayScale
    {
        public Bitmap SourceImage;
        public Bitmap ConvertedImage;

        LockBits.LockBitsClass LockBits;
        public GrayScale(Bitmap Image)
        {
            //9123
            int gr, gg, gb, result = 0;

            SourceImage = Image;
            //Processing here
            LockBits = new LockBits.LockBitsClass(SourceImage);
            LockBits.LockBits();
            for (int x = 0; x <= SourceImage.Width - 1; x++)
            {
                for (int y = 0; y <= SourceImage.Height - 1; y++)
                {
                    gr = (int)(LockBits.GetPixel(x, y).R * 0.3);
                    gg = (int)(LockBits.GetPixel(x, y).G * 0.584);
                    gb = (int)(LockBits.GetPixel(x, y).B * 0.114);
                    result = gr + gg + gb;
                    LockBits.SetPixel(x, y,Color.FromArgb(255,result,result,result ));
                }
            }
            LockBits.UnlockBits();
            ConvertedImage = SourceImage;
        }
    }
}
