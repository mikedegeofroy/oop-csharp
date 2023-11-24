using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public interface ICommandHandler
{
    HandlingResult Handle(string command);

    ICommandHandler SetNext(ICommandHandler commandHandler);

    ICommandHandler SetArgumentHandler(IArgumentHandler argumentHandler);
}