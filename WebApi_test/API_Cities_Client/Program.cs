using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Models;
using Newtonsoft.Json;

namespace API_Cities_AppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiOperations operaions = new ApiOperations();

            //получим все города
            //ApiOperations.GetAllCities();
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine();

            ////получим один город
            //ApiOperations.GetCityById(1);
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine();

            //добавим новый город
            //string newCity = "{\"name\": \"Morshansk\", \"description\": \"Тамбовская область\", \"numberOfPintsOfInterest\": 150}";
            //ApiOperations.AddCity(newCity);
            //System.Threading.Thread.Sleep(1000);

            //добавим новый город по объекту
            //CityCreateModel newCity = new CityCreateModel();
            //newCity.Name = "Калуга";
            //newCity.description = "Описание";
            //newCity.NumberOfPintsOfInterest = 100;
            //ApiOperations.AddCity(newCity);

            //удалим город
            ApiOperations.DeleteCity(5);
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Для завершения  програмы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    public class ApiOperations
    {
        //выведем все города
        public static async Task GetAllCities()
        {
            //Get
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/cities");
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }

        //выведем город по id
        public static async Task GetCityById(int id)
        {
            //Get
            string uri = "http://localhost:5000/cities" + $"/{id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }

        //Добавим новый город по строке
        public static async Task AddCity(string newCity)
        {
            //post
            WebRequest request = WebRequest.Create("http://localhost:5000/cities");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
                                     // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(newCity);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/json";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            //Console.WriteLine("Запрос выполнен...");
        }

        //Добавим новый город по объекту
        public static async Task AddCity(CityCreateModel newCity)
        {
            string str = JsonConvert.SerializeObject(newCity);

            AddCity(str);
        }

        //Удалим город
        public static async Task DeleteCity(int id)
        {
            //del
            string str = "http://localhost:5000/cities" + $"/{id}";
            WebRequest request = WebRequest.Create(str);
            request.Method = "Delete"; // для отправки используется метод Post
                                       // данные для отправки
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }

    }


}
