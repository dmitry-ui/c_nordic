using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Receiver.Core;
using Reminder.Storage.InMemory;
using System;
using System.Net;
using Reminder.Parsing;
using MihaZupan;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Telegram Bot Application!");
            var storage = new InMemoryReminderStorage();
            var domain = new ReminderDomain(storage);

            //мой токен
            string token = "697789387:AAFzSKZg8GmR-aMktYSwcz0kKiL1D7_ww";
            IWebProxy proxy = new HttpToSocks5Proxy("proxy.golyakov.net", 1080);
            var sender = new TelegramReminderSender(token, proxy);
            var receiver = new TelegramReminderReceiver(token, proxy);

            receiver.MessageReceived += (s, e) =>
            {
                //добавляем запись в хранилище
                Console.WriteLine($"Сообщение от {e.ContactId}, текст {e.Message}");

                var parsedMessage = MessageParser.Parse(e.Message);

                var item = new ReminderItem(
                        parsedMessage.Date,
                        parsedMessage.Message,
                        e.ContactId);

                storage.Add(item);
            };

            receiver.Run();

            domain.SendReminder = (ReminderItem ri) =>
            {
                sender.Send(ri.ContactId, ri.Message);
            };

            domain.Run();

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }

      
    }

    internal class ReminderParser
    {
    }
}
