using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class AtolApi : IAtolApi
{
    private readonly IFptr _kkt;
    
    public AtolApi()
    {
        _kkt = new Fptr();
        _kkt.open();

        IsConnected = _kkt.isOpened();
    }

    public AtolApi(string libraryPath)
    {
        _kkt = new Fptr(libraryPath);
        _kkt.open();
        
        IsConnected = _kkt.isOpened();
    }

    public AtolApi(string id, string libraryPath)
    {
        _kkt = new Fptr(id, libraryPath);
        _kkt.open();
        
        IsConnected = _kkt.isOpened();
    }

    /// <summary>
    /// Возвращает общую информацию о ККТ
    /// </summary>
    /// <returns>Общая информация о ККТ</returns>
    public GeneralInfoResponse GetGeneralInfo()
    {
        throw new NotImplementedException();
    }

    
    /// <summary>
    /// Выключение ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public ResponseBase PowerOff()
    {
        var response = new ResponseBase();

        var statusCode = _kkt.devicePoweroff();

        return statusCode < 0 ? GetErrorResponse() : GetSuccessResponse();
    }

    /// <summary>
    /// Перезагрузка ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public ResponseBase Reboot()
    {
        var response = new ResponseBase();
        
        var statusCode = _kkt.deviceReboot();

        return statusCode < 0 ? GetErrorResponse() : GetSuccessResponse();
    }
    
    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <returns>ResponseBase</returns>
    public ResponseBase Beep()
    {
        var statusCode = _kkt.beep();

        return statusCode < 0 ? GetErrorResponse() : GetSuccessResponse();
    }

    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <param name="frequency">Частота</param>
    /// <param name="duration">Длительность</param>
    /// <returns>ResponseBase</returns>
    public ResponseBase Beep(int frequency, int duration)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FREQUENCY, frequency);
        _kkt.setParam(Constants.LIBFPTR_PARAM_DURATION, duration);
        
        var statusCode = _kkt.beep();

        return statusCode < 0 ? GetErrorResponse() : GetSuccessResponse();
    }
    
    /// <summary>
    /// Подключена ли ККТ
    /// </summary>
    public bool IsConnected { get; private set; }

    private ResponseBase GetErrorResponse()
    {
        var response = new ResponseBase()
        {
            IsSuccess = false,
            ErrorCode = _kkt.errorCode(),
            Description = _kkt.errorDescription()
        };

        _kkt.resetError();

        return response;
    }

    private ResponseBase GetSuccessResponse()
    {
        var response = new ResponseBase()
        {
            IsSuccess = true
        };

        return response;
    }
}