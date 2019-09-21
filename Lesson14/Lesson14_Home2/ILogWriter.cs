using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home2
{
    interface ILogWriter
    {
        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message);
    }
}