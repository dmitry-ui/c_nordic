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
        static double InputDoubleValue(string comment)
        {
            double db=0;
            Console.WriteLine(comment);
            try
            {
                db = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено нечисловое значение:\n{0}", e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            

            return db;
        }
        
        static void Main(string[] args)
        {
            TypeFigure TF;
            double Radius = 0;
            double lengthTriangle = 0;
            double lengthREctangleA = 0;
            double lengthREctangleB = 0;
            double pi = 3.14;
            int intType=0;

            Console.WriteLine("Введите тип фигуры (1 - круг, 2 - равносторонний треугольник, 3- прямоугольник):");
            string str = Console.ReadLine();

            try
            {
                intType = int.Parse(str);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено нечисловое значение:\n{0}", e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
            if(intType>3 || intType<1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Необходимо ввести целое число от 1 до 3");
                Console.ForegroundColor = ConsoleColor.White;
                throw new Exception("Ошибка! Необходимо ввести целое число от 1 до 3");
            }


            TF = (TypeFigure)intType;

            try
            {
                switch (TF)
                {
                    case TypeFigure.Round:
                        Radius = InputDoubleValue("Введите радиус круга:");
                        Console.WriteLine("Площадь круга {0}", pi * Radius * Radius);
                        Console.WriteLine("Длина окружности {0}", 2 * pi * Radius);
                        break;

                    case TypeFigure.Triangle:
                        lengthTriangle = InputDoubleValue("Введите длину стороны треугольника:");
                        Console.WriteLine("Площадь треугольника {0}", Math.Sqrt(3) * lengthTriangle * lengthTriangle / 4);
                        Console.WriteLine("Периметр треугольника {0}", 3 * lengthTriangle);
                        break;

                    case TypeFigure.Rectangle:
                        lengthREctangleA = InputDoubleValue("Введите длину первой стороны прямоугольника:");
                        lengthREctangleB = InputDoubleValue("Введите длину второй стороны прямоугольника:");
                        Console.WriteLine("Площадь прямоугольника {0}", lengthREctangleA * lengthREctangleB);
                        Console.WriteLine("Периметр прямоугольника {0}", 2 * (lengthREctangleA + lengthREctangleB));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! {0}", e.Message);

            }
                 

        
            Console.WriteLine("Нажмите любую клавишу для выхода из программы...");
            Console.ReadKey();
        }
    }
}
