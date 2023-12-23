using AutomatedTellerMachine.Contracts.Accounts;

namespace AutomatedTellerMachine.Contracts.Admin;

public interface IAdminService
{
    LoginResult AdminLogin(string hashPass);
}