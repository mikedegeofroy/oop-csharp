using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IMessenger
{
    public void HandleMessage(IMessage message)
    {
        Console.WriteLine("Messenger: \n" + message.Render());
    }
}