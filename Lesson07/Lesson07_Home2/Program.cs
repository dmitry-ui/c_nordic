using System;

namespace Lesson07_Home1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Написать консольное приложение, которое запрашивает строку, а затем
            выводит все буквы приведенные к нижнему регистру в обратном порядке.
            Программа должна спрашивать исходную строку до тех пор, пока
            пользователь не введет строку, содержащую печатные символы.
             */
            string str;
            string str2 = string.Empty;
            char[] copy_str;
            bool ok=false;
            Console.WriteLine("Введите строку содержащую большие буквы:");
            do
            { 
                str = Console.ReadLine();
                //проверим строку на наличие печатных букв
                foreach(char ch in str)
                {
                    if(char.IsUpper(ch))
                    {
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                    Console.WriteLine("Введены некорректные данные\nПовторите ввод:");
            }
            while (!ok);

            copy_str = new char[str.Length];

            //пишем строку наоборот в массив
            int i, j;
            for (i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                copy_str[i] = str[j];
                copy_str[j] = str[i];
            }
            //если длина строки нечентая копируем средний элемент
            if (str.Length % 2 == 1)
            {
                copy_str[copy_str.Length / 2] = str[str.Length / 2];
            }

            //формируем выходную строку
            foreach ( char ch in copy_str)
                str2 = str2 + ch;
            
            //переводим в нижний регистр
            str2 = str2.ToLower();

            Console.WriteLine(str2);
            Console.ReadKey();

        }
    }
}
