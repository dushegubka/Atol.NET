using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class TcpIpConnector : ITcpIpConnector
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;
    private string _defaultPort = "5555";

    public TcpIpConnector(IFptr kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    
    
    public KktBaseResponse Connect()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_PORT, Constants.LIBFPTR_PORT_TCPIP .ToString());
            _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_IPPORT, _defaultPort);

            _kkt.applySingleSettings();
            _kkt.open();
        });
    }

    public ITcpIpConnector WithIp(string ip)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_IPADDRESS, ip);

        return this;
    }

    public ITcpIpConnector WithPort(string port)
    {
        _defaultPort = port;

        return this;
    }
}