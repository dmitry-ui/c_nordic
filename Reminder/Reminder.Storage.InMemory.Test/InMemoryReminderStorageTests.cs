using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void Method_Get_should_return_remnderitemobject_by_guid()
        {
            //создадим в словаре две записи и получим эти две записи

            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
            const string contactId = "ABCD123";
            const string message = "test message";
            var item = new ReminderItem(date, message, contactId);
            Guid guid_item = item.Id;
            var storage = new InMemoryReminderStorage();
            storage.Add(item);

            DateTimeOffset date2 = DateTimeOffset.Parse("2019-01-02T00:00:00+00:00");
            const string contactId2 = "ABCD456";
            const string message2 = "test message2";
            var item2 = new ReminderItem(date2, message2, contactId2);
            Guid guid_item2 = item2.Id;
            storage.Add(item2);

            //do test
            ReminderItem rit = storage.Get(guid_item);
            ReminderItem rit2 = storage.Get(guid_item2);

            //check result
            Assert.IsTrue(storage.Reminders.ContainsKey(guid_item));
            Assert.AreEqual(date, rit.Date);
            Assert.AreEqual(contactId, rit.ContactId);
            Assert.AreEqual(message, rit.Message);

            Assert.IsTrue(storage.Reminders.ContainsKey(guid_item2));
            Assert.AreEqual(date2, rit2.Date);
            Assert.AreEqual(contactId2, rit2.ContactId);
            Assert.AreEqual(message2, rit2.Message);
        }

        [TestMethod]
        public void Method_Get_should_return_list_of_reminders_by_status()
        {
            var storage = new InMemoryReminderStorage();

            ReminderItem item = new ReminderItem(
                                        DateTimeOffset.Parse("2019-01-01T00:00:00+00:00"),
                                        "test message",
                                        "ABCD123"
                                        )
            {
                Status = ReminderItemStatus.Ready
            };
            storage.Add(item);

            ReminderItem item2 = new ReminderItem(
                                         DateTimeOffset.Parse("2019-01-02T00:00:00+00:00"),
                                         "test message2",
                                         "ABCD456"
                                         )
            {
                Status = ReminderItemStatus.Ready
            };
            storage.Add(item2);

            ReminderItem item3 = new ReminderItem(
                                        DateTimeOffset.Parse("2019-01-02T00:00:00+00:00"),
                                        "test message2",
                                        "ABCD456"
                                        )
            {
                Status = ReminderItemStatus.Failed
            };
            storage.Add(item3);

            //do
            List<ReminderItem> resReady = storage.Get(ReminderItemStatus.Ready);
            List<ReminderItem> resFailed = storage.Get(ReminderItemStatus.Failed);
            List<ReminderItem> resAwating = storage.Get(ReminderItemStatus.Awating);
            List<ReminderItem> resSent = storage.Get(ReminderItemStatus.Sent);

            //
            foreach (ReminderItem ri in resReady)
            {
                Assert.AreEqual(ri.Status, ReminderItemStatus.Ready);
            }


            foreach (ReminderItem ri in resFailed)
            {
                Assert.AreEqual(ri.Status, ReminderItemStatus.Failed);
            }

            Assert.AreEqual(resReady.Count, 2);
            Assert.AreEqual(resFailed.Count, 1);
            Assert.AreEqual(resAwating.Count, 0);
            Assert.AreEqual(resSent.Count, 0);
        }

        [TestMethod]
        public void Method_Update_should_update_status()
        {
            var storage = new InMemoryReminderStorage();

            ReminderItem item = new ReminderItem(
                                        DateTimeOffset.Parse("2019-01-01T00:00:00+00:00"),
                                        "test message",
                                        "ABCD123"
                                        );
            Guid guid = item.Id;
            storage.Add(item);

            //do
            storage.Update(guid, ReminderItemStatus.Sent);

            //
            Assert.AreEqual(ReminderItemStatus.Sent, storage.Reminders[guid].Status);
            storage.Update(guid, ReminderItemStatus.Ready);
            Assert.AreEqual(ReminderItemStatus.Ready, storage.Reminders[guid].Status);
        }
    }
}