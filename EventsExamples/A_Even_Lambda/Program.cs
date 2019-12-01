using System;

namespace A_Even_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            A_SourceEvent ase = new A_SourceEvent();
            ase.A_EventHandler += i => Console.WriteLine("Обработчик через лямбду {0}", i);

            //тоже самое через анонимный метод
            //ase.A_EventHandler += delegate (int i)
            //  {
            //      Console.WriteLine("Обработчик через анонимный метод {0}", i);
            //  };

            ase.A_Method(1);
            ase.A_Method(5);

            Console.ReadKey();
        }
    }
}
