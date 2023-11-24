namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public record ParserOutput(string Message)
{
    public record SuccessfulExecution(string Message) : ParserOutput(Message);
    public record FailedExecution(string Message) : ParserOutput(Message);
    public record ParsingError(string Message) : ParserOutput(Message);
}