using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class PrintWorkingDirectory : ICommand
{
    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        Path? path = fileSystem.CurrentDirectory?.GetPath();
        if (path != null)
            return new CommandOutput.Success(path.Value);
        return new CommandOutput.Failure("Filesystem is not connected!");
    }

    public class Builder : ICommandBuilder
    {
        public ICommand Build()
        {
            return new PrintWorkingDirectory();
        }
    }
}