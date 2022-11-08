using Atol.NET.Enums;

namespace Atol.NET.Models.Registrations;

public class RegistrationSettings
{
    /// <summary>
    /// Адрес сайта ФНС
    /// </summary>
    public string? FnsSiteUrl { get; set; }

    /// <summary>
    /// Наименование пользователя
    /// </summary>
    public string? Username { get; set; }
    
    /// <summary>
    /// Адрес разчетов
    /// </summary>
    public string? BillingAddress { get; set; }

    /// <summary>
    /// ИНН пользователя
    /// </summary>
    public string? Inn { get; set; }
    
    /// <summary>
    /// Адрес электронной почты отправителя чека
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Системы налогообложения
    /// </summary>
    public List<TaxSystem>? TaxSystems { get; set; }

    /// <summary>
    /// Признак агента
    /// </summary>
    public List<AgentSign>? AgentSigns { get; set; }
    
    /// <summary>
    /// Место расчетов
    /// </summary>
    public string? BillingPlace { get; set; }
    
    /// <summary>
    /// Регистрационный номер ККТ
    /// </summary>
    public string? KktRegistrationNumber { get; set; }

    /// <summary>
    /// Версия ФФД
    /// </summary>
    public FfdVersion FfdVersion { get; set; }

    /// <summary>
    /// Признак осуществления ломбардной деятельности
    /// </summary>
    public bool IsPawnShop { get; set; }
    
    /// <summary>
    /// Признак осуществления страховой деятельности
    /// </summary>
    public bool IsInsurance { get; set; }
    
    /// <summary>
    /// Признак торговли маркированными товарами
    /// </summary>
    public bool IsTradeMarkedProducts { get; set; }
}