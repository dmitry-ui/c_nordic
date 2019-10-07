using MihaZupan;
using Reminder.Domain;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;
using System.Net;

namespace ReminderApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Telegram BotApp");
			var storage = new InMemoryReminderStorage();
			var domain = new ReminderDomain(storage);
			string token = "697789387:AAFzSKZg8GmR-_aMktYSwcz0kKiL1D7__ww";
			IWebProxy proxy = new HttpToSocks5Proxy("proxy.golyakov.net", 1080);
			var sender = new TelegramReminderSender(token, proxy);
			var receiver = new TelegramReminderReceiver(token, proxy);

			receiver.MessageReceived += (s, e) =>
			 {
				 Console.WriteLine($"Message received from contactId {e.ContactId} with text {e.Message}");

				 try
				 {
					 var parsedMessage = MessageParser.Parse(e.Message);

					 var item = new ReminderItem(
					 parsedMessage.Date,
					 parsedMessage.Message,
					 e.ContactId);
					 storage.Add(item);
				 }
				 catch (Exception ex)
				 {
					 Console.WriteLine($"The Format is Wrong  \n{ex.Message}");
				 }
			 };

			receiver.Run();

			domain.SendReminder = (ReminderItem ri) =>
			{
				sender.Send(ri.ContactId, ri.Message);
			};

			
			domain.Run();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
		
	}
}
