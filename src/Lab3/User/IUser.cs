namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public interface IUser : IRecipient
{
    public void MarkAsRead(int index);

    public InboxMessage GetMessage(int index);
}