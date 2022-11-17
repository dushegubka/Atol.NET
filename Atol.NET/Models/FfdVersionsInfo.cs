using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FfdVersionsInfo
{
    [Constant(Parameter.DeviceFfdVersion, typeof(int))]
    public FfdVersion DeviceFfdVersion { get; set; }

    [Constant(Parameter.FnFfdVersion, typeof(int))]
    public FfdVersion FnFfdVersion { get; set; }

    [Constant(Parameter.FnMaxFfdVersion, typeof(int))]
    public FfdVersion MaxFfdVersion { get; set; }

    [Constant(Parameter.FfdVersion, typeof(int))]
    public FfdVersion FfdVersion { get; set; }

    [Constant(Parameter.DeviceMaxFfdVersion, typeof(int))]
    public FfdVersion DeviceMaxFfdVersion { get; set; }

    [Constant(Parameter.DeviceMinFfdVersion, typeof(int))]
    public FfdVersion DeviceMinFfdVersion { get; set; }

    [Constant(Parameter.Version, typeof(int))]
    public FfdVersion DeviceModelVersion { get; set; }
}