using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson14_Home
{
    class Program
    {
        static void Main(string[] args)
        {
			//ConsoleLogWriter cl = ConsoleLogWriter.GetConsoleLogWriter();
			//ConsoleLogWriter cl1 = ConsoleLogWriter.GetConsoleLogWriter();
			////FileLogWriter fl = FileLogWriter.GetFileLogWriter(@"C:\SomeDir\my_log.log");
			///FileLogWriter fl1 = FileLogWriter.GetFileLogWriter(@"C:\SomeDir\my_log1.log");
			//List<ILogWriter> ILR = new List<ILogWriter>(4);
			//ILR.Add(cl);
			//ILR.Add(cl1);
			//ILR.Add(fl);
			//ILR.Add(fl1);
			//MultipleLogWriter ML = MultipleLogWriter.GetMultipleLogWriter(ILR);
			//ML.LogInfo("Работает INFO!!!");
			//ML.LogWarning("Работает Warning!!!");
			//ML.LogError("Работает Error!!!");
			//Console.ReadKey();

			ConsoleLogWriter cl = ConsoleLogWriter.GetConsoleLogWriter();
			cl.LogInfo("запись в лог");

			//FileLogWriter fl = new FileLogWriter(@"C:\SomeDir\my_log.log");
			//fl.LogInfo("запись в лог файла");

			FileLogWriter fl = new FileLogWriter(@"C:\SomeDir\my_log.log");
			fl.LogInfo("запись в лог файла");

			MultipleLogWriter mlw = new MultipleLogWriter(new List<ILogWriter> { cl, fl });
			mlw.LogInfo("Test");
			fl.Dispose();
				Console.ReadKey();
		}
    }
}
