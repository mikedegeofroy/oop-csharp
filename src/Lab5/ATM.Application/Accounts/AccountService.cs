using AutomatedTellerMachine.Abstractions.Auth;
using AutomatedTellerMachine.Abstractions.Repositories;
using AutomatedTellerMachine.Contracts.Accounts;
using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationsRepository _operationsRepository;

    public AccountService(IAuthenticationService authenticationService, IAccountRepository accountRepository, IOperationsRepository operationsRepository)
    {
        _authenticationService = authenticationService;
        _accountRepository = accountRepository;
        _operationsRepository = operationsRepository;
    }

    public LoginResult Login(long id, string hashedPin)
    {
        GenerateResult token = _authenticationService.Generate(id, hashedPin);

        return token switch
        {
            GenerateResult.Success success => new LoginResult.Success(success.Token),
            _ => new LoginResult.NotFound(),
        };
    }

    public double GetBalance(long id, string token)
    {
        _authenticationService.Validate(id, token);

        return _accountRepository.GetBalanceByAccountId(id);
    }

    public IEnumerable<Operation> GetOperations(long id, string token)
    {
        _authenticationService.Validate(id, token);

        return _operationsRepository.GetOperationsByAccount(id);
    }

    public OperationResult Credit(double amount, long id, string token)
    {
        _authenticationService.Validate(id, token);

        double balance = _accountRepository.GetBalanceByAccountId(id);

        if (balance < amount) return new OperationResult.Failure();

        _operationsRepository.AddOperation(id, -amount);
        _accountRepository.Credit(id, amount);
        return new OperationResult.Success();
    }

    public OperationResult Debit(double amount, long id, string token)
    {
        _authenticationService.Validate(id, token);

        _operationsRepository.AddOperation(id, amount);

        _accountRepository.Debit(id, amount);
        Console.WriteLine(amount);
        return new OperationResult.Success();
    }

    public long Create(string hashedPin)
    {
        return _accountRepository.CreateAccount(hashedPin).Id;
    }
}