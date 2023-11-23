namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

public class TerminationHandler : IHandler
{
    public HandlingResult Handle(string command)
    {
        return new HandlingResult.Failure("You are really really dumb.");
    }

    public void SetNext(IHandler handler)
    {
        throw new System.NotImplementedException();
    }
}