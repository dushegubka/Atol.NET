using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Enums;
using Atol.NET.Models.Responses;

namespace Atol.NET.Models.Connectors;

public class ComConnector : IComConnector
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public ComConnector(IKktDriver kkt, IKktRequestService requestService)
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

    public IComConnector OnPort(int port)
    {
        // Вариант только для Windows
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_COM_FILE, $"COM{port}");

        return this;
    }

    public IComConnector WithBaudRate(ComBaudRate baudRate)
    {
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_BAUDRATE, baudRate.ToString());

        return this;
    }

    public IComConnector WithDataBits(ComDataBits dataBits)
    {
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_BITS, dataBits.ToString());

        return this;
    }

    public IComConnector WithParity(ComParity parity)
    {
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_PARITY, parity.ToString());

        return this;
    }

    public IComConnector WithStopBits(ComStopBits stopBits)
    {
        _kkt.SetSingleSetting(Constants.LIBFPTR_SETTING_STOPBITS, stopBits.ToString());

        return this;
    }
}