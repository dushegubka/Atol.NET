using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class OfdError
{
    /// <summary>
    ///     Дата и время последнего успешного соединения с ОФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime LastSuccessConnection { get; set; }

    /// <summary>
    ///     Код ошибки сети
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_NETWORK_ERROR, typeof(int))]
    public int NetworkErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки сети
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_NETWORK_ERROR_TEXT, typeof(string))]
    public string? NetworkErrorMessage { get; set; }

    /// <summary>
    ///     Код ошибки ОФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_OFD_ERROR, typeof(int))]
    public int OfdErrorCode { get; set; }

    /// <summary>
    ///     Текст ошибки ОФД
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_OFD_ERROR_TEXT, typeof(string))]
    public string? OfdErrorMessage { get; set; }

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