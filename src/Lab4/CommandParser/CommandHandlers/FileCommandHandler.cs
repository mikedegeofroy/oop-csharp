using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public class FileCommandHandler : ICommandHandler
{
    private ICommandHandler? _next;
    private IArgumentHandler? _argumentHandler;

    public HandlingResult Handle(string command)
    {
        if (FindKeyword("copy", command))
        {
            return _argumentHandler?.Handle(command, new Copy.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("show", command))
        {
            return _argumentHandler?.Handle(command, new Show.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("move", command))
        {
            return _argumentHandler?.Handle(command, new Move.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("rename", command))
        {
            return _argumentHandler?.Handle(command, new Rename.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("delete", command))
        {
            return _argumentHandler?.Handle(command, new Delete.Builder())
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        return _next?.Handle(command) ?? throw new ArgumentException("Chain not terminated gracefully.");
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