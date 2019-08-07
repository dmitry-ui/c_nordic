using System;

namespace Lesson04
{
    class Program
    {
        //перечисления
        enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        enum Month : byte { Jan, Feb, Mar};

        static void Main(string[] args)
        {
            //int a = 1;
            //int h = 1;
            //double Sbok = 3 * a * h;
            //double Spoln = 3 * a * (a * Math.Sqrt(3) + 2 * h)/2;
            //double V = Math.Pow(a,2) * h * Math.Sqrt(3)/2;

            //Console.WriteLine("Sbok = {0}, Spoln ={1}, V={2}", Sbok, Spoln, V);

            //int a;
            //a = int.Parse("1");
            //Console.WriteLine(a);

            //int b=2;
            //bool ok = int.TryParse("23", out b);
            //Console.WriteLine(ok);
            //Console.WriteLine(b);

            //Day Today = Day.Sunday;
            //int dayNumber = (int)Today;
            //Console.WriteLine("{0}   {1}", Today, dayNumber);


            //padleft - дополняет нулями
            byte a = 3;
            byte b = 5;
            //Console.WriteLine(a.ToString("X")); //преобразуем в 16-формат
            //Console.WriteLine("0x" + a.ToString("X")); //дополняем префикс 0x
            //Console.WriteLine(Convert.ToString(a, 2)); //вывод в 2-формате
            //Console.WriteLine(Convert.ToString(a, 2).PadLeft(8, '0')); //вывод в 2-формате c нулями слева 

            Console.WriteLine(ToBinaryString(a|b));








            Console.ReadKey();
        }

        static string ToBinaryString(byte a)
        {
            return Convert.ToString(a, 2).PadLeft(8, '0');
        }
    }
}
