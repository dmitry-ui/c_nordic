using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Tests
{
    [TestClass]
    public class ReminderDomainTests
    {
        [TestMethod]
        public void Correct_Change_Status_To_Ready()
        {
            //var item = new ReminderItem();
            var storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromSeconds(1)))
            {
                //�.�. ������� � ������ ������������ ��� � �������, ���� ��������� ���� ������
                domain.Run();
                System.Threading.Thread.Sleep(200);
            }
            //��������
            var readyList = storage.Get(ReminderItemStatus.Ready);
            //g������ ������, � �� null
            Assert.IsNotNull(readyList);
            Assert.AreEqual(1, readyList.Count);
        }

        [TestMethod]
        public void Call_FailedEvent()
        {
            //var item = new ReminderItem();
            var storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

            bool failedEventCalled = false;
            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromSeconds(50)))
            {
                //�.�. ������� � ������ ������������ ��� � �������, ���� ��������� ���� ������

                domain.SendReminder += (r) =>
                {
                    throw new Exception("�������� ����������");
                };
                domain.SendingFailed += (s, e) =>
                {
                    if (e.SendingException.Message == "�������� ����������")
                    {
                        failedEventCalled = true;
                    }

                };

                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }

            //��������
            Assert.IsTrue(failedEventCalled);
           
        }
    }
}
