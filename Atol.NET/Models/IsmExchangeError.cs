using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class IsmExchangeError
{
    /// <summary>
    ///     Дата и время последнего успешного соединения с ИСМ
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime LastSuccessConnectionDate { get; set; }

    /// <summary>
    ///     Код ошибки сети
    /// </summary>
    [ParameterId(Parameter.NetworkError, typeof(int))]
    public int NetworkError { get; set; }

    /// <summary>
    ///     Текст ошибки сети
    /// </summary>
    [ParameterId(Parameter.NetworkErrorText, typeof(string))]
    public string? NetworkErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ИСМ
    /// </summary>
    [ParameterId(Parameter.IsmError, typeof(int))]
    public int IsmErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ИСМ
    /// </summary>
    [ParameterId(Parameter.IsmErrorText, typeof(string))]
    public string? IsmErrorMessage { get; set; }

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