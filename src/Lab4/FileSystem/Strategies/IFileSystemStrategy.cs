namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

public interface IFileSystemStrategy
{
    Directory Map(string location);
    byte[] GetFileData(string path);
    void WriteFileData(string path, byte[] fileData);
    void DeleteFile(string path);
}