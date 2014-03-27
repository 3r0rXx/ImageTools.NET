using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ImageToolsCSharp.MathematicalOperations.Matrix;
using ImageToolsCSharp.MathematicalOperations.Vector;
using ImageToolsCSharp.OCR.ConturComparer;
using ImageToolsCSharp.PixelOperations.Effects.GrayScale;
using ImageToolsCSharp.PixelOperations.LockBits;
using ImageToolsCSharp.PixelOperations.Pixel;
using ImageToolsCSharp.PixelOperations;
namespace ImageToolsCSharp.OCR.ConturScan
{
    public class ColorTools
    {
        Bitmap srcImage;
        int AmountColors;
        Color MostUsedColor;
        Color[] Colors;
        public LockBitsClass LockBits;
        public ColorTools(Bitmap Image)
        {
            //Load Image to srcImage;
            srcImage = Image;
            //Convert x3 in x1;
            srcImage = new GrayScale(Image).ConvertedImage;
            //Get amount of x1-Colors
            AmountColors = PixelHelper.GetColorCount(srcImage);
            //Get most used color
            MostUsedColor = PixelHelper.MostAvaibleColor(srcImage);
            Colors = PixelHelper.GetColors(srcImage);
            //lock bits of srcImage
            LockBits = new LockBitsClass(srcImage);

        }

        public Bitmap GetContureByColor_Beta()
        {
                LockBits.LockBits();
                for (int x = 0; x <= srcImage.Width - 1; x++)
                {
                    for (int y = 0; y <= srcImage.Height - 1; y++)
                    {
                        if (LockBits.GetPixel(x, y) != MostUsedColor)
                        {
                            if (!(x <= 1 || y <= 1))
                            {
                                if (LockBits.GetPixel(x - 1, y - 1) == MostUsedColor)
                                {
                                    LockBits.SetPixel(x, y, Color.FromArgb(255, 255, 0, 0));
                                }
                            }
                            if (!(x <= 1 || y >= srcImage.Height - 1))
                            {
                                if (LockBits.GetPixel(x - 1, y + 1) == MostUsedColor)
                                {
                                    LockBits.SetPixel(x, y, Color.FromArgb(255, 255, 0, 0));
                                }
                            }
                            if (!(x >= srcImage.Width - 1))
                            {
                                if (LockBits.GetPixel(x + 1, y) == MostUsedColor)
                                {
                                    LockBits.SetPixel(x, y, Color.FromArgb(255, 255, 0, 0));
                                }
                            }
                        }
                    }
                }
                LockBits.UnlockBits();
            return srcImage;
        }
    }
}
