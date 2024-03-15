using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayToConsole : IDisplayStrategy
{
    private Color _color;

    public DisplayToConsole()
    {
        _color = Color.White;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Out(string text)
    {
        Console.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}