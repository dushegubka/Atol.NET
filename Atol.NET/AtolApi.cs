﻿using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Categories;
using Atol.NET.DataProviders;
using Atol.NET.Exceptions;
using Atol.NET.Models;
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
        _kkt.open();

        Initialize();
    }

    public AtolApi(string libraryPath)
    {
        _kkt = new Fptr(libraryPath);
        _kkt.open();

        Initialize();
    }

    public AtolApi(string id, string libraryPath)
    {
        _kkt = new Fptr(id, libraryPath);
        _kkt.open();
        
        Initialize();
    }

    /// <inheridoc />
    public KktResponse<KktGeneralInfo> GetGeneralInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_STATUS);
        _kkt.queryData();

        var result = _requestService.GetData<KktGeneralInfo>();

        return result;
    }

    /// <inheridoc />
    public KktResponse<KktLicenseState> GetLicenseState(int licenseId)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_LICENSE_ACTIVATED);
        _kkt.setParam(Constants.LIBFPTR_PARAM_LICENSE_NUMBER, licenseId);
        _kkt.queryData();

        return _requestService.GetData<KktLicenseState>();
    }

    /// <inheridoc />
    public KktBaseResponse PowerOff()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.devicePoweroff();
        });
    }
    
    /// <inheridoc />
    public KktBaseResponse Reboot()
    {
        var result = _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_PRINT_REPORT, false);
            _kkt.deviceReboot();
        });

        return result;
    }
    
    /// <inheridoc />
    public KktBaseResponse Beep()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.beep();
        });
    }
    
    /// <inheridoc />
    public KktBaseResponse Beep(int frequency, int duration)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_FREQUENCY, frequency);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DURATION, duration);
            _kkt.beep();
        });
    }

    /// <inheridoc />
    public KktBaseResponse SetDateTime(DateTime dateTime)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_DATE_TIME, dateTime);
            _kkt.writeDateTime();
        });
    }

    /// <inheridoc />
    public IAtolViewSerializer? Serializer { get; private set; }
    
    /// <inheridoc />
    public IFiscalStorageCategory FiscalStorageCategory { get; private set; }
    
    /// <inheridoc />
    public bool IsConnected { get; private set; }

    private void Initialize()
    {
        IsConnected = _kkt.isOpened();
        
        _dataProviders = new List<IAtolDataProvider>()
        {
            new IntAtolDataProvider(_kkt),
            new StringAtolDataProvider(_kkt),
            new DateTimeAtolDataProvider(_kkt),
            new BooleanAtolDataProvider(_kkt),
            new DoubleAtolDataProvider(_kkt)
        };
        Serializer = new DefaultViewSerializer(_dataProviders, _kkt);
        _requestService = new KktRequestService(_kkt, Serializer);
        InitializerCategories();
    }

    private void InitializerCategories()
    {
        FiscalStorageCategory = new FiscalStorageCategory(_kkt, _requestService);
    }
}