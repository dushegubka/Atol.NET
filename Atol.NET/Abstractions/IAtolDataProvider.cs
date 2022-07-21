namespace Atol.NET.Abstractions;

public interface IAtolDataProvider
{
    Type GetResultType();
    
    object GetData(int constant);
}