using System;

namespace A_Event_CompNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Source sou = new Source();

            Subscriber sub = new Subscriber();

            sou.SomeEvent += sub.Handler;

            sou.OnSomeEvent();

            Console.ReadKey();
        }
    }
}
