﻿using System;
using System.Threading;
using System.Text;

namespace Lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            //для решения проблем с кодировкой
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            ///////////////////////////////////////////
            string str;
            Console.WriteLine("Введите  свое имя:");
            str = Console.ReadLine();
            Thread.Sleep(4000);
            Console.WriteLine("Ваше имя: {0}", str);
            //Console.WriteLine($"Ваше имя: {str}");

            Console.WriteLine("До свидания: {0}", str);
            Thread.Sleep(4000);
            Console.ReadKey();
        }
    }
}