using Atol.NET.Attributes;
using Atol.NET.Enums;

namespace Atol.NET.Models;

public class FfdVersionsInfo
{
    [Constant(Constants.LIBFPTR_PARAM_DEVICE_FFD_VERSION, typeof(int))]
    public FfdVersion DeviceFfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_FN_FFD_VERSION, typeof(int))]
    public FfdVersion FnFfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_FN_MAX_FFD_VERSION, typeof(int))]
    public FfdVersion MaxFfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_FFD_VERSION, typeof(int))]
    public FfdVersion FfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_DEVICE_MAX_FFD_VERSION, typeof(int))]
    public FfdVersion DeviceMaxFfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_DEVICE_MIN_FFD_VERSION, typeof(int))]
    public FfdVersion DeviceMinFfdVersion { get; set; }

    [Constant(Constants.LIBFPTR_PARAM_VERSION, typeof(int))]
    public FfdVersion DeviceModelVersion { get; set; }
}