namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record BuildResult
{
    public abstract bool ToBoolean();

    public record Success(string Message, Computer Computer) : BuildResult
    {
        public override bool ToBoolean() => true;
    }

    public record Failure(string Message) : BuildResult
    {
        public override bool ToBoolean() => false;
    }
}