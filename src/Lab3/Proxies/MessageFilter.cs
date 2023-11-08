using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxies;

public class MessageFilter : IRecipient
{
    private readonly IRecipient _recipient;
    private IEnumerable<Priority> _filter;

    public MessageFilter(IRecipient recipient)
    {
        _recipient = recipient;
        _filter = new List<Priority>()
        {
            Priority.High,
            Priority.Medium,
            Priority.Low,
        };
    }

    public void HandleMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        if (Filter(message.Priority)) _recipient.HandleMessage(message);
    }

    public void SetFilter(params Priority[] filter)
    {
        _filter = new List<Priority>(filter);
    }

    private bool Filter(Priority priority)
    {
        return _filter.Contains(priority);
    }
}