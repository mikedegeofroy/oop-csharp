using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayDriver
{
    private readonly IDisplayStrategy _strategy;

    public DisplayDriver(IDisplayStrategy strategy)
    {
        _strategy = strategy;
    }

    public void OutputText(string text, Color color)
    {
        _strategy.Clear();
        _strategy.SetColor(color);
        _strategy.Out(text);
    }
}