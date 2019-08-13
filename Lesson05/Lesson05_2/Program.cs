using System;

namespace Lesson05_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = RequestIntegerFromConsole("Введите сторону прямоугольника a");
                int b = RequestIntegerFromConsole("Введите сторону прямоугольника b");
                Console.WriteLine("Площадь прямоугольника равна {0}", a * b);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла ошибка работы программы!\n {e.Message}");
                throw;                                                                  //вызовем текст исключения
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа корректна завершена");


            Console.ReadKey();
        }

        static int RequestIntegerFromConsole (string requestMessage)
        {
            Console.WriteLine(requestMessage);
            return int.Parse(Console.ReadLine());

        }
    }
}
