﻿using System;
using Reminder.Storage.Core;

namespace Reminder.Domain.Models
{
	public class AddingToStorageFailedEventArgs : EventArgs
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public Exception ThrownException { get; set; }

		public AddingToStorageFailedEventArgs() { }

		public AddingToStorageFailedEventArgs(ReminderItem item, Exception exception)
		{
			Id = item.Id;
			Date = item.Date;
			Message = item.Message;
			ContactId = item.ContactId;
			Status = item.Status;
			ThrownException = exception;
		}
	}
}
