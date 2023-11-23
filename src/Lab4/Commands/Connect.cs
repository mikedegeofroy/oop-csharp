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

    public void Execute(FileSystem.FileSystem fileSystem)
    {
        fileSystem.Connect(_location, _strategy);
    }
}