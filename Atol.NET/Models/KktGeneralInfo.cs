using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktGeneralInfo
{
    /// <summary>
    /// Номер кассира
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_OPERATOR_ID, typeof(int))]
    public int OperatorId { get; set; }

    /// <summary>
    /// Номер ККТ в магазине
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_LOGICAL_NUMBER, typeof(int))]
    public int LogicalNumber { get; set; }

    /// <summary>
    /// Дата и время ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Флаг фискализации ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_FISCAL, typeof(bool))]
    public bool IsFiscalized { get; set; }

    /// <summary>
    /// Наличие ФН в ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_PRESENT, typeof(bool))]
    public bool IsFnPresent { get; set; }

    /// <summary>
    /// Флаг корректности ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_PRESENT, typeof(bool))]
    public bool IsFnInvalid { get; set; }

    /// <summary>
    /// Состояние смены
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SHIFT_STATE, typeof(ShiftState))]
    public ShiftState ShiftState { get; set; }

    /// <summary>
    /// Открыт ли денежный ящие
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_CASHDRAWER_OPENED, typeof(bool))]
    public bool IsCashdrawerOpened { get; set; }

    /// <summary>
    /// Есть ли бумага
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_PAPER_PRESENT, typeof(bool))]
    public bool IsPaperPresent { get; set; }

    /// <summary>
    /// Бумага скоро закончится. Если датчика бумаги в ККТ нет, то будет возвращено значение false.
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_PAPER_NEAR_END, typeof(bool))]
    public bool IsPaperNearAnd { get; set; }

    /// <summary>
    /// Открыта ли крышка
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_COVER_OPENED, typeof(bool))]
    public bool IsCoverOpened { get; set; }

    /// <summary>
    /// Заводской номер ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SERIAL_NUMBER, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Номер модели ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_MODEL, typeof(int))]
    public int ModelNumber { get; set; }

    /// <summary>
    /// Режим ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_MODE, typeof(int))]
    public int Mode { get; set; }
    
    /// <summary>
    /// Подрежим ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SUBMODE, typeof(int))]
    public int Submode { get; set; }

    /// <summary>
    /// Номер чека (внутренний счетчик ККТ)
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_NUMBER, typeof(int))]
    public int ReceiptNumber { get; set; }

    /// <summary>
    /// Номер документа (внутренний счетчик ККТ)
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }
    
    /// <summary>
    /// Номер открытой смены или номер последней закрытой смены + 1
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SHIFT_NUMBER, typeof(int))]
    public int ShiftNumber { get; set; }

    /// <summary>
    /// Тип открытого чека
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, typeof(ReceiptType))]
    public ReceiptType ReceiptType { get; set; }
    
    /// <summary>
    /// Тип открытого документа
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_TYPE, typeof(DocumentType))]
    public DocumentType DocumentType { get; set; }

    /// <summary>
    /// Сумма текущего чека
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_SUM, typeof(double))]
    public double ReceiptSum { get; set; }

    /// <summary>
    /// Ширина чековой ленты в сомволах
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_LINE_LENGTH, typeof(int))]
    public int ReceiptLineLength { get; set; }
    
    /// <summary>
    /// Ширина чековой ленты в пикселях
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_RECEIPT_LINE_LENGTH_PIX, typeof(int))]
    public int ReceiptLineLengthPixel { get; set; }

    /// <summary>
    /// Название ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_MODEL_NAME, typeof(string))]
    public string? ModelName { get; set; }
    
    /// <summary>
    /// Версия ПО ККТ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_UNIT_VERSION, typeof(string))]
    public string? UnitVersion { get; set; }

    /// <summary>
    /// Потеряно ли соединение с печатным механизмом
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_PRINTER_CONNECTION_LOST, typeof(bool))]
    public bool IsPrinterConnectionLost { get; set; }

    /// <summary>
    /// Невосстановимая ошибка печатного механизма
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_PRINTER_ERROR, typeof(bool))]
    public bool IsPrinterCriticalError { get; set; }

    /// <summary>
    /// Ошибка отрезчика
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_CUT_ERROR, typeof(bool))]
    public bool IsCutError { get; set; }
    
    /// <summary>
    /// Перегрет ли печатный механизм
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_PRINTER_OVERHEAT, typeof(bool))]
    public bool IsPrinterOverheated { get; set; }

    /// <summary>
    /// ККТ заблокирована из-за ошибок
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_BLOCKED, typeof(bool))]
    public bool IsBlocked { get; set; }
}