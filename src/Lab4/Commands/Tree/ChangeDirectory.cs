using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class ChangeDirectory : ICommand
{
    private readonly Path _location;

    public ChangeDirectory(Path location)
    {
        _location = location;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        try
        {
            fileSystem.GoToDir(_location);
        }
        catch (DirectoryNotFoundException e)
        {
            return new CommandOutput.Failure(e.Message);
        }

        return new CommandOutput.Success("Changed directory to ");
    }

    public class Builder : ICommandBuilder
    {
        private string? _location;

        public Builder SetLocation(string location)
        {
            _location = location;
            return this;
        }

        public ICommand Build()
        {
            if (string.IsNullOrEmpty(_location)) throw new ArgumentException();
            return new ChangeDirectory(new Path(_location));
        }
    }
}