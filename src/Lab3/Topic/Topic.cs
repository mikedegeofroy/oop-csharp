using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic : ITopic
{
    private readonly string _name;
    private readonly IRecipient _recipient;

    public Topic(string name, IRecipient recipient)
    {
        _name = name;
        _recipient = recipient;
    }

    public void HandleMessage(IMessage message)
    {
        _recipient.HandleMessage(message);
    }
}