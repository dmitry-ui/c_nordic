using Newtonsoft.Json;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.SqlServer.ADO.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var storage = new SqlReminderStorage(
				@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Reminder;Integrated Security=true;");

			//test add
			Guid id = storage.Add(
				DateTimeOffset.Now.AddMinutes(1),
				"Test message",
				"012345",
				Core.ReminderItemStatus.Failed);

			Console.WriteLine(id);

			//test get(id)
			var reminderItem = storage.Get(id);
			Console.WriteLine(JsonConvert.SerializeObject(reminderItem));


			//test get(status)
			storage.Add(
			DateTimeOffset.Now.AddMinutes(1),
			"Test message",
			"012345",
			Core.ReminderItemStatus.Failed);

			var list = storage.Get(ReminderItemStatus.Failed);

			Console.WriteLine(list.Count);

			list = storage.Get(ReminderItemStatus.Ready);  //проверка на  нулевую ссылку
			Console.WriteLine(list.Count);

			//test update
			storage.Update(id, ReminderItemStatus.Sent);
			list = storage.Get(ReminderItemStatus.Sent);
			Console.WriteLine(list.Count);

			Console.ReadKey();
		}
	}
}
