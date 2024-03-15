namespace AutomatedTellerMachine.Contracts.Accounts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success(string Token) : LoginResult;

    public sealed record NotFound : LoginResult;
}