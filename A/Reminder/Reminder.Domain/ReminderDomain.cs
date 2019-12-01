using System;
using System.Threading;
using Reminder.Storage.Core;
using Reminder.Domain.Models;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable //т.к. есть члены Taimer то надо наследовать от IDisposable
    {
        //необходимо
        //1.опрашивать хранилище на предмет подошло время отправлять сообщение
        //2.те что готовы - надо послать

        //берем именно интерфейс IReminderStorage, чтобы реализацию можно было заменить
        private IReminderStorage _storage;

        //период простановки статуса ready
        private TimeSpan _awatingRemindersCheckingPeriod;

        //период проверки для отправки
        private TimeSpan _readyRemindersSendingPeriod;

        //для выполнения циклических действий с заданным периодом
        //1.
        private Timer _awatingRemindersCheckingTimer;

        //2.
        private Timer _awatingRemindersSendingTimer;

        //делегат для отправки
        public Action<ReminderItem> SendReminder { get; set;}

        //события для оповещения по результатам отправки
        public event EventHandler<SendingSucceededEventArgs> SendingSuccedded ;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public ReminderDomain(IReminderStorage storage,
           TimeSpan awatingRemindersCheckingPeriod,
           TimeSpan readyRemindersSendingPeriod)
        {
            _storage = storage;
            _awatingRemindersCheckingPeriod = awatingRemindersCheckingPeriod;
            _readyRemindersSendingPeriod = readyRemindersSendingPeriod;
        }

        public ReminderDomain(IReminderStorage storage): 
                this(storage, 
                    TimeSpan.FromSeconds(1) ,
                    TimeSpan.FromSeconds(1))
        {
        }

        //стартует таймер и все процессы циклически
        public void Run()
        {
            //первый параметр - делегат который будез циклически запускаться 
            _awatingRemindersCheckingTimer = new Timer(
                checkAwaitingReminders, //метод кото будет запускаться
                null,  //таймер сразу запускать
                TimeSpan.Zero, // когда метод должен запустится относительно запуска таймера  
                _awatingRemindersCheckingPeriod);  //период опроса

            _awatingRemindersSendingTimer = new Timer(
                SendReadyReminders,
                null,
                TimeSpan.FromSeconds(1),
                _readyRemindersSendingPeriod
                );
        }

        private void SendReadyReminders(object state)
        {
            //отправка
            //находим что отправлять
            //отправляем
            //если ок  то статус в set
            //инача статус в failed

            var readyReminders = _storage.Get(ReminderItemStatus.Ready);
            foreach (var readyReminder in readyReminders)
            {
                try
                {
                    //отправляем, используем делегат
                    SendReminder(readyReminder);
                    //статус в sent
                    _storage.Update(
                        readyReminder.Id, 
                        ReminderItemStatus.Sent);

                    //запускаем событие об успешной отправке
                    SendingSuccedded?.Invoke(
                        this,
                        new SendingSucceededEventArgs
                        {
                            SendingItem = readyReminder
                        });

                }
                catch (Exception e)
                {
                    //статус в fault
                    _storage.Update(
                        readyReminder.Id, 
                        ReminderItemStatus.Failed);

                    //запускаем событие о сбое отправки
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

        private void checkAwaitingReminders(object state)
        {
            //находим все awaiting, проверям не наступило ли для них 
            //время отправки сообщения. Если наступило - ставим статус ready
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
            //т.к. таймер наследует от idisposable
            //то надо закрывать:
            if (_awatingRemindersCheckingTimer != null)
                _awatingRemindersCheckingTimer.Dispose();
            //аналогичная запись
            _awatingRemindersSendingTimer?.Dispose();
        }
    }
}
