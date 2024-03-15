using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;
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
        _fileSystemStrategy.Mount(location);
        Root = _fileSystemStrategy.Map();
        CurrentDirectory = Root;
    }

    public Directory Map(Path path)
    {
        return _fileSystemStrategy.Map(path.Value);
    }

    public void Remap()
    {
        if (Root == null || CurrentDirectory == null)
        {
            throw new FileSystemException("File system is not connected!");
        }

        Root = _fileSystemStrategy.Map();
        CurrentDirectory = GetDir(CurrentDirectory.GetPath());
    }

    public void Disconnect()
    {
        Root = null;
        CurrentDirectory = null;
    }

    public byte[] GetFileData(Path path)
    {
        string[] splitPath = path.Value.Split("/");
        string filename = splitPath.Last();
        Path absolute = GetAbsolutePath(new Path(string.Join("/", splitPath.SkipLast(1))));
        return _fileSystemStrategy.GetFileData(absolute.Value + "/" + filename);
    }

    public void WriteFileData(Path path, byte[] fileData)
    {
        string[] splitPath = path.Value.Split("/");
        string filename = splitPath.Last();
        Path absolute = GetAbsolutePath(new Path(string.Join("/", splitPath.SkipLast(1))));
        _fileSystemStrategy.WriteFileData(absolute.Value + "/" + filename, fileData);
    }

    public void DeleteFile(Path path)
    {
        string[] splitPath = path.Value.Split("/");
        string filename = splitPath.Last();
        Path absolute = GetAbsolutePath(new Path(string.Join("/", splitPath.SkipLast(1))));
        _fileSystemStrategy.DeleteFile(absolute.Value + "/" + filename);
    }

    public void GoToDir(Path path)
    {
        if (Root == null)
        {
            throw new FileSystemException("File system is not connected!");
        }

        Directory? root = path.IsRelative ? CurrentDirectory : Root;
        CurrentDirectory = GetDirectory(root, path);
    }

    public Directory GetDir(Path path)
    {
        Directory? root = path.IsRelative ? CurrentDirectory : Root;
        return GetDirectory(root, path);
    }

    private static Directory GetDirectory(Directory? root, Path path)
    {
        if (root == null)
        {
            throw new FileSystemException("File system is not connected!");
        }

        Directory head = root;
        string[] dirs = path.Value.Split("/");
        int skip = path.IsAbsolute ? 1 : 0;
        head = dirs.Skip(skip).Aggregate(head, (current, dir) => current.GetSubDirectory(dir));
        return head;
    }

    private Path GetAbsolutePath(Path path)
    {
        Directory? root = path.IsRelative ? CurrentDirectory : Root;
        return GetDirectory(root, path).GetPath();
    }

    private File GetFile(Path path)
    {
        string filename = path.Value.Split("/").Last();
        string enclosingDirRelativePath = string.Join("/", path.Value.Split("/").SkipLast(1));
        Path absolutePath = GetAbsolutePath(new Path(enclosingDirRelativePath));

        Directory directory = GetDir(absolutePath);
        return new File(filename, directory.GetPath());
    }
}