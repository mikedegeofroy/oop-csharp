using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public record InboxMessage(IMessage Message, bool Read);