using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class UserRecipient : IRecipient
{
    private readonly IUser _user;

    public UserRecipient(IUser user)
    {
        _user = user;
    }

    public void HandleMessage(IMessage message)
    {
        _user.HandleMessage(message);
    }
}