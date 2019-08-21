using System;
using System.Collections.Generic;

namespace Lesson08_2
{
	class Program
	{
		static void Main(string[] args)
		{
			////связанные списки
			//List<double> doubleList = new List<double>();
			//const string stop = "stop";
			//string inputString = String.Empty;
			//while (true)
			//{
			//	inputString = Console.ReadLine();
			//	if (inputString == stop)
			//	{
			//		break;
			//	}
			//	double doubleVal = Double.Parse(inputString);
			//	doubleList.Add(doubleVal);
			//}

			//////сумма элементов и среднее арифметическое
			//double count = 0;
			//foreach (double temp in doubleList)
			//	count += temp;
			//Console.WriteLine(count);
			//Console.WriteLine(count / doubleList.Count);

			//словари
			//Dictionary<int, string> countries = new Dictionary<int, string>(5);
			//countries.Add(1, "Russia");
			//countries.Add(2, "Grate Britan");
			//countries.Add(3, "USA");
			//countries.Add(4, "France");
			//countries.Add(5, "China");

			//foreach (KeyValuePair<int, string> keyValue in countries)
			//	Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
			//string country = countries[4];  //4- это ключ
			//countries[4] = "Spain";
			//countries.Remove(2);
			//Console.WriteLine();
			//foreach (KeyValuePair<int, string> keyValue in countries)
			//	Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");


			//Dictionary<string, string> countries1 = new Dictionary<string, string>(5);
			//countries1.Add("1qw", "Russia");
			//countries1.Add("2qw", "Grate Britan");
			//countries1.Add("3ee", "USA");
			//countries1.Add("4w", "France");
			//countries1.Add(5.ToString(), "China");
			//foreach (KeyValuePair<string, string> keyValue in countries1)
			//	Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
			//string country1 = countries1["4w"];  //4w- это ключ

			//Console.WriteLine(" f fg  f g f gfgf  {0} fgdg  fd g fdg  {0}", countries1["4w"]);




			Stack<string> type = new Stack<string>();
			type.Push("wash");

			while (type.Count>0)
			{
				string inpitValue = Console.ReadLine();
				if (inpitValue == "wash")
					type.Push("wash");
				if (inpitValue == "dry")
					type.Pop();
			}
			Console.WriteLine("стопка пуста");




			//foreach (string number in numbers)
			//{
			//	Console.WriteLine(number);
			//}
			//while (numbers.Count > 0)
			//{
			//	string n = numbers.Pop();
			//	Console.Write($"Processing \"{n}\"... ");
			//	// here we can really do something with popped element :)
			//	Console.WriteLine("OK");
			//}










			Console.ReadKey();
		}
	}
}
