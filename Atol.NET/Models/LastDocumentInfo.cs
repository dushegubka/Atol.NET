using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class LastDocumentInfo
{
    /// <summary>
    ///     Номер документа
    /// </summary>
    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Фискальный признак документа
    /// </summary>
    [ParameterId(Parameter.FiscalSign, typeof(string))]
    public string? FiscalSign { get; set; }

    /// <summary>
    ///     Дата и время документа
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }
}