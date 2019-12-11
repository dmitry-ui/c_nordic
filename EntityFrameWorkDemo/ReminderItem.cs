using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkDemo
{
	public enum ReminderItemStatus
	{
		Awaiting,
		Ready,
		Sent,
		Failed
	}

	public class ReminderItem
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

	}
}
