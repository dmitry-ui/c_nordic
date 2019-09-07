using Lesson12_Home02_ReminderItem;
using Lesson12_Home02_PhoneReminderItem;
using System;
using Lesson12_Home02_ChatReminderItem;

namespace Lesson12_Home02
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem[] rm = new ReminderItem[3];
            rm[0] = new ReminderItem(DateTimeOffset.Parse("2019-09-01"), "Первый месяц осени");
            rm[1] = new PhoneReminderItem("123456", DateTimeOffset.Parse("2019-10-01"), "Второй месяц осени");
            rm[2] = new ChatReminderItem("Чат об осени", "dabramov", DateTimeOffset.Parse("2019-11-01"), "Третий месяц осени");

            //foreach (ReminderItem ri in rm)
            //{
            //    ri.WriteProperties();
            //    Console.WriteLine();
            //}

            //демонстрация работы присваивания объекту базового класса 
            //объектов производных классов
            ChatReminderItem CRI1 = new ChatReminderItem("Чат о зиме", "dabramov", DateTimeOffset.Parse("2019-12-01"), "Первый месяц зимы");
            //создаем копию, реально копию, а не другую ссылку на тот же объект
            ChatReminderItem CRI2 = new ChatReminderItem(CRI1);

            //вывод перед внесением изменением
            CRI1.WriteProperties();
            Console.WriteLine();
            CRI2.WriteProperties();
            Console.WriteLine();

            //вносим изменения
            CRI2.AlarmDate = DateTimeOffset.Parse("2019-12-02");
            CRI2.AlarmMessage = "Второй месяц зимы";

            //вывод после внесения изменением
            CRI1.WriteProperties();
            Console.WriteLine();
            CRI2.WriteProperties();
            //в выводе видим, что изменились поля объекта CRI2, и неизменились поля объекта CRI1

            Console.ReadKey();
        }
    }
}
