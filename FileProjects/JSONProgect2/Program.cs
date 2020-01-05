using Newtonsoft.Json;
using System;
using System.IO;

namespace JSONProgect2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = JsonConvert.DeserializeObject<Person>(File.ReadAllText("person.json"));


            Console.ReadKey();
        }
    }
}
