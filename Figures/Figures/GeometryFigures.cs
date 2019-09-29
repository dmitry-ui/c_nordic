using System;

namespace Calculator.Figure
{
    public class Circle
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Calculate(Func<double, double> operation)
        {
            return operation(_radius);
        }
    }

    public class Rectangle
    {
        private double _sideA;

        private double _sideB;

        public Rectangle(double a, double b)
        {
            _sideA = a;
            _sideB = b;
        }

        public double Calculate(Func<double, double, double> operation)
        {
            return operation(_sideA, _sideB);
        }
    }

    public class Square : Rectangle
    {
        public Square(double a) : base (a, a)
        {
        }
    }


}
