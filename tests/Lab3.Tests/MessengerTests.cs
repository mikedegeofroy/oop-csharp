using Itmo.ObjectOrientedProgramming.Lab3.Messenger;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void Telegram_Success_WhenMessageSent()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        TelegramService telegram = Substitute.For<TelegramService>("9a4e4610-8609-11ee-b9d1-0242ac120002");
        var messenger = new TelegramAdapter(telegram);

        // Act
        messenger.HandleMessage(message);

        // Assert
        telegram.Received().SendMessage(message.Render());
    }
}