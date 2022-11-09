using Atol.NET.Enums;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IPrinterCategory
{
    /// <summary>
    ///     Перемотка чековой ленты на 1 строку
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse FeedLine();

    /// <summary>
    ///     Печать клише
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintCliche();

    /// <summary>
    ///     Печать текста
    /// </summary>
    /// <param name="text">Текс для печати</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintText(string text);

    /// <summary>
    ///     Печать текста
    /// </summary>
    /// <param name="options">Настройки печати</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintText(PrinterOptions options);

    /// <summary>
    ///     Печать штрихкода
    /// </summary>
    /// <param name="text">Текст, из которого формируется штрихкод</param>
    /// <param name="barcodeType">Тип штрихкода</param>
    /// <param name="defer">
    ///     Флаг отложенной печати
    ///     <a href="https://integration.atol.ru/api/?csharp#pechat-shtrihkoda">Документация</a>
    /// </param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintBarcode(string text, BarcodeType barcodeType = BarcodeType.EAN13, Defer defer = Defer.None);

    /// <summary>
    ///     Печать QR-кода
    /// </summary>
    /// <param name="text">Текст, из которого формируется QR-код</param>
    /// <param name="qrType">Тип QR кода</param>
    /// <param name="defer">
    ///     Флаг отложенной печати
    ///     <a href="https://integration.atol.ru/api/?csharp#pechat-shtrihkoda">Документация</a>
    /// </param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintQr(string text, QrType qrType = QrType.QR, Defer defer = Defer.None);

    /// <summary>
    ///     Печать штрихкода
    /// </summary>
    /// <param name="options">Параметры печати</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintBarcode(BarcodeOptions options);

    /// <summary>
    ///     Печать QR-кода
    /// </summary>
    /// <param name="options">Параметры печати</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintQr(QrCodeOptions options);

    /// <summary>
    ///     Печать изображения
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintImage(string imagePath);

    /// <summary>
    ///     Печать изображения из памяти
    /// </summary>
    /// <param name="imageNumber">Номер изображения</param>
    /// <param name="alignment">Выравнивание изображения</param>
    /// <param name="leftMargin">Дополнительный отступ слева</param>
    /// <param name="defer">Отложенная печать</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintImageFromMemory(int imageNumber, int leftMargin, Defer defer,
        TextAlignment alignment = TextAlignment.Center);

    /// <summary>
    ///     Печать пиксельного буффера
    /// </summary>
    /// <param name="options">Опции печати</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintPixelBuffer(PrintImageOptions options);
}