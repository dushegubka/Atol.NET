using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FfdVersionsInfo
{
    [ParameterId(Parameter.DeviceFfdVersion, typeof(int))]
    public FfdVersion DeviceFfdVersion { get; set; }

    [ParameterId(Parameter.FnFfdVersion, typeof(int))]
    public FfdVersion FnFfdVersion { get; set; }

    [ParameterId(Parameter.FnMaxFfdVersion, typeof(int))]
    public FfdVersion MaxFfdVersion { get; set; }

    [ParameterId(Parameter.FfdVersion, typeof(int))]
    public FfdVersion FfdVersion { get; set; }

    [ParameterId(Parameter.DeviceMaxFfdVersion, typeof(int))]
    public FfdVersion DeviceMaxFfdVersion { get; set; }

    [ParameterId(Parameter.DeviceMinFfdVersion, typeof(int))]
    public FfdVersion DeviceMinFfdVersion { get; set; }

    [ParameterId(Parameter.Version, typeof(int))]
    public FfdVersion DeviceModelVersion { get; set; }
}