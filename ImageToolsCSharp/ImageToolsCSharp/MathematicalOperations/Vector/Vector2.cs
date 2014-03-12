using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolsCSharp.MathematicalOperations.Vector
{
    public struct Vector2
    {
        public float X, Y;

        public Vector2 Location
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2(float ComponentX, float ComponentY)
        {
            X = ComponentX;
            Y = ComponentY;
        }
    }
}
