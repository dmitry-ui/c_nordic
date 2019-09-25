using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Test
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Constructor_Should_Fill_Properties_Correctly()
		{
			//prepare test data
			DateTimeOffset date = DateTimeOffset.Parse("2010-01-01T00:00:00");
			
			//do test
			const string contactId = "0123abc";
			const string message = "Test message";

			var reminderItem = new ReminderItem(date, message, contactId);
			
			//chek results
			Assert.IsNotNull(reminderItem);
			Assert.AreEqual(date, reminderItem.Date);
			Assert.AreEqual(message, reminderItem.Message);
			Assert.AreEqual(contactId, reminderItem.ContactId);
		}

		public void Constructor_Should_Fill_ID_Other_Then_guid_empty()
		{
			//prepare test data
			DateTimeOffset date = DateTimeOffset.Parse("2010-01-01T00:00:00");

			//do test
			const string contactId = "0123abc";
			const string message = "Test message";

			var reminderItem = new ReminderItem(date, message, contactId);

			//chek results
			Assert.AreNotEqual(Guid.Empty, reminderItem.Id);

		}
	}
}
