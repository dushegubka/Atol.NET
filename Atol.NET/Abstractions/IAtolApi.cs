using Atol.NET.Abstractions.Categories;
using Atol.NET.Abstractions.Connectors;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IAtolApi
{
    IFluentConnector ConnectBy { get; }

    KktBaseResponse Disconnect();
    
    /// <summary>
    /// Возвращает общую информацию о ККТ
    /// </summary>
    /// <returns>Общая информация о ККТ</returns>
    KktResponse<KktGeneralInfo> GetGeneralInfo();
    
    /// <summary>
    /// Возвращает информацию о лицензии
    /// </summary>
    /// <param name="licenseId">Id лицензии</param>
    /// <returns>Информация о лицензии</returns>
    KktResponse<KktLicenseState> GetLicenseState(int licenseId);

    /// <summary>
    /// Выключение ККТ
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse PowerOff();
    
    /// <summary>
    /// Перезагрузка ККТ
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse Reboot();
    
    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse Beep();
    
    /// <summary>
    /// Звуковой сигнал ККТ
    /// </summary>
    /// <param name="frequency">Частота</param>
    /// <param name="duration">Длительность</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse Beep(int frequency, int duration);
    
    /// <summary>
    /// Устанавливает дату и время ККТ
    /// </summary>
    /// <param name="dateTime">Дата и время</param>
    /// <returns>KktBaseResponse</returns>
    KktBaseResponse SetDateTime(DateTime dateTime);

    /// <summary>
    /// Сериализатор, строящий модели
    /// </summary>
    IAtolViewSerializer? Serializer { get; }
    
    /// <summary>
    /// Категория для работы с фискальным накопителем
    /// </summary>
    IFiscalStorageCategory FiscalStorage { get; }
    
    /// <summary>
    /// Категория для работы с печатным маханизмом ККТ
    /// </summary>
    IPrinterCategory Printer { get; }
    
    /// <summary>
    /// Категория для работы с отчетами
    /// </summary>
    IReportsCategory Reports { get; }

    /// <summary>
    /// Подключена ли ККТ
    /// </summary>
    bool IsConnected { get; }
}