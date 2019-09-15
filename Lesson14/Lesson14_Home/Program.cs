using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson13_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter cl = ConsoleLogWriter.SetConsoleLogWriter();
            ConsoleLogWriter cl1 = ConsoleLogWriter.SetConsoleLogWriter();
            FileLogWriter fl = FileLogWriter.SetFileLogWriter(@"C:\SomeDir\my_log.log");
            FileLogWriter fl1 = FileLogWriter.SetFileLogWriter(@"C:\SomeDir\my_log1.log");
            List<ILogWriter> ILR = new List<ILogWriter>(4);
            ILR.Add(cl);
            ILR.Add(cl1);
            ILR.Add(fl);
            ILR.Add(fl1);
            MultipleLogWriter ML = MultipleLogWriter.SetMultipleLogWriter(ILR);
            ML.LogInfo("Работает INFO!!!");
            ML.LogWarning("Работает Warning!!!");
            ML.LogError("Работает Error!!!");
            Console.ReadKey();
        }
    }
}
