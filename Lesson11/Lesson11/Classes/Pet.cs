using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11.Classes
{
	class Pet
	{
		public enum Animals { Mouse, Cat, Dog }
		//public enum SexOf { M, F }
		private string _birthPlace;
		private char sexof;
		private DateTime _dateOfBirth;
		public Animals Kind;
		public string shortDescription 
		{
			get
			{
				return $"Имя {Name}, тип {Kind}.";
			}
		}
		public string Name
		{ get; set; }
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
			set
			{
				_dateOfBirth = value;
			}
		}
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
		{
			get
			{
				DateTime CurentDate = DateTime.Now;
				return (Int32)((CurentDate - DateOfBirth).Days/365.242);
			}
		}
		public string Description
		{
			get
			{
				return $"{Name} is a {Kind} ({Sex}) of {Age} years old. It was born in {_birthPlace}";
			}
		}
		public Pet(string name)
		{
			Name = name;
		}
		public Pet(string name, Animals kind) : this(name)
		{
			Kind = kind;
		}
		public Pet()
		{
		}
		public void setBirthPlace(string par)
		{
			_birthPlace = par;
		}
		public void WriteOutDescription(bool isShortDescripthion=false)
		{
			if (isShortDescripthion)
				Console.WriteLine(shortDescription);
			else
				Console.WriteLine(Description);
		}
		public void UpdateProperties(string name, char sex)
		{
			Name = name;
			Sex = sex;
		}
		public void UpdateProperties(string name, Animals kind)
		{
			Name = name;
			Kind = kind;
		}
		public void UpdateProperties(string name, Animals kind, char sex)
		{
			Name = name;
			Kind = kind;
			Sex = sex;
		}
		
	}
}



