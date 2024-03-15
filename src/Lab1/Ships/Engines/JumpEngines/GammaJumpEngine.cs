using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;

public class GammaJumpEngine : IJumpEngine
{
    private const double TimeFactor = 1.0;
    private const double ConsumptionFactor = 1.0;

    public EngineConsumption GetConsumption(int distance)
    {
        int time = (int)(Math.Pow(distance, 3) * TimeFactor);
        double consumption = Math.Pow(distance, 3) * ConsumptionFactor;

        return new EngineConsumption(time, new Fuel.GravitonMatterFuel(consumption));
    }

    public int GetRange()
    {
        return 200;
    }
}