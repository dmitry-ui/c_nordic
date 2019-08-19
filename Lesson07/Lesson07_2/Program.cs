using System;

namespace HomeWork_Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            
            decimal num1, num2;
            decimal firstVal, secondVal;
            string tempVal, tempCh;

       
            Console.WriteLine("Введите первое число:");
            tempVal = Console.ReadLine();
            num1 = decimal.Parse(tempVal);
            Console.WriteLine("Введите второе число:");
            tempVal = Console.ReadLine();
            num2 = decimal.Parse(tempVal);
        OnceMore:
            Console.WriteLine("Введите операцию (+,-,*,/ или :, %(остаток от деления), ^(в степень)):");
            tempCh = Console.ReadLine();
            if (tempCh == "+")
                Console.WriteLine("{0:0.##}+{1:0.##}={2:0.##}", num1, num2, num1 + num2);  //форматирование с форматированием
            else if (tempCh == "-")
                Console.WriteLine($"{num1:0.##}-{num2:0.##}={(num1 - num2):0.##}");          //интерполяция с форматированием
            else if (tempCh == "*")
                //Console.WriteLine("{0}*{1}={2}", num1, num2, num1 * num2);
                Console.WriteLine(num1 + " * " + num2 + "=" + (num1 * num2));    //конкатенация


            Console.ReadKey();
        }
    }
}
