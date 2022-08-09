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
    
    /// <summary>
    /// Возвращает информацию о последнем документе
    /// </summary>
    /// <returns>LastDocumentInfo</returns>
    KktResponse<LastDocumentInfo> GetLastDocumentInfo();
    
    /// <summary>
    /// Возвращает информацию о смене
    /// </summary>
    /// <returns>ShiftInfo</returns>
    KktResponse<ShiftInfo> GetShiftInfo();

    /// <summary>
    /// Возвращает количество фискальных документов за смену
    /// </summary>
    /// <returns>Количество фискальных документов за смену </returns>
    KktResponse<uint> GetFiscalDocumentsCount();
}