using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

// TODO
// should have a display that takes in a string.
public class Display : IRecipient
{
    private readonly DisplayDriver _displayStrategy;

    public Display(IDisplayStrategy displayStrategy)
    {
        _displayStrategy = new DisplayDriver(displayStrategy);
    }

    public void HandleMessage(IMessage message)
    {
        _displayStrategy.OutputText(message.Render(), Color.Red);
    }
}