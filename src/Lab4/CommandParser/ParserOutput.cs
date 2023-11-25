using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public abstract record ParserOutput
{
    public sealed record Success(ICommand Command) : ParserOutput;
    public sealed record Failure(string Message) : ParserOutput;
}