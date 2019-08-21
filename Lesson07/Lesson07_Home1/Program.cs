using System;

namespace Lesson07_Home1
{
	class Program
	{
		//возвращает последнее слово в строке
		static string EndWord(string str)
		{
			string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			return words[words.Length - 1];
		}

		static void Main(string[] args)
		{
			//запросить строку, ввод строки оканчивается после ввода слова exit
			//вывести количество слов на букву А

			//вводим строку до тех пор пока не будет введено exit
			string str = string.Empty;
			do
			{
				str = str + Console.ReadKey().KeyChar;
			}
			while (EndWord(str) != "exit");

			//считаем количество слов на чинающихся на букву а
			string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			int count = 0;
			foreach (string s in words)
			{
				if()
			}

			/*
			 //поиск в строке
            string s13 = "hello world";
            char ch = 'o';
            int indexOfChar = s13.IndexOf(ch); // равно 4
            Console.WriteLine(indexOfChar);

            string subString = "wor";
            int indexOfSubstring = s13.IndexOf(subString); // равно 6
            Console.WriteLine(indexOfSubstring);
            //Подобным образом действует метод LastIndexOf, 
            //только находит индекс последнего вхождения символа или подстроки в строку.
			 
			 */



			Console.ReadKey();
		}
	}
}
