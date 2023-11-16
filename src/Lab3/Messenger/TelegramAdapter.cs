using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class TelegramAdapter : IRecipient
{
    private readonly TelegramService _telegramService;

    public TelegramAdapter(TelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    public void HandleMessage(IMessage message)
    {
        _telegramService.SendMessage(message.Render());
    }
}