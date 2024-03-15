using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommand
{
    private readonly string _location;
    private readonly IFileSystemStrategy _strategy;

    public Connect(string location, IFileSystemStrategy strategy)
    {
        _location = location;
        _strategy = strategy;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        fileSystem.Connect(_location, _strategy);
        return new CommandOutput.Success("Successfully connected to data source.");
    }

    public class Builder : ICommandBuilder
    {
        private string? _location;
        private IFileSystemStrategy? _strategy;

        public Builder SetLocation(string location)
        {
            _location = location;
            return this;
        }

        public Builder SetStrategy(IFileSystemStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public ICommand Build()
        {
            if (_location == null) throw new ArgumentException();
            if (_strategy == null) throw new ArgumentException();
            return new Connect(_location, _strategy);
        }
    }
}