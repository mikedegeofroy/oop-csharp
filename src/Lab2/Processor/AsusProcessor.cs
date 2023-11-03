namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public class AsusProcessor : IProcessor
{
    public AsusProcessor()
    {
        Socket = CpuSocket.Lga1151;
    }

    public CpuSocket Socket { get; }

    public Result Validate()
    {
        throw new System.NotImplementedException();
    }
}