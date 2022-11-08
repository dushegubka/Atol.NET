using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models.Registrations;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class RegistrationCategory : IRegistrationCategory
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public RegistrationCategory(
        IFptr kkt,
        IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    public KktBaseResponse Register(RegistrationSettings settings)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_OPERATION_TYPE, Constants.LIBFPTR_FNOP_REGISTRATION);

        SetRegistrationSettings(settings, RegistrationType.Registration);

        var result = _requestService.SendRequest(() => { _kkt.fnOperation(); });

        if (!result.IsSuccess)
            return result;

        var documentClosed = _requestService.SendRequest(() => { _kkt.checkDocumentClosed(); });

        return documentClosed;
    }

    public KktBaseResponse ReRegister(RegistrationSettings settings)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_OPERATION_TYPE, Constants.LIBFPTR_FNOP_CHANGE_PARAMETERS);
        
        SetRegistrationSettings(settings, RegistrationType.ReRegistration);
        
        var result = _requestService.SendRequest(() => { _kkt.fnOperation(); });
        
        if (!result.IsSuccess)
            return result;
        
        var documentClosed = _requestService.SendRequest(() => { _kkt.checkDocumentClosed(); });
        
        return documentClosed;
    }

    public KktBaseResponse CloseFiscalStorage(bool printReport)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_OPERATION_TYPE, Constants.LIBFPTR_FNOP_CLOSE_ARCHIVE);
        _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_ELECTRONICALLY, !printReport);

        return _requestService.SendRequest(() => { _kkt.fnOperation(); });
    }

    private void SetRegistrationSettings(RegistrationSettings settings, RegistrationType registrationType)
    {
        if (registrationType == RegistrationType.Registration)
        {
            _kkt.setParam(1018, settings.Inn);
            _kkt.setParam(1037, settings.KktRegistrationNumber);
        }
        
        _kkt.setParam((int) RegistrationParam.FnsSiteUrl, settings.FnsSiteUrl);
        _kkt.setParam(1009, settings.BillingAddress);
        _kkt.setParam(1048, settings.Username);
        _kkt.setParam(1062, ConcateTaxSystems(settings.TaxSystems!));
        _kkt.setParam(1117, settings.Email);
        _kkt.setParam(1057, ConcateAgentSigns(settings.AgentSigns!));
        _kkt.setParam(1187, settings.BillingPlace);
        _kkt.setParam(1209, (int)settings.FfdVersion);
    }

    //TODO: переделать в обобщенный метод
    private int ConcateTaxSystems(List<TaxSystem> taxSystems)
    {
        var result = 0;
        foreach (var taxSystem in taxSystems) result |= (int)taxSystem;

        return result;
    }

    private int ConcateAgentSigns(List<AgentSign> agentSigns)
    {
        var result = 0;
        foreach (var agentSign in agentSigns) result |= (int)agentSign;

        return result;
    }
    
    private int ConcateReRegistrationReasons(List<ReRegistrationReason> reRegistrationReasons)
    {
        var result = 0;
        foreach (var reRegistrationReason in reRegistrationReasons) 
            result |= (int)reRegistrationReason;

        return result;
    }
}