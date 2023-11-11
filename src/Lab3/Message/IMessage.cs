namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage : IRenderable
{
    int Priority { get; }
}