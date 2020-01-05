using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
//using LogReplacer;

namespace LogReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchiveOperations archiveOperations = new ArchiveOperations();
            
            //выводим на консоль перемещенный файл
            archiveOperations.EventMove += (x => Console.WriteLine(x));
            
            //пишем в лог перемещенный файл (добавил в самом классе)
            //archiveOperations.EventMove += archiveOperations.WriteFile;

            //поехали
            archiveOperations.Run();

            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
