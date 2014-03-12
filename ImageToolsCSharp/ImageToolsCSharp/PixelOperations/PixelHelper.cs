using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageToolsCSharp.PixelOperations
{
    public static class PixelHelper
    {

        public static LockBits.LockBitsClass LockBitsMethods;
        public static double GetPixelBrightness(Bitmap SourceImage, int x, int y)
        {
            LockBitsMethods = new PixelOperations.LockBits.LockBitsClass(SourceImage);
            double r, g, b, result = 0;
            LockBitsMethods.LockBits();
            r = LockBitsMethods.GetPixel(x, y).R * 0.3;
            g = LockBitsMethods.GetPixel(x, y).G * 0.584;
            b = LockBitsMethods.GetPixel(x, y).B * 0.114;
            result = r + g + b;
            LockBitsMethods.UnlockBits();
            return (255 / result);
        }

        public static Color MostAvaibleColor(Bitmap Image)
        {
            Dictionary<Color, int> Dictonary = new Dictionary<Color, int>();
            LockBitsMethods = new LockBits.LockBitsClass(Image);
            LockBitsMethods.LockBits();
            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    if (Dictonary.Keys.Contains(LockBitsMethods.GetPixel(x, y)))
                    {
                        Dictonary[LockBitsMethods.GetPixel(x, y)] = Dictonary[LockBitsMethods.GetPixel(x, y)] + 1;
                    }
                    else
                    {
                        Dictonary.Add(LockBitsMethods.GetPixel(x, y), 0);
                    }
                }
            }
            LockBitsMethods.UnlockBits();

            return Dictonary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
