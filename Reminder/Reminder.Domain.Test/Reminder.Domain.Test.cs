using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Method_Run_Should_Update_to_send_reminders_to_send_reminders_to()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));
			using (var domain = new ReminderDomain(storage, TimeSpan.FromMilliseconds(50), TimeSpan.FromSeconds(1)))
			{
				domain.Run();
				System.Threading.Thread.Sleep(200);
			}

			var readyList = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(readyList);
			Assert.AreEqual(1, storage.Get(ReminderItemStatus.Ready).Count);
		}

		////
		[TestMethod]
		public void Method_Run_Should_Call_Failed_Event_When_Sending_Throw_Exception()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));
			bool failedEventCalled = false;
			using (var domain = new ReminderDomain(storage, TimeSpan.FromMilliseconds(50), TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (reminder) =>
				{
					throw new Exception("test exception");
				};
				domain.SendingFailed += (s, e) =>
				{
					if(e.SendingException.Message == "test exception")
					failedEventCalled = true;
				};

				domain.Run();
				System.Threading.Thread.Sleep(200);
			}

			var readyList = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(readyList);
			Assert.AreEqual(1, storage.Get(ReminderItemStatus.Ready).Count);
		}
	}
}
