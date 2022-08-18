using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Connectors;

public interface IAtolConnector
{
    KktBaseResponse Connect();
}