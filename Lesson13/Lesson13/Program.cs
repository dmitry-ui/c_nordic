using Lesson13.Models;
using System;

namespace Lesson13
{
	class Program
	{
		static void Main(string[] args)
		{
			Plane pl = new Plane(5000, 4);
			pl.WriteAllProperties();
			pl.TakeUpper(2000);
			pl.WriteAllProperties();
			pl.TakeLower(1000);
			pl.WriteAllProperties();

			Console.WriteLine();

			Helicopter hc = new Helicopter(5000, 4);
			hc.WriteAllProperties();
			hc.TakeUpper(2000);
			hc.WriteAllProperties();
			hc.TakeLower(1000);
			hc.TakeUpper(10000);
			hc.WriteAllProperties();

			Flyers fl = new Flyers();

			Console.ReadKey();
		}
	}
}
