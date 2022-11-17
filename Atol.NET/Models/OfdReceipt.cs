using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class OfdReceipt
{
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    [Constant(Parameter.OfdFiscalSign, typeof(byte[]))]
    public byte[] FiscalSign { get; set; }
}