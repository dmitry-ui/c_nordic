using System;
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
            /*
             Реализовать класс LogWriterFactory, который бы сам реализовывал паттерн синглтон создавал и
выдавал экземпляры классов с позапрошлого (не синглтоны!) домашнего задания:
● ConsoleLogWriter,
● FileLogWriter,
● MultipleLogWriter.
Класс должен иметь один метод
public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter
и возвращать любой из трёх возможных классов выше (сами классы не должны меняться).
В основном потоке программы:
● Создать по одному экземпляру класса FileLogWriter и ConsoleLogWriter.
● Затем создать экземпляр класса MultipleLogWriter, который бы принял в конструктор
созданные выше экземпляры FileLogWriter и ConsoleLogWriter.
● Сделать по одной записи логов каждого типа, чтобы убедиться, что они одновременно
пишутся и в консоль и в файл.
             */

        }
    }
}
