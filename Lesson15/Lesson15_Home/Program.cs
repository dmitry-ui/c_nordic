using System;
using System.Collections.Generic;

namespace Lesson15_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            //через мульти
            ConsoleLogWriter CL =  new ConsoleLogWriter();

            FileLogWriter FL = new FileLogWriter("c:\\SomeDir\\my_log256.txt");

            FileLogWriter FL1 = new FileLogWriter("c:\\SomeDir\\my_log1.txt");

            List<ILogWriter> IL = new List<ILogWriter>() { CL, FL,FL1 };

            MultipleLogWriter ML = new MultipleLogWriter(IL);

            ML.LogInfo("Собщение из Мульти");

            ML.LogWarning("Предупреждение из Мульти");

            ML.LogError("Ошибка из Мульти");

            //видим, что все логи пишутся в первый файл

            Console.ReadKey();
        }
    }
}



