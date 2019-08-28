using System;
//using anotherNamwspace;  //для MyDemoClass
namespace Lesson10
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet Pet1 = new Pet();
			Pet1.Age = 10;
			Pet1.Kind = Pet.Enimals.Cat;
			Pet1.Name = "Petty";
			Pet1.Sex = Pet.SexOf.F;
			Console.WriteLine($"{Pet1.Name} is a {Pet1.Kind} ({Pet1.Sex}) of {Pet1.Age} years old.");

			Pet Pet2 = new Pet()
			{
				Age = 10,
				Kind = Pet.Enimals.Cat,
				Name = "Petty",
				Sex = Pet.SexOf.F
			};
			Console.WriteLine($"{Pet2.Name} is a {Pet2.Kind} ({Pet2.Sex}) of {Pet2.Age} years old.");
			Console.ReadKey();
		}
	}

	class Pet
	{
		public enum Enimals { Mouse, Cat, Dog }
		public enum SexOf { M, F }
		private string _birthPlace;
		public Enimals Kind;
		public string Name;
		public SexOf Sex { get; set; }
		public int Age { get; set; }
	}



}