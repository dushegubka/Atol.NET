using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Attributes;
using Atol.NET.Exceptions;

namespace Atol.NET;

public class DefaultViewSerializer : IAtolViewSerializer
{
    private readonly IEnumerable<IAtolDataProvider> _dataProviders;
    private readonly IFptr _kkt;

    public DefaultViewSerializer(IEnumerable<IAtolDataProvider> dataProviders, IFptr kkt)
    {
        _dataProviders = dataProviders;
        _kkt = kkt;
    }
    public T? GetView<T>()
    {
        var jsonObject = new JsonObject();
        var type = typeof(T);
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute(typeof(IntConstantAttribute)) as IntConstantAttribute;

            IAtolDataProvider provider = default;
            
            if (property.PropertyType.IsEnum)
            {
                provider = _dataProviders.FirstOrDefault(x => x.GetResultType() == typeof(int))!;
                jsonObject.Add(property.Name, JsonValue.Create(provider.GetData(attribute.Constant)));
                
                CheckAndThrowIfError();
                
                continue;
            }
            
            provider = _dataProviders.FirstOrDefault(x => x.GetResultType() == attribute.ReturningType);
            jsonObject.Add(property.Name, JsonValue.Create(provider.GetData(attribute.Constant)));
            
            CheckAndThrowIfError();
        }
        
        return JsonSerializer.Deserialize<T>(jsonObject.ToString());
    }

    private void CheckAndThrowIfError()
    {
        var result = _kkt.errorCode();

        if (result == 0) 
            return;
        
        var message = _kkt.errorDescription();

        // сбрасываем ошибку, чтобы не уйти в бесконечную ошибку (драйвер не сбрасывает самостоятельно ошибки при вызове методов)
        _kkt.resetError();
        
        throw new AtolException(message, result);
    }
}