using System;

namespace Lesson_06_Home02
{
    class Program
    {
        static void Main(string[] args)
        {
             /*
               Написать консольное приложение, которое запрашивает 1) сумму
               первоначального взноса, 2) ежедневный процент дохода и 3) желаемую
               сумму накопления. Программа должна вывести номер дня, когда
               накопление впервые превысит желаемое.
             */
            double firstSum = InputDoubleValue("Введите первоначальную сумму:");
            double percent = InputDoubleValue("Введите ежедневный процент:");
            double totalSum = InputDoubleValue("Введите итоговую сумму:");
            double tempSum = firstSum;  //здесь храним накопленную сумму дней для накопления нужной суммы
            int totalDays = 0;          //количество дней для накопления
            do
            {

                tempSum = tempSum + (firstSum * percent / 100);
                totalDays += 1;
            }
            while (tempSum < totalSum);
            Console.WriteLine("Понадобится {0} дней.",totalDays);

            Console.WriteLine("\nНажмите любую клавишу для выхода:");
            Console.ReadKey();
        }
        static double InputDoubleValue(string comment)
        {
            Console.WriteLine(comment);
            double doubleValue;
            do
            {
                try
                {
                    doubleValue = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено нечисловое значение.\nПовторите попытку:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                break;
            }
            while (true);
            return doubleValue;
        }
    }
}
