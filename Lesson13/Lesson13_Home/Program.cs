using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson13_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter cl = new ConsoleLogWriter();
            FileLogWriter fl = new FileLogWriter(@"C:\SomeDir\my_log.log");
            FileLogWriter fl1 = new FileLogWriter(@"C:\SomeDir\my_log1.log");
            List<ILogWriter> ILR = new List<ILogWriter>(2);
            ILR.Add(cl);
            ILR.Add(fl);
            ILR.Add(fl1);
            MultipleLogWriter ML = new MultipleLogWriter(ILR);
            ML.LogInfo("Работает INFO!!!");
            ML.LogWarning("Работает Warning!!!");
            ML.LogError("Работает Error!!!");
            Console.ReadKey();
        }
    }
}
