using System;
using Calculator.Figure;
using Calculator.Operation;

namespace CalculatorFigureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle cr = new Circle(1.5);
            double res = cr.Calculate(CircleOperations.Perimeter);
            Console.WriteLine(res);
            res = cr.Calculate(CircleOperations.Square);
            Console.WriteLine(res);

            Rectangle rectangle = new Rectangle(3.0, 2.0);
            res = rectangle.Calculate(RectangleOperations.Square);
            Console.WriteLine(res);
            res = rectangle.Calculate(RectangleOperations.Perimeter);
            Console.WriteLine(res);

            Square square = new Square(3.0);
            res = square.Calculate(RectangleOperations.Square);
            Console.WriteLine(res);
            res = square.Calculate(RectangleOperations.Perimeter);
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
