using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class BluetoothConnector : IBluetoothConnector
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public BluetoothConnector(IKktDriver kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    public KktBaseResponse Connect()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.ApplySingleSettings();
            _kkt.Open();
        });
    }

    public IBluetoothConnector WithMacAddress(string macAddress)
    {
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_MACADDRESS, macAddress);

        return this;
    }
}