using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson13_Home
{
    public interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }

    public abstract class ErrorMessage
    {
        //надо уменьшить количество функций
        public string GetInfoMessage(string str)
        {
            return $"{DateTime.Now}\tInfo\t{str}";
        }

        public string GetWarningMessage(string str)
        {
            return $"{DateTime.Now}\tWarning\t{str}";
        }

        public string GetErrorMessage(string str)
        {
            return $"{DateTime.Now}\tError\t{str}";
        }

        public abstract void LogInfo(string message);

        public abstract void LogWarning(string message);

        public abstract void LogError(string message);
    }

    public class ConsoleLogWriter : ErrorMessage, ILogWriter
    {
        public override void LogInfo(string message)
        {
            Console.WriteLine(GetInfoMessage(message));
        }

        public override void LogWarning(string message)
        {
            Console.WriteLine(GetWarningMessage(message));
        }

        public override void LogError(string message)
        {
            Console.WriteLine(GetErrorMessage(message));
        }
    }

    public class FileLogWriter : ErrorMessage
    { 
        public string writePath = @"C:\SomeDir\ath.txt";

        //надо констр с параметом
        
        public override void LogInfo(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetInfoMessage(message));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void LogWarning(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetWarningMessage(message));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void LogError(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetErrorMessage(message));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


