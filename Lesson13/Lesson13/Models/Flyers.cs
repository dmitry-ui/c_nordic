using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson13.Models
{
	public  class Flyers
	{
		public int MaxHeight { get; set;}

		public int CurrentHeight { get; set; }

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
				throw new Exception("Дельта должна быть больше нуля");
			else if ((CurrentHeight + delta) > MaxHeight)
				CurrentHeight = MaxHeight;
			else
				CurrentHeight = CurrentHeight + delta;
		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
				throw new Exception("Дельта должна быть больше нуля");
			else if ((CurrentHeight - delta) > 0)
				CurrentHeight = CurrentHeight -delta;
			else
				throw new Exception("Crush!!!");
		}

		public virtual void WriteAllProperties()
		{
			Console.WriteLine($"CurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
		}

	}
}
