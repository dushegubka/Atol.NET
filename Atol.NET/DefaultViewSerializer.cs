using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Atol.NET.Abstractions;
using Atol.NET.Attributes;
using Atol.NET.Exceptions;

namespace Atol.NET;

public class DefaultViewSerializer : IAtolViewSerializer
{
    private readonly IEnumerable<IAtolDataProvider>? _dataProviders;
    private readonly IKktDriver _kkt;

    public DefaultViewSerializer(IEnumerable<IAtolDataProvider>? dataProviders, IKktDriver kkt)
    {
        _dataProviders = dataProviders;
        _kkt = kkt;
    }

    public T? GetView<T>()
    {
        var jsonObject = new JsonObject();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute(typeof(ParameterIdAttribute)) as ParameterIdAttribute
                            ?? throw new InvalidOperationException("Property is null");

            var provider = property.PropertyType.IsEnum
                ? _dataProviders?.FirstOrDefault(x => x.GetResultType() == typeof(int))
                : _dataProviders?.FirstOrDefault(x => x.GetResultType() == property.PropertyType)
                  ?? throw new InvalidOperationException("No data provider found for this type");


            jsonObject.Add(property.Name, JsonValue.Create(provider?.GetData(attribute.Constant)));

            CheckAndThrowIfError();
        }

        return JsonSerializer.Deserialize<T>(jsonObject.ToString());
    }

    public T GetValueByConstant<T>(int contant)
    {
        var provider = _dataProviders?.FirstOrDefault(x => x.GetResultType() == typeof(T));

        var result = (T)provider.GetData(contant);

        CheckAndThrowIfError();

        return result;
    }

    private void CheckAndThrowIfError()
    {
        var result = _kkt.ErrorCode();

        if (result == 0)
            return;

        var message = _kkt.ErrorDescription();

        // сбрасываем ошибку, чтобы не уйти в бесконечную ошибку (драйвер не сбрасывает самостоятельно ошибки при вызове методов)
        _kkt.ResetError();

        throw new AtolException(message, result);
    }
}