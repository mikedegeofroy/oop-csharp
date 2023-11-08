using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}