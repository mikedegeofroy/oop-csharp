namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record Result
{
    public abstract bool ToBoolean();

    public record Success : Result
    {
        public override bool ToBoolean() => true;
    }

    public record Failure(string Message) : Result
    {
        public override bool ToBoolean() => false;
    }
}