using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class KktLicenseState
{
    /// <summary>
    ///     Лицензия введена
    /// </summary>
    [ParameterId(Parameter.LicenseEntered, typeof(bool))]
    public bool IsLicenseEntered { get; set; }

    /// <summary>
    ///     Дата начала действия лицензии
    /// </summary>
    [ParameterId(Parameter.LicenseValidFrom, typeof(DateTime))]
    public DateTime StartLicenseDate { get; set; }

    /// <summary>
    ///     Дата окончания действия лицензии
    /// </summary>
    [ParameterId(Parameter.LicenseValidUntil, typeof(DateTime))]
    public DateTime ExpirationDate { get; set; }
}