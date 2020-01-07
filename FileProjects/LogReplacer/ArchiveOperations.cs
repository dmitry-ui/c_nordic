using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LogReplacer
{
    public class ArchiveOperations
    {
        public ConfigReader configReader;

        public delegate void MoveHandler(string message);

        public event MoveHandler EventMove;

        public Timer[] timer;

        public ArchiveOperations()
        {
            //каталог запуска сборки, в ней же конфиг
            string ConfigFile = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Config.json";
            //загружаем данные из файла конфигурации в объект
            configReader = JsonConvert.DeserializeObject<ConfigReader>(File.ReadAllText(ConfigFile));

            timer = new Timer[configReader.Attributes.Length];

            EventMove += WriteFile;
        }

        public void MoveFilesToArh(object arhiv)
        {
            foreach (var fileToMove in GetFilesToMoveToArh((Arhiv)arhiv))
            {
                //перемещаем файл
                File.Move(((Arhiv)arhiv).FromDirectory + fileToMove,
                          ((Arhiv)arhiv).ToDirectory + fileToMove);

                //отправляем информацию о перемещенном файле подписчикам
                EventMove?.Invoke($"{DateTime.Now} " +
                                  $"Файл {((Arhiv)arhiv).FromDirectory}{fileToMove} " +
                                  $"перемещен в папку {((Arhiv)arhiv).ToDirectory}{fileToMove}");
            }
        }

        public List<string> GetFilesToMoveToArh(Arhiv arhiv)
        {
            //из списка файлов в каталоге из переменной arhiv
            //получаем список файлов подлежащих перемещению
            List<string> AllFilesInDir = GetAllFilesInDir(arhiv);
            List<string> FilesInDirToMove = new List<string>();

            foreach (string FileName in AllFilesInDir)
            {
                if (File.GetLastWriteTime(arhiv.FromDirectory + FileName) < DateTime.Now.AddDays(-arhiv.QuantityDaysToMove))
                {
                    FilesInDirToMove.Add(FileName);
                }
            }
            return FilesInDirToMove;
        }

        public List<string> GetAllFilesInDir(Arhiv arhiv)
        {
            List<string> FileNamesInPath = new List<string>();

            List<string> FileNamesInDir = new List<string>();

            FileNamesInPath.AddRange(Directory.GetFiles(arhiv.FromDirectory));

            //лист с именами без путей
            foreach (var FileNameInPath in FileNamesInPath)
            {
                FileNamesInDir.Add(Path.GetFileName(FileNameInPath));
            }

            return FileNamesInDir;
        }

        public void Run()
        {
            for (int i = 0; i < configReader.Attributes.Length; i++)
            {
                TimerCallback tm = new TimerCallback(MoveFilesToArh);
                timer[i] = new Timer(tm,
                                        configReader.Attributes[i],
                                        GetTimeSpanToStart(Convert.ToDateTime(configReader.Attributes[i].TimeStart)),
                                        TimeSpan.FromHours(configReader.Attributes[i].TimeIntervalHours));
            }
        }

        public void Stop()
        {
            for (int i = 0; i < configReader.Attributes.Length; i++)
            {
                //остановим работу всех таймеров
                timer[i].Change(System.Threading.Timeout.Infinite, 0);
            }
        }

        public void WriteFile(string message)
        {
            string FullFileName = configReader.LogDirectory + @"\LogMovier_" + (DateTime.Now.ToString("yyyy-MM-dd")) + ".log";

            // запись в файл
            if (!File.Exists(FullFileName))
            {
                try
                {
                    //запись в новый файл, если файл уже есть, то пересоздание файла
                    using (StreamWriter sw = new StreamWriter(FullFileName, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLineAsync(message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                //дозапись в существующий файл
                using (StreamWriter sw = new StreamWriter(FullFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLineAsync(message);
                }
            }
        }

        private TimeSpan GetTimeSpanToStart(DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
                //если дата в будущем 
                return dateTime.Subtract(DateTime.Now);
            else
            {
                //если дата в прошлом, то преобразуем ее в завтра
                DateTime date = new DateTime(DateTime.Now.AddDays(1).Year,
                              DateTime.Now.AddDays(1).Month,
                              DateTime.Now.AddDays(1).Day,
                              dateTime.Hour,
                              dateTime.Minute,
                              dateTime.Second);

                return date.Subtract(DateTime.Now);
            }
        }
    }
}
