namespace Atol.NET.Abstractions.Connectors;

public interface IUsbConnector : IAtolConnector
{
    IUsbConnector SetDevicePath(string devicePath);
}