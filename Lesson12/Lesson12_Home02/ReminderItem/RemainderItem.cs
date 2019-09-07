using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12_Home02_ReminderItem
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }  //время Х

        public string AlarmMessage { get; set; }    //сообщение, соответствующее будильнику

        public TimeSpan TimeToAlarm     // должно быть read-only, рассчитываться как AlarmDate минус текущее время
        {
            get
            {
                return AlarmDate - DateTimeOffset.Now;
            }
        }

        public bool IsOutdated   //(просрочено ли событие), должно быть read-only
        {
            get
            {
                return AlarmDate < DateTimeOffset.Now;
            }
        }

        public ReminderItem()
        { }

        public ReminderItem(DateTimeOffset time, string strMessage)
        {
            AlarmDate = time;
            AlarmMessage = strMessage;
        }

        public ReminderItem(ReminderItem RI)
        {
            AlarmDate = RI.AlarmDate;
            AlarmMessage = RI.AlarmMessage;
        }

        public virtual void WriteProperties()
        {
            Console.WriteLine($"Тип объекта: {GetType()}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}");
        }
    }
}
