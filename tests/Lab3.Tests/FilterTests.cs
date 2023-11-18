using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Filter;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FilterTests
{
    [Fact]
    public void Level2Filter_Success_WhenRecipientDidNotReceiveLevel1Message()
    {
        // Arrange
        var message = new Message.Message("Header", "Body", 1);
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new MessageFilter(mockRecipient, new PriorityFilter(2));

        // Act
        filter.HandleMessage(message);

        // Assert
        mockRecipient.DidNotReceive().HandleMessage(message);
    }

    [Fact]
    public void Level2Filter_Success_WhenRecipientReceivedLevel3Message()
    {
        // Arrange
        var message = new Message.Message("Hello", "yep", 3);
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new MessageFilter(mockRecipient, new PriorityFilter(2));

        // Act
        filter.HandleMessage(message);

        // Assert
        mockRecipient.Received().HandleMessage(message);
    }

    [Fact]
    public void Level3Filter_Success_WhenRecipientDidNotReceiveLevel2Message()
    {
        // Arrange
        var message = new Message.Message("Hello", "yep", 1);
        IRecipient mockRecipient = Substitute.For<IRecipient>();
        var filter = new MessageFilter(mockRecipient, new PriorityFilter(3));

        // Act
        filter.HandleMessage(message);

        // Assert
        mockRecipient.DidNotReceive().HandleMessage(message);
    }
}