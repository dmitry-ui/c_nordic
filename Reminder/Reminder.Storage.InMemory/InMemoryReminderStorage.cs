using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		internal Dictionary<Guid, ReminderItem> Reminders;

		public void Add(ReminderItem reminderItem)
		{
			Reminders.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid Id)
		{
			if (!Reminders.ContainsKey(Id))
				return null;
				return Reminders[Id];
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			//можно перебрать в цикле и добавить в список и список вернуть
			//можно через linq
			return Reminders.Values.Where((ReminderItem ri) => ri.Status == status).ToList();
		}

		public void Update(Guid Id, ReminderItemStatus status)
		{
			if (Reminders.ContainsKey(Id))
				Reminders[Id].Status = status;
		}
	}
}
