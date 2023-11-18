namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public interface IUser : IRecipient
{
    MessageReadResult MarkAsRead(int index);

    InboxMessage GetMessage(int index);
}