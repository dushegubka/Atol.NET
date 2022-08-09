using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

/// <summary>
/// Статус информационного обмена с ИСМ
/// <remarks><b>Поддерживается только для ККТ версий 5.X, работающих по ФФД ≥ 1.2</b></remarks>
/// </summary>
public class IsmExchangeStatusInfo
{   
    /// <summary>
    /// Количество непереданных документов
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENTS_COUNT, typeof(int))]
    public int DocumentsCount { get; set; }

    /// <summary>
    /// Номер первого непереданного уведомления
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    /// Дата и время первого непереданного уведомления
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime Date { get; set; }
}