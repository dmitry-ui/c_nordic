using System;

namespace Lesson12__2
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseDocument bd = new BaseDocument("Инструкция", "1", DateTimeOffset.Parse("2019-08-02"));
						bd.WriteToConsole();

			Console.WriteLine();
			
			Passport pas = new Passport("Россия", "Персона", "2", DateTimeOffset.Parse("2019-08-02"));
			
			pas.WriteToConsole();





			Console.ReadKey();
		}
	}

	
}
