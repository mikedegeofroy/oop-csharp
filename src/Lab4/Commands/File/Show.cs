using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Misc.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class Show : ICommand
{
    private readonly Path _source;
    private readonly IPrinter _printer;

    public Show(Path source, IPrinter printer)
    {
        _source = source;
        _printer = printer;
    }

    public CommandOutput Execute(FileSystem.FileSystem fileSystem)
    {
        byte[] file = fileSystem.GetFileData(_source);
        _printer.Out(Encoding.UTF8.GetString(file, 0, file.Length));
        return new CommandOutput.Success("Successfully outputted file.");
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
            if (_printer == null) throw new ArgumentException();
            return new Show(_source, _printer);
        }
    }
}