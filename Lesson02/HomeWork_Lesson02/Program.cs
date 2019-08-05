using System;

namespace HomeWork_Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать приложение, запрашивающее у пользователя поочерёдно 2
            //числа числа, а затем выводящее сумму, разницу и произведение этих
            //чисел в консоль.
            float num1, num2;
            float firstVal, secondVal;
            string tempVal, tempCh;
            
            Console.WriteLine("Введите первое число:");
            tempVal = Console.ReadLine();
            firstVal = float.Parse(tempVal);
            Console.WriteLine("Введите второе число:");
            tempVal = Console.ReadLine();
            secondVal = float.Parse(tempVal);
            Console.WriteLine("{0}+{1}={2}", firstVal, secondVal, firstVal + secondVal);
            Console.WriteLine("{0}-{1}={2}", firstVal, secondVal, firstVal - secondVal);
            Console.WriteLine("{0}*{1}={2}", firstVal, secondVal, firstVal * secondVal);
            
            Console.WriteLine("----------------------------");

            /*
                Написать приложение-калькулятор, запрашивающее у пользователя
                поочерёдно 2 числа числа, а также один из шести типов операций:
                ● сложение
                ● вычитание
                ● умножение
                ● деление
                ● остаток от деления
                ● возведение в степень
                а затем выводящее результат вычисления в консоль.

                во второй commite просто добавил эту строку
             */
            Start:
            Console.WriteLine("Введите первое число:");
            tempVal = Console.ReadLine();
            num1 = float.Parse(tempVal);
            Console.WriteLine("Введите второе число:");
            tempVal = Console.ReadLine();
            num2 = float.Parse(tempVal);
            OnceMore:
                        Console.WriteLine("Введите операцию (+,-,*,/ или :, %(остаток от деления), ^(в степень)):");
                        tempCh = Console.ReadLine();
            if (tempCh == "+")
                Console.WriteLine("{0}+{1}={2}", num1, num2, num1 + num2);
            else if (tempCh == "-")
                Console.WriteLine("{0}-{1}={2}", num1, num2, num1 - num2);
            else if (tempCh == "*")
                Console.WriteLine("{0}*{1}={2}", num1, num2, num1 * num2);
            else if (tempCh == "/" || tempCh == ":")
                Console.WriteLine("{0}:{1}={2}", num1, num2, num1 / num2);
            else if (tempCh == "%")
                Console.WriteLine("{0}%{1}={2}", num1, num2, num1 % num2);
            else if (tempCh == "^")
                Console.WriteLine("{0} в степени {1} = {2}", num1, num2, Math.Pow(num1, num2));
            else

                {
                    Console.WriteLine("Введите корректный знак операции, см. в скобках");
                    goto OnceMore;
                }
            
            Console.WriteLine("Выйти из программы (y/n)?:");
            char chClose = Console.ReadKey().KeyChar;
            if (chClose == 'y' || chClose == 'Y')
                Environment.Exit(0);
            else
            {
                Console.WriteLine();
                goto Start;
            }
        }
    }
}
