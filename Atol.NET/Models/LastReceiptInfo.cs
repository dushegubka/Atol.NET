using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class LastReceiptInfo
{
    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    [Constant(Parameter.ReceiptType, typeof(int))]
    public ReceiptType ReceiptType { get; set; }

    [Constant(Parameter.ReceiptSum, typeof(double))]
    public double Sum { get; set; }

    [Constant(Parameter.FiscalSign, typeof(string))]
    public string? FiscalSign { get; set; }

    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }
}