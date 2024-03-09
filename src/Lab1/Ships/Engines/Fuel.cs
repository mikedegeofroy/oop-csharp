namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

public abstract record Fuel(double Amount, double Rarity)
{
    public record ActivePlasmaFuel(double Amount) : Fuel(Amount, 0.5);

    public record GravitonMatterFuel(double Amount) : Fuel(Amount, 1);
}