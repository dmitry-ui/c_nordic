using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson16
{
    static class CalcCircle
    {
        public static double Perimetr(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public static double Square(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}
