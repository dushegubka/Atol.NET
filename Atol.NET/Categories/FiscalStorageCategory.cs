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

        return _requestService.GetDataByConstant<uint>(Constants.LIBFPTR_PARAM_DOCUMENTS_COUNT, typeof(int));
    }
}