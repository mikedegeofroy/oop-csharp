using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Show : ICommand
{
    private readonly Path _source;

    public Show(Path source)
    {
        _source = source;
    }

    public void Execute(FileSystem.FileSystem fileSystem)
    {
        byte[] file = fileSystem.GetFileData(_source);
        Console.WriteLine(Encoding.UTF8.GetString(file, 0, file.Length));
    }
}