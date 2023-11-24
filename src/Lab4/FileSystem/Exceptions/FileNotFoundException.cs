using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class FileNotFoundException : FileSystemException
{
    public FileNotFoundException() { }

    public FileNotFoundException(string message)
        : base(message) { }

    public FileNotFoundException(string message, Exception inner)
        : base(message, inner) { }
}