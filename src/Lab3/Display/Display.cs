using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class Display : IRecipient
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void HandleMessage(IMessage message)
    {
        _displayDriver.Clear();
        _displayDriver.Out();
    }
}