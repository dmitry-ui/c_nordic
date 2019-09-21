using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson14_Home2
{
    class FileLogWriter : LogWriter
    {
        //для синглтона
        private static FileLogWriter instance;

        public string FullFileName;

        //для синглтона изменен модификатор доступа на private
        private FileLogWriter(string FN)
        {
            FullFileName = FN;
        }

        //реализация единственного экземпляра класса
        public static FileLogWriter GetSingleFileLogWriter(string FN = "C:\\SomeDir\\my_log.txt")
        {
            if (instance == null)
                instance = new FileLogWriter(FN);
            return instance;
            

        }

        public override void WriteMessage(string messsage)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FullFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(messsage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
