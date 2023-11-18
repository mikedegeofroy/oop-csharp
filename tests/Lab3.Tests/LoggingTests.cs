using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class LoggingTests
{
    [Fact]
    public void Logger_Success_WhenLoggedRecipientMessage()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        Logger.Logger logger = Substitute.For<Logger.Logger>();

        var recipient = new User.User();
        var messageLogger = new MessageLogger(recipient, logger);

        // Act
        messageLogger.HandleMessage(message);

        // Assert
        logger.Received().Log(message.Render());
    }
}