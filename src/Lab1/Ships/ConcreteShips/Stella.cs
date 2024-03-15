using Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.DriveEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.ConcreteShips;

public class Stella : IShip
{
    private readonly IDamagable _hull;

    public Stella(bool photonDeflector = false, bool antiNitrineEmitter = false)
    {
        PhotonDeflector = photonDeflector;
        AntiNitrineEmitter = antiNitrineEmitter;
        _hull = new DeflectorClass1(new HullClass1());
        DriveEngine = new ConstantDriveEngine();
        JumpEngine = new OmegaJumpEngine();
    }

    public bool PhotonDeflector { get; }
    public bool AntiNitrineEmitter { get; }
    public IDriveEngine DriveEngine { get; }
    public IJumpEngine? JumpEngine { get; }

    public void TakeDamage(double points)
    {
        _hull.TakeDamage(points);
    }
}