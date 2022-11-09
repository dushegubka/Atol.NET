namespace Atol.NET.Abstractions.Connectors;

public interface IFluentConnector
{
    ITcpIpConnector TcpIp { get; }

    IBluetoothConnector Bluetooth { get; }

    IComConnector Com { get; }

    IUsbConnector Usb { get; }
}