using System;
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
        //синлтон
        //т.е. можно создать только один экземпляр класса
        private static ConsoleLogWriter _singleConsoleLogWriter;

        private ConsoleLogWriter()
        {
        }

        public static ConsoleLogWriter SetConsoleLogWriter()
        {
            if (_singleConsoleLogWriter == null)
                _singleConsoleLogWriter = new ConsoleLogWriter();
            return _singleConsoleLogWriter;
        }
        //
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
        //реализован синглтон
        private static FileLogWriter _instance;

        public string FullFileName;

        private FileLogWriter(string path)
        {
            FullFileName = path;
        }

        public static FileLogWriter SetFileLogWriter(string path = @"C:\SomeDir\ath.txt")
        {
            if (_instance == null)
                _instance = new FileLogWriter(path);
            return _instance;
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

        private static MultipleLogWriter _instance;

        //public string writePath = @"C:\SomeDir\read.log";

        private MultipleLogWriter(List<ILogWriter> data)
        {
            Data = data;
        }

        public static MultipleLogWriter SetMultipleLogWriter(List<ILogWriter> data)
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


