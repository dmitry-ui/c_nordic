using System;
using System.Collections.Generic;

namespace Lesson14_Home2
{
    class Program
    {
        static void Main(string[] args)
        {
            //через мульти
            ConsoleLogWriter CL = new ConsoleLogWriter();

            FileLogWriter FL = new FileLogWriter();

            List<ILogWriter> IL = new List<ILogWriter>() { CL, FL };

            MultipleLogWriter ML = new MultipleLogWriter(IL);

            ML.LogInfo("Собщение из Мульти");

            ML.LogWarning("Предупреждение из Мульти");

            ML.LogWarning("Ошибка из Мульти");

            Console.ReadKey();
        }
    }
}



