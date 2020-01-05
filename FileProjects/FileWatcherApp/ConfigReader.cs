using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileWatcherApp
{
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
