using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Misc.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;

public class FileShowModeHandler : IArgumentHandler
{
    private IArgumentHandler? _next;

    public HandlingResult Handle(string command, ICommandBuilder builder)
    {
        if (builder is not Show.Builder showBuilder)
        {
            return _next?.Handle(command, builder)
                   ?? throw new ArgumentException("Chain not terminated gracefully.");
        }

        var options = command.Split(" ").ToList();
        int location = options.FindIndex(x => x == "-m") + 1;

        if (options[location] == "console")
            showBuilder.SetPrinter(new ConsolePrinter());

        return new HandlingResult.Success(showBuilder.Build());
    }

    public IArgumentHandler SetNext(IArgumentHandler handler)
    {
        _next = handler;
        return _next;
    }
}