using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;

namespace Atol.NET.Models.Connectors;

public class FluentConnector : IFluentConnector
{
    public FluentConnector(IFptr kkt, IKktRequestService requestService)
    { 
        TcpIp = new TcpIpConnector(kkt, requestService);
        Bluetooth = new BluetoothConnector(kkt, requestService);
        Com = new ComConnector(kkt, requestService);
        Usb = new UsbConnector(kkt, requestService);
    }
    public ITcpIpConnector TcpIp { get; }
    
    public IBluetoothConnector Bluetooth { get; }
    
    public IComConnector Com { get; }
    
    public IUsbConnector Usb { get; }
}