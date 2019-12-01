using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event2
{
    public class A_Source
    {
        public event A_handler A_Event;

        public void MyMethod()
        {
            if (A_Event != null)
                A_Event();
        }
    }
}
