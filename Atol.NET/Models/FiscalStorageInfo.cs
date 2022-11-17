using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalStorageInfo
{
    /// <summary>
    ///     Серийный номер ФН
    /// </summary>
    [ParameterId(Parameter.SerialNumber, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    ///     Версия ФН
    /// </summary>
    [ParameterId(Parameter.FnVersion, typeof(string))]
    public string? Version { get; set; }

    /// <summary>
    ///     Исполнение ФН (только для ФН-М)
    /// </summary>
    [ParameterId(Parameter.FnExecution, typeof(string))]
    public string? Execution { get; set; }

    /// <summary>
    ///     Тип ФН
    /// </summary>
    [ParameterId(Parameter.FnType, typeof(int))]
    public FiscalStorageType FiscalStorageType { get; set; }

    /// <summary>
    ///     Состояние ФН
    /// </summary>
    [ParameterId(Parameter.FnState, typeof(int))]
    public FiscalStorageState FiscalStorageState { get; set; }

    /// <summary>
    ///     Нерасшифрованный байт флагов ФН
    /// </summary>
    [ParameterId(Parameter.FnFlags, typeof(int))]
    public int Flags { get; set; }

    /// <summary>
    ///     Требуется срочная замена ФН
    /// </summary>
    [ParameterId(Parameter.FnNeedReplacement, typeof(bool))]
    public bool IsNeedReplacement { get; set; }

    /// <summary>
    ///     Исчерпан ресурс ФН
    /// </summary>
    [ParameterId(Parameter.FnResourceExhausted, typeof(bool))]
    public bool IsResourceExhauted { get; set; }

    /// <summary>
    ///     Память ФН переполнена
    /// </summary>
    [ParameterId(Parameter.FnMemoryOverflow, typeof(bool))]
    public bool IsMemoryOverflow { get; set; }

    /// <summary>
    ///     Превышено время ожидания ответа от ОФД
    /// </summary>
    [ParameterId(Parameter.FnOfdTimeout, typeof(bool))]
    public bool IsOfdTimeout { get; set; }

    /// <summary>
    ///     Критическая ошибка ФН
    /// </summary>
    [ParameterId(Parameter.FnCriticalError, typeof(bool))]
    public bool IsCriticalError { get; set; }

    /// <summary>
    ///     ФН содержит URI сервера ОКП
    /// </summary>
    [ParameterId(Parameter.FnContainsKeysUpdaterServerUri, typeof(bool))]
    public bool IsContainsUpdaterServerUri { get; set; }

    /// <summary>
    ///     URI сервера ОКП
    /// </summary>
    [ParameterId(Parameter.FnContainsKeysUpdaterServerUri, typeof(string))]
    public string? UpdaterServerUri { get; set; }
}