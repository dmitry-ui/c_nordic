using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.InMemory.Test
{
	[TestClass]
	public class InMemoryReminderStorageTests
	{
		[TestMethod]
		public void Method_Add_showld_Add_new_Item_to_Internal_Dictionary()
		{
			//будем вызывать ADD  и смотреть в словарь
			DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
			const string contactId = "ABCD123";
			const string message = "test message";
			var item = new ReminderItem(date, message, contactId);
			var storage = new InMemoryReminderStorage();

			//do test
			storage.Add(item);

			//check result
			Assert.IsTrue(storage.Reminders.ContainsKey(item.Id));
			Assert.AreEqual(message, storage.Reminders[item.Id].Message);
			Assert.AreEqual(date, storage.Reminders[item.Id].Date);
			Assert.AreEqual(contactId, storage.Reminders[item.Id].ContactId);
		}

		//надо покрыть тестами остальные методы
	}
}
