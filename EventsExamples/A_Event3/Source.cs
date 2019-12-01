using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event3
{
    class Source
    {
        public event A_Delegate A_Event;

        public void A_Method()
        {
            if (A_Event != null)
                A_Event();
        }
    }
}
