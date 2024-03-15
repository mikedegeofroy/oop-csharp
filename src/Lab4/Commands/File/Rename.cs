using System;
using System.Threading.Tasks;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class Rename : ICommand
{
    private readonly Path _source;
    private readonly Path _destination;

    public Rename(Path source, Path destination)
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
        return new CommandOutput.Success("Successfully renamed file.");
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
            return new Rename(_source, _destination);
        }
    }
}