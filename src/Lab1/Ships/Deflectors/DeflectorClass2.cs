namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;

public class DeflectorClass2 : IDamagable
{
    private readonly IDamagable _damagable;

    public DeflectorClass2(IDamagable damagable)
    {
        _damagable = damagable;
    }

    public double TakeDamage(double points)
    {
        return _damagable.TakeDamage(points);
    }
}