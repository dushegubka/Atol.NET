using Atol.NET.Abstractions.Categories;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions;

public interface IAtolApi
{
    /// <summary>
    /// Возвращает общую информацию о ККТ
    /// </summary>
    /// <returns>Общая информация о ККТ</returns>
    KktResponse<KktGeneralInfo> GetGeneralInfo();
    
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
    IFiscalStorageCategory FiscalStorageCategory { get; }
    
    /// <summary>
    /// Подключена ли ККТ
    /// </summary>
    bool IsConnected { get; }
}