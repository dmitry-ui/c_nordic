using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13.Models
{
	class Plane :Flyers
	{
		private byte _enginesCount;

		public byte EnginesCount
		{
			get
			{
				return _enginesCount;
			}
			set
			{
				if (value <= 0)
					throw new Exception("Число двигателей самолета должно быть больше нуля");
				else _enginesCount = value;
			}
		}

		public Plane(int maxHeight, byte enginesCount)
		{
			MaxHeight = maxHeight;
			EnginesCount = enginesCount;
			CurrentHeight = 0;
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine($"EnginesCount: {EnginesCount}");
		}
	}
}
