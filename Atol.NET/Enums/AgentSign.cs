namespace Atol.NET.Enums;

[Flags]
public enum AgentSign
{
    /// <summary>
    ///     Признак агента отсутствует
    /// </summary>
    None = 0,

    /// <summary>
    ///     Банковский платежный агент
    /// </summary>
    BankPayingAgent = 1,

    /// <summary>
    ///     Банковский платежный субагент
    /// </summary>
    BankPayingSubagent = 2,

    /// <summary>
    ///     Платежный агент
    /// </summary>
    PayingAgent = 4,

    /// <summary>
    ///     Платежный субагент
    /// </summary>
    PayingSubagent = 8,

    /// <summary>
    ///     Поверенный
    /// </summary>
    Attorney = 16,

    /// <summary>
    ///     Комиссионер
    /// </summary>
    CommissionAgent = 32,

    /// <summary>
    ///     Другой тип агента, "иной" агент
    /// </summary>
    Another = 64
}