using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public class InboxMessage
{
    public InboxMessage(IMessage message, bool read)
    {
        Message = message;
        Read = read;
    }

    public IMessage Message { get; set; }
    public bool Read { get; set; }
}