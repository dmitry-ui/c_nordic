using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event_CompatibilityNET
{
    public class Subscriber_X
    {
        public void X_Handler(object sender, My_EventArg arg)
        {
            Console.WriteLine("Объект класса Х {0}, вызов {1}", sender, arg.EventNum);
        }
    }

    public class Subscriber_Y
    {
        public void Y_Handler(object sender, My_EventArg arg)
        {
            Console.WriteLine("Объект класса Y {0}, вызов {1}", sender, arg.EventNum);
        }
    }
}
