using System;

namespace Lesson14_2
{
    class Program
    {
        delegate int PerfCalculation(int a, int b);

        static void Main(string[] args)
        {
            //int a = 5;
            //int b = 3;
            //Console.WriteLine("{0}   {1}", a, b);
            //Swapper<int>.Swap(ref a, ref b);
            //Console.WriteLine("{0}   {1}", a, b);

            //string str1 = "str1";
            //string str2 = "str2";
            //Console.WriteLine("{0}   {1}", str1, str2);
            //Swapper<string>.Swap(ref str1, ref str2);
            //Console.WriteLine("{0}   {1}", str1, str2);

            //использование универсальных классов
            //Account<int> account = new Account<int>(5, "Denis");
            //account.WriteProperties();

            //Account<double> account1 = new Account<double>(5, "Denis");
            //account.WriteProperties();

            //Account<string> account2 = new Account<string>("One", "Denis");
            //account1.WriteProperties();

            Сalc calc = new Сalc();

            Console.WriteLine(calc.Sum(2, 3));
            Console.WriteLine(calc.Multi(2, 3));

            PerfCalculation perfCalculation;
            perfCalculation = calc.Sum;
            //сейчас делегат выполнит суммирование 
            Console.WriteLine(perfCalculation(2, 5));
            perfCalculation = calc.Multi;
            //а сейчас тот же делегат выполнит умножение
            Console.WriteLine(perfCalculation(2, 5));

            //несколько методов в один делегат
            PerfCalculation perfCalculation1;
            PerfCalculation perfCalculation2;

            perfCalculation1 = calc.Sum;
            perfCalculation2 = calc.Multi;
            //добавим один делегат в другой
            perfCalculation1 += perfCalculation2;
            //выполним полученный делегат состоящий из ссылок на два метода
            Console.WriteLine(perfCalculation1(2, 5));  //выполняются оба метода из делегата, но в выводе только последний

            //или так
            PerfCalculation perfCalculation3;
            PerfCalculation perfCalculation4;
            perfCalculation3 = calc.Sum;
            perfCalculation4 = calc.Multi;
            //добавим в тройку четверку
            perfCalculation3 = (PerfCalculation)Delegate.Combine(perfCalculation3, perfCalculation4);
            //int res = perfCalculation3(2, 5);
            //Console.WriteLine($"{nameof(res)}  {res}");

            //удаление из делегата ссылки на один из методов (из тройки вычесть четверку)
            perfCalculation3 = (PerfCalculation)Delegate.Remove(perfCalculation3, perfCalculation4);
            int res = perfCalculation3(2, 5);
            Console.WriteLine($"{nameof(res)}  {res}");

            //периметр круга
            double PerimeterCircle(double radius)
            {
                return 2 * Math.PI * radius;
            }

            //площадь круга
            double SquareCircle(double radius)
            {
                return Math.PI * radius * radius;
            }

            Circle circle = new Circle(1.5);
            Console.WriteLine(circle.Calculate(PerimeterCircle));
            Console.WriteLine(circle.Calculate(SquareCircle));

            Console.ReadKey();
        }
    }
}
