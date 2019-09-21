using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home2
{
    class ConsoleLogWriter : LogWriter
    {
        /////////синглтон///////////////////////////////
        private static ConsoleLogWriter instance;

        private ConsoleLogWriter()
        {
        }

        public static ConsoleLogWriter GetSingleConsoleLogWriter()
        {
            if (instance == null)
                instance = new ConsoleLogWriter();
            return instance;
        }
        //////////////////////////////////////////////////

        public override void WriteMessage(string messsage)
        {
            Console.WriteLine(messsage);
        }
    }
}
