using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public interface IRecipient
{
    public void HandleMessage(IMessage message);
}