using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using Reminder.Storage.Core;

namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTests
    {
        [TestMethod]
        public void Constructor_Parameters_Should_Fill_Properties_Correctly()
        {
            //prepare data
            //ReminderItem ri = new ReminderItem();
            DateTimeOffset date = DateTimeOffset.Parse(
                "2019-01-01T00:00:00");
            const string contactId = "123qw";
            const string message = "Позвони маме";
            //ReminderItemStatus status = ReminderItemStatus.Awating;

            //do test
            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            //check result
            Assert.IsNotNull(ri);
            Assert.AreEqual(date, ri.Date);
            Assert.AreEqual(message, ri.Message);
            Assert.AreEqual(contactId, ri.ContactId);
        }

        [TestMethod]
        public void Constructor_Should_Fill_Id_other_Then_Guid_Empty()
        {
            //prepare data
            //ReminderItem ri = new ReminderItem();
            DateTimeOffset date = DateTimeOffset.Parse(
                "2019-01-01T00:00:00");
            const string contactId = "123qw";
            const string message = "Позвони маме";
            //ReminderItemStatus status = ReminderItemStatus.Awating;

            //do test
            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            //check result
            Assert.AreNotEqual(Guid.Empty, ri.Id);
        }
    }
}
