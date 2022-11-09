namespace Atol.NET.Enums;

[Flags]
public enum TaxSystem
{
    /// <summary>
    ///     Общая система налогообложения
    /// </summary>
    Osn = 1,

    /// <summary>
    ///     Упрощенная система налогообложения (доход)
    /// </summary>
    UsnIncome = 2,

    /// <summary>
    ///     Упрощенная система налогообложения (доход минус расход)
    /// </summary>
    UsnIncomeOutcome = 4,

    /// <summary>
    ///     Единый сельскохозяйственный доход
    /// </summary>
    Esn = 16,

    /// <summary>
    ///     Патентная система налогообложения
    /// </summary>
    Patent = 32
}