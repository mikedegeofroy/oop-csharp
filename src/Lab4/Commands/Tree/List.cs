using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class List : ICommand
{
    private readonly int _depth;
    private readonly string _root;
    private readonly StringBuilder _stringBuilder;

    public List(string root, int depth)
    {
        _root = root;
        _depth = depth;
        _stringBuilder = new StringBuilder();
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        PrintDirectory(fileSystem.GetDir(new Path(_root)), 0, new List<bool>());
        return new CommandOutput.Success(_stringBuilder.ToString());
    }

    private void PrintIndentation(int level, List<bool> parentLevels)
    {
        for (int i = 0; i < level - 1; i++)
        {
            _stringBuilder.Append(parentLevels[i] ? "\u2502\t" : "\t");
        }

        // Use a different symbol for the last item
        _stringBuilder.Append(
            parentLevels.Count > 0 && parentLevels[^1] ? "\u251c\u2500\u2500 " : "\u2514\u2500\u2500 ");
    }

    private void PrintFile(FileSystem.File file, int level, List<bool> parentLevels)
    {
        PrintIndentation(level, parentLevels);
        _stringBuilder.AppendLine("\ud83c\udf0c " + file.Name);
    }

    private void PrintDirectory(Directory directory, int level, List<bool> parentLevels)
    {
        if (level > _depth)
        {
            return;
        }

        if (level > 0)
        {
            PrintIndentation(level, parentLevels);
        }

        _stringBuilder.AppendLine("📂" + directory.Name);

        if (level == _depth)
        {
            return;
        }

        var files = directory.Files.ToList();
        var subDirs = directory.GetSubDirectories().ToList();
        int totalItems = files.Count + subDirs.Count;

        for (int i = 0; i < totalItems; i++)
        {
            bool isLast = i == totalItems - 1;
            var newParentLevels = new List<bool>(parentLevels) { !isLast };

            if (i < files.Count)
            {
                PrintFile(files[i], level + 1, newParentLevels);
            }
            else
            {
                PrintDirectory(subDirs[i - files.Count], level + 1, newParentLevels);
            }
        }
    }

    public class Builder : ICommandBuilder
    {
        private int _depth;
        private string? _directory;

        public Builder SetDepth(int depth)
        {
            _depth = depth;
            return this;
        }

        public Builder SetDirectory(string directory)
        {
            _directory = directory;
            return this;
        }

        public ICommand Build()
        {
            if (string.IsNullOrEmpty(_directory)) throw new ArgumentException();
            return new List(_directory, _depth);
        }
    }
}
