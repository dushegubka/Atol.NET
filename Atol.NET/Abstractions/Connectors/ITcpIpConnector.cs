namespace Atol.NET.Abstractions.Connectors;

public interface ITcpIpConnector : IAtolConnector
{
    ITcpIpConnector WithIp(string ip);
    
    ITcpIpConnector WithPort(string port);
}