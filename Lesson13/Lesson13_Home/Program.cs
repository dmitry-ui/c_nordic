using System;

namespace Lesson13_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter.LogInfo("Все ОК");
            ConsoleLogWriter.LogWarning("Что-то не совсем так");
            ConsoleLogWriter.LogError("Error!!!");

            Console.ReadKey();
        }
    }
}
