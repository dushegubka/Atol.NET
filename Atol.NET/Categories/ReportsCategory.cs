using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class ReportsCategory : IReportsCategory
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public ReportsCategory(IFptr kkt, IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    
    /// <inheritdoc/>
    public KktBaseResponse PrintXReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_X);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintLastDocument()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_LAST_DOCUMENT);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintOfdExchangeStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OFD_EXCHANGE_STATUS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintDemo()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_KKT_DEMO);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintKktInformation()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_KKT_INFO);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintOfdStatus()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OFD_TEST);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintQuantityReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_QUANTITY);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintDepartmentsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_DEPARTMENTS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintOperatorsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_OPERATORS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintHoursReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_HOURS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintFnRegistrationReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_REGISTRATIONS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintShiftTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_SHIFT_TOTAL_COUNTERS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintFnTotalCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_TOTAL_COUNTERS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintNotSentDocumentCounters()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_NOT_SENT_DOCUMENTS_COUNTERS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintCommoditiesByTaxationTypes()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_TAXATION_TYPES);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintCommoditiesByDepartments()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_DEPARTMENTS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintCommoditiesBySums()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_COMMODITIES_BY_SUMS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintServiceReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_START_SERVICE);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintDiscountsReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_DISCOUNTS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintCloseShiftReport()
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT_REPORTS);
            _kkt.report();
        });
    }

    /// <inheritdoc/>
    public KktBaseResponse PrintDocumentFromFn(int documentNumber)
    {
        return _requestService.SendRequest(() =>
        {
            _kkt.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_FN_DOC_BY_NUMBER);
            _kkt.setParam(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, documentNumber);
            _kkt.report();
        });
    }
}