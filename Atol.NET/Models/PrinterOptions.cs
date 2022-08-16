using Atol.NET.Enums;

namespace Atol.NET.Models;

public class PrinterOptions
{
    public string? Text { get; set; }

    public TextAlignment TextAlignment { get; set; }

    public TextWrap TextWrap { get; set; }

    public int FontId { get; set; } = 2;
    
    public bool DoubleWidth { get; set; }
    
    public bool DoubleHeight { get; set; }

    public int LineSpacing { get; set; }
    
    public int Brightness { get; set; }
    
    public Defer Defer { get; set; }
}