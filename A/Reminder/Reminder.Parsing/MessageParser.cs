using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage Parse(string message)
        {
            //2019-10-02T21:20:00 Congratulations
            int SpaceIndex = message.IndexOf(' ');

            return new ParsedMessage
            {
                Date = DateTimeOffset.Parse(message.Substring(0, SpaceIndex)),
                Message = message.Substring(SpaceIndex + 1)
            };
        }
    }
}
