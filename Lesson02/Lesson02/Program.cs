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
            string name = "Некоторая строка";
            char ch = 'r';
            var myvar = 15;
            var myvar1 = "строка";
            

            Console.WriteLine("Hello World! {0}/{1}={2}", a, b, a/b);
            Console.WriteLine($"{a}*{b}={a * b}");
            Console.WriteLine(a * b);
            Console.WriteLine(name);
            var q = Console.ReadKey();

            Console.ReadKey();
        }
    }
}
