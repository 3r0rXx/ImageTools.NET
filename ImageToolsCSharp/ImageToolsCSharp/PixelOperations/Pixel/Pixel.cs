using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageToolsCSharp.MathematicalOperations.Vector;
namespace ImageToolsCSharp.PixelOperations.Pixel
{
    public class Pixel
    {
        public ARGB ARGB;
        public System.Drawing.Color PixelColor;
        public Vector2 Position;


        public Pixel(Vector2 pos, ARGB argb)
        {
            Position = pos;
            ARGB = argb;
        }

        public Pixel(Vector2 pos, System.Drawing.Color Color)
        {
            Position = pos;
            PixelColor = Color;
        }

        public Pixel(Vector2 pos, byte A, byte RGB)
        {
            Position = pos;
            ARGB.A = A;
            ARGB.R = RGB;
            ARGB.G = RGB;
            ARGB.B = RGB;
        }


        public static bool operator ==(Pixel p1, Pixel p2)
        {
            return object.Equals(p1, p2);
        }
        public static bool operator !=(Pixel p1, Pixel p2)
        {
            return !(object.Equals(p1, p2));
        }
    }
}
