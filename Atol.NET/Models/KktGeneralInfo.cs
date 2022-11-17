using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktGeneralInfo
{
    /// <summary>
    ///     Номер кассира
    /// </summary>
    [Constant(Parameter.OperatorId, typeof(int))]
    public int OperatorId { get; set; }

    /// <summary>
    ///     Номер ККТ в магазине
    /// </summary>
    [Constant(Parameter.LogicalNumber, typeof(int))]
    public int LogicalNumber { get; set; }

    /// <summary>
    ///     Дата и время ККТ
    /// </summary>
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Флаг фискализации ФН
    /// </summary>
    [Constant(Parameter.FnFiscal, typeof(bool))]
    public bool IsFiscalized { get; set; }

    /// <summary>
    ///     Наличие ФН в ККТ
    /// </summary>
    [Constant(Parameter.FnPresent, typeof(bool))]
    public bool IsFnPresent { get; set; }

    /// <summary>
    ///     Флаг корректности ФН
    /// </summary>
    [Constant(Parameter.FnPresent, typeof(bool))]
    public bool IsFnInvalid { get; set; }

    /// <summary>
    ///     Состояние смены
    /// </summary>
    [Constant(Parameter.ShiftState, typeof(ShiftState))]
    public ShiftState ShiftState { get; set; }

    /// <summary>
    ///     Открыт ли денежный ящие
    /// </summary>
    [Constant(Parameter.CashdrawerOpened, typeof(bool))]
    public bool IsCashdrawerOpened { get; set; }

    /// <summary>
    ///     Есть ли бумага
    /// </summary>
    [Constant(Parameter.ReceiptPaperPresent, typeof(bool))]
    public bool IsPaperPresent { get; set; }

    /// <summary>
    ///     Бумага скоро закончится. Если датчика бумаги в ККТ нет, то будет возвращено значение false.
    /// </summary>
    [Constant(Parameter.PaperNearEnd, typeof(bool))]
    public bool IsPaperNearAnd { get; set; }

    /// <summary>
    ///     Открыта ли крышка
    /// </summary>
    [Constant(Parameter.CoverOpened, typeof(bool))]
    public bool IsCoverOpened { get; set; }

    /// <summary>
    ///     Заводской номер ККТ
    /// </summary>
    [Constant(Parameter.SerialNumber, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    ///     Номер модели ККТ
    /// </summary>
    [Constant(Parameter.Model, typeof(int))]
    public int ModelNumber { get; set; }

    /// <summary>
    ///     Режим ККТ
    /// </summary>
    [Constant(Parameter.Mode, typeof(int))]
    public int Mode { get; set; }

    /// <summary>
    ///     Подрежим ККТ
    /// </summary>
    [Constant(Parameter.Submode, typeof(int))]
    public int Submode { get; set; }

    /// <summary>
    ///     Номер чека (внутренний счетчик ККТ)
    /// </summary>
    [Constant(Parameter.ReceiptNumber, typeof(int))]
    public int ReceiptNumber { get; set; }

    /// <summary>
    ///     Номер документа (внутренний счетчик ККТ)
    /// </summary>
    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Номер открытой смены или номер последней закрытой смены + 1
    /// </summary>
    [Constant(Parameter.ShiftNumber, typeof(int))]
    public int ShiftNumber { get; set; }

    /// <summary>
    ///     Тип открытого чека
    /// </summary>
    [Constant(Parameter.ReceiptType, typeof(ReceiptType))]
    public ReceiptType ReceiptType { get; set; }

    /// <summary>
    ///     Тип открытого документа
    /// </summary>
    [Constant(Parameter.DocumentType, typeof(DocumentType))]
    public DocumentType DocumentType { get; set; }

    /// <summary>
    ///     Сумма текущего чека
    /// </summary>
    [Constant(Parameter.ReceiptSum, typeof(double))]
    public double ReceiptSum { get; set; }

    /// <summary>
    ///     Ширина чековой ленты в сомволах
    /// </summary>
    [Constant(Parameter.ReceiptLineLength, typeof(int))]
    public int ReceiptLineLength { get; set; }

    /// <summary>
    ///     Ширина чековой ленты в пикселях
    /// </summary>
    [Constant(Parameter.ReceiptLineLengthPix, typeof(int))]
    public int ReceiptLineLengthPixel { get; set; }

    /// <summary>
    ///     Название ККТ
    /// </summary>
    [Constant(Parameter.ModelName, typeof(string))]
    public string? ModelName { get; set; }

    /// <summary>
    ///     Версия ПО ККТ
    /// </summary>
    [Constant(Parameter.UnitVersion, typeof(string))]
    public string? UnitVersion { get; set; }

    /// <summary>
    ///     Потеряно ли соединение с печатным механизмом
    /// </summary>
    [Constant(Parameter.PrinterConnectionLost, typeof(bool))]
    public bool IsPrinterConnectionLost { get; set; }

    /// <summary>
    ///     Невосстановимая ошибка печатного механизма
    /// </summary>
    [Constant(Parameter.PrinterError, typeof(bool))]
    public bool IsPrinterCriticalError { get; set; }

    /// <summary>
    ///     Ошибка отрезчика
    /// </summary>
    [Constant(Parameter.CutError, typeof(bool))]
    public bool IsCutError { get; set; }

    /// <summary>
    ///     Перегрет ли печатный механизм
    /// </summary>
    [Constant(Parameter.PrinterOverheat, typeof(bool))]
    public bool IsPrinterOverheated { get; set; }

    /// <summary>
    ///     ККТ заблокирована из-за ошибок
    /// </summary>
    [Constant(Parameter.Blocked, typeof(bool))]
    public bool IsBlocked { get; set; }
}