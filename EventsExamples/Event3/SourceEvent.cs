using System;
using System.Collections.Generic;
using System.Text;

namespace Event3
{
    class SourceEvent
    {
        public event MyEventHandler MyEvent;

        public void OnMyEvent()
        {
            if (MyEvent != null)
                MyEvent();
        }

    }
}
