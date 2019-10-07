using System;
using System.Collections.Generic;
using System.Text;

namespace PublishAndSubscribeEvents
{
	using System;
	using System.Collections.Generic;

	// Define a class to hold custom event info
	//возможность использования класса CustomEventArgs
	//в параметрах обработчика событий созданного через делегат
	public class CustomEventArgs : EventArgs
	{
		private string message;

		public CustomEventArgs(string s)
		{
			message = s;
		}
		
		public string Message
		{
			get { return message; }
			set { message = value; }
		}
	}
}
