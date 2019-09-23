using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson17
{
	public delegate void WorkStartedEventHandler(int hours, WorkType workType);

	class Worker
	{
		public event WorkStartedEventHandler WorkStarted;
		
		//сист делегат
		public event WorkStartedEventHandler WorkPerformed;
		public event EventHandler WorkCompleted;

		public void DoWork(int hours, WorkType workType)
		{
			//if (WorkStarted != null)
			//	WorkStarted(hours, workType);

			WorkStarted?.Invoke(hours, workType);

			for (int i = 0; i < hours; i++)
			{
				System.Threading.Thread.Sleep(500);
				//if (WorkPieceDone != null)
				//	WorkPieceDone(i + 1, workType);
				//WorkPerformed?.Invoke(i + 1, workType);
				OnWorkPerformed(i + 1, workType);
			}
				//Console.WriteLine($"{i+1} hours done");

			//if (WorkCompleted != null)
			//	WorkCompleted(this, EventArgs.Empty);

			WorkCompleted?.Invoke(this, EventArgs.Empty);

		}

		private void OnWorkPerformed(int hours, WorkType workType)
		{
			WorkPerformed?.Invoke(hours, workType);
		}
	}
}
