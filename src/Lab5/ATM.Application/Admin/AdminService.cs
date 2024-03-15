using AutomatedTellerMachine.Abstractions.Auth;
using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Contracts.Accounts;
using AutomatedTellerMachine.Contracts.Admin;

namespace AutomatedTellerMachine.Application.Admin;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAuthenticationService _authenticationService;

    public AdminService(IAccountRepository accountRepository, IAuthenticationService authenticationService)
    {
        _accountRepository = accountRepository;
        _authenticationService = authenticationService;
    }

    public LoginResult AdminLogin(string hashPass)
    {
        GenerateResult token = _authenticationService.Generate(0, hashPass);

        return token switch
        {
            GenerateResult.Success success => new LoginResult.Success(success.Token),
            _ => new LoginResult.NotFound(),
        };
    }
}