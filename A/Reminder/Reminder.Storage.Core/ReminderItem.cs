using System;


namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
        public Guid Id { get; }

        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }

        public string ContactId { get; set; }

        public ReminderItemStatus Status { get; set; }

        public bool IsReadyToSend => DateTimeOffset.Now > Date;

        public TimeSpan TimeToAlarm => Date - DateTime.Now;
        
        public ReminderItem(DateTimeOffset DateTimeOffset,
                            string message,
                            string contactId)
        {
            Id = Guid.NewGuid();
            Date = DateTimeOffset;
            Message = message;
            ContactId = contactId;
            Status = ReminderItemStatus.Awating;
        }

        public ReminderItem()
        {
        }
    }
} 
