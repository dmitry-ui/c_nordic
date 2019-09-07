using Lesson11_Home01;
using System;
using System.Collections.Generic;
using System.Text;
using Lesson12_Home01_ReminderItem;

namespace Lesson12_Home01_PhoneReminderItem
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; } //номер на который надо отправлять сообщение
        public PhoneReminderItem(string pn, DateTimeOffset time, string strMessage): base(time, strMessage)
        {
            PhoneNumber = pn;
        }
        public override void WriteProperties()
        {
            Console.WriteLine($"Тип объекта: {GetType()}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}" +
                $"\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}" +
                $"\nPhoneNumber: {PhoneNumber}");
        }

    }
}
 