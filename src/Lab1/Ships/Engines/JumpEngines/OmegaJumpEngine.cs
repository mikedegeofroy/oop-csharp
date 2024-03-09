using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;

public class OmegaJumpEngine : IJumpEngine
{
    private const double TimeFactor = 1.0;
    private const double ConsumptionFactor = 1.0;

    public EngineConsumption GetConsumption(int distance)
    {
        int time = (int)(TimeFactor * distance * Math.Log(distance));
        double consumption = ConsumptionFactor * distance * Math.Log(distance);

        return new EngineConsumption(time, new Fuel.GravitonMatterFuel(consumption));
    }

    public int GetRange()
    {
        return 150;
    }
}