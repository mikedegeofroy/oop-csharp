using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

public class MacOsFileSystemStrategy : IFileSystemStrategy
{
    private string _localPath = string.Empty;
    public Directory Map(string path)
    {
        return MapDirectory(new Directory("/"), _localPath + "/" + path);
    }

    public void Mount(string location)
    {
        _localPath = location;
    }

    public byte[] GetFileData(string path)
    {
        try
        {
            return System.IO.File.ReadAllBytes(_localPath + "/" + path);
        }
        catch (UnauthorizedAccessException)
        {
            throw new InsufficientPermissionsException("Insufficient permissions.");
        }
    }

    public void WriteFileData(string? path, byte[] fileData)
    {
        System.IO.File.WriteAllBytes(_localPath + "/" + path, fileData);
    }

    public void DeleteFile(string? path)
    {
        try
        {
            System.IO.File.Delete(_localPath + "/" + path);
        }
        catch (UnauthorizedAccessException)
        {
            throw new InsufficientPermissionsException("Insufficient permissions.");
        }
    }

    private static Directory MapDirectory(Directory directory, string location)
    {
        string[] dirs = System.IO.Directory.GetDirectories(location);
        foreach (string dir in dirs)
        {
            string name = dir.Split("/").Last();
            directory.AddSubDirectory(MapDirectory(new Directory(name, directory), dir));
        }

        string[] files = System.IO.Directory.GetFiles(location);
        foreach (string file in files)
        {
            string name = file.Split("/").Last();
            var newFile = new File(name, new Path(file));
            directory.AddFile(newFile);
        }

        return directory;
    }
}