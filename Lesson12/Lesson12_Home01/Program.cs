using Lesson12_Home01_ReminderItem;
using Lesson12_Home01_PhoneReminderItem;
using System;
using Lesson12_Home01_ChatReminderItem;

namespace Lesson11_Home01
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem[] rm = new ReminderItem[3];
            rm[0] = new ReminderItem(DateTimeOffset.Parse("2019-09-01"), "Первый месяц осени");
            rm[1] = new PhoneReminderItem("123456", DateTimeOffset.Parse("2019-10-01"), "Второй месяц осени");
            rm[2] = new ChatReminderItem("Чат об осени", "dabramov", DateTimeOffset.Parse("2019-11-01"), "Третий месяц осени");

            foreach (ReminderItem ri in rm)
            {
                ri.WriteProperties();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
