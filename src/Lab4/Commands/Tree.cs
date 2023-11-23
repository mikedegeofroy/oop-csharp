using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Tree : ICommand
{
    private readonly FileSystem.FileSystem _fileSystem;

    public Tree(FileSystem.FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        Directory root = _fileSystem.CurrentDirectory ?? new Directory("/");
        PrintDirectory(root, 0, new List<bool>());
    }

    private static void PrintIndentation(int level, List<bool> parentLevels)
    {
        for (int i = 0; i < level - 1; i++)
        {
            Console.Write(parentLevels[i] ? "\u2502\t" : "\t");
        }

        // Use a different symbol for the last item
        Console.Write(parentLevels.Count > 0 && parentLevels[^1] ? "\u251c\u2500\u2500 " : "\u2514\u2500\u2500 ");
    }

    private static void PrintFile(File file, int level, List<bool> parentLevels)
    {
        PrintIndentation(level, parentLevels);
        Console.WriteLine("\ud83c\udf0c " + file.Name);
    }

    private void PrintDirectory(Directory directory, int level, List<bool> parentLevels)
    {
        if (level > 0)
        {
            PrintIndentation(level, parentLevels);
        }

        Console.WriteLine("📂" + directory.Name);

        List<bool> newParentLevels;

        var files = directory.Files.ToList();
        for (int i = 0; i < files.Count; i++)
        {
            bool isLast = false;
            newParentLevels = new List<bool>(parentLevels) { !isLast };
            PrintFile(files[i], level + 1, newParentLevels);
        }

        var subDirs = directory.GetSubDirectories().ToList();
        for (int i = 0; i < subDirs.Count; i++)
        {
            bool isLast = i == subDirs.Count - 1;
            newParentLevels = new List<bool>(parentLevels) { !isLast };
            PrintDirectory(subDirs[i], level + 1, newParentLevels);
        }
    }
}
