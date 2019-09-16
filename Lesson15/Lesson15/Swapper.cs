using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson15
{
	public static class Swapper<T> where T : class, new()  // struct
	{
		public static void Swap(ref T a, ref T b) 
		{
			T temp = a;
			a = b;
			b = temp;
		}

		public static T GetDefaultObject()
		{
			return new T();
		}
	}
}
