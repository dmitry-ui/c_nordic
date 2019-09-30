using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSource
{
    class EventSubscriber1
    {
        //этот метод мы тоже добавим в делегат
        public void Message(int i)
        {
            Console.WriteLine($"выполнено {i}%");
        }

		public void ProcessPartDone(object sender, CounterEventArgs e)
		{
			Console.WriteLine($"[новый] выполнено {e.Percentage}%");
		}

	}
}
