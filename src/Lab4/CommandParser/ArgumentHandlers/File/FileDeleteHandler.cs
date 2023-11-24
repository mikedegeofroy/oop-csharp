using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;

public class FileDeleteHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public HandlingResult Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Delete.Builder deleteBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "delete") + 1;

        deleteBuilder.SetFile(options[location]);

        return new HandlingResult.Success(deleteBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}