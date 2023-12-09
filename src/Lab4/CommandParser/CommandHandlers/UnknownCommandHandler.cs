using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public class UnknownCommandHandler : ICommandHandler
{
    public ParserOutput Handle(string command)
    {
        return new ParserOutput.Failure("There was an error parsing the command, please try again.");
    }

    public ICommandHandler SetNext(ICommandHandler commandHandler)
    {
        throw new ArgumentException("Unknown Command Handler must be last in chain.");
    }

    public ICommandHandler SetArgumentHandler(IArgumentHandler argumentHandler)
    {
        throw new ArgumentException("Unknown Command Handler can't have arguments");
    }
}