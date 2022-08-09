using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalDocumentInfo
{
    /// <summary>
    /// Тип документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_DOCUMENT_TYPE, typeof(FiscalDocumentType))]
    public FiscalDocumentType DocumentType { get; set; }

    /// <summary>
    /// Дата и время документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Номер ФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    /// Флаг наличия подтверждения ОФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_HAS_OFD_TICKET, typeof(bool))]
    public bool HasOfdTicket { get; set; }

    /// <summary>
    /// Фискальный признак
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FISCAL_SIGN, typeof(string))]
    public string? FiscalFign { get; set; }
}