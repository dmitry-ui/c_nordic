using Lesson12_Home01_ReminderItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12_Home01_ChatReminderItem
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

        public override void WriteProperties()
        {
            Console.WriteLine($"Тип объекта: {GetType()}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}" +
                $"\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}" +
                $"\nChatName: {ChatName} \nAccountName: {AccountName}");
        }
    }
}
