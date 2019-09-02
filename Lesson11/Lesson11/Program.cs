using System;
using Lesson11.Classes;
//using anotherNamwspace;  //для MyDemoClass
namespace Lesson11
{
	class Program
	{
		static void Main(string[] args)
		{
			Pet Pet1 = new Pet("Petty", Pet.Animals.Cat);
			Pet1.DateOfBirth = DateTime.Parse("2001-09-01");
			//Pet1.Kind = Pet.Animals.Cat;
			//Pet1.Name = "Petty";
			Pet1.Sex = 'm';
			Pet1.setBirthPlace("Moscow zoo");
			//Console.WriteLine(Pet1.Description);
			Pet1.WriteOutDescription(true);
			Pet1.WriteOutDescription(false);
			Pet1.WriteOutDescription();
			Pet1.UpdateProperties("Конь", 'm');
			Pet1.UpdateProperties("Конь", Pet.Animals.Mouse);
			Pet1.UpdateProperties("Конь", Pet.Animals.Mouse, 'F');
			Pet1.WriteOutDescription(true);
			Pet1.WriteOutDescription(false);
			Pet1.WriteOutDescription();


			Console.ReadKey();
		}
	}
}