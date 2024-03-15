using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class TelegramService
{
    private string _uid;

    public TelegramService(string uid)
    {
        _uid = uid;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine(message + "sent to: " + _uid);
    }
}