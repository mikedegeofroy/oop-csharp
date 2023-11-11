using System;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxies;

public class MessageLogger : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public MessageLogger(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void HandleMessage(IMessage message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Log(message);
        _recipient.HandleMessage(message);
    }

    private void Log(IRenderable message)
    {
        _logger.Log(message.Render());
    }
}