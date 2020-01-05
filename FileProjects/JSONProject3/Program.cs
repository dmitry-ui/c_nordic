using System;
using Newtonsoft.Json;
using System.IO;

namespace JSONProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = JsonConvert.DeserializeObject<Menu>(File.ReadAllText("json2.json"));

            foreach(var item in menu.Items)
            {
                Console.WriteLine(item.Id);
            }

            

            Console.ReadKey();
        }
    }
}
