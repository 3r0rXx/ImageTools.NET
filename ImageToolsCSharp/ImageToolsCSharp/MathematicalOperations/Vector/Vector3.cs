using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolsCSharp.MathematicalOperations.Vector
{
    public struct Vector3
    {
        public float X, Y, Z;

        public Vector3 Location
        {
            get { return new Vector3(X, Y, Z); }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        public Vector3(float ComponentX, float ComponentY, float ComponentZ)
        {
            X = ComponentX;
            Y = ComponentY;
            Z = ComponentZ;
        }

        public Vector3(Vector2 ComponentVector2, float ComponentZ)
        {
            X = ComponentVector2.X;
            Y = ComponentVector2.Y;
            Z = ComponentZ;
        }

            
    }
}
