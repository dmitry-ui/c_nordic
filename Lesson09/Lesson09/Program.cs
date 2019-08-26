using System;
using System.Diagnostics;

namespace Lesson09
{
	class Program
	{
		static void Main(string[] args)
		{
			const int length = 30000;
			const int maxValue = int.MaxValue;
			int a = 10;
			Stopwatch sw = new Stopwatch();
			UpdateValue(ref a);   //передается по ссылке
			Console.WriteLine(a);
			int[] arr = GetInitialArray(length, maxValue);
			//OutputArray(arr, "Исходные данные:");
			sw.Start();
			int[] arr1 = BubleSort(arr);
			sw.Stop();
			Console.WriteLine("{0}", sw.ElapsedMilliseconds);

			sw.Restart();
			int[] sortedArray = SystemSort(arr);
			sw.Stop();
			Console.WriteLine("{0}", sw.ElapsedMilliseconds);

			//OutputArray(arr1, "Результирующие данные arr1:");
			//OutputArray(sortedArray, "Результирующие данные sortedArray:");
			Console.ReadKey();
		}

		public static int[] GetInitialArray(int arrayLenght, int maxEleventValue)
		{
			int[] arr = new int[arrayLenght];
			var rnd = new Random();

			for (int i = 0; i < arr.Length; i++)
				arr[i] = rnd.Next(maxEleventValue);

			return arr;
		}
		public static void OutputArray(int[] arr, string message)
		{
			Console.WriteLine(message);
			Console.WriteLine(string.Join(",  ", arr) + "\n");
		}
		public static int[] BubleSort(int[] inputArr)
		{
			//int[] arr = new int[inputArr.Length];
			//for(int i = 0; i<arr.Length; i++)
			//{
			//	arr[i] = inputArr[i];
			//}

			int[] arr = (int[])inputArr.Clone();


			for (int j = 0; j < arr.Length - 1; j++)
				for (int i = 0; i < arr.Length - 1 - j; i++)
				{
					if (arr[i] > arr[i + 1])
					{
						int temp = arr[i];
						arr[i] = arr[i + 1];
						arr[i + 1] = temp;
					}
				}
			return arr;
		}
		public static void UpdateValue(ref int a) //передается по ссылке
		{
			a++;
			Console.WriteLine(a);
		}
		private static int[] SystemSort(int[] arr)
		{
			int[] a = (int[])arr.Clone();
			Array.Sort(a);    //встроенная функция сортировки
			return a;
		}
	}
}
