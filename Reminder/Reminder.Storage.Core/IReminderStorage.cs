using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
	public interface IReminderStorage
	{
		void Add(ReminderItem reminderItem);

		void Update(Guid Id, ReminderItemStatus status);

		ReminderItem Get(Guid Id);

		List<ReminderItem> Get(ReminderItemStatus status);

	}
}
