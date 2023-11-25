using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;

public class FileRenameHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Rename.Builder renameBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "rename") + 1;

        renameBuilder.SetSource(options[location]);
        renameBuilder.SetDestination(options[location + 1]);

        return new ParserOutput.Success(renameBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}