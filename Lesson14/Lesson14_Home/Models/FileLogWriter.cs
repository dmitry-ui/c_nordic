using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson14_Home
{

    public class FileLogWriter : BaseErrorMessage, IEnumerable
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
                    sw.WriteLine(GetMessage(LogMessageType.Info, message));
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
                    sw.WriteLine(GetMessage(LogMessageType.Warning, message));
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
                    sw.WriteLine(GetMessage(LogMessageType.Error, message));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
