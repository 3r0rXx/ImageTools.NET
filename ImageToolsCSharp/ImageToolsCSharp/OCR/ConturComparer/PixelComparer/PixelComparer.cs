using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageToolsCSharp.OCR.ConturComparer
{
    public class PixelComparer
    {

        public struct PixelCompareResult
        {

        }
        private Bitmap Btm1, Btm2;

        public PixelComparer(Bitmap s1, Bitmap s2)
        {
            Btm1 = s1;
            Btm2 = s2;

            Btm1 = ResizeBitmap(Btm1, new Size(800,800));
            Btm2 = ResizeBitmap(Btm2, new Size(800,800));
        }
        public double Compare()
        {
            double difference = 0;
            ImageToolsCSharp.PixelOperations.LockBits.LockBitsClass LockBits1 = new PixelOperations.LockBits.LockBitsClass(Btm1);
            ImageToolsCSharp.PixelOperations.LockBits.LockBitsClass LockBits2 = new PixelOperations.LockBits.LockBitsClass(Btm2);

            LockBits1.LockBits();
            LockBits2.LockBits();

            for (int x = 0; x <= Btm1.Width - 1; x++)
            {
                for (int y = 0; y <= Btm1.Height - 1; y++)
                {
                    if (LockBits1.GetPixel(x, y) != LockBits2.GetPixel(x, y))
                    {
                        difference += 1;
                    }
                }
            }

            LockBits1.UnlockBits();
            LockBits2.UnlockBits();

            return difference / (Btm1.Width * Btm1.Height );
        }

        public static Bitmap ResizeBitmap(Bitmap Bitmap, Size NewSize)
        {
            Bitmap bmp = new Bitmap(NewSize.Width, NewSize.Height, Bitmap.PixelFormat);
            var _with1 = Graphics.FromImage(bmp);
            _with1.DrawImage(Bitmap, 0, 0, NewSize.Width, NewSize.Height);
            return bmp;
        }
    }
}
