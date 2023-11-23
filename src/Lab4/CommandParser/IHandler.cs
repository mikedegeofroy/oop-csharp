namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public interface IHandler
{
    HandlingResult Handle(string command);

    void SetNext(IHandler handler);
}