using System;
using System.Collections.Generic;

namespace Lesson08_Home01
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //словари
            /*
             Написать приложение-игру:
            ● Программа хранит небольшой список стран и соответствующих им
            столиц
            ● Пользователя циклически спрашивают столицу страны в случайном
            порядке до тех пор, пока он не ошибется
            ● Если пользователь угадал столицу, его нужно похвалить.
            ● При ошибке, сообщаем, что пользователь ошибся и выходим из
            приложения
             */
            int countCountries = 6;
            Dictionary<int, string> Countries = new Dictionary<int, string>(countCountries);
            //Countries.Add("Россия", "Москва");
            //Countries.Add("Сербия", "Белград");
            Countries.Add(1,"Австралия");
            Countries.Add(2, "Дания");
            Countries.Add(3, "Ирландия");
            Countries.Add(4, "Исландия");
            Countries.Add(5, "Гондурас");

            Dictionary<int, string> Capitals = new Dictionary<int, string>(countCountries);
            Capitals.Add(1, "Канберра");
            Capitals.Add(2, "Копенгаген");
            Capitals.Add(3, "Дублин");
            Capitals.Add(4, "Рейкьявик");
            Capitals.Add(5, "Тегусигальпа");

            //Создание объекта для генерации чисел
            Random rnd = new Random();

            do
            {
                //Получить случайное число (в диапазоне от 1 до countCountries)
                int rndValue = rnd.Next(1, countCountries);
                Console.WriteLine("Введите столицу государства {0}:", Countries[rndValue]);
                string inputStr = Console.ReadLine();
                if (inputStr== Capitals[rndValue])
                {
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine("К сожалению, вы ошиблись...\n");
                    break;
                }
            }
            while (true);
            Console.WriteLine("Для закрытия программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
