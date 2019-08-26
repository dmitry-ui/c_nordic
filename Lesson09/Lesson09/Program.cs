using System;

namespace Lesson09
{
	class Program
	{
		static void Main(string[] args)
		{
			const int length = 10;
			const int maxValue = 100;
			int a = 10;
			UpdateValue(ref a);   //передается по ссылке
			Console.WriteLine(a);
			int[] arr = GetInitialArray(length, maxValue);
			OutputArray(arr, "Исходные данные:");
			int[] arr1 = BubleSort(arr);

			OutputArray(arr, "Результирующие данные:");
			OutputArray(arr1, "Результирующие данные:");
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
	}
}
