using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class ReportsCategory : IReportsCategory
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public ReportsCategory(IKktDriver kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    /// <inheritdoc />
    public KktBaseResponse PrintXReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.X);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintLastDocument()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.LastDocument);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOfdExchangeStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.OfdExchangeStatus);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDemo()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.KktDemo);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintKktInformation()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.KktInfo);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOfdStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.OfdTest);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQuantityReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.Quantity);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDepartmentsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.Departments);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOperatorsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.Operators);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintHoursReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.Hours);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintFnRegistrationReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.FnRegistrations);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintShiftTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.FnShiftTotalCounters);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintFnTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.FnTotalCounters);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintNotSentDocumentCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.FnNotSentDocumentsCounters);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesByTaxationTypes()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.CommoditiesByTaxationTypes);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesByDepartments()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.CommoditiesByDepartments);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesBySums()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.CommoditiesBySums);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintServiceReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.StartService);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDiscountsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.Discounts);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCloseShiftReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.CloseShiftReports);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDocumentFromFn(int documentNumber)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Parameter.ReportType, ReportType.FnDocByNumber);
            _kkt.SetParam(Parameter.DocumentNumber, documentNumber);
            _kkt.Report();
        });
    }
}