using System;
using System.Collections.Generic;
using System.Text;

namespace Event2
{
    class EventsSource
    {
        public event MyHandlers myHandlers;
         
        public void OnMyHandlers()
        {
            if (myHandlers != null)
                myHandlers();
        }
    }
}
