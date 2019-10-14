using System;

namespace Events
{
    // Объявить тип делегата для события.
    delegate void MyEventHandler();

    // Объявить класс, содержащий событие.
    class MyEvent
    {
        public event MyEventHandler SomeEvent;

        // Этот метод вызывается для запуска события.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }

    class EventDemo
    {
        // Обработчик события.
        static void Handler()
        {
            Console.WriteLine("Произошло событие");
        }
        static void Handler1()
        {
            Console.WriteLine("Произошло событие1");
        }


        static void Main()
        {
            MyEvent evt = new MyEvent();
            // Добавить метод Handler() в список событий.
            evt.SomeEvent += Handler;
            evt.SomeEvent += Handler1;
            // Запустить событие.
            evt.OnSomeEvent();
            Console.ReadKey();
        }
    }}

