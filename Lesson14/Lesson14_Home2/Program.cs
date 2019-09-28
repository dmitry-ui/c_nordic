using System;
using System.Collections.Generic;

namespace Lesson14_Home2
{
    class Program
    {
        static void Main(string[] args)
        {
            //через мульти
            ConsoleLogWriter CL = ConsoleLogWriter.GetSingleConsoleLogWriter();

            FileLogWriter FL = FileLogWriter.GetSingleFileLogWriter("c:\\SomeDir\\my_log.txt");

            FileLogWriter FL1 = FileLogWriter.GetSingleFileLogWriter("c:\\SomeDir\\my_log1.txt");

            List<ILogWriter> IL = new List<ILogWriter>() { CL, FL,FL1 };

            MultipleLogWriter ML = MultipleLogWriter.GetSingleMultipleLogWriter(IL);

            ML.LogInfo("Собщение из Мульти");

            ML.LogWarning("Предупреждение из Мульти");

            ML.LogWarning("Ошибка из Мульти");

            //видим, что все логи пишутся в первый файл, синглтон работает

            Console.ReadKey();
        }
    }
}



