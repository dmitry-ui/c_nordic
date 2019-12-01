using System;
using System.Collections.Generic;
using System.Text;

namespace A_Event_CompatibilityNET
{
    class MyEvent
    {
        public int count;

        //собственный делегат
        //public event My_EventHandler SomeEvent;

        //тоже самое через встроенный делегат, при этом объявление делегата не нужно
        public event EventHandler<My_EventArg> SomeEvent;

        public void OnSomeEvent()
        {
            My_EventArg arg = new My_EventArg();
            if (SomeEvent != null)
            {
                arg.EventNum = ++count;
                SomeEvent(this, arg);
            }
        }
    }
}
