using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event3
{
    class Subscriber
    {
        public void MyEventHandler()
        {
            Console.WriteLine("Нестатический обработчик экземпляра");
        }
    }
}
