using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktGeneralInfo
{
    /// <summary>
    /// Номер кассира
    /// </summary>
    public int OperatorId { get; set; }

    /// <summary>
    /// Номер ККТ в магазине
    /// </summary>
    public int LogicalNumber { get; set; }

    /// <summary>
    /// Дата и время ККТ
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Флаг фискализации ФН
    /// </summary>
    public bool IsFiscalized { get; set; }

    /// <summary>
    /// Наличие ФН в ККТ
    /// </summary>
    public bool IsFnPresent { get; set; }

    /// <summary>
    /// Флаг корректности ФН
    /// </summary>
    public bool IsFnInvalid { get; set; }

    /// <summary>
    /// Состояние смены
    /// </summary>
    public ShiftState ShiftState { get; set; }

    /// <summary>
    /// Открыт ли денежный ящие
    /// </summary>
    public bool IsCashdrawerOpened { get; set; }

    /// <summary>
    /// Есть ли бумага
    /// </summary>
    public bool IsPaperPresent { get; set; }

    /// <summary>
    /// Бумага скоро закончится. Если датчика бумаги в ККТ нет, то будет возвращено значение false.
    /// </summary>
    public bool IsPaperNearAnd { get; set; }

    /// <summary>
    /// Открыта ли крышка
    /// </summary>
    public bool IsCoverOpened { get; set; }

    /// <summary>
    /// Заводской номер ККТ
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Номер модели ККТ
    /// </summary>
    public int ModelNumber { get; set; }

    /// <summary>
    /// Режим ККТ
    /// </summary>
    public int Mode { get; set; }
    
    /// <summary>
    /// Подрежим ККТ
    /// </summary>
    public int Submode { get; set; }

    /// <summary>
    /// Номер чека (внутренний счетчик ККТ)
    /// </summary>
    public int ReceiptNumber { get; set; }

    /// <summary>
    /// Номер документа (внутренний счетчик ККТ)
    /// </summary>
    public int DocumentNumber { get; set; }
    
    /// <summary>
    /// Номер открытой смены или номер последней закрытой смены + 1
    /// </summary>
    public int ShiftNumber { get; set; }

    /// <summary>
    /// Тип открытого чека
    /// </summary>
    public ReceiptType ReceiptType { get; set; }
    
    /// <summary>
    /// Тип открытого документа
    /// </summary>
    public DocumentType DocumentType { get; set; }

    /// <summary>
    /// Сумма текущего чека
    /// </summary>
    public double ReceiptSum { get; set; }

    /// <summary>
    /// Ширина чековой ленты в сомволах
    /// </summary>
    public int ReceiptLineLength { get; set; }
    
    /// <summary>
    /// Ширина чековой ленты в пикселях
    /// </summary>
    public int ReceiptLineLengthPixel { get; set; }

    /// <summary>
    /// Название ККТ
    /// </summary>
    public string? ModelName { get; set; }
    
    /// <summary>
    /// Версия ПО ККТ
    /// </summary>
    public string? UnitVersion { get; set; }

    /// <summary>
    /// Потеряно ли соединение с печатным механизмом
    /// </summary>
    public bool IsPrinterConnectionLost { get; set; }

    /// <summary>
    /// Невосстановимая ошибка печатного механизма
    /// </summary>
    public bool IsPrinterCriticalError { get; set; }

    /// <summary>
    /// Ошибка отрезчика
    /// </summary>
    public bool IsCutError { get; set; }
    
    /// <summary>
    /// Перегрет ли печатный механизм
    /// </summary>
    public bool IsPrinterOverheated { get; set; }

    /// <summary>
    /// ККТ заблокирована из-за ошибок
    /// </summary>
    public bool IsBlocked { get; set; }
}