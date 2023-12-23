namespace AutomatedTellerMachine.Abstractions.Auth;

public abstract record GenerateResult
{
    private GenerateResult() { }

    public sealed record Success(string Token) : GenerateResult;

    public sealed record NotFound : GenerateResult;
}