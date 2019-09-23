﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson15_Home
{
    class LogWriterFactory
    {
        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter, new()
        {
            //фабрика класса ConsoleLogWriter
            //return new ConsoleLogWriter();

            //фабрика класса FileLogWriter
            //return new FileLogWriter("C:\\SomeDir\\my_log256.txt");

            //фабрика класса MultipleLogWriter
            //надо содать список из ILogWriter и передать его в конструктор

            T TempObject = new T();
            if(TempObject is ConsoleLogWriter)
            { return TempObject; }
            else if (TempObject is FileLogWriter)
            { }


        }
    }
}
