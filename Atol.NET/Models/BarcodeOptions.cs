using Atol.NET.Enums;

namespace Atol.NET.Models;

public class BarcodeOptions : CodeOptionsBase
{
    /// <summary>
    /// Высота штрихкода, пикс.
    /// </summary>
    public int Height { get; set; } = 30;

    /// <summary>
    /// Флаг печати данных ШК
    /// </summary>
    public bool PrintText { get; set; }

    /// <summary>
    /// Тип штрихкода
    /// </summary>
    public BarcodeType BarcodeType { get; set; }
}