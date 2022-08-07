using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Exceptions;
using Atol.NET.Models.Responses;

namespace Atol.NET;

public class KktRequestService : IKktRequestService
{
    private readonly IFptr _kkt;
    private readonly IAtolViewSerializer _serializer;

    public KktRequestService(IFptr kkt, IAtolViewSerializer serializer)
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
                Error = new KktResponseError()
            };
        }
        catch (AtolException e)
        {
            Console.WriteLine(e);
            return new KktBaseResponse()
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

    public KktResponse<T> GetData<T>() where T : class
    {
        try
        {
            var response = _serializer.GetView<T>();
            return new KktResponse<T>
            {
                Data = response,
                IsSuccess = true,
                Error = new KktResponseError()
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
    }
    
    private void CheckAndThrowIfError()
    {
        var result = _kkt.errorCode();

        if (result == 0) 
            return;
        
        var message = _kkt.errorDescription();

        // сбрасываем ошибку, чтобы не уйти в бесконечную ошибку (драйвер не сбрасывает самостоятельно ошибки при вызове методов)
        _kkt.resetError();
        
        throw new AtolException(message, result);
    }
}