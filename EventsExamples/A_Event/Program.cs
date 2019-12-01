using System;

namespace A_Event
{
    class Program
    {
        static void A_Handler()
        {
            Console.WriteLine("Обработка события");
        }

        static void Main(string[] args)

        { 
            EventSource es = new EventSource();
 
            es.A_Event += A_Handler;

            es.A_Method();

            Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
