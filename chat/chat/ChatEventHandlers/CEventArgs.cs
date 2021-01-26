using System;
using chat;

namespace chat.ChatEventHandlers
{
    public class CEventArgs : EventArgs
    {
        public CEventArgs(Message message)
        {
            SenderName = message.User;
            ReceivedDate = DateTime.Now;
        }

        public DateTime ReceivedDate { get; }
        public string SenderName { get; }
    }
}