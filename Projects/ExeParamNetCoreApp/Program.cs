using System;

namespace ExeParamNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Параметры командной строки:");
            for (int i=0;i<args.Length; i++)
            Console.WriteLine(args[i]);
            Console.ReadKey();
        }
        
    }
}


