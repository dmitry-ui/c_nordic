using System;

namespace Lesson07_Home1
{
	class Program
	{
		static void Main(string[] args)
		{
			//вводим строку до тех пор пока не будет введено exit
			string str = string.Empty;
            string[] words;
            int count = 0;
            Console.WriteLine("Введите строку длиной не меньше двух слов:");
            do
            {
                str = Console.ReadLine();
                words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length < 2)
                {
                    Console.WriteLine("Введены некорректные данные.\nПовторите ввод:");
                }
            }
            while (words.Length < 2);

            //считаем количество слов на букву а
            foreach (string tempStr in words)
            {
                if (tempStr[0] == 'а')
                    count += count;
            }
            Console.WriteLine("В строке {0} слов на букву а.", count);




            Console.ReadKey();
		}
	}
}
