using System;

namespace A_Event_PressKey
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyEvent ke = new KeyEvent();
            int count = 0;
            ConsoleKeyInfo k;
            ke.KeyPress += (sender, e) => Console.WriteLine("\nНажата клавиша {0}", e.ch);
            ke.KeyPress += (sender,e) => count++;

            Console.WriteLine("Введите символы...");
            do
            {
                k = Console.ReadKey();
                ke.OnPressKey(k.KeyChar);
            }
            while (k.KeyChar != '.');

            Console.WriteLine("Всего нажато {0} клавиш.", count);


            Console.ReadKey();
        }
    }
}
