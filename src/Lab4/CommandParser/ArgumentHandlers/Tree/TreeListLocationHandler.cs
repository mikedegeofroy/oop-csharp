using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Tree;

public class TreeListLocationHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        if (builder is not List.Builder listBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "list") + 1;
        listBuilder.SetDirectory(location >= options.Count ? "." : options[location]);

        return new ParserOutput.Success(listBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }

    private static bool FindKeyword(string keyword, string command)
    {
        string funnel = command.Split(" ")
            .SingleOrDefault(x => x == keyword) ?? string.Empty;

        return !string.IsNullOrEmpty(funnel);
    }
}