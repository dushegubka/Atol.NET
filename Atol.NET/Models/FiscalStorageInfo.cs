using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalStorageInfo
{
    /// <summary>
    ///     Серийный номер ФН
    /// </summary>
    [Constant(Parameter.SerialNumber, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    ///     Версия ФН
    /// </summary>
    [Constant(Parameter.FnVersion, typeof(string))]
    public string? Version { get; set; }

    /// <summary>
    ///     Исполнение ФН (только для ФН-М)
    /// </summary>
    [Constant(Parameter.FnExecution, typeof(string))]
    public string? Execution { get; set; }

    /// <summary>
    ///     Тип ФН
    /// </summary>
    [Constant(Parameter.FnType, typeof(int))]
    public FiscalStorageType FiscalStorageType { get; set; }

    /// <summary>
    ///     Состояние ФН
    /// </summary>
    [Constant(Parameter.FnState, typeof(int))]
    public FiscalStorageState FiscalStorageState { get; set; }

    /// <summary>
    ///     Нерасшифрованный байт флагов ФН
    /// </summary>
    [Constant(Parameter.FnFlags, typeof(int))]
    public int Flags { get; set; }

    /// <summary>
    ///     Требуется срочная замена ФН
    /// </summary>
    [Constant(Parameter.FnNeedReplacement, typeof(bool))]
    public bool IsNeedReplacement { get; set; }

    /// <summary>
    ///     Исчерпан ресурс ФН
    /// </summary>
    [Constant(Parameter.FnResourceExhausted, typeof(bool))]
    public bool IsResourceExhauted { get; set; }

    /// <summary>
    ///     Память ФН переполнена
    /// </summary>
    [Constant(Parameter.FnMemoryOverflow, typeof(bool))]
    public bool IsMemoryOverflow { get; set; }

    /// <summary>
    ///     Превышено время ожидания ответа от ОФД
    /// </summary>
    [Constant(Parameter.FnOfdTimeout, typeof(bool))]
    public bool IsOfdTimeout { get; set; }

    /// <summary>
    ///     Критическая ошибка ФН
    /// </summary>
    [Constant(Parameter.FnCriticalError, typeof(bool))]
    public bool IsCriticalError { get; set; }

    /// <summary>
    ///     ФН содержит URI сервера ОКП
    /// </summary>
    [Constant(Parameter.FnContainsKeysUpdaterServerUri, typeof(bool))]
    public bool IsContainsUpdaterServerUri { get; set; }

    /// <summary>
    ///     URI сервера ОКП
    /// </summary>
    [Constant(Parameter.FnContainsKeysUpdaterServerUri, typeof(string))]
    public string? UpdaterServerUri { get; set; }
}