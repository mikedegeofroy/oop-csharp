using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public static class ShipRepository
{
    public static IShip CreateShip(string name, bool photonDeflector = false, bool antiNitrineEmitter = false)
    {
        return name switch
        {
            "Avgur" => new Avgur(photonDeflector, antiNitrineEmitter),
            "PleasureShuttle" => new PleasureShuttle(photonDeflector, antiNitrineEmitter),
            "Meridian" => new Meridian(photonDeflector, antiNitrineEmitter),
            "Stella" => new Stella(photonDeflector, antiNitrineEmitter),
            "Vaklass" => new Vaklass(photonDeflector, antiNitrineEmitter),
            _ => throw new ArgumentException($"Unknown ship type: {name}", nameof(name)),
        };
    }
}