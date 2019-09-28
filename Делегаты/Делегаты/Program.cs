using System;

namespace Делегаты
{
    //объявление делегата
    public delegate int AriphmeticCalc(int first, int second);

    class Program
    {
        static void Main(string[] args)
        {
            Ariphmetic ar = new Ariphmetic();

            //присваиваем делегату функцию
            AriphmeticCalc ariphmeticcalc = ar.Summa;
            
            //вызываем делегат, т.е. фенкцию на которую он ссылается
            Console.WriteLine(ariphmeticcalc(1, 1));

            //присваиваем делегату новую функцию
            ariphmeticcalc = ar.Diff;
            Console.WriteLine(ariphmeticcalc(10, 9));

            //можно загнать в делегат несколько функций
            AriphmeticCalc ariphmeticcalc2 = ar.Summa;
            ariphmeticcalc += ariphmeticcalc2;
            //в итоге выведется последняяфункция, т.е. сложение
            Console.WriteLine(ariphmeticcalc(10, 9));



            Console.ReadKey();
        }

       
    }

    class Ariphmetic
    {
        public int Summa(int a, int b)
        {
            return a + b;
        }

        public int Diff(int a, int b)
        {
            return a - b;
        }
    }
}
