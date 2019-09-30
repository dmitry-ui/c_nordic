using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSource
{
	public class CounterEventArgs: EventArgs
	{
		public int Percentage { get; set; }
	}
}
