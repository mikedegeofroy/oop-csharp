namespace Itmo.ObjectOrientedProgramming.Lab2.GraphicsCard;

public interface IGraphicsCard : IValidatable, IPowerManagement
{
    public Dimensions Dimensions { get; }
    public string PcieVersion { get; }
    public double ClockRate { get; }
    public int Memory { get; }
}