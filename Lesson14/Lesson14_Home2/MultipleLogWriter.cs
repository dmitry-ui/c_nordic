using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson14_Home2
{
    class MultipleLogWriter : LogWriter
    {
        private static MultipleLogWriter instance;

        List<ILogWriter> _lw = new List<ILogWriter>();

        public static MultipleLogWriter GetSingleMultipleLogWriter(List<ILogWriter> lw)
        {
            if (instance == null)
                instance = new MultipleLogWriter(lw);
            return instance;
        }

        private MultipleLogWriter(List<ILogWriter> lw)
        {
            _lw = lw;
        }

        public override void WriteMessage(string messsage)
        {
            foreach (ILogWriter iw in _lw)
            {
                if (iw is ConsoleLogWriter)
                    ((ConsoleLogWriter)iw).WriteMessage(messsage);
                else if (iw is FileLogWriter)
                    ((FileLogWriter)iw).WriteMessage(messsage);
            }
        }
    }
}
