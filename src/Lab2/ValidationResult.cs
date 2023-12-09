namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record ValidationResult
{
    public abstract bool ToBoolean();

    public record Success() : ValidationResult
    {
        public override bool ToBoolean() => true;
    }

    public record Warning(string Message) : ValidationResult
    {
        public override bool ToBoolean() => true;
    }

    public record Failure(string Message) : ValidationResult
    {
        public override bool ToBoolean() => false;
    }
}