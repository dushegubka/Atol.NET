using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Enums;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class ComConnector : IComConnector
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public ComConnector(IFptr kkt, IKktRequestService requestService)
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

    public IComConnector OnPort(int port)
    {
        // Вариант только для Windows
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_COM_FILE, $"COM{port}");

        return this;
    }

    public IComConnector WithBaudRate(ComBaudRate baudRate)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_BAUDRATE, baudRate.ToString());
        
        return this;
    }

    public IComConnector WithDataBits(ComDataBits dataBits)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_BITS, dataBits.ToString());

        return this;
    }

    public IComConnector WithParity(ComParity parity)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_PARITY, parity.ToString());

        return this;
    }

    public IComConnector WithStopBits(ComStopBits stopBits)
    {
        _kkt.setSingleSetting(Constants.LIBFPTR_SETTING_STOPBITS, stopBits.ToString());

        return this;
    }
}