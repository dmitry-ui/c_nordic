using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home2
{
    class ConsoleLogWriter : LogWriter
    {
        public override void WriteMessage(string messsage)
        {
            Console.WriteLine(messsage);
        }
    }
}
