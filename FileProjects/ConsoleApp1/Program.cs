using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ConfigReader configReader = new ConfigReader();
            Console.WriteLine(configReader.configFromFile.ControlPath);
            Console.WriteLine(configReader.configFromFile.FullLogFileName);

            Console.ReadKey();
        }
    }

    public class ConfigFromFile
    {
        public string FullLogFileName;

        public string ControlPath;
    }

    public class ConfigReader
    {
        public ConfigFromFile configFromFile = new ConfigFromFile();

        public ConfigReader()
        {
            configFromFile = JsonConvert.DeserializeObject<ConfigFromFile>(File.ReadAllText("MyConfig.json"));
        }
    }



}
