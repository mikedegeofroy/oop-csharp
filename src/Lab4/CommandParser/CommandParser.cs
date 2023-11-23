using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public class CommandParser
{
    private readonly IHandler _head;

    public CommandParser()
    {
        _head = BuildCommandHandlerChain();
    }

    public void Parse(string command)
    {
        HandlingResult result = _head.Handle(command);
        var fileSystem = new FileSystem.FileSystem();
        switch (result)
        {
            case HandlingResult.Success success:
                success.Command.Execute(fileSystem);
                break;
            case HandlingResult.Failure failure:
                Console.WriteLine(failure.Message);
                break;
        }
    }

    private static IHandler BuildCommandHandlerChain()
    {
        var connectHandler = new ConnectHandler();
        var disconnectHandler = new DisconnectHandler();
        var terminationHandler = new TerminationHandler();

        connectHandler.SetNext(disconnectHandler);
        disconnectHandler.SetNext(terminationHandler);

        return connectHandler;
    }
}