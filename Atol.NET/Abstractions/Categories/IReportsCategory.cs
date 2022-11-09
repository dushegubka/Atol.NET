using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IReportsCategory
{
    /// <summary>
    ///     Печать X-отчета
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintXReport();

    /// <summary>
    ///     Печать копии последнего документа
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintLastDocument();

    /// <summary>
    ///     Отчет о состоянии расчетов
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintOfdExchangeStatus();

    /// <summary>
    ///     Демо-печать
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintDemo();

    /// <summary>
    ///     Печать информации о ККТ
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintKktInformation();

    /// <summary>
    ///     Диагностика соединения с ОФД
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintOfdStatus();

    /// <summary>
    ///     Отчет количеств
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintQuantityReport();

    /// <summary>
    ///     Отчет по секциям
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintDepartmentsReport();

    /// <summary>
    ///     Отчет по кассирам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintOperatorsReport();

    /// <summary>
    ///     Отчет по часам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintHoursReport();

    /// <summary>
    ///     Печать итогов регистрации / перерегистрации
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintFnRegistrationReport();

    /// <summary>
    ///     Счетчики итогов смены
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintShiftTotalCounters();

    /// <summary>
    ///     Счетчики итогов ФН
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintFnTotalCounters();

    /// <summary>
    ///     Счетчики по непереданным документам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintNotSentDocumentCounters();

    /// <summary>
    ///     Отчет по товарам по СНО
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintCommoditiesByTaxationTypes();

    /// <summary>
    ///     Отчет по товарам по отделам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintCommoditiesByDepartments();

    /// <summary>
    ///     Отчет по товарам по суммам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintCommoditiesBySums();

    /// <summary>
    ///     Начать служебный отчет
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintServiceReport();

    /// <summary>
    ///     Отчет по скидкам
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintDiscountsReport();

    /// <summary>
    ///     Печать нераспечатанных отчетов о закрытии смены
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintCloseShiftReport();

    /// <summary>
    ///     Печать документа из ФН
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PrintDocumentFromFn(int documentNumber);
}