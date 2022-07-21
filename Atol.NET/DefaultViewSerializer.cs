using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Atol.NET.Abstractions;
using Atol.NET.Attributes;

namespace Atol.NET;

public class DefaultViewSerializer : IAtolViewSerializer
{
    private readonly IEnumerable<IAtolDataProvider> _dataProviders;
    
    public DefaultViewSerializer(IEnumerable<IAtolDataProvider> dataProviders)
    {
        _dataProviders = dataProviders;
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
                
                continue;
            }
            
            provider = _dataProviders.FirstOrDefault(x => x.GetResultType() == attribute.ReturningType);
            jsonObject.Add(property.Name, JsonValue.Create(provider.GetData(attribute.Constant)));
        }
        
        return JsonSerializer.Deserialize<T>(jsonObject.ToString());
    }
}