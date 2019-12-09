using System;
using Reminder.Storage.Core;

namespace Reminder.Domain.Models
{
	public class AddingToStorageFailedEventArgs : EventArgs
	{
		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public Exception ThrownException { get; set; }

		public AddingToStorageFailedEventArgs() { }

		public AddingToStorageFailedEventArgs(
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status,
			Exception exception)
		{
			Date = date;
			Message = message;
			ContactId = contactId;
			Status = status;
			ThrownException = exception;
		}
	}
}
