using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Copy : ICommand
{
    private readonly Path _source;
    private readonly Path _destination;

    public Copy(Path source, Path destination)
    {
        _source = source;
        _destination = destination;
    }

    public void Execute(FileSystem.FileSystem fileSystem)
    {
        byte[] data = fileSystem.GetFileData(_source);
        fileSystem.WriteFileData(_destination, data);
    }
}