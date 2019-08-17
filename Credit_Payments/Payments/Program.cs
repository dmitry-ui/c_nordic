using System;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Расчет сумммы платежей по кредиту
            исходя из суммы кредита, срока займа,числа выплат в год, процентной ставки
            */
            char ch; //для выхода из программы

            do
            {
                double Principal;       //сумма по кредиту
                double IntRatePercent;  //процентная ставка по ссуде в год в %
                double IntRate;         //процентная ставка по ссуде в год (например 0,075)
                double PayPerYear;   //число платежей в год
                double NumYars;      //срок кредита
                double Payment;      //регулярный ежемесячный платеж
                double numer, denom; // временные переменные ( числитель и знаменатель)
                double b, e;         //основание и порядок для функции возведения в степень pow
                double TotalRates;   //всего выплачено процентов за весь срок кредита

                Principal = InputDoubleValue("Введите сумму кредита:");
                IntRatePercent = InputDoubleValue("Введите процентную ставку в год, в процентах:");
                PayPerYear = InputDoubleValue("Введите число платежей в год:");
                NumYars = InputDoubleValue("Введите количество лет по кредиту:");

                //формула довольна сложная...
                IntRate = IntRatePercent / 100;
                numer = IntRate * Principal / PayPerYear;
                e = -(PayPerYear * NumYars);
                b = (IntRate / PayPerYear) + 1;
                denom = 1 - Math.Pow(b, e);
                Payment = numer / denom;
                TotalRates = Payment * PayPerYear * NumYars - Principal;

                Console.WriteLine("Платеж по кредиту составит: {0}", Payment);
                Console.WriteLine("Всего выплачено процентов: {0}", TotalRates);
                Console.WriteLine("\nПовторить расчет (y/n)?");
                ch = Console.ReadKey().KeyChar;
                Console.WriteLine("");
            }
            while (Char.ToUpper(ch) != 'N');
            
        }

        static double InputDoubleValue(string comment)
        {
            Console.WriteLine(comment);
            double doubleValue;
            do
            {
                try
                {
                    doubleValue = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено нечисловое значение.\nПовторите попытку:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                break;
            }
            while (true);
            return doubleValue;
        }
    }
}
