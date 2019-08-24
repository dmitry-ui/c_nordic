using System;

namespace Lesson07_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дана строка с “грязными” пробелами, например:
            //string text = " lorem ipsum dolor sit amet ";
            //Необходимо произвести над ней следующие операции:
            //1. “Очистить” исходную строку от лишних пробелов в начале, в конце
            //строки, а также между словами, а также поднять регистр второго слова:
            //○ “ lorem ipsum dolor sit amet ” → “lorem IPSUM dolor sit amet”
            //2.Удалить из исходной строки последнее слово и пробелы перед ним:
            //○ “ lorem ipsum dolor sit amet ” → “ lorem ipsum dolor sit”
            //Результаты по каждому пункту вывести отдельной строкой.Пример:
            //lorem IPSUM dolor sit amet
            // lorem ipsum dolor sit

            

            string text = "  lorem ipsum       dolor sit amet ";
            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            words[1] = words[1].ToUpper();
            string text1 = string.Empty;
            string text2 = string.Empty;
            
            //по 1 пункту задания
            for (int i = 0; i < words.Length; i++)
                text1 = text1 + words[i] + " ";
            text1 = text1.TrimEnd();

            //по 2 пункту задания
            words[1] = words[1].ToLower();
            for (int i = 0; i < words.Length-1; i++)
                text2 = text2 + words[i] + " ";
            text2 = text2.TrimEnd();

            //все на выход
            Console.WriteLine(text);
            Console.WriteLine(text1);
            Console.WriteLine(text2);
            Console.ReadKey();
        }
    }
}
