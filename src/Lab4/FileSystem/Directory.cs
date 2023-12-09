using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class Directory
{
    private readonly string _name;
    public Directory(string name, Directory? parent = null)
    {
        _name = name;
        Subdirectories = new Dictionary<string, Directory>();
        Files = new List<File>();
        Subdirectories["."] = this;
        if (parent != null)
        {
            Subdirectories[".."] = parent;
        }
    }

    public string Name => Subdirectories.ContainsKey("..") ? _name : string.Empty;

    public IList<File> Files { get; }

    private Dictionary<string, Directory> Subdirectories { get; }

    public void AddSubDirectory(Directory directory)
    {
        Subdirectories.Add(directory.Name, directory);
    }

    public void AddFile(File file)
    {
        Files.Add(file);
    }

    public IEnumerable<Directory> GetSubDirectories()
    {
        var values = Subdirectories.Values.ToList();
        values.Remove(this);
        if (Subdirectories.TryGetValue("..", out Directory? subdirectory))
            values.Remove(subdirectory);
        return values;
    }

    public Directory GetSubDirectory(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return this;
        }
        else
        {
            try
            {
                return Subdirectories[name];
            }
            catch (KeyNotFoundException)
            {
                throw new Exceptions.DirectoryNotFoundException("No such directory: " + name);
            }
        }
    }

    public Path GetPath()
    {
        string path = Name;
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