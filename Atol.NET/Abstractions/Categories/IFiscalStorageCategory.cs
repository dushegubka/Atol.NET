using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IFiscalStorageCategory
{
    /// <summary>
    /// Возвращает информацию о фискальном накопителе
    /// </summary>
    /// <returns>FiscalStorageInfo</returns>
    KktResponse<FiscalStorageInfo> GetFiscalStorageInfo();
    
    /// <summary>
    /// Возвращает информацию о последнем чеке
    /// </summary>
    /// <returns>LastReceiptInfo</returns>
    KktResponse<LastReceiptInfo> GetLastReceiptInfo();
}