using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{

    public class ConsoleLogWriter : BaseLogWriter
	{
        //синлтон
        //т.е.можно создать только один экземпляр класса
        private static ConsoleLogWriter _singleConsoleLogWriter;

        private ConsoleLogWriter()
        {
        }

        public static ConsoleLogWriter GetConsoleLogWriter()
        {
            if (_singleConsoleLogWriter == null)
                _singleConsoleLogWriter = new ConsoleLogWriter();
            return _singleConsoleLogWriter;
        }

		public override void LogSingleRecord(LogMessageType logMessageType, string message)
		{
			Console.WriteLine(GetMessage(logMessageType, message));
		}
	}

}
