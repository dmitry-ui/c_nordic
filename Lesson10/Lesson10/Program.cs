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
			Pet1.Kind = Pet.Animals.Cat;
			Pet1.Name = "Petty";
			Pet1.Sex = 'm';
			Pet1.setBirthPlace("Moscow zoo");
			Console.WriteLine(Pet1.Description);

			Pet Pet2 = new Pet()
			{
				Age = 5,
				Kind = Pet.Animals.Dog,
				Name = "Sally",
				Sex = 'f',
			};
			Pet2.setBirthPlace("London zoo");
			Console.WriteLine(Pet2.Description);
			Console.ReadKey();
		}
	}

	class Pet
	{
		public enum Animals { Mouse, Cat, Dog }
		//public enum SexOf { M, F }
		private string _birthPlace;
		private char sexof;
		public Animals Kind;
		public string Name;

		public char Sex
		{
			get
			{
				return sexof;
			}
			set
			{
				if (Char.ToUpper(value).Equals('F') || Char.ToUpper(value).Equals('M'))
					sexof = Char.ToUpper(value);
				else
					throw new Exception();
			}

		}
		public int Age
		{ get;


			set;
		}
		public string Description
		{
			get
			{
				return $"{Name} is a {Kind} ({Sex}) of {Age} years old. It was born in {_birthPlace}";
			}
		}
		public void setBirthPlace(string par)
		{
			_birthPlace = par;
		}

	}



}