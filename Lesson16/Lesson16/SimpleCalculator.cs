using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lesson16
{
	class SimpleCalculator
	{
		public static int Sum(int x,  int y)
		{
			Debug.WriteLine("Sum()"); //вывод в output вместо консоли
			return x + y;
		}

		public static int Multiply(int x, int y)
		{
			Debug.WriteLine("Multiply()");
			return x * y;
		}

		public static int Devide(int x, int y)
		{
			Debug.WriteLine("Devide()");
			return x / y;
		}
	}
}
