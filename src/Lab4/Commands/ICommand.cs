namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    CommandOutput Execute(FileSystem.FileSystem fileSystem);
}