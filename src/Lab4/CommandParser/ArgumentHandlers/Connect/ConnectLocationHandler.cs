using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Connect;

public class ConnectLocationHandler : IArgumentHandler
{
    private IArgumentHandler? _next;
    public HandlingResult Handle(string command, ICommandBuilder builder)
    {
        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "connect") + 1;
        if (builder is Commands.Connect.Builder connectBuilder)
        {
            if (location >= options.Count)
                return new HandlingResult.Failure("Please supply a location to mount on.");
            connectBuilder.SetLocation(options[location]);
        }
        else
        {
            throw new ArgumentException("Chain not terminated gracefully.");
        }

        return _next?.Handle(command, connectBuilder)
               ?? throw new ArgumentException("Chain not terminated gracefully.");
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}