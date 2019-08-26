using System;
using System.Collections.Generic;

namespace Lesson08_Home02
{
	public enum skobki { open, close}
	class Program
	{

		static void Main(string[] args)
		{
			//проверить скобки
			Stack<char> skobki = new Stack<char>();

			Console.WriteLine("Введите выражение со скобками:");
			string expression = Console.ReadLine();

			foreach (char symbol in expression)
			{
				if (symbol == '(')
				{
					skobki.Push('(');
					//Console.WriteLine(skobki.Count);
				}
				if (symbol == '[')
				{
					skobki.Push('[');
					//Console.WriteLine(skobki.Count);
				}
				if (symbol == ']')
				{
					if(skobki.Peek() == '[')
						skobki.Pop();
					else
						Console.WriteLine("Ошибки в скобках!");
					//Console.WriteLine(skobki.Count);
				}

				if (symbol == ')')
				{
					if (skobki.Peek() == '(')
						skobki.Pop();
					else
						Console.WriteLine("Ошибки в скобках!");
					//Console.WriteLine(skobki.Count);
				}
				






			}
			Console.ReadKey();
		}
	}
}
