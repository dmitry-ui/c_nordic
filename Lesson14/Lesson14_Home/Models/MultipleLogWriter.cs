using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home
{

    public class MultipleLogWriter : BaseErrorMessage
    {
        List<ILogWriter> Data;

        private static MultipleLogWriter _instance;

        //public string writePath = @"C:\SomeDir\read.log";

        private MultipleLogWriter(List<ILogWriter> data)
        {
            Data = data;
        }

        public static MultipleLogWriter GetMultipleLogWriter(List<ILogWriter> data)
        {
            if (_instance == null)
                _instance = new MultipleLogWriter(data);
            return _instance;
        }

        public override void LogInfo(string message)
        {
            foreach (ILogWriter IL in Data)
            {
                IL.LogInfo(message);
            }
        }

        public override void LogError(string message)
        {
            foreach (ILogWriter IL in Data)
            {
                IL.LogWarning(message);
            }
        }

        public override void LogWarning(string message)
        {
            foreach (ILogWriter IL in Data)
            {
                IL.LogError(message);
            }
        }
    }
}
