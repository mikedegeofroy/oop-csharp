using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class MessagingService
{
    public static void SendMessage(IRecipient recipient, IMessage message)
    {
        recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        recipient.HandleMessage(message);
    }
}