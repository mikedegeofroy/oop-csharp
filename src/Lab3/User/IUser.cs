namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public interface IUser : IRecipient
{
    void MarkAsRead(int index);

    InboxMessage GetMessage(int index);
}