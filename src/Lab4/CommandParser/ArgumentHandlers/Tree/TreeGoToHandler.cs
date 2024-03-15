using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Tree;

public class TreeGoToHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        if (builder is not ChangeDirectory.Builder changeDirectoryBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "goto") + 1;

        if (location >= options.Count)
            return new ParserOutput.Failure("Please supply a valid directory.");
        changeDirectoryBuilder.SetLocation(options[location]);

        return new ParserOutput.Success(changeDirectoryBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}