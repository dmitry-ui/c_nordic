using System;

namespace Lesson06
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string str=string.Empty;
            //string str;
            //do
            //{
            //     str = Console.ReadLine();
            //}
            //while (str != "Exit");
            //Console.WriteLine("Вышли из цикла");


            //do
            //{
            // string  str = Console.ReadLine();
            //    if (str == "Exit")
            //        break;
            //}
            //while (true);
            //Console.WriteLine("Вышли из цикла");


            //do
            //{
            //    string str = Console.ReadLine();
            //    if (str.Length<=15)
            //    {
            //        Console.WriteLine("Длина строки {0}", str.Length);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Длина строки слишком большая");
            //        continue;
            //    }

            //    if (str == "Exit")
            //        break;

            //}
            //while (true);
            ////Console.WriteLine("Вышли из цикла");


            //спросить 5 чисел и вывести сумму . если ввел не число - не считается
            //int sum = 0;
            //int num = 0;
            //while (num<5)
            //{
            //    int i;

            //    try
            //    {
            //         i = int.Parse(Console.ReadLine());
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Вы ввели не число. Повторите попытку.");
            //        continue;
            //    }
            //    sum += i;
            //    num++;
            //}
            //Console.WriteLine("Сумма {0}", sum);

            //получить средние оценки за день и за неделю
            //int[][] marks = new[]
            //{
            //    new[] {2,3,3,2,3},
            //    new[] {2,4,5,3},
            //    null,
            //    //new[] {2,4,5,3},
            //    new[] {5,5,5,5},
            //    new[] {4}
            //};
            //double avrDay = 0;
            //double sumDay = 0;
            //double avrWeek = 0;
            //double sumWeek = 0;
            //int Count = 0;
            //for (int i=0; i< marks.Length; i++)
            //{
            //    if (marks[i] != null)
            //    {
            //        for (int j = 0; j < marks[i].Length; j++)
            //        {
            //            Count += 1;
            //            sumDay = sumDay + marks[i][j];
            //        }
            //        avrDay = sumDay / marks[i].Length;
            //        Console.WriteLine("За день {0}: средний бал {1}", i, avrDay);
            //        sumWeek = sumWeek + sumDay;
            //        sumDay = 0;
            //    }
            //}
            //avrWeek = sumWeek / Count;
            //Console.WriteLine("За неделю средний бал {0}", Math.Round(avrWeek,2));
            //Console.ReadKey();


            //переписать на foreach
            int[][] marks = new[]
            {
                new[] {2,3,3,2,3},
                new[] {2,4,5,3},
                null,
                //new[] {2,4,5,3},
                new[] {5,5,5,5},
                new[] {4}
            };
            double avrDay = 0;
            double sumDay = 0;
            double avrWeek = 0;
            double sumWeek = 0;
            int Count = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] != null)
                {
                    for (int j = 0; j < marks[i].Length; j++)
                    {
                        Count += 1;
                        sumDay = sumDay + marks[i][j];
                    }
                    avrDay = sumDay / marks[i].Length;
                    Console.WriteLine("За день {0}: средний бал {1}", i, avrDay);
                    sumWeek = sumWeek + sumDay;
                    sumDay = 0;
                }
            }
            avrWeek = sumWeek / Count;
            Console.WriteLine("За неделю средний бал {0}", Math.Round(avrWeek, 2));
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
