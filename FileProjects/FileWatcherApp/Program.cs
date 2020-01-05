using System;
using System.IO;
using System.Threading;

namespace FileWatcherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();

            logger.Info();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
            logger.Stop();

        }
    }
}
