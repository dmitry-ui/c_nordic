using System;
using Calculator.Figure;

namespace Calculator.Operation
{
    public static class CircleOperations
    {
        public static double Square(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public static double Perimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }
    }

    public static class RectangleOperations
    {
        public static double Square(double a, double b)
        {
            return a * b;
        }

        public static double Perimeter(double a, double b)
        {
            return 2 * (a + b);
        }
    }
}
