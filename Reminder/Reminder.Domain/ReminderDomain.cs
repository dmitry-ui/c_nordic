using Reminder.Storage.Core;
using System;
using System.Threading;

namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		//изменяем статус
		private IReminderStorage _storage;
		//период опроса
		private TimeSpan _awaitingRemindersCheckingPeriod;
		//период отправки(для записей в статусе ready попытаться отправить их. Если ок то статус send, иначе статус Failed)
		private TimeSpan _ReadyRemindersSendingPeriod;
		//таймер
		private Timer _awaitingRemindersCheckingTimer;
		private Timer _ReadyRemindersSendingPeriodTimer;

		//делегат для оправки
		public Action<ReminderItem> SendReminder{get;set;}

		public ReminderDomain(IReminderStorage storage) : this (storage, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
		{
		}

		public ReminderDomain(IReminderStorage storage, TimeSpan awaitingRemindersCheckingPeriod, TimeSpan ReadyReminderssendingPeriod)
		{
			_storage = storage;
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_ReadyRemindersSendingPeriod = ReadyReminderssendingPeriod;
		}

		//метод который запустит процесс и начнет обрабатывать очереди
		public void Run()
		{
			_awaitingRemindersCheckingTimer = new Timer(CheckAwaitingReminders, null, TimeSpan.Zero, _awaitingRemindersCheckingPeriod);
			_ReadyRemindersSendingPeriodTimer = new Timer(SendReadyReminders, null, TimeSpan.FromSeconds(1), _ReadyRemindersSendingPeriod);
		}

		private void SendReadyReminders(object state)
		{
			//ищем записи
			var readyReminders = _storage.Get(ReminderItemStatus.Ready);
				foreach (var readyReminder in readyReminders)
			{
				try
				{
					SendReminder(readyReminder);
					_storage.Update(readyReminder.Id, ReminderItemStatus.Sent);
				}
				catch
				{
					_storage.Update(readyReminder.Id, ReminderItemStatus.Failed);
				}
			}

			//отправляем

			//Если ок  то в статус send, иначе failed

		}

		private void CheckAwaitingReminders(object state)
		{
			//здесь будем смотреть хранилище на предмет выбора записей в статусе awaiting готовых к отправки
			var awaitingReminders = _storage.Get(ReminderItemStatus.Awating);
			foreach(var awaitingReminder in awaitingReminders)
			{
				if(awaitingReminder.IsReadyToSend)
				{
					_storage.Update(awaitingReminder.Id, ReminderItemStatus.Ready);
				}
			}
		}

		public void Dispose()
		{
			//проверим на null  и если  то запускаем
			_awaitingRemindersCheckingTimer?.Dispose();
			_ReadyRemindersSendingPeriodTimer?.Dispose();
		}
	}
}
