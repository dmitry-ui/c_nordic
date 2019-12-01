using System;
using System.Collections.Generic;
using System.Text;

namespace A_Even_Lambda
{
    public class A_SourceEvent
    {
        public event A_Handler A_EventHandler;
        
        public void A_Method(int a)
        {
            if (A_EventHandler != null)
                A_EventHandler(a);
        }
    }
}
