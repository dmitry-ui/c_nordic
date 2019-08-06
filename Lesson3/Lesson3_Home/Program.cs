using System;

namespace Lesson3_Home
{
    class Program
    {
        static void Main(string[] args)
        {

            //вывести таблицу Пифагора на экран
            Console.WriteLine("Выведем таблицу Пифагора:");
            int[] First = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] Second = { 1, 2, 3, 4, 5, 6};

            for (int i = 0; i < Second.Length; i++)
            {
                for (int j = 0; j < First.Length; j++)
                    Console.Write("{0}   \t ", First[j] * Second[i]);
                Console.WriteLine();
            }


            //прочитать из консоли 5 элементов типа int
            //вывести квадраты этих чисел
            Console.WriteLine("Еще ДЗ.");
            int[] res = new int[5];
            Console.WriteLine("Введите пять целых чисел:");
            for(int i=0; i<5; i++)
            {
                Console.WriteLine("Введите {0} число:", i+1);
                res[i] = Convert.ToInt32(Console.ReadLine());
            }
            //вывод квадратов введеных чисел
            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}*{0}={1}   \t", res[i], res[i] * res[i]);
            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
