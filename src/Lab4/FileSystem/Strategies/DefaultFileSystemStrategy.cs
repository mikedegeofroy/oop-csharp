namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

public class DefaultFileSystemStrategy : IFileSystemStrategy
{
    public Directory Map(string path)
    {
        throw new System.NotImplementedException();
    }

    public byte[] GetFileData(string path)
    {
        throw new System.NotImplementedException();
    }

    public void Mount(string location)
    {
        throw new System.NotImplementedException();
    }

    public void WriteFileData(string? path, byte[] fileData)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteFile(string? path)
    {
        throw new System.NotImplementedException();
    }
}