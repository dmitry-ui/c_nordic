using System;
using System.Collections.Generic;

namespace Словарь
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> openWith = new Dictionary<int, string>();
            openWith.Add(1, "Строка1");
            openWith.Add(2, "Строка2");

            if (openWith.ContainsKey(2))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            

            Console.ReadKey();
        }
    }
}
