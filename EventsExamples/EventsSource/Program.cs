using System;

namespace EventsSource
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://habr.com/ru/post/213809/            
            //объект класса источник события
            EventsSource eventsSource = new EventsSource();

            //объекты классов подписчиков, т.е. в которых запустятся методы
            //по срабатыванию события
            EventSubscriber eventSubscriber = new EventSubscriber();
            EventSubscriber1 eventSubscriber1 = new EventSubscriber1();

            //подписываемся на событие
            eventsSource.OnCount += eventSubscriber.Message;
            eventsSource.OnCount += eventSubscriber1.Message;

			eventsSource.ProcessPartDone += eventSubscriber1.ProcessPartDone;

            //запускаем метод в котором срабатывает событие
            eventsSource.Count();


            
            Console.ReadKey();
        }
	}
}