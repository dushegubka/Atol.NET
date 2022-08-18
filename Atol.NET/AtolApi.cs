using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Categories;
using Atol.NET.DataProviders;
using Atol.NET.Models;
using Atol.NET.Models.Connectors;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class AtolApi : IAtolApi
{
    private readonly IFptr _kkt;
    private IEnumerable<IAtolDataProvider>? _dataProviders;
    private IKktRequestService _requestService;
    public AtolApi()
    {
        _kkt = new Fptr();

        Initialize();
    }

    public AtolApi(string libraryPath)
    {
        _kkt = new Fptr(libraryPath);

        Initialize();
    }

    public AtolApi(string id, string libraryPath)
    {
        _kkt = new Fptr(id, libraryPath);
        
        Initialize();
    }

    public IFluentConnector ConnectBy { get; private set; }

    public KktBaseResponse Disconnect()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.close();
        });
    }

    /// <inheritdoc />
    public KktResponse<KktGeneralInfo> GetGeneralInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_STATUS);
        _kkt.queryData();

        var result = _requestService.GetData<KktGeneralInfo>();

        return result;
    }

    /// <inheritdoc />
    public KktResponse<KktLicenseState> GetLicenseState(int licenseId)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_LICENSE_ACTIVATED);
        _kkt.setParam(Constants.LIBFPTR_PARAM_LICENSE_NUMBER, licenseId);
        _kkt.queryData();

        return _requestService.GetData<KktLicenseState>();
    }

    /// <inheritdoc />
    public KktBaseResponse PowerOff()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.devicePoweroff();
        });
    }
    
    /// <inheritdoc />
    public KktBaseResponse Reboot()
    {
        var result = _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_PRINT_REPORT, false);
            _kkt.deviceReboot();
        });

        return result;
    }
    
    /// <inheritdoc />
    public KktBaseResponse Beep()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.beep();
        });
    }
    
    /// <inheritdoc />
    public KktBaseResponse Beep(int frequency, int duration)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_FREQUENCY, frequency);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DURATION, duration);
            _kkt.beep();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse SetDateTime(DateTime dateTime)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_DATE_TIME, dateTime);
            _kkt.writeDateTime();
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
    public bool IsConnected => _kkt.isOpened();
    private void Initialize()
    {
        _dataProviders = new List<IAtolDataProvider>()
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
    }
}