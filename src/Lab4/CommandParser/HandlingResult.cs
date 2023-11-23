using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public abstract record HandlingResult
{
    public sealed record Success(ICommand Command) : HandlingResult;
    public sealed record Failure(string Message) : HandlingResult;
}