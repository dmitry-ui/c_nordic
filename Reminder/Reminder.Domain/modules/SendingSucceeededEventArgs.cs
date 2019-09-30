using Reminder.Storage.Core;
using System;

namespace Reminder.Domain
{
	public class SendingSucceeededEventArgs : EventArgs
	{
		public ReminderItem SendingItem { get; set; }
		public Exception SendingException { get; set; }
	}
}