namespace Atol.NET.Abstractions.Connectors;

public interface IBluetoothConnector : IAtolConnector
{
    IBluetoothConnector WithMacAddress(string macAddress);
}