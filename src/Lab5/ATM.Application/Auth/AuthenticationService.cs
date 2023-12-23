using System.Security.Cryptography;
using System.Text;
using AutomatedTellerMachine.Abstractions.Auth;
using AutomatedTellerMachine.Abstractions.Repositories;

namespace AutomatedTellerMachine.Application.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly Dictionary<string, string> _tokens = new();
    private readonly IPinRepository _pinRepository;

    public AuthenticationService(IPinRepository pinRepository)
    {
        _pinRepository = pinRepository;
    }

    public GenerateResult Generate(string id, string pin)
    {
        // check if the combination is correct
        string localPinHash = _pinRepository.GetPinHashByUserId(id);
        string pinHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(pin)));

        return localPinHash == pinHash ? new GenerateResult.Success(GenerateToken(id)) : new GenerateResult.NotFound();
    }

    public ValidationResult Validate(string id, string token)
    {
        if (_tokens[token] != id) return new ValidationResult.NotFound();

        byte[] data = Convert.FromBase64String(token);
        var when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
        if (when < DateTime.UtcNow.AddMinutes(-5))
        {
            return new ValidationResult.TimedOut();
        }

        return new ValidationResult.Success();
    }

    private string GenerateToken(string id)
    {
        byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        byte[] key = Guid.NewGuid().ToByteArray();
        string token = Convert.ToBase64String(time.Concat(key).ToArray());
        _tokens.Add(token, id);
        return token;
    }
}