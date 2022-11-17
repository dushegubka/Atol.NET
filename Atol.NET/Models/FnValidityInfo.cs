using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FnValidityInfo
{
    /// <summary>
    ///     Срок действия ФН
    /// </summary>
    [ParameterId(Parameter.DateTime, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    ///     Сделано перерегистраций
    /// </summary>
    [ParameterId(Parameter.RegistrationsCount, typeof(int))]
    public int RegistrationsCount { get; set; }

    /// <summary>
    ///     Осталось перерегистраций
    /// </summary>
    [ParameterId(Parameter.RegistrationsRemain, typeof(int))]
    public int RegistrationsRemain { get; set; }
}