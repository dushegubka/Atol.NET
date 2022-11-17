using Atol.NET.Abstractions;
using Atol.NET.Abstractions.Categories;
using Atol.NET.Enums;
using Atol.NET.Models;
using Atol.NET.Models.Responses;

namespace Atol.NET.Categories;

public class FiscalStorageCategory : IFiscalStorageCategory
{
    private readonly IKktDriver _kkt;
    private readonly IKktRequestService _requestService;

    public FiscalStorageCategory(
        IKktDriver kkt,
        IKktRequestService requestService)
    {
        _kkt = kkt;
        _requestService = requestService;
    }

    /// <inheritdoc />
    public KktResponse<FiscalStorageInfo> GetFiscalStorageInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.FnInfo);
        _kkt.FnQueryData();

        return _requestService.GetData<FiscalStorageInfo>();
    }

    /// <inheritdoc />
    public KktResponse<LastReceiptInfo> GetLastReceiptInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.LastReceipt);
        _kkt.FnQueryData();

        return _requestService.GetData<LastReceiptInfo>();
    }

    /// <inheritdoc />
    public KktResponse<LastDocumentInfo> GetLastDocumentInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.LastDocument);
        _kkt.FnQueryData();

        return _requestService.GetData<LastDocumentInfo>();
    }

    /// <inheritdoc />
    public KktResponse<ShiftInfo> GetShiftInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.Shift);
        _kkt.FnQueryData();

        return _requestService.GetData<ShiftInfo>();
    }

    /// <inheritdoc />
    public KktResponse<uint> GetFiscalDocumentsCount()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.DocumentsCountInShift);
        _kkt.FnQueryData();

        return _requestService.GetDataByConstant<uint>(Parameter.DocumentsCount);
    }

    /// <inheritdoc />
    public KktResponse<FfdVersionsInfo> GetFfdVersionsInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.FfdVersions);
        _kkt.FnQueryData();

        return _requestService.GetData<FfdVersionsInfo>();
    }

    /// <inheritdoc />
    public KktResponse<FnValidityInfo> GetFnValidityInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.Validity);
        _kkt.FnQueryData();

        return _requestService.GetData<FnValidityInfo>();
    }

    /// <inheritdoc />
    public KktResponse<uint> GetFnRemainingDays(DateTime date)
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.ValidityDays);
        _kkt.SetParam(Parameter.DataType, date);
        _kkt.FnQueryData();

        return _requestService.GetDataByConstant<uint>(Parameter.FnDaysRemain);
    }

    /// <inheritdoc />
    public KktResponse<OfdError> GetOfdErrors()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.Errors);
        _kkt.FnQueryData();

        return _requestService.GetData<OfdError>();
    }

    /// <inheritdoc />
    public KktResponse<OfdReceipt> GetOfdReceipt(int receiptNumber)
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.TicketByDocNumber);
        _kkt.SetParam(Parameter.DocumentNumber, receiptNumber);
        _kkt.FnQueryData();

        return _requestService.GetData<OfdReceipt>();
    }

    /// <inheritdoc />
    public KktResponse<FiscalDocumentInfo> GetFiscalDocumentInfo(int receiptNumber)
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.DocumentByNumber);
        _kkt.SetParam(Parameter.DocumentNumber, receiptNumber);
        _kkt.FnQueryData();

        return _requestService.GetData<FiscalDocumentInfo>();
    }

    /// <inheritdoc />
    public KktResponse<IsmExchangeStatusInfo> GetIsmExchangeStatusInfo()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.IsmExchangeStatus);
        _kkt.FnQueryData();

        return _requestService.GetData<IsmExchangeStatusInfo>();
    }

    /// <inheritdoc />
    public KktResponse<IsmExchangeError> GetIsmExchangeErrors()
    {
        _kkt.SetParam(Parameter.FnDataType, FiscalDataType.IsmErrors);
        _kkt.FnQueryData();

        return _requestService.GetData<IsmExchangeError>();
    }
}