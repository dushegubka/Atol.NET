using System.Runtime.InteropServices;
using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class UsbConnector : IUsbConnector
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public UsbConnector(IFptr kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    
    public KktBaseResponse Connect()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.applySingleSettings();
            _kkt.open();
        });
    }

    /// <summary>
    /// Задаёт расположение USB-устройства в системе
    /// <remarks><b>Только для Linux</b></remarks>
    /// </summary>
    /// <param name="devicePath">Расположение USB-устройства</param>
    /// <returns>IUsbConnector</returns>
    public IUsbConnector SetDevicePath(string devicePath)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new PlatformNotSupportedException("This method is only available on Linux");
        
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_USB_DEVICE_PATH, devicePath);

        return this;
    }
}