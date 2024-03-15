using System;
using System.Drawing;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public class DisplayToFile : IDisplayStrategy
{
    private Color _color;

    public DisplayToFile()
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
        const string path = "test.txt";

        if (File.Exists(path)) return;

        using StreamWriter sw = File.CreateText(path);
        sw.WriteLine(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}