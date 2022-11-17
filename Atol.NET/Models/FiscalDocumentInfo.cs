using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalDocumentInfo
{
    /// <summary>
    ///     Тип документа
    /// </summary>
    [ParameterId(Parameter.FnDocumentType, typeof(FiscalDocumentType))]
    public FiscalDocumentType DocumentType { get; set; }

    /// <summary>
    ///     Дата и время документа
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Номер ФД
    /// </summary>
    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Флаг наличия подтверждения ОФД
    /// </summary>
    [ParameterId(Parameter.HasOfdTicket, typeof(bool))]
    public bool HasOfdTicket { get; set; }

    /// <summary>
    ///     Фискальный признак
    /// </summary>
    [ParameterId(Parameter.FiscalSign, typeof(string))]
    public string? FiscalFign { get; set; }
}