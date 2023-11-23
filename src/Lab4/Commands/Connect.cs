namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommand
{
    private readonly FileSystem.FileSystem _fs;
    private readonly string _location;

    public Connect(FileSystem.FileSystem fs, string location)
    {
        _fs = fs;
        _location = location;
    }

    public void Execute()
    {
        _fs.Connect(_location);
    }
}