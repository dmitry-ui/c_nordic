using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event
{
    class EventSource
    {
        public event A_EventHandler A_Event;

        public void A_Method()
        {
            if(A_Event != null)
            A_Event();
        }
    }
}
