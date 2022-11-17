using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalDocumentInfo
{
    /// <summary>
    ///     Тип документа
    /// </summary>
    [Constant(Parameter.FnDocumentType, typeof(FiscalDocumentType))]
    public FiscalDocumentType DocumentType { get; set; }

    /// <summary>
    ///     Дата и время документа
    /// </summary>
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Номер ФД
    /// </summary>
    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Флаг наличия подтверждения ОФД
    /// </summary>
    [Constant(Parameter.HasOfdTicket, typeof(bool))]
    public bool HasOfdTicket { get; set; }

    /// <summary>
    ///     Фискальный признак
    /// </summary>
    [Constant(Parameter.FiscalSign, typeof(string))]
    public string? FiscalFign { get; set; }
}