namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

public interface IFileSystemStrategy
{
    Directory Map(string path = "");
    byte[] GetFileData(string path);
    void Mount(string location);
    void WriteFileData(string? path, byte[] fileData);
    void DeleteFile(string? path);
}