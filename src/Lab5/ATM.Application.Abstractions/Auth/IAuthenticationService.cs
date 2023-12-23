namespace AutomatedTellerMachine.Abstractions.Auth;

public interface IAuthenticationService
{
    GenerateResult Generate(long id, string hashedPin);
    ValidationResult Validate(long id, string token);
}