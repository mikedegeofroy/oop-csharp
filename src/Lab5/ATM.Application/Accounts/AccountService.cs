using AutomatedTellerMachine.Abstractions.Auth;
using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Contracts.Accounts;
using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAuthenticationService authenticationService, IAccountRepository accountRepository)
    {
        _authenticationService = authenticationService;
        _accountRepository = accountRepository;
    }

    public LoginResult Login(string id, string pin)
    {
        GenerateResult token = _authenticationService.Generate(id, pin);

        return token switch
        {
            GenerateResult.Success success => new LoginResult.Success(success.Token),
            _ => new LoginResult.NotFound(),
        };
    }

    public double GetBalance(string id, string token)
    {
        _authenticationService.Validate(id, token);
        Account account = _accountRepository.GetAccountById(id);
        return account.Balance;
    }

    public string Create(string pin)
    {
        return _accountRepository.CreateAccount(pin).Id;
    }
}