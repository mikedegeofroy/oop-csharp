using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;

public interface IArgumentHandler
{
    HandlingResult Handle(string command, ICommandBuilder builder);

    IArgumentHandler SetNext(IArgumentHandler handler);
}