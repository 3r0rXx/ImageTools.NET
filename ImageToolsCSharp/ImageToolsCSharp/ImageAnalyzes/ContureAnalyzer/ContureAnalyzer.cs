using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageToolsCSharp.PixelOperations;
namespace ImageToolsCSharp.ImageAnalyzes.ContureAnalyzer
{
    public static class ContureAnalyzer
    {

        public static System.Drawing.Bitmap AnalyzeImage(System.Drawing.Bitmap Image)
        {
            PixelHelper.LockBitsMethods = new PixelOperations.LockBits.LockBitsClass(Image);
            float result = 0;
            PixelHelper.LockBitsMethods.LockBits();
            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    result = PixelHelper.LockBitsMethods.GetPixel(x, y).R / 255f;
                        if (result >= 0.001 & result <= 0.02 || result >= 0.33 & result <= 0.36 || result >= 0.8 & result <= 0.9)
                        {
                            PixelHelper.LockBitsMethods.SetPixel(x, y, System.Drawing.Color.Red);
                        }
                }
            }
            PixelHelper.LockBitsMethods.UnlockBits();
            return Image;
        }


        public static System.Drawing.Bitmap AnalyzeImagePixel(System.Drawing.Bitmap Image,bool OrginalColor = false)
        {
            System.Drawing.Bitmap ContureSetBitmap = new System.Drawing.Bitmap(Image.Width, Image.Height);
            PixelHelper.LockBitsMethods = new PixelOperations.LockBits.LockBitsClass(Image);
            ImageToolsCSharp.PixelOperations.LockBits.LockBitsClass LockBits = new PixelOperations.LockBits.LockBitsClass(ContureSetBitmap);
            float result = 0;
            PixelHelper.LockBitsMethods.LockBits();
            LockBits.LockBits();
            for (int x = 0; x <= Image.Width - 1; x++)
            {
                for (int y = 0; y <= Image.Height - 1; y++)
                {
                    result = PixelHelper.LockBitsMethods.GetPixel(x, y).R / 255f;
                    if (result >= 0.001 & result <= 0.02 || result >= 0.33 & result <= 0.36 || result >= 0.8 & result <= 0.9)
                    {
                        if (OrginalColor)
                        {
                            LockBits.SetPixel(x, y, PixelHelper.LockBitsMethods.GetPixel(x, y));
                        }
                        else
                        {
                            LockBits.SetPixel(x, y, System.Drawing.Color.Red);
                        }
                    }
                }
            }
            PixelHelper.LockBitsMethods.UnlockBits();
            LockBits.UnlockBits();
            return ContureSetBitmap;
        }
    }
}
