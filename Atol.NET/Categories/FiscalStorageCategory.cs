using Atol.Drivers10.Fptr;
using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class FiscalStorageCategory : IFiscalStorageCategory
{
    private readonly IFptr _kkt;
    private readonly IKktRequestService _requestService;

    public FiscalStorageCategory(
        IFptr kkt, 
        IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }
    
    /// <inheritdoc />
    public KktResponse<FiscalStorageInfo> GetFiscalStorageInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_FN_INFO);
        _kkt.fnQueryData();

        return _requestService.GetData<FiscalStorageInfo>();
    }

    /// <inheritdoc />
    public KktResponse<LastReceiptInfo> GetLastReceiptInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_LAST_RECEIPT);
        _kkt.fnQueryData();

        return _requestService.GetData<LastReceiptInfo>();
    }

    /// <inheritdoc />
    public KktResponse<LastDocumentInfo> GetLastDocumentInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_LAST_DOCUMENT);
        _kkt.fnQueryData();

        return _requestService.GetData<LastDocumentInfo>();
    }

    /// <inheritdoc />
    public KktResponse<ShiftInfo> GetShiftInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_SHIFT);
        _kkt.fnQueryData();

        return _requestService.GetData<ShiftInfo>();
    }

    /// <inheritdoc />
    public KktResponse<uint> GetFiscalDocumentsCount()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_DOCUMENTS_COUNT_IN_SHIFT);
        _kkt.fnQueryData();

        return _requestService.GetDataByConstant<uint>(Constants.LIBFPTR_PARAM_DOCUMENTS_COUNT);
    }

    /// <inheritdoc />
    public KktResponse<FfdVersionsInfo> GetFfdVersionsInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_FFD_VERSIONS);
        _kkt.fnQueryData();

        return _requestService.GetData<FfdVersionsInfo>();
    }
    
    /// <inheritdoc />
    public KktResponse<FnValidityInfo> GetFnValidityInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_VALIDITY);
        _kkt.fnQueryData();

        return _requestService.GetData<FnValidityInfo>();
    }

    /// <inheritdoc />
    public KktResponse<uint> GetFnRemainingDays(DateTime date)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_VALIDITY_DAYS);
        _kkt.setParam(Constants.LIBFPTR_PARAM_DATE_TIME, date);
        _kkt.fnQueryData();

        return _requestService.GetDataByConstant<uint>(Constants.LIBFPTR_PARAM_FN_DAYS_REMAIN);
    }

    /// <inheritdoc />
    public KktResponse<OfdError> GetOfdErrors()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_ERRORS);
        _kkt.fnQueryData();

        return _requestService.GetData<OfdError>();
    }

    /// <inheritdoc />
    public KktResponse<OfdReceipt> GetOfdReceipt(int receiptNumber)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_TICKET_BY_DOC_NUMBER);
        _kkt.setParam(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, receiptNumber);
        _kkt.fnQueryData();

        return _requestService.GetData<OfdReceipt>();
    }
    
    /// <inheritdoc />
    public KktResponse<FiscalDocumentInfo> GetFiscalDocumentInfo(int receiptNumber)
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_DOCUMENT_BY_NUMBER);
        _kkt.setParam(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER, receiptNumber);
        _kkt.fnQueryData();
        
        return _requestService.GetData<FiscalDocumentInfo>();
    }

    /// <inheritdoc />
    public KktResponse<IsmExchangeStatusInfo> GetIsmExchangeStatusInfo()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_ISM_EXCHANGE_STATUS);
        _kkt.fnQueryData();

        return _requestService.GetData<IsmExchangeStatusInfo>();
    }

    /// <inheritdoc />
    public KktResponse<IsmExchangeError> GetIsmExchangeErrors()
    {
        _kkt.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_ISM_ERRORS);
        _kkt.fnQueryData();
        
        return _requestService.GetData<IsmExchangeError>();
    }
}