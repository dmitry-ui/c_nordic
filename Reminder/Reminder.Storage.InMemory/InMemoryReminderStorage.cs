using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		private Dictionary<Guid, ReminderItem> reminders;

		public void Add(ReminderItem reminderItem)
		{
			reminders.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid Id)
		{
			if (!reminders.ContainsKey(Id))
				return null;
				return reminders[Id];
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			//можно перебрать в цикле и добавить в список и список вернуть
			//можно через linq
			return 	reminders.Values.Where((ReminderItem ri) => ri.Status == status).ToList();
		}

		public void Update(Guid Id, ReminderItemStatus status)
		{
			if (reminders.ContainsKey(Id))
				reminders[Id].Status = status;
		}
	}
}
