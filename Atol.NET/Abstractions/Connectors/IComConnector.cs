using Atol.NET.Enums;

namespace Atol.NET.Abstractions.Connectors;

public interface IComConnector : IAtolConnector
{
    IComConnector OnPort(int port);
    IComConnector WithBaudRate(ComBaudRate baudRate);
    IComConnector WithDataBits(ComDataBits dataBits);
    IComConnector WithParity(ComParity parity);
    IComConnector WithStopBits(ComStopBits stopBits);
}