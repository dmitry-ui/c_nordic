using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.Models
{
    //будет использоваться в качестве параметра в событии
    public class SendingFailedEventArgs : EventArgs
    {
        public ReminderItem SendingItem { get; set; }
        public Exception SendingException { get; set; }
    }
}