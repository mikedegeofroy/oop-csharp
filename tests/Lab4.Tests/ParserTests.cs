using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;
using Path = Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void Parse_ShouldBeConnect_WhenInputIsConnect()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("connect /Users/mikedegeofroy/Desktop");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.True(success.Command is Connect);
        }

        fs.Received().Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());
    }

    [Fact]
    public void Parse_ShouldBeListDepth3_WhenInputIsListDepth3()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        fs.Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("list / -d 3");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.True(success.Command is List);
        }

        fs.Received().GetDir(new Path("/"));
    }

    [Fact]
    public void Parse_ShouldBeDisconnect_WhenInputIsDisconnect()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("disconnect");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.IsType<Disconnect>(success.Command);
        }

        fs.Received().Disconnect();
    }

    [Fact]
    public void Parse_ShouldBeTreeGoto_WhenInputIsTreeGoto()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        fs.Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("tree goto /itmo");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.IsType<ChangeDirectory>(success.Command);
        }

        fs.Received().GoToDir(new Path("/itmo"));
    }

    [Fact]
    public void Parse_ShouldBeFileShow_WhenInputIsFileShowWithPath()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        fs.Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("file show /itmo/databases/questions.txt -m console");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.IsType<Show>(success.Command);
        }

        fs.Received().GetFileData(new Path("/itmo/databases/questions.txt"));
    }

    [Fact]
    public void Parse_ShouldBeFileMove_WhenInputIsFileMoveWithSourceAndDestination()
    {
        // Arrange
        FileSystem.FileSystem? fs = Substitute.For<FileSystem.FileSystem>();
        fs.Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());
        var parser = new CommandParser.CommandParser();

        // Act
        ParserOutput output = parser.Parse("file move /itmo/databases/questions.txt /itmo/databases/questions2.txt");

        // Assert
        Assert.True(output is ParserOutput.Success);
        if (output is ParserOutput.Success success)
        {
            Assert.IsType<Move>(success.Command);
        }

        fs.Received().GetFileData(new Path("/itmo/databases/questions.txt"));
    }
}