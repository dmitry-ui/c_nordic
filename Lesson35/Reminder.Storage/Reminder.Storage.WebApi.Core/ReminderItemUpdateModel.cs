﻿using System.ComponentModel.DataAnnotations;
using Reminder.Storage.Core;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemUpdateModel
	{
		[Required]
		public ReminderItemStatus Status { get; set; }
	}
}
