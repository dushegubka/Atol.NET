using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktLicenseState
{
    /// <summary>
    ///     Лицензия введена
    /// </summary>
    [Constant(Parameter.LicenseEntered, typeof(bool))]
    public bool IsLicenseEntered { get; set; }

    /// <summary>
    ///     Дата начала действия лицензии
    /// </summary>
    [Constant(Parameter.LicenseValidFrom, typeof(DateTime))]
    public DateTime StartLicenseDate { get; set; }

    /// <summary>
    ///     Дата окончания действия лицензии
    /// </summary>
    [Constant(Parameter.LicenseValidUntil, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }
}