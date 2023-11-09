namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage : IRenderable
{
    public Priority Priority { get; }
}