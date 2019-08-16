using System;

namespace Lesson_06_Home01
{
    class Program
    {
        /*
Написать консольное приложение, которое запрашивает натуральное число
и выводит количество четных цифр в нем.
Пример работы программы:
> Введите положительное натуральное число не более 2 миллиардов:
> -5 /это ввод пользователя/
> Введено неверное значение! Попробуйте ещё раз:
> 300000000000 /это ввод пользователя/
> Ошибка System.OverflowException! Попробуйте ещё раз:
> ABCD /это ввод пользователя/
> Ошибка System.FormatException! Попробуйте ещё раз
> 1234567 /это ввод пользователя/ 
> В числе 1234567 содержится следующее количество четных цифр: 3.
> Нажмите любую клавишу для выхода...
Не забывать обрабатывать все предсказуемые исключения.         
        */

        static void Main(string[] args)
        {
            uint intValue;
            int count = 0;
            Console.WriteLine("Введите натуральное число:");
            do
            {
                try
                {
                    intValue = uint.Parse(Console.ReadLine());  //целое без знака
                }
                catch
                {
                    Console.WriteLine("Введены некорректные данные.\nПовторите попытку...");
                    continue;
                }
                break;
            }
            while (true);

            //считаем количество четных цифр в числе
            string strValue = intValue.ToString();
            
            foreach (char ch in strValue)
            {
                if(ch=='2'|| ch == '4'|| ch == '6' || ch == '8')
                {
                    count += 1;
                }
            }
            Console.WriteLine("Количество четных цифр числе {0} равно {1}.", strValue, count);
            Console.ReadKey();
        }
    }
}
