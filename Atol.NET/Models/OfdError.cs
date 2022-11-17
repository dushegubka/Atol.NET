using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class OfdError
{
    /// <summary>
    ///     Дата и время последнего успешного соединения с ОФД
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime LastSuccessConnection { get; set; }

    /// <summary>
    ///     Код ошибки сети
    /// </summary>
    [ParameterId(Parameter.NetworkError, typeof(int))]
    public int NetworkErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки сети
    /// </summary>
    [ParameterId(Parameter.NetworkErrorText, typeof(string))]
    public string? NetworkErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ОФД
    /// </summary>
    [ParameterId(Parameter.OfdError, typeof(int))]
    public int OfdErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ОФД
    /// </summary>
    [ParameterId(Parameter.OfdErrorText, typeof(string))]
    public string? OfdErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ФН
    /// </summary>
    [ParameterId(Parameter.FnError, typeof(int))]
    public int FnErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ФН
    /// </summary>
    [ParameterId(Parameter.FnErrorText, typeof(string))]
    public string? FnErrorMessage { get; set; }

    /// <summary>
    ///     Номер ФД, на котором произошла ошибка
    /// </summary>
    [ParameterId(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Команда ФН, на которой произошла ошибка
    /// </summary>
    [ParameterId(Parameter.CommandCode, typeof(int))]
    public int CommandCode { get; set; }
}