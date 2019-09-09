using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13.Models
{
	class Helicopter : Flyers
	{
		public byte BladesCount { get; set; }

		public Helicopter(int maxHewight, byte bladesCount)
		{
			MaxHeight = maxHewight;
			BladesCount = bladesCount;
			CurrentHeight = 0;
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine($"BladesCount: {BladesCount}");
		}
	}
}
