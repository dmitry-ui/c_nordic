using System;
using System.Collections.Generic;

namespace Lesson08_2
{
	class Program
	{
		static void Main(string[] args)
		{
			List<double> doubleList = new List<double>();
			const string stop = "stop";
			string inputString = String.Empty;
			while (true)
			{
				inputString = Console.ReadLine();
				if (inputString == stop)
				{
					break;
				}
				double doubleVal = Double.Parse(inputString);
				doubleList.Add(doubleVal);
			}

			////сумма элементов
			double count = 0;
			foreach (double temp in doubleList)
				count += temp;
			Console.WriteLine(count);
			Console.WriteLine(count / doubleList.Count);











			Console.ReadLine();
		}
	}
}
