namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract record CommandOutput(string Message)
{
    public record Success(string Message = "") : CommandOutput(Message);

    public record Failure(string Message = "") : CommandOutput(Message);
}