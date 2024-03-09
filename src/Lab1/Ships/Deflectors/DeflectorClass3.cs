namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;

public class DeflectorClass3 : IDamagable
{
    private readonly IDamagable _damagable;

    public DeflectorClass3(IDamagable damagable)
    {
        _damagable = damagable;
    }

    public double TakeDamage(double points)
    {
        return _damagable.TakeDamage(points);
    }
}