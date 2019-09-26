using System;
using System.Threading;

namespace Lesson17
{

	class Program
	{
		

		static void Main(string[] args)
		{
			/*WorkPerformedEventHandler del1 = WorkPerformed1;
			WorkPerformedEventHandler del2 = WorkPerformed2;
			WorkPerformedEventHandler del3 = WorkPerformed3;
			del1 += del2 + del3;
			//через делегат запустим  все три метода
			int Finalresult = del1(1, WorkType.Work);
			//т.к. третий метод последний, то увидим 4
			Console.WriteLine($"FinalResult {Finalresult}");
			*/

			Worker worker = new Worker();
			worker.WorkStarted += OnWorkStarted;
			worker.WorkPerformed += OnWorkPieceDone;
			worker.WorkCompleted += OnWorkCompleted;

			Thread thread1 = new Thread(() => worker.DoWork(5, WorkType.Work));
			Thread thread2 = new Thread(() => worker.DoWork(3, WorkType.DoNothing));

			thread1.Start();
			thread2.Start();
			
			//ждем завершения потоков
			thread1.Join();
			thread2.Join();

			Console.WriteLine("Finish");

			
			Console.ReadKey();
		}

		
		private static void OnWorkStarted(int hours, WorkType workType)
		{
			Console.WriteLine($"WorkStarted: {workType} {hours}");
		}

		private static void OnWorkPieceDone(int hours, WorkType workType)
		{
			Console.WriteLine($"{hours + 1} hours done");
		}

		private static void OnWorkCompleted(object sender, EventArgs e)
		{
			Console.WriteLine($"WorkCompleted: {sender}");
		}

		//private static int WorkPerformed1(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[1] Work of type {workType} performed for {hours} hours.");
		//	return hours + 1;
		//}

		//private static int WorkPerformed2(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[2] Work of type {workType} performed for {hours} hours.");
		//	return hours + 2;
		//}

		//private static int WorkPerformed3(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[3] Work of type {workType} performed for {hours} hours.");
		//	return hours + 3;
		//}
	}
}
