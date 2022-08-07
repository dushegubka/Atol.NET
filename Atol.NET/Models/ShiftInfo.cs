using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class ShiftInfo
{
    /// <summary>
    /// Количество чеков за смену
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_NUMBER, typeof(int))]
    public int ReceiptNumber { get; set; }
    
    /// <summary>
    /// Номер смены
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SHIFT_NUMBER, typeof(int))]
    public int ShiftNumber { get; set; }
}