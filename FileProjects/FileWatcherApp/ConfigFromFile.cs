using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherApp
{
    class ConfigFromFile
    {
        //файл лога куда пишем созданные, измененные, удаленные файлы
        public string FullLogFileName;

        //каталог в котором отслеживаем изменения файлов
        public string ControlPath;
    }
}
