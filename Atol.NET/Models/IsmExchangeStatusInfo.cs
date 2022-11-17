using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

/// <summary>
///     Статус информационного обмена с ИСМ
///     <remarks>
///         <b>Поддерживается только для ККТ версий 5.X, работающих по ФФД ≥ 1.2</b>
///     </remarks>
/// </summary>
public class IsmExchangeStatusInfo
{
    /// <summary>
    ///     Количество непереданных документов
    /// </summary>
    [Constant(Parameter.DocumentsCount, typeof(int))]
    public int DocumentsCount { get; set; }

    /// <summary>
    ///     Номер первого непереданного уведомления
    /// </summary>
    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Дата и время первого непереданного уведомления
    /// </summary>
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime Date { get; set; }
}