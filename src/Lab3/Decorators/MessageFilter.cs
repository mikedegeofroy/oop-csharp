using Itmo.ObjectOrientedProgramming.Lab3.Filter;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class MessageFilter : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly IFilter _filter;

    public MessageFilter(IRecipient recipient, IFilter filter)
    {
        _recipient = recipient;
        _filter = filter;
    }

    public void HandleMessage(IMessage message)
    {
        if (_filter.Filter(message)) _recipient.HandleMessage(message);
    }
}