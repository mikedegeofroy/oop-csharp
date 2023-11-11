using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class MessagingService
{
    public static void SendMessage(IRecipient recipient, IMessage message)
    {
        recipient.HandleMessage(message);
    }
}