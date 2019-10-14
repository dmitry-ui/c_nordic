using System;

namespace Event2
{
    class Program
    {
        static void Main(string[] args)
        {
            EventsSource es = new EventsSource();
            es.myHandlers += ()=> Console.WriteLine("Метод который выполняется при стабатывании события");
            es.myHandlers += () => Console.WriteLine("Второй метод который выполняется при стабатывании события");
            es.OnMyHandlers();

            Console.ReadKey();
        }
    }
}
