using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class DirectoryNotFoundException : FileSystemException
{
    public DirectoryNotFoundException() { }

    public DirectoryNotFoundException(string message)
        : base(message) { }

    public DirectoryNotFoundException(string message, Exception inner)
        : base(message, inner) { }
}