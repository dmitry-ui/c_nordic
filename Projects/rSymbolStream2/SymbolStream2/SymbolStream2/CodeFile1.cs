// Простая сервисная программа ввода с диска и вывода на экран,
// демонстрирующая применение класса StreamReader.
using System;
using System.IO;
class Start
{
    static void Main()
    {
        string str;
        FileStream fs;
        try
        {
            fs = new FileStream("test.txt", FileMode.Open);
        }
         catch(IOException ios)
        {
            Console.WriteLine("ошибка открытия файла: {0}", ios.Message);
        }

        try
        {

        }



    }
}