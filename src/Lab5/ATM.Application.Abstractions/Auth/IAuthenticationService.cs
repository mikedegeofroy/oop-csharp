namespace AutomatedTellerMachine.Abstractions.Auth;

public interface IAuthenticationService
{
    GenerateResult Generate(string id, string pin);
    ValidationResult Validate(string id, string token);
}