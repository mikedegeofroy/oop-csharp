using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public class GroupRecipient : IRecipient
{
    private readonly IEnumerable<IRecipient> _recipients;

    public GroupRecipient(IEnumerable<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void HandleMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.HandleMessage(message);
        }
    }
}