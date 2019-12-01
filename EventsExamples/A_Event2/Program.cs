using System;

namespace A_Event2
{
    class Program
    {
        A_Source AS = new A_Source();

        static void Main(string[] args)
        {

            A_Source aso = new A_Source();
            //Subscriber1 s1 = new Subscriber1();
            Subscriber2 s2 = new Subscriber2();
            aso.A_Event += Subscriber1.Subscriber1Method;
            aso.A_Event += s2.Subscriber2Method;

            aso.MyMethod();

            Console.ReadKey();
        }
    }
}
