using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class IsmExchangeError
{
    /// <summary>
    ///     Дата и время последнего успешного соединения с ИСМ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime LastSuccessConnectionDate { get; set; }

    /// <summary>
    ///     Код ошибки сети
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_NETWORK_ERROR, typeof(int))]
    public int NetworkError { get; set; }

    /// <summary>
    ///     Текст ошибки сети
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_NETWORK_ERROR_TEXT, typeof(string))]
    public string? NetworkErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ИСМ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_ISM_ERROR, typeof(int))]
    public int IsmErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ИСМ
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_ISM_ERROR_TEXT, typeof(string))]
    public string? IsmErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_ERROR, typeof(int))]
    public int FnErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_FN_ERROR_TEXT, typeof(string))]
    public string? FnErrorMessage { get; set; }

    /// <summary>
    ///     Номер ФД, на котором произошла ошибка
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, typeof(int))]
    public int DocumentNumber { get; set; }

    /// <summary>
    ///     Команда ФН, на которой произошла ошибка
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_COMMAND_CODE, typeof(int))]
    public int CommandCode { get; set; }
}