using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class SettingsCategory : ISettingsCategory
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public SettingsCategory(IFptr kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    
    public KktBaseResponse ShowSettingsWindow(IntPtr descriptor)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.showProperties(Constants.LIBFPTR_GUI_PARENT_NATIVE, descriptor);
        });
    }
}