using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IFiscalStorageCategory
{
    KktResponse<FiscalStorageInfo> GetFiscalStorageInfo();
    
    KktResponse<LastReceiptInfo> GetLastReceiptInfo();
}