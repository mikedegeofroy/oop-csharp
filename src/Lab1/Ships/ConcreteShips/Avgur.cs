using Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;

public class Avgur : IShip
{
    private readonly IDamagable _hull;

    public Avgur()
    {
        DriveEngine = new ExponentialDriveEngine();
        JumpEngine = new AlphaJumpEngine();
        _hull = new DeflectorClass3(new HullClass3());
    }

    public IDriveEngine DriveEngine { get; }
    public IJumpEngine? JumpEngine { get; }

    public void TakeDamage(double points)
    {
        _hull.TakeDamage(points);
    }
}