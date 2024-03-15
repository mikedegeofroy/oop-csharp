using System;
using System.Threading.Tasks;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class Move : ICommand
{
    private readonly Path _source;
    private readonly Path _destination;

    public Move(Path source, Path destination)
    {
        _source = source;
        _destination = destination;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        byte[] data = fileSystem.GetFileData(_source);
        fileSystem.DeleteFile(_source);
        fileSystem.WriteFileData(_destination, data);
        Task.Run(fileSystem.Remap);
        return new CommandOutput.Success("Successfully moved file");
    }

    public class Builder : ICommandBuilder
    {
        private Path? _source;
        private Path? _destination;

        public Builder SetSource(string source)
        {
            _source = new Path(source);
            return this;
        }

        public Builder SetDestination(string destination)
        {
            _destination = new Path(destination);
            return this;
        }

        public ICommand Build()
        {
            if (_source == null) throw new ArgumentException();
            if (_destination == null) throw new ArgumentException();
            return new Move(_source, _destination);
        }
    }
}