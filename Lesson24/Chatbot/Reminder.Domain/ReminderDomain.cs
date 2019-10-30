using System;
using System.Threading;
using Reminder.Domain.Models;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Storage.Core;
using MessageReceivedEventArgs = Reminder.Domain.Models.MessageReceivedEventArgs;

namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		private IReminderStorage _storage;
		private IReminderReceiver _receiver;

		private readonly TimeSpan _awaitingRemindersCheckingPeriod;
		private readonly TimeSpan _readyRemindersSendingPeriod;

		private Timer _awaitingRemindersCheckingTimer;
		private Timer _readyRemindersSendingTimer;

		public Action<ReminderItem> SendReminder { get; set; }

		public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;

		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public event EventHandler<MessageParsingSucceddedEventArgs> MessageParsingSuccedded;
		public event EventHandler<MessageParsingFailedEventArgs> MessageParsingFailed;

		public event EventHandler<AddingToStorageSucceddedEventArgs> AddingToStorageSuccedded;
		public event EventHandler<AddingToStorageFailedEventArgs> AddingToStorageFailed;

		public ReminderDomain(
			IReminderStorage storage,
			IReminderReceiver receiver,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersSendingPeriod)
		{
			_storage = storage;
			_receiver = receiver;
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersSendingPeriod = readyRemindersSendingPeriod;

			_receiver.MessageReceived += Receiver_MessageReceived;
		}

		private void Receiver_MessageReceived(object sender, Receiver.Core.MessageReceivedEventArgs e)
		{
			MessageReceivedInvoke(e.ContactId, e.Message);
			ParsedMessage parsedMessage;

			try
			{
				parsedMessage = MessageParser.Parse(e.Message);
				MessageParsingSucceddedInvoke(e.ContactId, parsedMessage.Date, parsedMessage.Message);
			}
			catch (Exception ex)
			{
				MessageParsingFailedInvoke(e.ContactId, e.Message, ex);
				return;
			}

			var item = new ReminderItem(
				parsedMessage.Date,
				parsedMessage.Message,
				e.ContactId);

			try
			{
				_storage.Add(item);
				AddingToStorageSucceddedInvoke(item);
			}
			catch (Exception ex)
			{
				AddingToStorageFailedInvoke(item, ex);
			}
		}

		private void AddingToStorageFailedInvoke(ReminderItem item, Exception exception)
		{
			AddingToStorageFailed?.Invoke(
				this,
				new AddingToStorageFailedEventArgs(item, exception));
		}

		private void AddingToStorageSucceddedInvoke(ReminderItem item)
		{
			AddingToStorageSuccedded?.Invoke(
				this,
				new AddingToStorageSucceddedEventArgs(item));
		}

		private void MessageParsingFailedInvoke(string contactId, string message, Exception exception)
		{
			MessageParsingFailed?.Invoke(
				this,
				new MessageParsingFailedEventArgs
				{
					ContactId = contactId,
					Message = message,
					ParsingException = exception
				});
		}

		private void MessageParsingSucceddedInvoke(string contactId, DateTimeOffset date, string message)
		{
			MessageParsingSuccedded?.Invoke(
				this,
				new MessageParsingSucceddedEventArgs
				{
					ContactId = contactId,
					Date = date,
					Message = message
				});
		}

		private void MessageReceivedInvoke(string contactId, string message)
		{
			MessageReceived?.Invoke(
				this,
				new MessageReceivedEventArgs
				{
					ContactId = contactId,
					Message = message
				});
		}

		public ReminderDomain(
			IReminderStorage storage,
			IReminderReceiver receiver)
			: this(storage, receiver, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
		{
		}

		public void Run()
		{
			_awaitingRemindersCheckingTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				_awaitingRemindersCheckingPeriod);

			_readyRemindersSendingTimer = new Timer(
				SendReadyReminders,
				null,
				TimeSpan.FromSeconds(1),
				_readyRemindersSendingPeriod);

			_receiver.Run();
		}

		private void SendReadyReminders(object state)
		{
			// find ready reminders
			// try "send"
			// if success update status to Sent
			// else update status to Failed

			var readyReminders = _storage.Get(ReminderItemStatus.Ready);
			foreach (var readyReminder in readyReminders)
			{
				try
				{
					// try "send"
					SendReminder(readyReminder);

					// update status to Sent
					_storage.Update(
						readyReminder.Id,
						ReminderItemStatus.Sent);

					// send event
					SendingSucceeded?.Invoke(
						this,
						new SendingSucceededEventArgs
						{
							SendingItem = readyReminder
						});
				}
				catch (Exception e)
				{
					// update status to Failed
					_storage.Update(
						readyReminder.Id,
						ReminderItemStatus.Failed);

					// send event
					SendingFailed?.Invoke(
						this,
						new SendingFailedEventArgs
						{
							SendingItem = readyReminder,
							SendingException = e
						});
				}
			}
		}

		private void CheckAwaitingReminders(object state)
		{
			// here we will check storage for awaiting items
			// check each for its date
			// if it is time to send, change the status to Ready

			var awaitingReminders = _storage.Get(ReminderItemStatus.Awaiting);
			foreach (var awaitingReminder in awaitingReminders)
			{
				if (awaitingReminder.IsReadyToSend)
				{
					_storage.Update(awaitingReminder.Id, ReminderItemStatus.Ready);
				}
			}
		}

		public void Dispose()
		{
			_awaitingRemindersCheckingTimer?.Dispose();
			_readyRemindersSendingTimer?.Dispose();
		}
	}
}
