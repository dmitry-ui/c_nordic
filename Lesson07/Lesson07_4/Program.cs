using System;
using System.Text;

namespace Lesson07_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Дана строка с “грязными” пробелами:
            //“Очистить” исходную строку от лишних пробелов в начале, в конце строки, а также между
            //словами, а также поднять регистр второго слова, но сделать это надо перебором каждого
            //символа исходной строки(в цикле for или foreach) и “набора” результирующей строки в
            //StringBuilder
            
            string text = "  lorem    ipsum dolor sit amet      ";
            //StringBuilder sb = new StringBuilder("", 50);.
            Console.WriteLine(text);
            Console.WriteLine(OptimaizProbels(text));
            Console.WriteLine(ChangeSecondWordToUpper(OptimaizProbels(text)));
            

            Console.ReadKey();
        }

        //возвращает строку без начальных пробелов
        static string DeleteFirstProbels(string str)
        {
            //удаляем все начальные пробелы в строке
            int countF = 0; //количество начальных пробелов
            for (int i = 0; str[i] == ' '; i++)
                countF += 1;
            return str.Substring(countF, str.Length - countF);
        }

        //возвращает строку без оконечных пробелов
        static string DeleteEndProbels(string str)
        {
            //удаляем все конечные пробелы в строке
            int countFh = 0; //количество конечных пробелов
            for (int i = str.Length - 1; str[i] == ' '; i--)
                countFh += 1;
            return str.Substring(0, str.Length - countFh);
        }

        //возвращает количество подряд идущих пробелов в строке начиная с заданной позиции
        static int GetCountProbels(string str, int pos)
        {
            if (str[pos] != ' ')
            throw new Exception();

            int CountProbels = 0;  //количество подряд идущих пробелов 
            for (int i = pos; str[i] == ' '; i++)
                CountProbels += 1;

            return CountProbels;
        }

        //возвращает строку в которой несколько подряд следующих пробелов заменены на один пробел в заданной позиции
        static string OneProbelInPosition(string str, int pos)
        {
            if (str[pos] != ' ')
                throw new Exception();

            string res=string.Empty;
            res = str.Substring(0,pos)  + ' ' + str.Substring(pos + GetCountProbels(str, pos));


            return res;
        } 

        //возвращает строку в которой все двойные и более пробелы между словами заменены на один
        static string OptimaizProbels(string str)
        {
            string res = str;
            res = DeleteFirstProbels(res);
            res = DeleteEndProbels(res);

            //удалим пробелы между словами
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] == ' ')
                    res = OneProbelInPosition(res, i);
            }
            return res;
        }

        //возвращает второе слово
        static string GetSecondWordFromString(string str)
        {
            string res = OptimaizProbels(str);
            //Console.WriteLine(res);
            string secondWord = string.Empty;
            int pos = 0;
            pos = res.IndexOf(' ');

            if (pos != 0)
                secondWord = res.Substring(pos + 1);

            pos = secondWord.IndexOf(' ');
            if (pos != 0)
                secondWord = secondWord.Substring(0, pos);

            return secondWord;
        }

        //возвращает второе слово в верхнем регистре
        static string GetSecondWordFromStringToUpper(string str)
        {
           return GetSecondWordFromString(str).ToUpper();
        }

        //в строке изменим второе слово на верхний регистр
        static string ChangeSecondWordToUpper(string str)
        {
            return str.Replace(GetSecondWordFromString(str), GetSecondWordFromStringToUpper(str));
        }

    }
}
