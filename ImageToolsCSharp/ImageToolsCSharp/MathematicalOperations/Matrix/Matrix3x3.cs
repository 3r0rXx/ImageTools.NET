using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageToolsCSharp.MathematicalOperations.Vector;
namespace ImageToolsCSharp.MathematicalOperations.Matrix
{
    public class Matrix3x3
    {
        public float M11, M12, M13, M21, M22, M23, M31, M32, M33, r11, r12, r21, r22, r31, r32;

        public Matrix3x3(Vector3 MatrixLine0, Vector3 MatrixLine1, Vector3 MatrixLine2)
        {
            
            M11 = MatrixLine0.X;
            M12 = MatrixLine0.Y;
            M13 = MatrixLine0.Z;

            M21 = MatrixLine1.X;
            M22 = MatrixLine1.Y;
            M23 = MatrixLine1.Z;

            M31 = MatrixLine2.X;
            M32 = MatrixLine2.Y;
            M33 = MatrixLine2.Z;

            //Determinant
            r11 = M11;
            r12 = M12;

            r21 = M21;
            r22 = M22;

            r31 = M31;
            r32 = M32;
        }


        public float GetDeterminant(Matrix3x3 Matrix3x3)
        {
            return Matrix3x3.M11 * Matrix3x3.M22 * Matrix3x3.M33 + Matrix3x3.M12 * Matrix3x3.M23 * Matrix3x3.r31 + Matrix3x3.M13 * Matrix3x3.r21 * Matrix3x3.M32 - Matrix3x3.M31 * Matrix3x3.M22 * Matrix3x3.M13 - Matrix3x3.M32 * Matrix3x3.M23 * Matrix3x3.r11 - Matrix3x3.M33 * Matrix3x3.r21 * Matrix3x3.r12;
        }


        public static Matrix3x3 operator +(Matrix3x3 m1, Matrix3x3 m2)
        {
            float m11, m12, m13, m21, m22, m23, m31, m32, m33 = 0;

            m11 = m1.M11 + m2.M11;
            m12 = m1.M12 + m2.M12;
            m13 = m1.M13 + m2.M13;

            m21 = m1.M21 + m2.M21;
            m22 = m1.M22 + m1.M22;
            m23 = m1.M23 + m1.M23;

            m31 = m1.M31 + m2.M31;
            m32 = m1.M32 + m2.M32;
            m33 = m1.M33 + m2.M33;

            return new Matrix3x3(new Vector3(m11, m12, m13), new Vector3(m21, m22, m23), new Vector3(m31, m32, m33));
        }


        public static Matrix3x3 operator -(Matrix3x3 m1, Matrix3x3 m2)
        {
            float m11, m12, m13, m21, m22, m23, m31, m32, m33 = 0;

            m11 = m1.M11 - m2.M11;
            m12 = m1.M12 - m2.M12;
            m13 = m1.M13 - m2.M13;

            m21 = m1.M21 - m2.M21;
            m22 = m1.M22 - m1.M22;
            m23 = m1.M23 - m1.M23;

            m31 = m1.M31 - m2.M31;
            m32 = m1.M32 - m2.M32;
            m33 = m1.M33 - m2.M33;

            return new Matrix3x3(new Vector3(m11, m12, m13), new Vector3(m21, m22, m23), new Vector3(m31, m32, m33));
        }


        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
        {
            float m11, m12, m13, m21, m22, m23, m31, m32, m33 = 0;

            m11 = m1.M11 * m2.M11 + m1.M12 * m2.M21 + m1.M13 * m2.M31;
            m12 = m1.M11 * m2.M12 + m1.M12 * m2.M22 + m1.M13 * m2.M32;
            m13 = m1.M11 * m2.M13 + m1.M12 * m2.M23 + m1.M13 * m2.M33;

            m21 = m1.M21 * m2.M11 + m1.M22 * m2.M21 + m1.M23 * m2.M31;
            m22 = m1.M21 * m2.M12 + m1.M22 * m2.M22 + m1.M23 * m2.M32;
            m23 = m1.M21 * m2.M13 + m1.M22 * m2.M23 + m1.M23 * m2.M33;

            m31 = m1.M31 * m2.M11 + m1.M32 * m2.M21 + m1.M33 * m2.M31;
            m32 = m1.M31 * m2.M12 + m1.M32 * m2.M22 + m1.M33 * m2.M32;
            m33 = m1.M31 * m2.M13 + m1.M32 * m2.M23 + m1.M33 * m2.M33;

            return new Matrix3x3(new Vector3(m11, m12, m13), new Vector3(m21, m22, m23), new Vector3(m31, m32, m33));
        }

    }
}
