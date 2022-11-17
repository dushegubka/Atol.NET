using Atol.NET.Abstractions;
using Atol.NET.Exceptions;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class KktRequestService : IKktRequestService
{
    private readonly IKktDriver _kkt;
    private readonly IAtolViewSerializer _serializer;

    //TODO: добавить сброс параметров IFptr после каждого запроса
    public KktRequestService(IKktDriver kkt, IAtolViewSerializer serializer)
    {
        _kkt = kkt;
        _serializer = serializer;
    }

    public KktBaseResponse SendRequest(Action action)
    {
        try
        {
            action.Invoke();
            CheckAndThrowIfError();
            return new KktBaseResponse
            {
                IsSuccess = true,
                Error = new KktResponseError
                {
                    Code = 0,
                    Description = string.Empty
                }
            };
        }
        catch (AtolException e)
        {
            return new KktBaseResponse
            {
                IsSuccess = false,
                Error = new KktResponseError
                {
                    Code = e.ErrorCode,
                    Description = e.Message
                }
            };
        }
    }

    public KktResponse<T> GetData<T>()
    {
        try
        {
            var response = _serializer.GetView<T>();
            return new KktResponse<T>
            {
                Data = response,
                IsSuccess = true,
                Error = new KktResponseError
                {
                    Code = 0,
                    Description = string.Empty
                }
            };
        }
        catch (AtolException e)
        {
            return new KktResponse<T>
            {
                IsSuccess = false,
                Error = new KktResponseError
                {
                    Code = e.ErrorCode,
                    Description = e.Message
                }
            };
        }
        finally
        {
            _kkt.ResetParams();
        }
    }

    public KktResponse<T> GetDataByConstant<T>(int constant)
    {
        try
        {
            var response = _serializer.GetValueByConstant<T>(constant);

            return new KktResponse<T>
            {
                Data = response,
                IsSuccess = true,
                Error = new KktResponseError
                {
                    Code = 0,
                    Description = string.Empty
                }
            };
        }
        catch (AtolException e)
        {
            return new KktResponse<T>
            {
                IsSuccess = false,
                Error = new KktResponseError
                {
                    Code = e.ErrorCode,
                    Description = e.Message
                }
            };
        }
        finally
        {
            _kkt.ResetParams();
        }
    }

    public KktResponse<T> GetDataByConstant<T>(Enum constant)
    {
        try
        {
            var response = _serializer.GetValueByConstant<T>(Convert.ToInt32(constant));

            return new KktResponse<T>
            {
                Data = response,
                IsSuccess = true,
                Error = new KktResponseError
                {
                    Code = 0,
                    Description = string.Empty
                }
            };
        }
        catch (AtolException e)
        {
            return new KktResponse<T>
            {
                IsSuccess = false,
                Error = new KktResponseError
                {
                    Code = e.ErrorCode,
                    Description = e.Message
                }
            };
        }
        finally
        {
            _kkt.ResetParams();
        }
    }

    private void CheckAndThrowIfError()
    {
        var result = _kkt.ErrorCode();

        if (result == 0)
            return;

        var message = _kkt.ErrorDescription();

        // сбрасываем ошибку, чтобы не уйти в бесконечную ошибку (драйвер не сбрасывает самостоятельно ошибки при вызове методов)
        _kkt.ResetError();

        throw new AtolException(message, result);
    }
}