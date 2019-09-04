using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lesson12
{
	class Person
	{
		public string name { get; set;}
		public DateTimeOffset DateOfBirth { get; set; }
		public Person(string name, DateTimeOffset DateOfBirth)
		{
			this.name = name;
			this.DateOfBirth = DateOfBirth;
			Debug.WriteLine("Constructor Person(name, dateOfBirth) called");
		}
		public virtual string ShortDescription
		{
			get
			{
				return $"{GetType().Name} " +
					   $"\nname: {name}" +
					   $"\ndate of birth: {DateOfBirth:dd-MM-yy}";
			}
		}
		public void WriteShortDescription()
		{
			Console.WriteLine(ShortDescription);
			
		}
	}
}
