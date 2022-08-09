namespace Atol.NET.Models.Responses;

/// <summary>
/// Используется для ответов на методы, которые возвращают большое кол-во данных
/// </summary>
/// <typeparam name="T">Класс, описывающий модель ответа</typeparam>
public class KktResponse<T> : KktBaseResponse
{
    public T Data { get; set; }
}