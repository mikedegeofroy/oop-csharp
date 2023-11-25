using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Connect;

public class ConnectStrategyHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public ParserOutput Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Commands.Connect.Builder connectBuilder)
            throw new ArgumentException("bad usage");

        if (!FindFlag("-m", command))
        {
            connectBuilder.SetStrategy(new MacOsFileSystemStrategy());
            return new ParserOutput.Success(connectBuilder.Build());
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "-m") + 1;

        if (options[location] == "local")
        {
            connectBuilder.SetStrategy(new MacOsFileSystemStrategy());
        }
        else
        {
            return new ParserOutput.Failure("Unknown mounting mode: " + options[location]);
        }

        return new ParserOutput.Success(connectBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }

    private static bool FindFlag(string flag, string command)
    {
        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == flag);

        return location != -1;
    }
}