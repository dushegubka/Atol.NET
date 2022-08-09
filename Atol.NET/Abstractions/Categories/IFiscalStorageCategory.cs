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
    
    /// <summary>
    /// Возвращает информацию о версиях ФФД
    /// </summary>
    /// <returns>Информация о версиях ФФД</returns>
    KktResponse<FfdVersionsInfo> GetFfdVersionsInfo();
    
    /// <summary>
    /// Возвращает информацию о сроке действия ФН
    /// </summary>
    /// <returns>Информация о сроке действия ФН</returns>
    KktResponse<FnValidityInfo> GetFnValidityInfo();
    
    /// <summary>
    /// Возвращает количество дней, оставшихся до окончания срока действия ФН
    /// </summary>
    /// <param name="date">Дата с которой начать считать дни до окончания</param>
    /// <returns>Количество дней, оставшихся до окончания срока действия</returns>
    KktResponse<uint> GetFnRemainingDays(DateTime date);

    /// <summary>
    /// Возвращает ошибки обмена с ОФД
    /// </summary>
    /// <returns>Ошибки обмена с ОФД</returns>
    KktResponse<OfdError> GetOfdErrors();
    
    /// <summary>
    /// Возвращает квитанцию ОФД из ФН 
    /// </summary>
    /// <param name="receiptNumber">Номер документа в фискальном накопителе</param>
    /// <returns>Квитанция ОФД</returns>
    KktResponse<OfdReceipt> GetOfdReceipt(int receiptNumber);
}