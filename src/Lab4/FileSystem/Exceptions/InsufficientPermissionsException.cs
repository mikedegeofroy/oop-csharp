using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class InsufficientPermissionsException : FileSystemException
{
    public InsufficientPermissionsException() { }

    public InsufficientPermissionsException(string message)
        : base(message) { }

    public InsufficientPermissionsException(string message, Exception inner)
        : base(message, inner) { }
}