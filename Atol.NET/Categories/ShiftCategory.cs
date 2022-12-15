using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class ShiftCategory : IShiftCategory
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public ShiftCategory(IKktDriver kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    public KktBaseResponse OpenShift(string? operatorName, string? operatorInn)
    {
        _kkt.SetParam(1021, operatorName);
        _kkt.SetParam(1203, operatorInn);

        return _requestService.SendRequest(() =>
        {
            _kkt.OperatorLogin();
            _kkt.OpenShift();
        });
    }

    public KktBaseResponse CloseShift(ReportType reportType, bool printReport)
    {
        _kkt.SetParam(Parameter.ReportType, reportType);
        _kkt.SetParam(Parameter.ReportElectronically, !printReport);
        
        return _requestService.SendRequest(() =>
        {
            _kkt.Report();
        });
    }
}