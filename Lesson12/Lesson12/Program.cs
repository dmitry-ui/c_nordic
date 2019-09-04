using System;

namespace Lesson12
{
	class Program
	{
		static void Main(string[] args)
		{
			Person p1 = new Person
			(
				"Andrey",
				 DateTimeOffset.Parse("1982-03-14")
			);
			p1.WriteShortDescription();
			Console.WriteLine(p1.ToString());  //доступно за счет авытоматического наследования от Object

			Console.WriteLine();

			Employee e1 = new Employee("Dima", DateTimeOffset.Parse("1975-08-02"));
				e1.employeeCode = "000001";
				e1.HireDate = DateTimeOffset.Parse("2016-10-01");
				e1.WriteShortDescription();
			Console.WriteLine(e1.ToString());

			Console.ReadKey();
		}
	}
}
