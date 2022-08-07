using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class LastDocumentInfo
{
    /// <summary>
    /// Номер документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    /// Фискальный признак документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FISCAL_SIGN, typeof(string))]
    public string? FiscalSign { get; set; }

    /// <summary>
    /// Дата и время документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime DateTime { get; set; }
}