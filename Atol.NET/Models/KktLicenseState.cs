using Atol.Drivers10.Fptr;
using Atol.NET.Attributes;

namespace Atol.NET.Models;

public class KktLicenseState
{
    /// <summary>
    /// Лицензия введена
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_LICENSE_ENTERED, typeof(bool))]
    public bool IsLicenseEntered { get; set; }

    /// <summary>
    /// Дата начала действия лицензии
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_LICENSE_VALID_FROM, typeof(DateTime))]
    public DateTime StartLicenseDate { get; set; }
    
    /// <summary>
    /// Дата окончания действия лицензии
    /// </summary>
    [Constant(Constants.LIBFPTR_PARAM_LICENSE_VALID_UNTIL, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }
}