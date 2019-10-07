using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get;}

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public TimeSpan TimeToAllarm => Date - DateTimeOffset.Now;

		public bool IsReadyToSend => DateTimeOffset.Now > Date;

		public ReminderItem(DateTimeOffset dt, string message, string contactId)
		{
			Id = Guid.NewGuid();
			Date = dt;
			Message = message;
			ContactId = contactId;
			Status = ReminderItemStatus.Awating;
		}
	}
}
