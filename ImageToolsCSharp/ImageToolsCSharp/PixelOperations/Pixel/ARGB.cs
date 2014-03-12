using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageToolsCSharp.PixelOperations.Pixel
{
    public struct ARGB
    {
        public byte A, R, G, B;

        public Color GetColor(byte a, byte r, byte g, byte b)
        {
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
    }
}
