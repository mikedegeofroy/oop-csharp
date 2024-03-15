using System;
using System.Threading.Tasks;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class Delete : ICommand
{
    private readonly Path _source;

    public Delete(Path source)
    {
        _source = source;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        fileSystem.DeleteFile(_source);
        Task.Run(fileSystem.Remap);
        return new CommandOutput.Success("Successfully deleted file");
    }

    public class Builder : ICommandBuilder
    {
        private Path? _source;

        public Builder SetFile(string source)
        {
            _source = new Path(source);
            return this;
        }

        public ICommand Build()
        {
            if (_source == null) throw new ArgumentException();
            return new Delete(_source);
        }
    }
}