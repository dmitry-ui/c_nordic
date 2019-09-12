using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13_Home
{
    public static class ErrorMessage
    { 
        public static string GetInfoMessage(string str)
        {
            return $"{DateTime.Now} <tab>Info<tab>{str}";
        }

        public static string GetWarningMessage(string str)
        {
            return $"{DateTime.Now} <tab>Warning<tab>{str}";
        }

        public static string GetErrorMessage(string str)
        {
            return $"{DateTime.Now} <tab>Error<tab>{str}";
        }
    }

    public static class ConsoleLogWriter
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine(ErrorMessage.GetInfoMessage(message));
        }

        public static void LogWarning(string message)
        {
            Console.WriteLine(ErrorMessage.GetWarningMessage(message));
        }

        public static void LogError(string message)
        {
            Console.WriteLine(ErrorMessage.GetErrorMessage(message));
        }

    }
}
