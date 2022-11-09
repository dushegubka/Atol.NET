using Atol.NET.Enums;

namespace Atol.NET.Models;

public class PrintImageOptions
{
    public byte[] PixelBuffer { get; set; }

    public int Width { get; set; }

    public TextAlignment Alignment { get; set; }

    public int ScalePercent { get; set; }

    public int LeftMargin { get; set; }

    public int RepeatNumber { get; set; }

    public Defer Defer { get; set; }
}