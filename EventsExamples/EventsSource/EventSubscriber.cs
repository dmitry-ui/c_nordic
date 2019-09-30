using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSource
{
    class EventSubscriber
    {
        //этот метод мы добавим в делегат в основной программе
        //и он будет запускаться при срабатывании события
        public void Message(int i)
        {
            Console.WriteLine($"выполнено {i}%");
        }
    }
}
