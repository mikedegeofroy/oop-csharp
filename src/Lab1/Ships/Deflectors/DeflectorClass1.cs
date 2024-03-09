namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Deflectors;

public class DeflectorClass1 : IDamagable
{
    private readonly IDamagable _damagable;
    private double _hp = 200;

    public DeflectorClass1(IDamagable damagable)
    {
        _damagable = damagable;
    }

    public double TakeDamage(double points)
    {
        double diff = _hp - points;
        _hp -= points;

        return diff > 0 ? _damagable.TakeDamage(diff) : _damagable.TakeDamage(0);
    }
}