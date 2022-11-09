namespace Atol.NET.Exceptions;

public class AtolException : Exception
{
    public AtolException(string errorMessage, int errorCode) : base(errorMessage)
    {
        ErrorCode = errorCode;
    }

    public int ErrorCode { get; }
}