using Atol.NET.Enums;

namespace Atol.NET.Models;

public class QrCodeOptions : CodeOptionsBase
{
    /// <summary>
    /// Коррекция QR-кода
    /// </summary>
    public int Correction { get; set; }

    /// <summary>
    /// Версия QR-кода
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Тип QR-кода
    /// </summary>
    public QrType QrType { get; set; }
}