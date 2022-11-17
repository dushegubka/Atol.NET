using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IKktRequestService
{
    KktBaseResponse SendRequest(Action action);
    KktResponse<T> GetData<T>();

    KktResponse<T> GetDataByConstant<T>(int constant);
    KktResponse<T> GetDataByConstant<T>(Enum constant);
}