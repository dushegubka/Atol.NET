using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FnValidityInfo
{
    /// <summary>
    ///     Срок действия ФН
    /// </summary>
    [Constant(Parameter.DateTime, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    ///     Сделано перерегистраций
    /// </summary>
    [Constant(Parameter.RegistrationsCount, typeof(int))]
    public int RegistrationsCount { get; set; }

    /// <summary>
    ///     Осталось перерегистраций
    /// </summary>
    [Constant(Parameter.RegistrationsRemain, typeof(int))]
    public int RegistrationsRemain { get; set; }
}