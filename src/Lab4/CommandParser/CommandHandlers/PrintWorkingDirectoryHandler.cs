using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public class PrintWorkingDirectoryHandler : ICommandHandler
{
    private ICommandHandler? _next;

    public ParserOutput Handle(string command)
    {
        if (FindKeyword("pwd", command))
        {
            return new ParserOutput.Success(new PrintWorkingDirectory());
        }

        return _next?.Handle(command)
               ?? throw new ArgumentException("Chain not terminated gracefully.");
    }

    public ICommandHandler SetNext(ICommandHandler commandHandler)
    {
        _next = commandHandler;
        return _next;
    }

    public ICommandHandler SetArgumentHandler(IArgumentHandler argumentHandler)
    {
        return this;
    }

    private static bool FindKeyword(string keyword, string command)
    {
        string funnel = command.Split(" ")
            .SingleOrDefault(x => x == keyword) ?? string.Empty;

        return !string.IsNullOrEmpty(funnel);
    }
}