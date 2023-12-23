using AutomatedTellerMachine.Models;

namespace ATM.Presentation.Console.CurrentAccount;

public record CurrentAccount(long Id, string Token) : Account(Id);