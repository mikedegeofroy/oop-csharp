using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;

public class FileShowHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Show.Builder showBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "show") + 1;

        showBuilder.SetSource(options[location]);

        return _next?.Handle(command, showBuilder)
               ?? throw new ArgumentException("Chain not terminated gracefully.");
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}