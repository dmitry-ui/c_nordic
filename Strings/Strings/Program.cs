using System;
using System.IO;  //для Directory

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////конкатенация
            string s1 = "hello";
            string s2 = "world";
            string s3 = s1 + " " + s2; // результат: строка "hello world"
            string s4 = String.Concat(s3, "!!!"); // результат: строка "hello world!!!"
            Console.WriteLine(s4);

            ///////////интерполяция
            ///Интерполяция строк
            //Специальный знак $ в начале строки делает интерполированную строку.
            //При вычислении интерполированной строки в результирующую элементы заменяются
            //строковыми представлениями результатов выражений.
            double i1 = 15;
            double j1 = Math.PI;
            var s11 = $"{i1} divided by {j1:#.##} equals to {i1 / j1:#.##}";
            Console.WriteLine(s11); // 15 divided by 3.14 equals to 4.77
            DateTime now = DateTime.Now;
            string result4 = $"Now is {now:dd.MM.yyyy HH:mm}";
            Console.WriteLine(result4); // Now is 29.01.2019 14:00

            //Объединение строк с переменными других типов также возможно с
            //помощью оператора +.При объединении переменные других типов будут
            //автоматически приведены к строке с помощью метода ToString().
            int ii = 15;
            int j = 3;
            string result1 = ii + " divided by " + j + " equals to " + ii / j;
            Console.WriteLine(result1); // 15 divided by 3 equals to 5
            DateTime nowA = DateTime.Now;
            string result2 = String.Format("Now is {0:dd.MM.yyyy HH:mm}", nowA);
            Console.WriteLine(result2); // Now is 05.02.2019 12:00

            /////////////соединение строк с использованием join
            string s5 = "apple";
            string s6 = "a day";
            string s7 = "keeps";
            string s8 = "a doctor";
            string s9 = "away";
            string[] values = new string[] { s5, s6, s7, s8, s9 };
            String s10 = String.Join(" ", values);
            Console.WriteLine(s10);
            // результат: строка "apple a day keeps a doctor away"

            ////////////////////сравнение строк
            string s111 = "hello";
            string s12 = "world";
            int result = String.Compare(s111, s12);
            if (result < 0)
            {
                Console.WriteLine("Строка s111 перед строкой s12");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка s111 стоит после строки s12");
            }
            else
            {
                Console.WriteLine("Строки s111 и s12 идентичны");
            }
            // результатом будет "Строка s111 перед строкой s2"

            string a = "test";
            string b = "Test";            Console.WriteLine(a == b); // false
            Console.WriteLine(a.Equals(b)); // false
                                            // but this will return true
            Console.WriteLine(a.Equals(b, StringComparison.InvariantCultureIgnoreCase));

            //Методы проверки строк
            //IsNullOrEmpty(строка не определена или равна string.Emtpy)
            //IsNullOrWhiteSpace(строка не определена или содержит лишь знаки отступов)
            Console.WriteLine(string.IsNullOrWhiteSpace(" \t ")); // true
            Console.WriteLine(string.IsNullOrEmpty("")); // true
            Console.WriteLine(string.IsNullOrEmpty(null)); // true


            //////////////////////поиск в строке
            string s13 = "hello world";
            char ch = 'o';
            int indexOfChar = s13.IndexOf(ch); // равно 4
            Console.WriteLine(indexOfChar);

            string subString = "wor";
            int indexOfSubstring = s13.IndexOf(subString); // равно 6
            Console.WriteLine(subString.Contains("or"));
            Console.WriteLine(indexOfSubstring);
            //Подобным образом действует метод LastIndexOf, 
            //только находит индекс последнего вхождения символа или подстроки в строку.


            //Еще одна группа методов позволяет узнать начинается или заканчивается ли строка на определенную подстроку.
            //Для этого предназначены методы StartsWith и EndsWith. 
            //Например, у нас есть задача удалить из папки все файлы с расширением exe:
            string path = @"C:\SomeDir";
            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".exe"))
                    File.Delete(files[i]);
            }


            ///////////////////разделение строк
            string text = "И поэтому все так произошло";
            string[] words = text.Split(new char[] { ' ' });
            //так лучше
            //string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            //Это не лучший способ разделения по пробелам, так как во входной строке у нас могло бы быть 
            //несколько подряд идущих пробелов и в итоговый массив также бы попадали пробелы, 
            //поэтому лучше использовать другую версию метода:
            //string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //Второй параметр StringSplitOptions.RemoveEmptyEntries говорит, что надо удалить все пустые подстроки.


            ////////////////////////Обрезка строки
            //Для обрезки начальных или концевых символов используется функция Trim:
            string textA = " hello world ";
            Console.WriteLine(textA);
            textA = textA.Trim(); // результат "hello world"
            Console.WriteLine(textA);
            textA = textA.Trim(new char[] { 'd', 'h' }); // результат "ello worl"
            Console.WriteLine(textA);
            //Эта функция имеет частичные аналоги: 
            //функция TrimStart обрезает начальные символы, а функция TrimEnd обрезает конечные символы.


            //Обрезать определенную часть строки
            string textB = "Хороший день";
            // обрезаем начиная с третьего символа
            textB = textB.Substring(2);
            // результат "роший день"
            Console.WriteLine(textB);
            // обрезаем сначала до последних двух символов
            textB = textB.Substring(0, textB.Length - 2);
            // результат "роший де"
            Console.WriteLine(textB);
            //Функция Substring также возвращает обрезанную строку. 
            //В качестве параметра первая использованная версия применяет индекс, 
            //начиная с которого надо обрезать строку. 
            //Вторая версия применяет два параметра - индекс начала обрезки и длину вырезаемой части строки.




            ///////////////////////////вставка
            //Первым параметром в функции Insert является индекс, по которому надо вставлять подстроку, 
            //а второй параметр - собственно подстрока.
            string textC = "Хороший день";
            string subStringC = "замечательный ";
            textC = textC.Insert(8, subStringC);
            Console.WriteLine(textC);

            //Удалить часть строки помогает метод Remove
            string textD = "Хроший день";
            // индекс последнего символа
            int ind = textD.Length - 1;
            // вырезаем последний символ
            textD = textD.Remove(ind);
            Console.WriteLine(textD);
            // вырезаем первые два символа
            textD = textD.Remove(0, 2);

            ///////////////////////////////Замена
            //Чтобы заменить один символ или подстроку на другую, применяется метод Replace:
            string textE = "хороший день";
            textE = textE.Replace("хороший", "плохой");
            Console.WriteLine(textE);
            textE = textE.Replace("о", "");
            Console.WriteLine(textE);

            /////////////////////////////Смена регистра
            //Для приведения строки к верхнему и нижнему регистру 
            //используются соответственно функции ToUpper() и ToLower():
            string hello = "Hello world!";
            Console.WriteLine(hello.ToLower()); // hello world!
            Console.WriteLine(hello.ToUpper()); // HELLO WORLD!

            ////////////////////////Буквальные строковые литералы(@)
            //Буквальные строки используются для удобства и читабельности, если текст
            //строки содержит символы обратной косой черты, например в путях к
            //файлам:
            Console.WriteLine("c:\\path\\to\\file1.txt"); // c:\path\to\file1.txt
            Console.WriteLine(@"c:\path\to\file2.txt"); // c:\path\to\file2.txt

            ////////////////////////Форматирование строк
            //Форматирование позволяет сформировать строку используя шаблон и
            //объекты с возможностью указать формат. Для этого используется метод
            //String.Format(...).
            double q = 15;
            double w = Math.PI;
            string qw = String.Format("{0} divided by {1} equals to {2}", q, w, q / w);
            Console.WriteLine(qw);

            //Можно также указывать формат для некоторых переменных, например можно указать сколько
            //выводить знаков после запятой или в каком формате указывать дату и время.
            //Формат указывается через двоеточие после индекса переменной:
            //{ 0:#.###},
            //{ 1:dd.MM.yyyy HH:mm}, и т.д.:
            double e = 15;
            double r = Math.PI;
            var ss = String.Format("{0} divided by {1:#.##} equals to {2:#.##}", e, r, e / r);
            Console.WriteLine(ss); // 15 divided by 3.14 equals to 4.77
            DateTime now1 = DateTime.Now;
            string resultA = String.Format("Now is {0:dd.MM.yyyy HH:mm}", now1);
            Console.WriteLine(resultA); // Now is 29.01.2019 14:00


            Console.ReadKey();
        }
    }
}
