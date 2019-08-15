using System;

namespace Lesson05_Home
{ 
    enum TypeFigure
    {
        Round=1,
        Triangle=2,
        Rectangle=3
    }
    class Program
    {
        public const double pi = 3.14;
        static double InputDoubleValue(string comment)
        {
            Console.WriteLine(comment);
            double doubleValue;
            do
            {
                try
                {
                    doubleValue = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено нечисловое значение.\nПовторите попытку:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                break;
            }
            while (true);
            return doubleValue;
        }

        static int InputIntValue(string comment, int maxValue, int minValue)
        {
            Console.WriteLine(comment);
            //string str = Console.ReadLine();
            int intValue;
            do
            {
                string str = Console.ReadLine();
                try
                {
                    intValue = int.Parse(str);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено нечисловое значение.\nПовторите попытку");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                if (intValue > maxValue || intValue < minValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Необходимо ввести целое число от 1 до 3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                break;
                
            }
            while (true);
            return intValue;
        }
        static void SquareAndPerimetrOfRound()
        {
            double Radius = InputDoubleValue("Введите радиус круга:");
            Console.WriteLine("Площадь круга {0}", pi * Radius * Radius);
            Console.WriteLine("Длина окружности {0}", 2 * pi * Radius);
        }
        static void SquareAndPerimetrOfTriangle()
        {
            double lengthTriangle = InputDoubleValue("Введите длину стороны треугольника:");
            Console.WriteLine("Площадь треугольника {0}", Math.Sqrt(3) * lengthTriangle * lengthTriangle / 4);
            Console.WriteLine("Периметр треугольника {0}", 3 * lengthTriangle);
        }
        static void SquareAndPerimetrOfRectangle()
        {
            double lengthREctangleA = InputDoubleValue("Введите длину первой стороны прямоугольника:");
            double lengthREctangleB = InputDoubleValue("Введите длину второй стороны прямоугольника:");
            Console.WriteLine("Площадь прямоугольника {0}", lengthREctangleA * lengthREctangleB);
            Console.WriteLine("Периметр прямоугольника {0}", 2 * (lengthREctangleA + lengthREctangleB));
        }
        static void Main(string[] args)
        {
            TypeFigure TF;
            int intType;

            intType = InputIntValue("Введите тип фигуры (1 - круг, 2 - равносторонний треугольник, 3- прямоугольник):", 3, 1);
            TF = (TypeFigure)intType;

                switch (TF)
                {
                    case TypeFigure.Round:
                        SquareAndPerimetrOfRound();
                        break;

                    case TypeFigure.Triangle:
                        SquareAndPerimetrOfTriangle();
                        break;

                    case TypeFigure.Rectangle:
                         SquareAndPerimetrOfRectangle();
                         break;
                }

            Console.WriteLine("Нажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}
