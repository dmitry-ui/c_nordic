using System;

namespace Lesson11_Home01
{
	class Program
	{
		static void Main(string[] args)
		{
			ReminderItem rm = new ReminderItem("2019-09-25", "Просто дата");
			Console.ReadKey();
		}
	}

	class ReminderItem
	{
		public DateTimeOffset AlarmDate { get; set; }  //время Х
		public string AlarmMessage { get; set;}    //сообщение, соответствующее будильнику
		public TimeSpan TimeToAlarm     // должно быть read-only, рассчитываться как текущее время минус AlarmDate
		{
			get
			{
				return AlarmDate - DateTimeOffset.Now; 	   //написать
			}
		}
		public bool IsOutdated   //(просрочено ли событие), должно быть read-only, рассчитываться как true, если TimeToAlarm больше либо равно 0  false, если TimeToAlarm меньше 0
		{
			get
			{
				//написать
				if ((int)(TimeToAlarm) >= 0)
					return false;
				else
					return true;
			}
		}
		public ReminderItem(string v)
		{ }
		public ReminderItem(DateTimeOffset time, string strMessage )
		{
			AlarmDate = time;
			AlarmMessage = strMessage;
		}
		public void WriteOutItems()
		{
			Console.WriteLine($"AlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}\nTimeToAlarm: {TimeToAlarm}  ");
		}
		




	}
}
