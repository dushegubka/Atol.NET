using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class ShiftInfo
{
    /// <summary>
    ///     Количество чеков за смену
    /// </summary>
    [Constant(Parameter.ReceiptNumber, typeof(int))]
    public int ReceiptNumber { get; set; }

    /// <summary>
    ///     Номер смены
    /// </summary>
    [Constant(Parameter.ShiftNumber, typeof(int))]
    public int ShiftNumber { get; set; }
}