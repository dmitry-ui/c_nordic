using System;
using System.Collections.Generic;

namespace Lesson15
{
	class Program
	{
		static void Main(string[] args)
		{
			//int c = 10;
			//int d = 20;
			//Console.WriteLine($"{c}   {d}");
			//Swapper.Swap(ref c, ref d);
			//Console.WriteLine($"{c}   {d}");

			////string aa = "aaa";
			////string bb = "bbb";
			////Console.WriteLine($"{aa}   {bb}");
			////Swapper<string>.Swap(ref aa, ref bb);
			////Console.WriteLine($"{aa}   {bb}");

			//Account<int, string> a = new Account<int, string>(10, "Число");
			//Account<string, string> str = new Account<string, string>("11", "Строка");
			//Account<Guid, string> mguid = new Account<Guid, string>(Guid.NewGuid(), "Строка");

			//a.WriteProperties();
			//str.WriteProperties();
			//mguid.WriteProperties();

			//пример
			List<string> l = Swapper<List<string>>.GetDefaultObject();

			Console.ReadKey();
		}
	}
}
