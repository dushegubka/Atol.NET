using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class PrinterCategory : IPrinterCategory
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public PrinterCategory(
        IFptr kkt, 
        IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    /// <inheritdoc />
    public KktBaseResponse FeedLine()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.lineFeed();
        });
    }

    public KktBaseResponse PrintCliche()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.printCliche();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintText(string text)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_TEXT, text);
            _kkt.printText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintText(PrinterOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_TEXT, options.Text);
            _kkt.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.TextAlignment);
            _kkt.setParam(Constants.LIBFPTR_PARAM_FONT, options.FontId);
            _kkt.setParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_WIDTH, options.DoubleWidth);
            _kkt.setParam(Constants.LIBFPTR_PARAM_FONT_DOUBLE_HEIGHT, options.DoubleHeight);
            _kkt.setParam(Constants.LIBFPTR_PARAM_TEXT_WRAP, (int)options.TextWrap);
            _kkt.setParam(Constants.LIBFPTR_PARAM_LINESPACING, options.LineSpacing);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BRIGHTNESS, options.Brightness);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.printText();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(string text, BarcodeType barcodeType = BarcodeType.EAN13, Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE, text);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)barcodeType);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.printBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(string text, QrType qrType = QrType.QR, Defer defer = Defer.None)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE, text);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)qrType);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.printBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintBarcode(BarcodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE, options.Text);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)options.BarcodeType);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.setParam(Constants.LIBFPTR_PARAM_SCALE, options.Scale);
            _kkt.setParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, options.LeftMargin);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_INVERT, options.ColorInvert);
            _kkt.setParam(Constants.LIBFPTR_PARAM_HEIGHT, options.Height);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_PRINT_TEXT, options.PrintText);
            _kkt.printBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQr(QrCodeOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE, options.Text);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, (int)options.QrType);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.setParam(Constants.LIBFPTR_PARAM_SCALE, options.Scale);
            _kkt.setParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, options.LeftMargin);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_INVERT, options.ColorInvert);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_CORRECTION, options.Correction);
            _kkt.setParam(Constants.LIBFPTR_PARAM_BARCODE_VERSION, options.Version);
            _kkt.printBarcode();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintImage(string imagePath)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_FILENAME, imagePath);
            _kkt.printPicture();
        });
    }

    public KktBaseResponse PrintImageFromMemory(int imageNumber, int leftMargin, Defer defer, TextAlignment alignment = TextAlignment.Center)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_PICTURE_NUMBER, imageNumber);
            _kkt.setParam(Constants.LIBFPTR_PARAM_LEFT_MARGIN, leftMargin);
            _kkt.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)alignment);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)defer);
            _kkt.printPictureByNumber();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintPixelBuffer(PrintImageOptions options)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_PIXEL_BUFFER, options.PixelBuffer);
            _kkt.setParam(Constants.LIBFPTR_PARAM_WIDTH, options.Width);
            _kkt.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, (int)options.Alignment);
            _kkt.setParam(Constants.LIBFPTR_PARAM_SCALE_PERCENT, options.ScalePercent);
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPEAT_NUMBER, options.RepeatNumber);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DEFER, (int)options.Defer);
            _kkt.printPixelBuffer();
        });
    }
}