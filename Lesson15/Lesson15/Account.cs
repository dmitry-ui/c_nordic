using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson15
{
	class Account<T, T1>
	{
		public T Id { get; set; }
		public T1 Name { get; private set;}

		public Account(T id, T1 name)
		{
			Id = id;
			Name = name;
		}

		public void WriteProperties()
		{
			Console.WriteLine($"Id = {Id}, Name = {Name}");
		}



	}
}
