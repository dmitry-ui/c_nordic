using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event_CompNET
{
    class Source
    {
        public event EventHandler SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent(this, EventArgs.Empty);
            }
        }
    }
}
