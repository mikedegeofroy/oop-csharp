using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public class TreeCommandHandler : ICommandHandler
{
    private ICommandHandler? _next;
    private IArgumentHandler? _argumentHandler;

    public HandlingResult Handle(string command)
    {
        if (FindKeyword("goto", command))
        {
            return _argumentHandler?.Handle(command, new ChangeDirectory.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("list", command))
        {
            return _argumentHandler?.Handle(command, new List.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
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
        _argumentHandler = argumentHandler;
        return this;
    }

    private static bool FindKeyword(string keyword, string command)
    {
        string funnel = command.Split(" ")
            .SingleOrDefault(x => x == keyword) ?? string.Empty;

        return !string.IsNullOrEmpty(funnel);
    }
}