using System;
using System.Collections.Generic;

namespace Lesson08_Home02
{
	
	class Program
	{

		static void Main(string[] args)
		{
			//проверить скобки
			Stack<char> skobki = new Stack<char>();
            bool ok = true;

			Console.WriteLine("Введите выражение со скобками:");
			string expression = Console.ReadLine();

            foreach (char symbol in expression)
			{
                switch (symbol)
                {
                    case '(':
                        skobki.Push('(');
                        break;
                    case '[':
                        skobki.Push('[');
                        break;
                    case ')':
                        if(skobki.Count==0)
                        {
                            ok = false;
                            break;
                        }
                        if (skobki.Peek() == '(')
                            skobki.Pop();
                        else
                            ok = false;
                        break;
                    case ']':
                        if (skobki.Count == 0)
                        {
                            ok = false;
                            break;
                        }
                        if (skobki.Peek() == '[')
                            skobki.Pop();
                        else
                            ok = false;
                        break;
                } 
			}

            if(skobki.Count!=0)
                ok = false;

            if(ok)
                Console.WriteLine("Скобки расставлены корректно.");
            else
                Console.WriteLine("Ошибка при расставлении скобок!");
            Console.WriteLine("\nДля выхода из программы нажмите любую клавишу:");
			Console.ReadKey();
		}
	}
}
