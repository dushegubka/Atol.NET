using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktGeneralInfo
{
    /// <summary>
    ///     Номер кассира
    /// </summary>
    [ParameterId(Parameter.OperatorId, typeof(int))]
    public int OperatorId { get; set; }

    /// <summary>
    ///     Номер ККТ в магазине
    /// </summary>
    [ParameterId(Parameter.LogicalNumber, typeof(int))]
    public int LogicalNumber { get; set; }

    /// <summary>
    ///     Дата и время ККТ
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Флаг фискализации ФН
    /// </summary>
    [ParameterId(Parameter.FnFiscal, typeof(bool))]
    public bool IsFiscalized { get; set; }

    /// <summary>
    ///     Наличие ФН в ККТ
    /// </summary>
    [ParameterId(Parameter.FnPresent, typeof(bool))]
    public bool IsFnPresent { get; set; }

    /// <summary>
    ///     Флаг корректности ФН
    /// </summary>
    [ParameterId(Parameter.FnPresent, typeof(bool))]
    public bool IsFnInvalid { get; set; }

    /// <summary>
    ///     Состояние смены
    /// </summary>
    [ParameterId(Parameter.ShiftState, typeof(ShiftState))]
    public ShiftState ShiftState { get; set; }

    /// <summary>
    ///     Открыт ли денежный ящие
    /// </summary>
    [ParameterId(Parameter.CashdrawerOpened, typeof(bool))]
    public bool IsCashdrawerOpened { get; set; }

    /// <summary>
    ///     Есть ли бумага
    /// </summary>
    [ParameterId(Parameter.ReceiptPaperPresent, typeof(bool))]
    public bool IsPaperPresent { get; set; }

    /// <summary>
    ///     Бумага скоро закончится. Если датчика бумаги в ККТ нет, то будет возвращено значение false.
    /// </summary>
    [ParameterId(Parameter.PaperNearEnd, typeof(bool))]
    public bool IsPaperNearAnd { get; set; }

    /// <summary>
    ///     Открыта ли крышка
    /// </summary>
    [ParameterId(Parameter.CoverOpened, typeof(bool))]
    public bool IsCoverOpened { get; set; }

    /// <summary>
    ///     Заводской номер ККТ
    /// </summary>
    [ParameterId(Parameter.SerialNumber, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    ///     Номер модели ККТ
    /// </summary>
    [ParameterId(Parameter.Model, typeof(int))]
    public int ModelNumber { get; set; }

    /// <summary>
    ///     Режим ККТ
    /// </summary>
    [ParameterId(Parameter.Mode, typeof(int))]
    public int Mode { get; set; }

    /// <summary>
    ///     Подрежим ККТ
    /// </summary>
    [ParameterId(Parameter.Submode, typeof(int))]
    public int Submode { get; set; }

    /// <summary>
    ///     Номер чека (внутренний счетчик ККТ)
    /// </summary>
    [ParameterId(Parameter.ReceiptNumber, typeof(int))]
    public int ReceiptNumber { get; set; }

    /// <summary>
    ///     Номер документа (внутренний счетчик ККТ)
    /// </summary>
    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Номер открытой смены или номер последней закрытой смены + 1
    /// </summary>
    [ParameterId(Parameter.ShiftNumber, typeof(int))]
    public int ShiftNumber { get; set; }

    /// <summary>
    ///     Тип открытого чека
    /// </summary>
    [ParameterId(Parameter.ReceiptType, typeof(ReceiptType))]
    public ReceiptType ReceiptType { get; set; }

    /// <summary>
    ///     Тип открытого документа
    /// </summary>
    [ParameterId(Parameter.DocumentType, typeof(DocumentType))]
    public DocumentType DocumentType { get; set; }

    /// <summary>
    ///     Сумма текущего чека
    /// </summary>
    [ParameterId(Parameter.ReceiptSum, typeof(double))]
    public double ReceiptSum { get; set; }

    /// <summary>
    ///     Ширина чековой ленты в сомволах
    /// </summary>
    [ParameterId(Parameter.ReceiptLineLength, typeof(int))]
    public int ReceiptLineLength { get; set; }

    /// <summary>
    ///     Ширина чековой ленты в пикселях
    /// </summary>
    [ParameterId(Parameter.ReceiptLineLengthPix, typeof(int))]
    public int ReceiptLineLengthPixel { get; set; }

    /// <summary>
    ///     Название ККТ
    /// </summary>
    [ParameterId(Parameter.ModelName, typeof(string))]
    public string? ModelName { get; set; }

    /// <summary>
    ///     Версия ПО ККТ
    /// </summary>
    [ParameterId(Parameter.UnitVersion, typeof(string))]
    public string? UnitVersion { get; set; }

    /// <summary>
    ///     Потеряно ли соединение с печатным механизмом
    /// </summary>
    [ParameterId(Parameter.PrinterConnectionLost, typeof(bool))]
    public bool IsPrinterConnectionLost { get; set; }

    /// <summary>
    ///     Невосстановимая ошибка печатного механизма
    /// </summary>
    [ParameterId(Parameter.PrinterError, typeof(bool))]
    public bool IsPrinterCriticalError { get; set; }

    /// <summary>
    ///     Ошибка отрезчика
    /// </summary>
    [ParameterId(Parameter.CutError, typeof(bool))]
    public bool IsCutError { get; set; }

    /// <summary>
    ///     Перегрет ли печатный механизм
    /// </summary>
    [ParameterId(Parameter.PrinterOverheat, typeof(bool))]
    public bool IsPrinterOverheated { get; set; }

    /// <summary>
    ///     ККТ заблокирована из-за ошибок
    /// </summary>
    [ParameterId(Parameter.Blocked, typeof(bool))]
    public bool IsBlocked { get; set; }
}