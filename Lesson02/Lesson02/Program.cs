using System;

namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            int b;
            b = 5;
            int a=10;
            Int32 c = 15;// тот же int
            System.Int32 d = 20;// тот же int
            string name = "Некоторая строка";
            char ch = 'r';
            var myvar = 15;
            var myvar1 = "строка";

            //форматы целых чисел
            byte maxBite = 255; //от 0 до 255
            sbyte maxSignedBite=SByte.MaxValue; // от -128 до 127
            sbyte minSignedBite = SByte.MinValue;

            byte ageHex = 0x24;
            Console.WriteLine(ageHex);


            //два байта
            short df = -21;

            //плав точка


            int sun=1_321_123;
            long univers = sun;

            //ошибка
            //sun=univers

            //надо так
            sun = (int)univers;
            //в строку можно превратить все:
            string valueOfSun = sun.ToString();
            Console.WriteLine("valueOfSun={0}", valueOfSun);
            Console.WriteLine(sun);

            //если надо записать в int  с клавиатуры:
            Console.WriteLine("Введите число:");
            string value = Console.ReadLine();
            int intVal = int.Parse(value); //  Parse  -  что мы парсим чтобы получить int

            Console.WriteLine(value + value);
            Console.WriteLine(intVal + intVal);
                                 
            Console.WriteLine("Hello World! {0}/{1}={2}", a, b, a/b);
            Console.WriteLine($"{a}*{b}={a * b}");
            Console.WriteLine(a * b*c*d);
            Console.WriteLine(name);
            Console.WriteLine(myvar1);
            var q = Console.ReadKey();

            Console.ReadKey();
        }
    }
}
