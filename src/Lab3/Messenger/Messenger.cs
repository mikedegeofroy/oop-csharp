using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IRecipient
{
    private readonly IRecipient _adapter;

    public Messenger(IRecipient adapter)
    {
        _adapter = adapter;
    }

    public void HandleMessage(IMessage message)
    {
        _adapter.HandleMessage(message);
    }
}