using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IRecipient
{
    void HandleMessage(IMessage message);
}