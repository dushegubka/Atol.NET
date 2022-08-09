using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class OfdReceipt
{
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_OFD_FISCAL_SIGN, typeof(byte[]))]
    public byte[] FiscalSign { get; set; }
}