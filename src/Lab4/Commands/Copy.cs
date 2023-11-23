using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Copy : ICommand
{
    private readonly FileSystem.FileSystem _fs;
    private readonly Path _source;
    private readonly Path _destination;

    public Copy(Path source, Path destination, FileSystem.FileSystem fs)
    {
        _source = source;
        _destination = destination;
        _fs = fs;
    }

    public void Execute()
    {
        byte[] data = _fs.GetFileData(_source);
        _fs.WriteFileData(_destination, data);
    }
}