using Lesson12_Home02_ReminderItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12_Home02_ChatReminderItem
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; } // имя чата 

        public string AccountName { get; set; } //логин в чате  

        public ChatReminderItem(string cn, string an, DateTimeOffset time, string strMessage) : base(time, strMessage)
        {
            ChatName = cn;
            AccountName = an;
        }

        //демонстрация работы присваивания объекту базового класса объектов производных классов
        //здесь в конструктор базового класса передается объект производного класса
        //при этом все работает
        public ChatReminderItem(ChatReminderItem CRI) : base(CRI.AlarmDate, CRI.AlarmMessage)
        {
            ChatName = CRI.ChatName;
            AccountName = CRI.AccountName;
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"Тип объекта: {GetType()}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}" +
                $"\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}" +
                $"\nChatName: {ChatName} \nAccountName: {AccountName}");
        }
    }
}
