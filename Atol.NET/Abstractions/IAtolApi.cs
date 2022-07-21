using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IAtolApi
{
    GeneralInfoResponse GetGeneralInfo();
    ResponseBase PowerOff();
    ResponseBase Reboot();
    ResponseBase Beep();
    ResponseBase Beep(int frequency, int duration);
    IAtolViewSerializer Serializer { get; }
    bool IsConnected { get; }
}