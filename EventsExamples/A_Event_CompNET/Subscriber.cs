using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event_CompNET
{
    class Subscriber
    {
        public void Handler(object sender, EventArgs arg)
        {
            Console.WriteLine($"Произошло событие.");
            Console.WriteLine($"Обработчик в классе Subscriber {sender}");
        }
    }
}
