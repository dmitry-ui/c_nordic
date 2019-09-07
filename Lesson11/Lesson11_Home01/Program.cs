using System;

namespace Lesson11_Home01
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem[] rm = new ReminderItem[2];
            for (int i = 0; i <= 1; i++)
            {
                rm[i] = new ReminderItem(DateTimeOffset.Parse("2019-09-06 18:00:00").AddDays(i * 7), i + 1 + " пятницa, вечер");
                rm[i].WriteOutItems();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
