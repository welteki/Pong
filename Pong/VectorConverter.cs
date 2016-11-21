using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Convert
{
    static class VectorConverter
    {
        public static double VectorToAngle(Vector vector)
        {
            Vector z = new Vector(1, 0);
            double angle = Vector.AngleBetween(vector, z);
            return angle;
        }

        public static Vector AngleToVector(double angle)                                                    //Werkt niet
        {
            Vector z = new Vector(Math.Cos(Math.PI * angle / 180), -Math.Sin(Math.PI * angle / 180));
            return z;
        }
    }
}
