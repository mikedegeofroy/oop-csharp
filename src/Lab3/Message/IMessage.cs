namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage
{
    public Priority Priority { get; }
    public string Render();
}