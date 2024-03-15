using Itmo.ObjectOrientedProgramming.Lab3.User;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserTests
{
    [Fact]
    public void User_Success_WhenReceivedMessageIsUnread()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        var user = new User.User();

        // Act
        user.HandleMessage(message);

        // Assert
        Assert.False(user.GetMessage(0).Read);
    }

    [Fact]
    public void User_Success_WhenReadingUnreadMessage()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        var user = new User.User();

        // Act
        user.HandleMessage(message);
        user.MarkAsRead(0);

        // Assert
        Assert.True(user.GetMessage(0).Read);
    }

    [Fact]
    public void User_Fail_WhenMessageIsAlreadyRead()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        var user = new User.User();

        // Act
        user.HandleMessage(message);
        user.MarkAsRead(0);

        // Assert
        Assert.True(user.MarkAsRead(0) is MessageReadResult.Failed);
    }
}