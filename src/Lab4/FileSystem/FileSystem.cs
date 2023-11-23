using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystem
{
    private IFileSystemStrategy _fileSystemStrategy;

    public FileSystem()
    {
        _fileSystemStrategy = new DefaultFileSystemStrategy();
    }

    public Directory? Root { get; private set; }
    public Directory? CurrentDirectory { get; private set; }

    public void Connect(string location, IFileSystemStrategy fileSystemStrategy)
    {
        _fileSystemStrategy = fileSystemStrategy;
        Root = _fileSystemStrategy.Map(location);
        CurrentDirectory = Root;
    }

    public void Disconnect()
    {
        Root = null;
        CurrentDirectory = null;
    }

    public byte[] GetFileData(Path path)
    {
        File file = GetFile(path);
        return _fileSystemStrategy.GetFileData(file.Path.Value + file.Name);
    }

    public void WriteFileData(Path path, byte[] fileData)
    {
        _fileSystemStrategy.WriteFileData(path.Value, fileData);
    }

    public void DeleteFile(Path path)
    {
        _fileSystemStrategy.DeleteFile(GetDir(path).GetPath().Value);
    }

    public void GoToDir(Path path)
    {
        Directory? root = path.IsRelative ? CurrentDirectory : Root;
        CurrentDirectory = GetDirectory(root, path);
    }

    public Directory GetDir(Path path)
    {
        Directory? root = path.IsRelative ? CurrentDirectory : Root;
        return GetDirectory(root, path);
    }

    public File GetFile(Path path)
    {
        string filename = path.Value.Split("/").Last();
        string enclosingDirPathArray = string.Join("/", path.Value.Split("/").SkipLast(1));
        var enclosingDirectoryPath = new Path(enclosingDirPathArray);

        Directory directory = GetDir(enclosingDirectoryPath);

        return new File(filename, directory.GetPath());
    }

    private static Directory GetDirectory(Directory? root, Path path)
    {
        if (root == null) throw new ArgumentException("FileSystem is not connected!");

        Directory head = root;
        string[] dirs = path.Value.Split("/");
        int skip = path.IsAbsolute ? 1 : 0;
        head = dirs.Skip(skip).Aggregate(head, (current, dir) => current.GetSubDirectory(dir));
        return head;
    }
}