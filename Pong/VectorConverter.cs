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
            Vector z = new Vector(1, 0);                        //Werkt niet
            double angle = Vector.AngleBetween(vector, z);
            if (angle < 0)
                return angle + 360;
            return angle;
        }

        public static Vector AngleToVector(double angle)
        {
            Vector z = new Vector(Math.Cos(Math.PI * angle / 180), -Math.Sin(Math.PI * angle / 180));
            return z;
        }
    }
}
