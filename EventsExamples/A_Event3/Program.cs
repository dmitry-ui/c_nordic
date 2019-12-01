using System;

namespace A_Event3
{
    class Program
    {
        static void Main(string[] args)
        {
            Source sou = new Source();
            Subscriber scr = new Subscriber();
            Subscriber scr2 = new Subscriber();
            Subscriber scr3 = new Subscriber();

            //нестатический обработчик события, на каждый экземпляр
            sou.A_Event += scr.MyEventHandler;
            sou.A_Event += scr2.MyEventHandler;
            sou.A_Method();

            //статический обработчик события, на класс
            Subscriber2 s2cr = new Subscriber2();
            Source sou2 = new Source();
            sou2.A_Event += Subscriber2.MyEventHandler;
            sou2.A_Method();



            Console.ReadKey();
        }
    }
}
