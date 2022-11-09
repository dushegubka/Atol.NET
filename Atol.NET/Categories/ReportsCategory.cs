using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
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
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_X);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintLastDocument()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_LAST_DOCUMENT);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOfdExchangeStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OFD_EXCHANGE_STATUS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDemo()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_KKT_DEMO);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintKktInformation()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_KKT_INFO);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOfdStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OFD_TEST);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintQuantityReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_QUANTITY);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDepartmentsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_DEPARTMENTS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintOperatorsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OPERATORS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintHoursReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_HOURS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintFnRegistrationReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_REGISTRATIONS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintShiftTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_SHIFT_TOTAL_COUNTERS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintFnTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_TOTAL_COUNTERS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintNotSentDocumentCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_NOT_SENT_DOCUMENTS_COUNTERS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesByTaxationTypes()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_TAXATION_TYPES);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesByDepartments()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_DEPARTMENTS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCommoditiesBySums()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_SUMS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintServiceReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_START_SERVICE);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDiscountsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_DISCOUNTS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintCloseShiftReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT_REPORTS);
            _kkt.Report();
        });
    }

    /// <inheritdoc />
    public KktBaseResponse PrintDocumentFromFn(int documentNumber)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.SetParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_DOC_BY_NUMBER);
            _kkt.SetParam(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, documentNumber);
            _kkt.Report();
        });
    }
}