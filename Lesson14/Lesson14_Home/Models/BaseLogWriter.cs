using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{
	public abstract class BaseLogWriter : ILogWriter
	{
		protected string _logFormat = "{0:yyyy-MM-dd hh:mm:ss}+0000\t{1}\t{2}";

		//public string GetLogFormat

		protected string GetMessage(LogMessageType logMessageType, string message)
		{
			return $"{DateTime.Now}\t{logMessageType}\t{message}";
		}

		public void LogInfo(string message)
		{
			LogSingleRecord(LogMessageType.Info, message);
		}

		public void LogWarning(string message)
		{
			LogSingleRecord(LogMessageType.Warning, message);
		}

		public void LogError(string message)
		{
			LogSingleRecord(LogMessageType.Error, message);
		}

		public abstract void LogSingleRecord(LogMessageType logMessageType, string message);
    }

}
