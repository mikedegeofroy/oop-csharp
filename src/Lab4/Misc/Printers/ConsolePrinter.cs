using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Misc.Printers;

public class ConsolePrinter : IPrinter
{
    public void Out(string output)
    {
        Console.WriteLine(output);
    }
}