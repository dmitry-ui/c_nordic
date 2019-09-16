using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{
    public interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
		void LogSingleRecord(LogMessageType logMessageType, string message);
	}
}
