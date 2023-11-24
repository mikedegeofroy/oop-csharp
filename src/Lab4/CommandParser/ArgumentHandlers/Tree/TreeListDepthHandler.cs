using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Tree;

public class TreeListDepthHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public HandlingResult Handle(string command, ICommandBuilder builder)
    {
        if (builder is not List.Builder listBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        if (FindKeyword("-d", command))
        {
            var options = command.Split(" ").ToList();
            int location = options.FindIndex(x => x == "-d") + 1;
            bool result = int.TryParse(options[location], out int depth);
            if (!result)
                return new HandlingResult.Failure("Please set a valid depth.");
            options.RemoveAt(location);
            options.RemoveAt(location - 1);
            command = string.Join(" ", options);
            listBuilder.SetDepth(depth);
        }
        else
        {
            listBuilder.SetDepth(1);
        }

        return _next?.Handle(command, listBuilder)
               ?? throw new ArgumentException("Chain not terminated gracefully.");
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