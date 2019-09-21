using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson14_Home2
{
    class FileLogWriter : LogWriter
    {
        public string FullFileName;

        public FileLogWriter(string FN = "C:\\SomeDir\\my_log.txt")
        {
            FullFileName = FN;
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
