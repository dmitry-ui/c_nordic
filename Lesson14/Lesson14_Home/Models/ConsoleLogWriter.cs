using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{

    public class ConsoleLogWriter : BaseErrorMessage
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

        public override void LogInfo(string message)
        {
            Console.WriteLine(GetMessage(LogMessageType.Info, message));
        }

        public override void LogWarning(string message)
        {
            Console.WriteLine(GetMessage(LogMessageType.Warning, message));
        }

        public override void LogError(string message)
        {
            Console.WriteLine(GetMessage(LogMessageType.Error, message));
        }
    }

}
