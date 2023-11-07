using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class User : IUser
{
    private ICollection<InboxMessage> _inbox;

    public User()
    {
        _inbox = new Collection<InboxMessage>();
    }

    public void HandleMessage(IMessage message)
    {
        _inbox.Add(new InboxMessage(message, false));
    }
}