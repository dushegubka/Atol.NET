using Atol.NET.Enums;

namespace Atol.NET.Models;

public class CodeOptionsBase
{
    /// <summary>
    /// Текст для кодирования
    /// </summary>
    public string? Text { get; set; }
    
    /// <summary>
    /// Выравнивание штрихкода
    /// </summary>
    public TextAlignment Alignment { get; set; }
    
    /// <summary>
    /// Коэффициент увеличения штрихкода
    /// </summary>
    public int Scale { get; set; }

    /// <summary>
    /// Дополнительный отступ слева
    /// </summary>
    public int LeftMargin { get; set; }

    /// <summary>
    /// Инверсия цвета
    /// </summary>
    public bool ColorInvert { get; set; }

    /// <summary>
    /// Отложенная печать
    /// </summary>
    public Defer Defer { get; set; }
}