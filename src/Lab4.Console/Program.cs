using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Strategies;

var fileSystem = new FileSystem();
fileSystem.Connect("/Users/mikedegeofroy/Desktop", new MacOsFileSystemStrategy());

var parser = new CommandParser(fileSystem);

while (true)
{
    string? command = Console.ReadLine();
    if (!string.IsNullOrEmpty(command))
    {
        ParserOutput output = parser.Parse(command);
        Console.WriteLine(output.Message);
    }
}