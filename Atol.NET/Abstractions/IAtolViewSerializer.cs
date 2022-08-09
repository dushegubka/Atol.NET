namespace Atol.NET.Abstractions;

public interface IAtolViewSerializer
{
    T? GetView<T>();

    T? GetValueByConstant<T>(int contant, Type returningType);
}