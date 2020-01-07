using System;
using System.IO;
using System.Threading;

namespace FileWatcherMultiService
{

    class Logger
    {
        ConfigReader _configReader = new ConfigReader();

        FileSystemWatcher[] watcher;
        object obj = new object();
        bool enabled = true;
        public Logger()
        {
            watcher = new FileSystemWatcher[_configReader.Count()];

            for (int i = 0; i < _configReader.Count(); i++)
            {
                watcher[i] = new FileSystemWatcher(_configReader.GetControlPath(i));
                watcher[i].Deleted += Watcher_Deleted;
                watcher[i].Created += Watcher_Created;
                watcher[i].Changed += Watcher_Changed;
                watcher[i].Renamed += Watcher_Renamed;
            }

        }

        public void Start()
        {
            for (int i = 0; i < _configReader.Count(); i++)
            {
                watcher[i].EnableRaisingEvents = true;
            }

            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            for (int i = 0; i < _configReader.Count(); i++)
            {
                watcher[i].EnableRaisingEvents = false;
            }

            enabled = false;
        }
        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(_configReader.GetFullLogFileName(), true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }

        public void Info()
        {
            // Console.WriteLine("Ведется контроль изменений каталога " + _configReader.GetControlPath());
            for (int i = 0; i < _configReader.Count(); i++)
            {
                Console.WriteLine("Ведется контроль изменений каталога " + _configReader.GetControlPath(i));
            }

            Console.WriteLine("Запись изменений ведется в файл " + _configReader.GetFullLogFileName());
        }
    }
}
