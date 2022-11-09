using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class SettingsCategory : ISettingsCategory
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public SettingsCategory(IKktDriver kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    public KktBaseResponse ShowSettingsWindow(IntPtr descriptor)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.ShowProperties(Constants.LIBFPTR_GUI_PARENT_NATIVE, descriptor);
        });
    }
}