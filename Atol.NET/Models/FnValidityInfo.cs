using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class FnValidityInfo
{
    /// <summary>
    /// Срок действия ФН
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_DATE_TIME, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }
    
    /// <summary>
    /// Сделано перерегистраций
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_REGISTRATIONS_COUNT, typeof(int))]
    public int RegistrationsCount { get; set; }
    
    /// <summary>
    /// Осталось перерегистраций
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_REGISTRATIONS_REMAIN, typeof(int))]
    public int RegistrationsRemain { get; set; }
}