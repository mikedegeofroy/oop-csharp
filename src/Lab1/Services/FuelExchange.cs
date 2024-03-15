using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class FuelExchange
{
    public static double GetFuelPrice(Fuel fuel)
    {
        return fuel.Amount * fuel.Rarity;
    }
}