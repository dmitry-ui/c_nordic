using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.InMemory.Tests
{
    [TestClass]
    public class InMemoryReminderStorageTests
    {
        [TestMethod]
        public void AddMethodToStorage()
        {
            //prepare data

            DateTimeOffset date = DateTimeOffset.Parse(
                   "2019-01-01T00:00:00");
            const string contactId = "123qw";
            const string message = "Позвони маме";

            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            InMemoryReminderStorage Storage = new InMemoryReminderStorage();

            //do test
            Storage.Add(ri);

            //check result
            //в хранилище есть нужная запись
            Assert.IsTrue(Storage.Reminders.ContainsKey(ri.Id));
            Assert.AreEqual(contactId, Storage.Reminders[ri.Id].ContactId);
            Assert.AreEqual(date, Storage.Reminders[ri.Id].Date);
            Assert.AreEqual(message, Storage.Reminders[ri.Id].Message);
            Assert.AreEqual(ReminderItemStatus.Awating, Storage.Reminders[ri.Id].Status);
        }

        [TestMethod]
        public void GetMethodFromStorage()
        {
            //prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00");
            const string contactId = "1f23qw";
            const string message = "Позвони папе";

            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            InMemoryReminderStorage Storage = new InMemoryReminderStorage();
            Storage.Reminders.Add(ri.Id, ri);

            //do test
            ReminderItem item = Storage.Get(ri.Id);
            ReminderItem item2 = Storage.Get(Guid.Empty);

            //check result
            //null если нет такого guid в хранилище
            Assert.IsNull(item2);
            //в хранилище то что надо
            Assert.AreEqual(date, item.Date);
            Assert.AreEqual(contactId, item.ContactId);
            Assert.AreEqual(message, item.Message);
        }

        [TestMethod]
        public void GetMethodFromStorageToList()
        {
            //prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00");
            DateTimeOffset date2 = DateTimeOffset.Parse("2019-02-01T00:00:00");
            DateTimeOffset date3 = DateTimeOffset.Parse("2019-03-01T00:00:00");
            const string contactId = "1f231qw";
            const string contactId2 = "1f232qw";
            const string contactId3 = "1f233qw";
            const string message = "Позвони папе";
            const string message2 = "Пора домой";
            const string message3 = "Пора на работу";

            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            ReminderItem ri2 = new ReminderItem
                (
                    date2,
                    message2,
                    contactId2
                );

            ReminderItem ri3 = new ReminderItem
                (
                    date3,
                    message3,
                    contactId3
                );
            ri3.Status = ReminderItemStatus.Sent;

            InMemoryReminderStorage Storage = new InMemoryReminderStorage();
            Storage.Reminders.Add(ri.Id, ri);
            Storage.Reminders.Add(ri2.Id, ri2);
            Storage.Reminders.Add(ri3.Id, ri3);

            //do test
            List<ReminderItem> lri = Storage.Get(ReminderItemStatus.Awating);

            //check result
            Assert.AreEqual(ri, lri[0]);
            Assert.AreEqual(ri2, lri[1]);
            Assert.AreNotEqual(ri3, lri[0]);
            Assert.AreNotEqual(ri3, lri[1]);
        }

        [TestMethod]
        public void UpdateMethodInStorage()
        {
            //prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-04-01T00:00:00");
            const string contactId = "1f237qw";
            const string message = "Хочу есть";

            ReminderItem ri = new ReminderItem
                (
                    date,
                    message,
                    contactId
                );

            InMemoryReminderStorage Storage = new InMemoryReminderStorage();
            Storage.Reminders.Add(ri.Id, ri);

            //do test
            Storage.Update(ri.Id, ReminderItemStatus.Ready);

            //check results
            Assert.AreEqual(ReminderItemStatus.Ready, Storage.Reminders[ri.Id].Status);
        }
    }
}
