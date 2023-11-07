using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void HandleMessage(IMessage message)
    {
        _messenger.HandleMessage(message);
    }
}