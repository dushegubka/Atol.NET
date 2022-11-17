using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class OfdReceipt
{
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    [ParameterId(Parameter.OfdFiscalSign, typeof(byte[]))]
    public byte[] FiscalSign { get; set; }
}