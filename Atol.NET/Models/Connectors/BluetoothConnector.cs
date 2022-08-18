using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class BluetoothConnector : IBluetoothConnector
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public BluetoothConnector(IFptr kkt, IKktRequestService requestService)
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

    public IBluetoothConnector WithMacAddress(string macAddress)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_MACADDRESS, macAddress);

        return this;
    }
}