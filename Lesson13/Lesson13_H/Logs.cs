using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13_H
{
	class Logs
	{
		public enum TypeMessege {info, warning, error};

		public TypeMessege TM;

		public Logs(TypeMessege tm)
		{
			TM = tm;
		}

		public string LogMessage(string str)
		{
			return $"Пишем в лог {TM.ToString()} сообщение: {str}";
		}
	}

	class ConsoleLogs : Logs
	{
		public ConsoleLogs(TypeMessege tm) : base(tm)
		{
		}
		public void Write(string str)
		{
			Console.WriteLine(LogMessage(str));
		}


	}
}
