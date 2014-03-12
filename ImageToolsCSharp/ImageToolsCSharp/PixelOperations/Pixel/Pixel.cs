using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageToolsCSharp.MathematicalOperations.Vector;
namespace ImageToolsCSharp.PixelOperations.Pixel
{
    public struct Pixel
    {
        public ARGB ARGB;
        public Vector2 Position;


        public Pixel(Vector2 pos, ARGB argb)
        {
            Position = pos;
            ARGB = argb;
        }

        public Pixel(Vector2 pos, byte A, byte RGB)
        {
            Position = pos;
            ARGB.A = A;
            ARGB.R = RGB;
            ARGB.G = RGB;
            ARGB.B = RGB;
        }
    }
}
