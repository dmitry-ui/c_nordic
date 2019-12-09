using System;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;

namespace Reminder.App.Debug
{
	class Program
	{
		static void Main(string[] args)
		{
			IReminderStorage storageClient = new ReminderStorageWebApiClient(
				"http://localhost:5000/api/reminders");

			// Check that without data storage returns empty list
			var emptyList = storageClient.Get(ReminderItemStatus.Awaiting);
			if (emptyList == null || emptyList.Count > 0)
				throw new Exception();

			// Add reminder item
			var id = storageClient.Add(
				DateTimeOffset.Now.AddMinutes(1),
				"Test Message",
				"12345678",
				ReminderItemStatus.Awaiting);

			// Check that just added reminder item returned by ID
			var item = storageClient.Get(id);
			if (item == null)
				throw new Exception();

			// Check that just added reminder item returned by status
			var awaitngList = storageClient.Get(ReminderItemStatus.Awaiting);
			if (awaitngList == null || awaitngList.Count != 1)
				throw new Exception();

			// Check that Get() by status returns empty list if no corresponding items found
			var readyList = storageClient.Get(ReminderItemStatus.Ready);
			if (readyList == null || readyList.Count != 0)
				throw new Exception();

			// Update item's status
			storageClient.Update(id, ReminderItemStatus.Failed);

			// Check that Get() by status returns not empty list
			var faliedList = storageClient.Get(ReminderItemStatus.Failed);
			if (faliedList == null || faliedList.Count != 1)
				throw new Exception();
		}
	}
}
