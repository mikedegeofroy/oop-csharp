namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Disconnect : ICommand
{
    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        fileSystem.Disconnect();
        return new CommandOutput.Success("Successfully disconnected from data source.");
    }
}