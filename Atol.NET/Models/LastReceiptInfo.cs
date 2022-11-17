using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class LastReceiptInfo
{
    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    [ParameterId(Parameter.ReceiptType, typeof(int))]
    public ReceiptType ReceiptType { get; set; }

    [ParameterId(Parameter.ReceiptSum, typeof(double))]
    public double Sum { get; set; }

    [ParameterId(Parameter.FiscalSign, typeof(string))]
    public string? FiscalSign { get; set; }

    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }
}