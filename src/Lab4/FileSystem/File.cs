namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class File
{
    public File(string name, Path path)
    {
        Name = name;
        Path = path;
    }

    public string Name { get; private set; }
    public Path Path { get; private set; }
}