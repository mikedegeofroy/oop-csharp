namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public abstract record MessageReadResult
{
    public record Success(InboxMessage Message) : MessageReadResult;
    public record Failed(string Reason) : MessageReadResult;
}