using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Misc.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class Show : ICommand
{
    private readonly Path _source;

    public Show(Path source)
    {
        _source = source;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        byte[] file = fileSystem.GetFileData(_source);
        return new CommandOutput.Success(Encoding.UTF8.GetString(file, 0, file.Length));
    }

    public class Builder : ICommandBuilder
    {
        private Path? _source;
        private IPrinter? _printer;

        public Builder SetSource(string source)
        {
            _source = new Path(source);
            return this;
        }

        public Builder SetPrinter(IPrinter printer)
        {
            _printer = printer;
            return this;
        }

        public ICommand Build()
        {
            if (_source == null) throw new ArgumentException();
            return new Show(_source);
        }
    }
}