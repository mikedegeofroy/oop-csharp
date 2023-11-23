using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Show : ICommand
{
    private readonly Path _source;
    private readonly FileSystem.FileSystem _fs;

    public Show(Path source, FileSystem.FileSystem fs)
    {
        _source = source;
        _fs = fs;
    }

    public void Execute()
    {
        byte[] file = _fs.GetFileData(_source);
        Console.WriteLine(Encoding.UTF8.GetString(file, 0, file.Length));
    }
}