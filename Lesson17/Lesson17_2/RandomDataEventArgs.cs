using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson17_2
{
	class RandomDataEventArgs : EventArgs
	{
		public int BytesDone { get; set; }

		public int TotalBytes { get; set; }
		
	}
}
