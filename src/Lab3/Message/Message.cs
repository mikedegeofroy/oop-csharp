namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class Message : IMessage
{
    private readonly string _header;
    private readonly string _body;

    public Message(string header, string body, Priority priority)
    {
        _header = header;
        _body = body;
        Priority = priority;
    }

    public Priority Priority { get; }

    public string Render()
    {
        return _header + '\n' + _body;
    }
}