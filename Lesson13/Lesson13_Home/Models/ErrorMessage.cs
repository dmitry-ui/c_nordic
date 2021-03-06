﻿using System;
using System.Collections;
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

    public abstract class ErrorMessage : ILogWriter, IEnumerable
    {
        public enum TypeLogMessage { Info, Warning, Error }

        public string GetMessage(TypeLogMessage LM, string str)
        {
            return $"{DateTime.Now}\t{LM}\t{str}";
        }

        public abstract void LogInfo(string message);

        public abstract void LogWarning(string message);

        public abstract void LogError(string message);

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ConsoleLogWriter : ErrorMessage
    {
        public override void LogInfo(string message)
        {
            Console.WriteLine(GetMessage(TypeLogMessage.Info, message));
        }

        public override void LogWarning(string message)
        {
            Console.WriteLine(GetMessage(TypeLogMessage.Warning, message));
        }

        public override void LogError(string message)
        {
            Console.WriteLine(GetMessage(TypeLogMessage.Error, message));
        }
    }

    public class FileLogWriter : ErrorMessage
    {
        public string FullFileName;

        public FileLogWriter(string path = @"C:\SomeDir\ath.txt")
        {
            FullFileName = path;
        }

        public override void LogInfo(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FullFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetMessage(TypeLogMessage.Info, message));
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
                using (StreamWriter sw = new StreamWriter(FullFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetMessage(TypeLogMessage.Warning, message));
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
                using (StreamWriter sw = new StreamWriter(FullFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(GetMessage(TypeLogMessage.Error, message));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class MultipleLogWriter : ErrorMessage
    {
        List<ILogWriter> Data;

        public string writePath = @"C:\SomeDir\read.log";

        public MultipleLogWriter(List<ILogWriter> data)
        {
            Data = data;
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


