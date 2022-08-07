using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IKktRequestService
{
    KktBaseResponse SendRequest(Action action);
    KktResponse<T> GetData<T>() where T : class;
}