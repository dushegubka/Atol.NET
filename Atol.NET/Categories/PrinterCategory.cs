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
            _kkt.SetParam(Constants.LIBFPTR_PARAM_TEXT, text);
            _kkt.PrintText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintText(PrinterOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_TEXT, options.Text);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.TextAlignment);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_FONT, options.FontId);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_WIDTH, options.DoubleWidth);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_HEIGHT, options.DoubleHeight);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_TEXT_WRAP, (int)options.TextWrap);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_LINESPACING, options.LineSpacing);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BRIGHTNESS, options.Brightness);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.PrintText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(string text, BarcodeType barcodeType = BarcodeType.EAN13,
        Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE, text);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)barcodeType);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(string text, QrType qrType = QrType.QR, Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE, text);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)qrType);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(BarcodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE, options.Text);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)options.BarcodeType);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_SCALE, options.Scale);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, options.LeftMargin);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_INVERT, options.ColorInvert);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_HEIGHT, options.Height);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_PRINT_TEXT, options.PrintText);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(QrCodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE, options.Text);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)options.QrType);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_SCALE, options.Scale);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, options.LeftMargin);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_INVERT, options.ColorInvert);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_CORRECTION, options.Correction);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_BARCODE_VERSION, options.Version);
            _kkt.PrintBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintImage(string imagePath)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_FILENAME, imagePath);
            _kkt.PrintPicture();
        });
    }

    public KktBaseResponse PrintImageFromMemory(int imageNumber, int leftMargin, Defer defer,
        TextAlignment alignment = TextAlignment.Center)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_PICTURE_NUMBER, imageNumber);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, leftMargin);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)alignment);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.PrintPictureByNumber();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintPixelBuffer(PrintImageOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_PIXEL_BUFFER, options.PixelBuffer);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_WIDTH, options.Width);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_SCALE_PERCENT, options.ScalePercent);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPEAT_NUMBER, options.RepeatNumber);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.PrintPixelBuffer();
        });
    }
}