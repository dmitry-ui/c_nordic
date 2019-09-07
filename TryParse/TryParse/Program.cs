using System;

namespace TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            //так не очень
            //Console.WriteLine("Введите число:");
            //string str = Console.ReadLine();
            //int val = int.Parse(str);
            //Console.WriteLine("Вы ввели число {0}", val);

            //так лучше
            int val1;
            Console.WriteLine("Введите число:");
            string str1;
            str1 = Console.ReadLine();
            bool ok;
            ok = int.TryParse(str1, out val1);
            if (!ok)
            {
                do
                {
                    Console.WriteLine("Вы ввели некорректное число, повторите попытку:");
                    str1 = Console.ReadLine();
                    ok = int.TryParse(str1, out val1);
                }
                while (!ok);
            } 
            
            Console.WriteLine("Вы ввели число {0}", val1);
            
            Console.ReadKey();
        }
    }
}
