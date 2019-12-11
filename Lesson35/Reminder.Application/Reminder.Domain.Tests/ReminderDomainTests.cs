using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;
using Moq;
using Reminder.Receiver.Core;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		[TestMethod]
		public void Method_Run_Should_Update_Ready_To_Send_Reminders_To_Status_Ready_From_Awiating()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(DateTimeOffset.Now, null, null, ReminderItemStatus.Awaiting);

			//создает класс содержащий  интерфейс
			var mockReceiver = new Mock<IReminderReceiver>();
			var fakeReceiver = mockReceiver.Object;


			using (var domain = new ReminderDomain(
				storage,
				fakeReceiver,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(1)))
			{
				domain.Run();
				System.Threading.Thread.Sleep(200);
			}

			var readyList = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(readyList);
			Assert.AreEqual(1, readyList.Count);
		}

		[TestMethod]
		public void Method_Run_Should_Call_Failed_Event_When_Sending_does_not_Thrown()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(DateTimeOffset.Now, null, null, ReminderItemStatus.Awaiting);

			bool failedEventCalled = false;

			//создает класс содержащий  интерфейс
			var mockReceiver = new Mock<IReminderReceiver>();
			var fakeReceiver = mockReceiver.Object;

			using (var domain = new ReminderDomain(
				storage,
				fakeReceiver,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (reminder) =>
				{
					throw new Exception("test exception");
				};

				domain.SendingFailed += (s, e) =>
				{
					if (e.SendingException.Message == "test exception")
					{
						failedEventCalled = true;
					}
				};

				domain.Run();
				System.Threading.Thread.Sleep(1200);
			}

			Assert.IsTrue(failedEventCalled);
		}

		[TestMethod]
		public void Method_Run_Should_Call_Succeedded_Event_When_Sending_Thrown_Exception()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(DateTimeOffset.Now, null, null, ReminderItemStatus.Awaiting);

			bool succeededEventCalled = false;

			//создает класс содержащий  интерфейс
			var mockReceiver = new Mock<IReminderReceiver>();
			var fakeReceiver = mockReceiver.Object;

			using (var domain = new ReminderDomain(
				storage,
				fakeReceiver,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (reminder) => { };

				domain.SendingSucceeded += (s, e) =>
				{
					succeededEventCalled = true;
				};

				domain.Run();
				System.Threading.Thread.Sleep(1200);
			}

			Assert.IsTrue(succeededEventCalled);
		}
	}
}
