namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage : IRenderable
{
    Priority Priority { get; }
}