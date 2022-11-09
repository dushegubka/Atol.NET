using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FiscalStorageInfo
{
    /// <summary>
    ///     Серийный номер ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_SERIAL_NUMBER, typeof(string))]
    public string? SerialNumber { get; set; }

    /// <summary>
    ///     Версия ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_VERSION, typeof(string))]
    public string? Version { get; set; }

    /// <summary>
    ///     Исполнение ФН (только для ФН-М)
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_EXECUTION, typeof(string))]
    public string? Execution { get; set; }

    /// <summary>
    ///     Тип ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_TYPE, typeof(int))]
    public FiscalStorageType FiscalStorageType { get; set; }

    /// <summary>
    ///     Состояние ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_STATE, typeof(int))]
    public FiscalStorageState FiscalStorageState { get; set; }

    /// <summary>
    ///     Нерасшифрованный байт флагов ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_FLAGS, typeof(int))]
    public int Flags { get; set; }

    /// <summary>
    ///     Требуется срочная замена ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_NEED_REPLACEMENT, typeof(bool))]
    public bool IsNeedReplacement { get; set; }

    /// <summary>
    ///     Исчерпан ресурс ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_RESOURCE_EXHAUSTED, typeof(bool))]
    public bool IsResourceExhauted { get; set; }

    /// <summary>
    ///     Память ФН переполнена
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_MEMORY_OVERFLOW, typeof(bool))]
    public bool IsMemoryOverflow { get; set; }

    /// <summary>
    ///     Превышено время ожидания ответа от ОФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_OFD_TIMEOUT, typeof(bool))]
    public bool IsOfdTimeout { get; set; }

    /// <summary>
    ///     Критическая ошибка ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_CRITICAL_ERROR, typeof(bool))]
    public bool IsCriticalError { get; set; }

    /// <summary>
    ///     ФН содержит URI сервера ОКП
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_CONTAINS_KEYS_UPDATER_SERVER_URI, typeof(bool))]
    public bool IsContainsUpdaterServerUri { get; set; }

    /// <summary>
    ///     URI сервера ОКП
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_KEYS_UPDATER_SERVER_URI, typeof(string))]
    public string? UpdaterServerUri { get; set; }
}