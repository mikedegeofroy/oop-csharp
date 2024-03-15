namespace Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

public interface IWifiAdapter : IValidatable, IPowerManagement
{
    public string WifiVersion { get; }
    public string PcieVersion { get; }
    public bool IntegratedBluetooth { get; }
}