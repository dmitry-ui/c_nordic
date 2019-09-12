using System;
using System.IO;

namespace Lesson13_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter cl = new ConsoleLogWriter();
            cl.LogInfo("Все ОК");
            cl.LogWarning("Что-то не совсем так");
            cl.LogError("Error!!!");

            FileLogWriter fl = new FileLogWriter();
            fl.LogInfo("Все ОК");
            fl.LogWarning("Что-то не совсем так");
            fl.LogError("Error!!!");





            Console.ReadKey();
        }
    }
}
