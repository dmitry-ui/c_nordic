﻿using System;
using System.Net;
using MihaZupan;
using Newtonsoft.Json;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;
using MessageReceivedEventArgs = Reminder.Domain.Models.MessageReceivedEventArgs;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Telegram Bot Application!");

			var storage = new ReminderStorageWebApiClient(
				"http://localhost:5000/api/reminders");

			//string token = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";
			string token = "697789387:AAFzSKZg8GmR-_aMktYSwcz0kKiL1D7__ww";

			IWebProxy proxy = new HttpToSocks5Proxy(
				"proxy.golyakov.net", 1080);

			//var receiver = new TelegramReminderReceiver(token);
			var receiver = new TelegramReminderReceiver(token, proxy);

			var domain = new ReminderDomain(storage, receiver);

			var sender = new TelegramReminderSender(token, proxy);
			//var sender = new TelegramReminderSender(token);

			domain.SendReminder = (ReminderItem ri) =>
			{
				sender.Send(ri.ContactId, ri.Message);
			};

			domain.MessageReceived += Domain_MessageReceived;
			domain.MessageParsingSuccedded += Domain_MessageParsingSuccedded;
			domain.MessageParsingFailed += Domain_MessageParsingFailed;
			domain.AddingToStorageSuccedded += Domain_AddingToStorageSuccedded;
			domain.AddingToStorageFailed += Domain_AddingToStorageFailed;
			domain.SendingFailed += Domain_SendingFailed;

			domain.Run();

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static void Domain_SendingFailed(object sender, SendingFailedEventArgs e)
		{
			Console.WriteLine(
				$"Sending of item with ID {e.SendingItem.Id} failed with exception {e.SendingException }.");
		}

		private static void Domain_AddingToStorageFailed(object sender, AddingToStorageFailedEventArgs e)
		{
			string itemInfo = JsonConvert.SerializeObject(
				new
				{
					e.Date,
					e.Message,
					e.ContactId,
					e.Status
				});

			Console.WriteLine(
				$"Adding of item {itemInfo} failed with exception {e.ThrownException}.");
		}

		private static void Domain_AddingToStorageSuccedded(object sender, AddingToStorageSucceddedEventArgs e)
		{
			//Console.WriteLine(
			//	$"Item ID = {e.Id}" +
			//	$"for time = {e.Date} " +
			//	$"sent by user {e.ContactId} " +
			//	$"with message {e.Message} " +
			//	$"in status {e.Status} successfully added to the storage.");

			Console.WriteLine(
				$"Item {JsonConvert.SerializeObject(e)} successfully added to the storage.");
		}

		private static void Domain_MessageParsingFailed(object sender, MessageParsingFailedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} parsing failed. Text = \"{e.Message}\"");
		}

		private static void Domain_MessageParsingSuccedded(object sender, MessageParsingSucceddedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} successfully parsed. Date = \"{e.Date}\" Text = \"{e.Message}\"");
		}

		private static void Domain_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} received. Text = \"{e.Message}\"");
		}
	}
}
