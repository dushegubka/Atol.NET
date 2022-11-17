using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class OfdError
{
    /// <summary>
    ///     Дата и время последнего успешного соединения с ОФД
    /// </summary>
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime LastSuccessConnection { get; set; }

    /// <summary>
    ///     Код ошибки сети
    /// </summary>
    [Constant(Parameter.NetworkError, typeof(int))]
    public int NetworkErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки сети
    /// </summary>
    [Constant(Parameter.NetworkErrorText, typeof(string))]
    public string? NetworkErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ОФД
    /// </summary>
    [Constant(Parameter.OfdError, typeof(int))]
    public int OfdErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ОФД
    /// </summary>
    [Constant(Parameter.OfdErrorText, typeof(string))]
    public string? OfdErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ФН
    /// </summary>
    [Constant(Parameter.FnError, typeof(int))]
    public int FnErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ФН
    /// </summary>
    [Constant(Parameter.FnErrorText, typeof(string))]
    public string? FnErrorMessage { get; set; }

    /// <summary>
    ///     Номер ФД, на котором произошла ошибка
    /// </summary>
    [Constant(Parameter.DocumentNumber, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Команда ФН, на которой произошла ошибка
    /// </summary>
    [Constant(Parameter.CommandCode, typeof(int))]
    public int CommandCode { get; set; }
}