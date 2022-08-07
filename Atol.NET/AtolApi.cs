using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.DataProviders;
using Atol.NET.Exceptions;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class AtolApi : IAtolApi
{
    private readonly IFptr _kkt;

    private readonly IEnumerable<IAtolDataProvider> _dataProviders;

    // TODO: перенести инициализацию в фабричный метод
    public AtolApi()
    {
        _kkt = new Fptr();
        _kkt.open();

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
    }

    public AtolApi(string libraryPath)
    {
        _kkt = new Fptr(libraryPath);
        _kkt.open();
        
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
    }

    public AtolApi(string id, string libraryPath)
    {
        _kkt = new Fptr(id, libraryPath);
        _kkt.open();
        
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
    }

    /// <summary>
    /// Возвращает общую информацию о ККТ
    /// </summary>
    /// <returns>Общая информация о ККТ</returns>
    public KktResponse<KktGeneralInfo> GetGeneralInfo()
    {
        throw new NotImplementedException();
    }

    
    /// <summary>
    /// Выключение ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public KktBaseResponse PowerOff()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Перезагрузка ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public KktBaseResponse Reboot()
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public KktBaseResponse Beep()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <param name="frequency">Частота</param>
    /// <param name="duration">Длительность</param>
    /// <returns>ResponseBase</returns>
    public KktBaseResponse Beep(int frequency, int duration)
    {
        throw new NotImplementedException();
    }

    public IAtolViewSerializer Serializer { get; }

    /// <summary>
    /// Подключена ли ККТ
    /// </summary>
    public bool IsConnected { get; private set; }
}