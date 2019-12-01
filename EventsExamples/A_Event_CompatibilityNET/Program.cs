using System;

namespace A_Event_CompatibilityNET
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent me = new MyEvent();

            Subscriber_X sx = new Subscriber_X();
            Subscriber_Y sy = new Subscriber_Y();

            me.SomeEvent += sx.X_Handler;
            me.SomeEvent += sy.Y_Handler;

            me.OnSomeEvent();
            me.OnSomeEvent();
            me.OnSomeEvent();

            Console.ReadKey();
        }
    }
}
