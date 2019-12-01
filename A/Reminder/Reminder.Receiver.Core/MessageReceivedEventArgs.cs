using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Receiver.Core
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }
    }
}
