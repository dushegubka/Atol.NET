using Atol.NET.Abstractions.Categories;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IAtolApi
{
    KktResponse<KktGeneralInfo> GetGeneralInfo();
    KktBaseResponse PowerOff();
    KktBaseResponse Reboot();
    KktBaseResponse Beep();
    KktBaseResponse Beep(int frequency, int duration);
    KktBaseResponse SetDateTime(DateTime dateTime);
    IAtolViewSerializer? Serializer { get; }
    IFiscalStorageCategory FiscalStorageCategory { get; }
    bool IsConnected { get; }
}