using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{

    public abstract class BaseErrorMessage : ILogWriter
    {
        public enum LogMessageType { Info, Warning, Error }

        public string GetMessage(LogMessageType LM, string str)
        {
            return $"{DateTime.Now}\t{LM}\t{str}";
        }

        public abstract void LogInfo(string message);

        public abstract void LogWarning(string message);

        public abstract void LogError(string message);
    }

}
