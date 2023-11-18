using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Filter;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class MessagingService
{
    public static IRecipient Log(IRecipient endpoint)
    {
        return new MessageLogger(endpoint, new Logger.Logger());
    }

    public static IRecipient Filter(IRecipient endpoint, int level)
    {
        return new MessageFilter(endpoint, new PriorityFilter(level));
    }

    public static void SendMessage(IRecipient recipient, IMessage message)
    {
        recipient.HandleMessage(message);
    }
}