using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSource
{
    class EventsSource 
    {
        public int iMax = 10;

        public delegate void MethodContainer(int a);

        public event MethodContainer OnCount;

        //переделать на EventArgs
        //public event EventHandler<MethodContainer> OnCount;

        public void Count()
        {
            for(int i = 1; i<= iMax; i++)
            {
                if (i == iMax / 4)
                {
                    //сейчас событие сработает и запустятся все методы из делегата
                    if (OnCount != null)
                        OnCount(25);
                }
                else if (i == iMax/2)
                {
                    //сейчас событие сработает и запустятся все методы из делегата
                    if(OnCount != null)
                        OnCount(50);
                }
                else if (i == 3 * iMax / 4)
                {
                    //сейчас событие сработает и запустятся все методы из делегата
                    if (OnCount != null)
                        OnCount(75);
                }
                else if (i == iMax)
                {
                    //сейчас событие сработает и запустятся все методы из делегата
                    if (OnCount != null)
                        OnCount(100);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
