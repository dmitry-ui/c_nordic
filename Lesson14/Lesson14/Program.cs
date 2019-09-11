using System;

namespace Lesson14
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ErrorList errorList = new ErrorList("Категория"))
			{
				errorList.Add("что-то там");
				errorList.Add("еще раз...");

				errorList.WriteToConsole();
			}



				Console.ReadKey();
		}
	}
}
