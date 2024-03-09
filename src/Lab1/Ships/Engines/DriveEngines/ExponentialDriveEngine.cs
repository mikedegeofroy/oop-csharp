using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;

public class ExponentialDriveEngine : IDriveEngine
{
    private const double TimeFactor = 1.0;
    private const double ConsumptionFactor = 1.0;
    private const double DistanceFactor = 5.0;

    public EngineConsumption GetConsumption(int distance)
    {
        int time = (int)(Math.Pow(distance, 2) * TimeFactor);
        double consumption = ConsumptionFactor * Math.Exp(DistanceFactor * distance);

        return new EngineConsumption(time, new Fuel.ActivePlasmaFuel(consumption));
    }
}