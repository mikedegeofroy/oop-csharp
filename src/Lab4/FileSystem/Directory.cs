using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class Directory
{
    public Directory(string name, Directory? parent = null)
    {
        Name = name;
        Subdirectories = new Dictionary<string, Directory>();
        Files = new List<File>();
        if (parent != null)
        {
            Subdirectories[".."] = parent;
        }
    }

    public string Name { get; private set; }
    public IList<File> Files { get; }

    private Dictionary<string, Directory> Subdirectories { get; }

    public void AddSubDirectory(Directory directory)
    {
        Subdirectories[directory.Name] = directory;
    }

    public void AddFile(File file)
    {
        Files.Add(file);
    }

    public IEnumerable<Directory> GetSubDirectories()
    {
        return Subdirectories.Values.ToList();
    }

    public Directory GetSubDirectory(string name)
    {
        return string.IsNullOrEmpty(name) ? this : Subdirectories[name];
    }

    public Path GetPath()
    {
        string path = Subdirectories.ContainsKey("..") ? Name : "/";
        Dictionary<string, Directory> dirs = Subdirectories;
        while (dirs.ContainsKey(".."))
        {
            Directory parentDir = dirs[".."];
            path = parentDir.Name + "/" + path;

            dirs = parentDir.Subdirectories;
        }

        return new Path(path);
    }
}