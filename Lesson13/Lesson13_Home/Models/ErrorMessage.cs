using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson13_Home
{
    public class ErrorMessage
    {
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
    }

    public class ConsoleLogWriter : ErrorMessage
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(GetInfoMessage(message));
        }

        public void LogWarning(string message)
        {
            Console.WriteLine(GetWarningMessage(message));
        }

        public void LogError(string message)
        {
            Console.WriteLine(GetErrorMessage(message));
        }

    }

    public class FileLogWriter : ErrorMessage
    { 

        public string writePath = @"C:\SomeDir\ath.txt";
        //public string text = "1234566";
        public void LogInfo(string message)
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

        public void LogWarning(string message)
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

        public void LogError(string message)
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


