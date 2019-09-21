using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{

	public class MultipleLogWriter : BaseLogWriter
	{
		private List<ILogWriter> _logWriters;

		//private static MultipleLogWriter _instance;

		//public string writePath = @"C:\SomeDir\read.log";

		public MultipleLogWriter(List<ILogWriter> logWriters)
		{
			_logWriters = logWriters;
		}

		//public static MultipleLogWriter GetMultipleLogWriter(List<ILogWriter> data)
		//{
		//	if (_instance == null)
		//		_instance = new MultipleLogWriter(data);
		//	return _instance;
		//}

		public override void LogSingleRecord(LogMessageType logMessageType, string message)
		{
			foreach (var logWriter in _logWriters)
			{
				logWriter.LogSingleRecord(logMessageType, message);
			}
		}

		//		public override void LogError(string message)
		//{
		//	foreach (ILogWriter IL in Data)
		//	{
		//		IL.LogWarning(message);
		//	}
		//}

		//public override void LogWarning(string message)
		//{
		//	foreach (ILogWriter IL in Data)
		//	{
		//		IL.LogError(message);
		//	}
		//}


	}
}
