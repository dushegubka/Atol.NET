using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class PrinterCategory : IPrinterCategory
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public PrinterCategory(
        IKktDriver kkt,
        IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    /// <inheritdoc />
    public KktBaseResponse FeedLine()
    {
        return _requestService.SendRequest(() => { _kkt.LineFeed(); });
    }

    public KktBaseResponse PrintCliche()
    {
        return _requestService.SendRequest(() => { _kkt.PrintCliche(); });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintText(string text)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Text, text);
            _kkt.PrintText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintText(PrinterOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Text, options.Text);
            _kkt.SetParam(Parameter.Alignment, (int)options.TextAlignment);
            _kkt.SetParam(Parameter.Font, options.FontId);
            _kkt.SetParam(Parameter.FontDoubleWidth, options.DoubleWidth);
            _kkt.SetParam(Parameter.FontDoubleHeight, options.DoubleHeight);
            _kkt.SetParam(Parameter.TextWrap, (int)options.TextWrap);
            _kkt.SetParam(Parameter.Linespacing, options.LineSpacing);
            _kkt.SetParam(Parameter.Brightness, options.Brightness);
            _kkt.SetParam(Parameter.Defer, (int)options.Defer);
            _kkt.PrintText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(string text, BarcodeType barcodeType = BarcodeType.EAN13,
        Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Barcode, text);
            _kkt.SetParam(Parameter.BarcodeType, barcodeType);
            _kkt.SetParam(Parameter.Defer, defer);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(string text, QrType qrType = QrType.QR, Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Barcode, text);
            _kkt.SetParam(Parameter.BarcodeType, qrType);
            _kkt.SetParam(Parameter.Defer, defer);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(BarcodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Barcode, options.Text);
            _kkt.SetParam(Parameter.BarcodeType, options.BarcodeType);
            _kkt.SetParam(Parameter.Defer, options.Defer);
            _kkt.SetParam(Parameter.Alignment, options.Alignment);
            _kkt.SetParam(Parameter.Scale, options.Scale);
            _kkt.SetParam(Parameter.LeftMargin, options.LeftMargin);
            _kkt.SetParam(Parameter.BarcodeInvert, options.ColorInvert);
            _kkt.SetParam(Parameter.Height, options.Height);
            _kkt.SetParam(Parameter.BarcodePrintText, options.PrintText);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(QrCodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.Barcode, options.Text);
            _kkt.SetParam(Parameter.BarcodeType, (int)options.QrType);
            _kkt.SetParam(Parameter.Defer, (int)options.Defer);
            _kkt.SetParam(Parameter.Alignment, (int)options.Alignment);
            _kkt.SetParam(Parameter.Scale, options.Scale);
            _kkt.SetParam(Parameter.LeftMargin, options.LeftMargin);
            _kkt.SetParam(Parameter.BarcodeInvert, options.ColorInvert);
            _kkt.SetParam(Parameter.BarcodeCorrection, options.Correction);
            _kkt.SetParam(Parameter.BarcodeVersion, options.Version);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    // TODO: добавить недостающие параметры
    public KktBaseResponse PrintImage(string imagePath)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.FileName, imagePath);
            _kkt.PrintPicture();
        });
    }

    public KktBaseResponse PrintImageFromMemory(int imageNumber, int leftMargin, Defer defer,
        TextAlignment alignment = TextAlignment.Center)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.PictureNumber, imageNumber);
            _kkt.SetParam(Parameter.LeftMargin, leftMargin);
            _kkt.SetParam(Parameter.Alignment, (int)alignment);
            _kkt.SetParam(Parameter.Defer, (int)defer);
            _kkt.PrintPictureByNumber();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintPixelBuffer(PrintImageOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.PixelBuffer, options.PixelBuffer);
            _kkt.SetParam(Parameter.Width, options.Width);
            _kkt.SetParam(Parameter.Alignment, (int)options.Alignment);
            _kkt.SetParam(Parameter.ScalePercent, options.ScalePercent);
            _kkt.SetParam(Parameter.RepeatNumber, options.RepeatNumber);
            _kkt.SetParam(Parameter.Defer, (int)options.Defer);
            _kkt.PrintPixelBuffer();
        });
    }
}