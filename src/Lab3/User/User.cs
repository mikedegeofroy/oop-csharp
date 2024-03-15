using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class User : IUser
{
    private readonly List<InboxMessage> _inbox;

    public User()
    {
        _inbox = new List<InboxMessage>();
    }

    public void HandleMessage(IMessage message)
    {
        _inbox.Add(new InboxMessage(message, false));
    }

    public MessageReadResult MarkAsRead(int index)
    {
        InboxMessage message = _inbox.ElementAt(index);
        if (message.Read) return new MessageReadResult.Failed("The message was already read.");
        message.Read = true;
        return new MessageReadResult.Success(message);
    }

    public InboxMessage GetMessage(int index)
    {
        return _inbox.ElementAt(index);
    }
}