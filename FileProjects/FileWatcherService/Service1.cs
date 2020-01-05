using System;
using System.ServiceProcess;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace FileWatcherService
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }

    class Logger
    {
        public ConfigReader _configReader = new ConfigReader();

        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public Logger()
        {
            watcher = new FileSystemWatcher(_configReader.GetControlPath());
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
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
            Console.WriteLine("Ведется контроль изменений каталога " + _configReader.GetControlPath());
            Console.WriteLine("Запись изменений ведется в файл " + _configReader.GetFullLogFileName());
        }
    }

    class ConfigFromFile
    {
        //файл лога куда пишем созданные, измененные, удаленные файлы
        public string FullLogFileName;

        //каталог в котором отслеживаем изменения файлов
        public string ControlPath;
    }

    class ConfigReader
    {
        ConfigFromFile _configFromFile = new ConfigFromFile();

        public ConfigReader()
        {
            //каталог запуска сборки, в ней же конфиг
            string ConfigFile = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\FWConfig.json";
            //загружаем данные из файла конфигурации в объект
            _configFromFile = JsonConvert.DeserializeObject<ConfigFromFile>(File.ReadAllText(ConfigFile));
        }

        public string GetFullLogFileName()
        {
            return _configFromFile.FullLogFileName;
        }

        public string GetControlPath()
        {
            return _configFromFile.ControlPath;
        }
    }

}