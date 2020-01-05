using Newtonsoft.Json;
using System;
using System.IO;

namespace JSONProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //если файл есть,то в объект из файла
            Person person = File.Exists("person.json")
                ? JsonConvert.DeserializeObject<Person>(File.ReadAllText("person.json"))
                //иначе создаем объект
                : new Person
                {
                    FirstName = "Дима",
                    LastName = "Абрамов",
                    Age = 45
                };

            ////объект в строку
            //var jsonData = JsonConvert.SerializeObject(person);
            ////строку в объект
            //var person2 = JsonConvert.DeserializeObject<Person>(jsonData);

            person.Age++;
            //записываем измененный объект в файл
            File.WriteAllText("person.json", JsonConvert.SerializeObject(person));

            Console.ReadKey();
        }
    }
}
