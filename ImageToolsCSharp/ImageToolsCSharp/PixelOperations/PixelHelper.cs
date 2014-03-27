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
        public static float GetPixelBrightness(Bitmap SourceImage, int x, int y)
        {
            LockBitsMethods = new PixelOperations.LockBits.LockBitsClass(SourceImage);
            float r, g, b, result = 0;
            LockBitsMethods.LockBits();
            r = LockBitsMethods.GetPixel(x, y).R * 0.3f;
            g = LockBitsMethods.GetPixel(x, y).G * 0.584f;
            b = LockBitsMethods.GetPixel(x, y).B * 0.114f;
            result = r + g + b;
            LockBitsMethods.UnlockBits();
            return (result / 255);
        }
        public static float GetPixelBrightness(Color Color)
        {
            float r, g, b, result = 0;
            r = Color.R * 0.3f;
            g = Color.G * 0.584f;
            b = Color.B * 0.114f;
            result = r + g + b;
            return (result / 255);
        }

        public static float MostAvaibleBrightness(Bitmap Image)
        {
            Dictionary<float, int> Dictonary = new Dictionary<float, int>();
            float result = 0;
            Image = new ImageToolsCSharp.PixelOperations.Effects.GrayScale.GrayScale(Image).ConvertedImage;
            LockBitsMethods = new LockBits.LockBitsClass(Image);
            LockBitsMethods.LockBits();
            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    result = LockBitsMethods.GetPixel(x, y).R / 255f;
                    if (Dictonary.Keys.Contains(result))
                    {
                        Dictonary[result] = Dictonary[result] + 1;
                    }
                    else
                    {
                        Dictonary.Add(result, 0);
                    }
                }
            }
            LockBitsMethods.UnlockBits();

            return Dictonary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
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
        public static Color[] GetAvaibleColorsAndSort(Bitmap Image)
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
            Dictonary = Dictonary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return Dictonary.Keys.ToArray();
        }

        public static int GetColorCount(Bitmap Image)
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
                     
                    }
                    else
                    {
                        Dictonary.Add(LockBitsMethods.GetPixel(x, y), 0);
                    }
                }
            }
            LockBitsMethods.UnlockBits();

            return Dictonary.Count;
        }
        public static Color[] GetColors(Bitmap Image)
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

                    }
                    else
                    {
                        Dictonary.Add(LockBitsMethods.GetPixel(x, y), 0);
                    }
                }
            }
            LockBitsMethods.UnlockBits();

            return Dictonary.Keys.ToArray();
        }

        public static bool IsSimilar(Bitmap Image,MathematicalOperations.Vector.Vector2 pos1, MathematicalOperations.Vector.Vector2 pos2)
        {
            int r, g, b, r1, g1, b1 = 0;

            LockBitsMethods = new LockBits.LockBitsClass(Image);
            LockBitsMethods.LockBits();
            r = LockBitsMethods.GetPixel((int)pos1.X, (int)pos1.Y).R;
            g = LockBitsMethods.GetPixel((int)pos1.X, (int)pos1.Y).G;
            b = LockBitsMethods.GetPixel((int)pos1.X, (int)pos1.Y).B;

            r1 = LockBitsMethods.GetPixel((int)pos2.X, (int)pos2.Y).R;
            g1 = LockBitsMethods.GetPixel((int)pos2.X, (int)pos2.Y).G;
            b1 = LockBitsMethods.GetPixel((int)pos2.X, (int)pos2.Y).B;
            int diffR, diffG, diffB = 0;

            if (r > r1)
            {
                diffR = r - r1;
            }
            {
                diffR = r1 - r;
            }
            if (g > g1)
            {
                diffG = g - g1;
            }
            {
                diffG = g1 - g;
            }
            if (b > b1)
            {
                diffB = b - b1;
            }
            {
                diffB = b1 - b;
            }
            LockBitsMethods.UnlockBits();
            if ((diffR - diffG - diffB > -125))
            {
                return true;
            }
            {
                return false;
            }
        }

        public static bool Contains(Bitmap Image, Color Color)
        {
            bool Contains_ = false;
            LockBitsMethods = new LockBits.LockBitsClass(Image);
            LockBitsMethods.LockBits();

            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    if (LockBitsMethods.GetPixel(x, y) == Color)
                    {
                        Contains_ = true;
                    }
                }
            }
            LockBitsMethods.UnlockBits();
            return Contains_;
        }


        public static double GetColorAvailabilityInPercents(Bitmap Image, Color Color)
        {
            double Pixels = Image.Width * Image.Height;
            double Counter = 0;

            LockBitsMethods = new LockBits.LockBitsClass(Image);
            LockBitsMethods.LockBits();

            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    if (LockBitsMethods.GetPixel(x, y) == Color)
                    {
                        Counter += 1;
                    }
                }
            }
            LockBitsMethods.UnlockBits();

            return Math.Round(Counter / Pixels, 2);
        }

    }
}
