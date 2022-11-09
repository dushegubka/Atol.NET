namespace Atol.NET.Models.Responses;

/// <summary>
///     Используется для ответа от методов, которые возвращают только успешность запроса.
/// </summary>
public class KktBaseResponse
{
    public bool IsSuccess { get; set; }

    public KktResponseError Error { get; set; }
}