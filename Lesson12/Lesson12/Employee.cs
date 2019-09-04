using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lesson12
{
	class Employee : Person   //наследуем от класса Person
	{
		public string employeeCode { get; set; }
		public DateTimeOffset HireDate { get; set; }
		
		public override string ShortDescription    //сказали компилятору, что мы специально сокрыли свойство базового класса
		{
			get
			{
				return base.ShortDescription +
					   $"\nname: {name}" +
					   $"\ndate of birth: {DateOfBirth:dd-MM-yy}";
			}
		}
		public Employee(string name, DateTimeOffset dateOfBirth) : base(name, dateOfBirth)
		{
			Debug.WriteLine("Constructor Employee(name, dateOfBirth) called");
		}
	}
}
