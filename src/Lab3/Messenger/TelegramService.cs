using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class TelegramService
{
    public void SendMessage(string message, string uid)
    {
        Console.WriteLine(message + "sent to: " + uid);
    }
}