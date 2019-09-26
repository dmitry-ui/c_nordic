using System;
using System.IO;
using System.IO.Compression;

namespace Lesson17_2
{
	class Program
	{
		static void Main(string[] args)
		{
			const string binaryFileName = "random.data";
			const string zipFileName = binaryFileName +".zip";

			var gen = new RandomDataGenerator();
			gen.RandomDataGenerated += OnRandomDataGenerated;
			gen.RandomDataGenerationDone += OnRandomDataGenerationDone;

			var randomBytes = gen.GetRandomData(1000000, 10000);

			File.WriteAllBytes(binaryFileName, randomBytes);

			if (File.Exists(zipFileName))
				File.Delete(zipFileName);

			using (var zip = ZipFile.Open(binaryFileName + ".zip", ZipArchiveMode.Create))
				zip.CreateEntryFromFile(binaryFileName, binaryFileName);
					   			 		  		  
				Console.ReadKey();
		}

		private static void OnRandomDataGenerationDone(object sender, RandomDataGenerationDoneEventArgs e)
		{
			Console.WriteLine($"Готово: {Convert.ToBase64String(e.RandomData)}");
		}

		private static void OnRandomDataGenerated(object sender, RandomDataEventArgs e)
		{
			Console.WriteLine($"Готово {e.BytesDone} из  {e.TotalBytes}");
		}

		//private static void OnRandomDataGenerated____(int byteDone, int totalBytes)
		//{
		//	Console.WriteLine($"Готово {byteDone} из  {totalBytes}");
		//}
	}
}
