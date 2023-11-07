namespace Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

public class BaseWifiAdapter : IWifiAdapter
{
    public BaseWifiAdapter(string wifiVersion, string pcieVersion, bool integratedBluetooth, int consumption)
    {
        Power = new Power(consumption);
        WifiVersion = wifiVersion;
        PcieVersion = pcieVersion;
        IntegratedBluetooth = integratedBluetooth;
    }

    public string WifiVersion { get; }
    public string PcieVersion { get; }
    public bool IntegratedBluetooth { get; }
    public Power Power { get; }
    public ValidationResult Validate()
    {
        return new ValidationResult.Success();
    }
}