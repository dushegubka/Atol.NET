using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class LastReceiptInfo
{
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, typeof(int))]
    public ReceiptType ReceiptType { get; set; }
    
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_SUM, typeof(double))]
    public double Sum { get; set; }
    
    [Constant(Constants.LIBFPTR_PARAM_FISCAL_SIGN, typeof(string))]
    public string? FiscalSign { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime DateTime { get; set; }
}