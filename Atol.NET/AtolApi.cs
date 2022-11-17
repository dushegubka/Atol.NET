using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Categories;
using Atol.NET.DataProviders;
using Atol.NET.Enums;
using Atol.NET.Models;
using Atol.NET.Models.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class AtolApi : IAtolApi
{
    private readonly IKktDriver _kkt;
    private IEnumerable<IAtolDataProvider>? _dataProviders;
    private IKktRequestService _requestService;

    public AtolApi()
    {
        _kkt = new KktDriver();

        Initialize();
    }

    public AtolApi(string libraryPath)
    {
        _kkt = new KktDriver(libraryPath);

        Initialize();
    }

    public AtolApi(string id, string libraryPath)
    {
        _kkt = new KktDriver(id, libraryPath);

        Initialize();
    }

    public IFluentConnector ConnectBy { get; private set; }

    public KktBaseResponse Disconnect()
    {
        return _requestService.SendRequest(() => { _kkt.Close(); });
    }

    /// <inheritdoc />
    public KktResponse<KktGeneralInfo> GetGeneralInfo()
    {
        _kkt.SetParam(Parameter.DataType, DataType.Status);
        _kkt.QueryData();

        var result = _requestService.GetData<KktGeneralInfo>();

        return result;
    }

    /// <inheritdoc />
    public KktResponse<KktLicenseState> GetLicenseState(int licenseId)
    {
        _kkt.SetParam(Parameter.DataType, DataType.LicenseActivated);
        _kkt.SetParam(Parameter.LicenseNumber, licenseId);
        _kkt.QueryData();

        return _requestService.GetData<KktLicenseState>();
    }

    /// <inheritdoc />
    public KktBaseResponse PowerOff()
    {
        return _requestService.SendRequest(() => { _kkt.DevicePoweroff(); });
    }

    /// <inheritdoc />
    public KktBaseResponse Reboot()
    {
        var result = _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.PrintReport, false);
            _kkt.DeviceReboot();
        });

        return result;
    }

    /// <inheritdoc />
    public KktBaseResponse Beep()
    {
        return _requestService.SendRequest(() => { _kkt.Beep(); });
    }

    /// <inheritdoc />
    public KktBaseResponse Beep(int frequency, int duration)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Frequency, frequency);
            _kkt.SetParam(Parameter.Duration, duration);
            _kkt.Beep();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse SetDateTime(DateTime dateTime)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.DateTime, dateTime);
            _kkt.WriteDateTime();
        });
    }

    /// <inheritdoc />
    public IAtolViewSerializer? Serializer { get; private set; }

    /// <inheritdoc />
    public IFiscalStorageCategory FiscalStorage { get; private set; }

    /// <inheritdoc />
    public IPrinterCategory Printer { get; private set; }

    /// <inheritdoc />
    public IReportsCategory Reports { get; private set; }

    /// <inheritdoc />
    public IRegistrationCategory Registration { get; set; }

    /// <inheritdoc />
    public ISettingsCategory Settings { get; private set; }

    /// <inheritdoc />
    public bool IsConnected => _kkt.IsOpened();

    private void Initialize()
    {
        _dataProviders = new List<IAtolDataProvider>
        {
            new IntAtolDataProvider(_kkt),
            new StringAtolDataProvider(_kkt),
            new DateTimeAtolDataProvider(_kkt),
            new BooleanAtolDataProvider(_kkt),
            new DoubleAtolDataProvider(_kkt),
            new ByteAtolDataProvider(_kkt)
        };

        Serializer = new DefaultViewSerializer(_dataProviders, _kkt);
        _requestService = new KktRequestService(_kkt, Serializer);

        ConnectBy = new FluentConnector(_kkt, _requestService);

        InitializerCategories();
    }

    private void InitializerCategories()
    {
        FiscalStorage = new FiscalStorageCategory(_kkt, _requestService);
        Printer = new PrinterCategory(_kkt, _requestService);
        Reports = new ReportsCategory(_kkt, _requestService);
        Registration = new RegistrationCategory(_kkt, _requestService);
        Settings = new SettingsCategory(_kkt, _requestService);
    }
}