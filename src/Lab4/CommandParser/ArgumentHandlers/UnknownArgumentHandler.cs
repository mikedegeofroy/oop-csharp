using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;

public class UnknownArgumentHandler : IArgumentHandler
{
    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        return new ParserOutput.Failure("Unknown argument: " + command);
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        throw new ArgumentException("Unknown Argument Handler must be last in chain.");
    }
}