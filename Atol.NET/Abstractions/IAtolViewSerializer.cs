namespace Atol.NET.Abstractions;

public interface IAtolViewSerializer
{
    T? GetView<T>();
}