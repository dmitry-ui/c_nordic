using Lesson12_Home02;
using System;
using System.Collections.Generic;
using System.Text;
using Lesson12_Home02_ReminderItem;

namespace Lesson12_Home02_PhoneReminderItem
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; } //номер на который надо отправлять сообщение

        public PhoneReminderItem(string pn, DateTimeOffset time, string strMessage): base(time, strMessage)
        {
            PhoneNumber = pn;
        }

        //демонстрация работы присваивания объекту базового класса объектов производных классов
        public PhoneReminderItem(PhoneReminderItem FRI) : base(FRI.AlarmDate, FRI.AlarmMessage)
        {
            PhoneNumber = FRI.PhoneNumber;
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"Тип объекта: {GetType()}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}" +
                $"\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}" +
                $"\nPhoneNumber: {PhoneNumber}");
        }
    }
}
 