using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson15_Home
{
    public abstract class LogWriter : ILogWriter
    {
        public enum MessageType { Info, Warning, Error };

        public string FormatMessage = "{0}+0000\t{1}\t{2}";

        public abstract void WriteMessage(string messsage);

        public void LogInfo(string message)
        {
            WriteMessage(string.Format(FormatMessage, DateTime.Now, MessageType.Info, message));
        }

        public void LogWarning(string message)
        {
            WriteMessage(string.Format(FormatMessage, DateTime.Now, MessageType.Warning, message));
        }

        public void LogError(string message)
        {
            WriteMessage(string.Format(FormatMessage, DateTime.Now, MessageType.Error, message));
        }
    }
}
