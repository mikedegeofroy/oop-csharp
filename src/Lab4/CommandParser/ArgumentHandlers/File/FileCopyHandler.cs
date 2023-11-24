using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;

public class FileCopyHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public HandlingResult Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Copy.Builder copyBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "copy") + 1;

        copyBuilder.SetSource(options[location]);
        copyBuilder.SetDestination(options[location + 1]);

        return new HandlingResult.Success(copyBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}