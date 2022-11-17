namespace Atol.NET.Abstractions;

public interface IKktDriver
{
    void Destroy();

    string Version();

    int LogWrite(string tag, int level, string message);

    int ChangeLabel(string label);

    int ShowProperties(int parentType, IntPtr parent);

    bool IsOpened();

    int ErrorCode();

    string ErrorDescription();

    void ResetError();

    int SetSettings(string settings);

    string GetSettings();

    void SetSingleSetting(string key, string setting);

    string GetSingleSetting(string key);

    void SetParam(int paramId, uint value);

    void SetParam(int paramId, bool value);

    void SetParam(int paramId, double value);

    void SetParam(int paramId, byte[] value);

    void SetParam(int paramId, DateTime value);

    void SetParam(int paramId, string value);

    void SetParam<TParam, TValue>(TParam paramId, TValue value) where TParam : Enum;

    void SetNonPrintableParam(int paramId, uint value);

    void SetNonPrintableParam(int paramId, bool value);

    void SetNonPrintableParam(int paramId, double value);

    void SetNonPrintableParam(int paramId, byte[] value);

    void SetNonPrintableParam(int paramId, DateTime value);

    void SetNonPrintableParam(int paramId, string value);

    void SetUserParam(int paramId, uint value);

    void SetUserParam(int paramId, bool value);

    void SetUserParam(int paramId, double value);

    void SetUserParam(int paramId, byte[] value);

    void SetUserParam(int paramId, DateTime value);

    void SetUserParam(int paramId, string value);

    uint GetParamInt(int paramId);

    bool GetParamBool(int paramId);

    double GetParamDouble(int paramId);

    byte[] GetParamByteArray(int paramId);

    DateTime GetParamDateTime(int paramId);

    string GetParamString(int paramId);

    int ApplySingleSettings();

    int Open();

    int Close();

    int ResetParams();

    int RunCommand();

    int Beep();

    int OpenDrawer();

    int Cut();

    int DevicePoweroff();

    int DeviceReboot();

    int OpenShift();

    int ResetSummary();

    int InitDevice();

    int QueryData();

    int CashIncome();

    int CashOutcome();

    int OpenReceipt();

    int CancelReceipt();

    int CloseReceipt();

    int CheckDocumentClosed();

    int ReceiptTotal();

    int ReceiptTax();

    int Registration();

    int Payment();

    int Report();

    int PrintText();

    int PrintCliche();

    int BeginNonfiscalDocument();

    int EndNonfiscalDocument();

    int PrintBarcode();

    int PrintPicture();

    int PrintPictureByNumber();

    int UploadPictureFromFile();

    int ClearPictures();

    int WriteDeviceSettingRaw();

    int ReadDeviceSettingRaw();

    int CommitSettings();

    int InitSettings();

    int ResetSettings();

    int WriteDateTime();

    int WriteLicense();

    int FnOperation();

    int FnQueryData();

    int FnWriteAttributes();

    int ExternalDevicePowerOn();

    int ExternalDevicePowerOff();

    int ExternalDeviceWriteData();

    int ExternalDeviceReadData();

    int OperatorLogin();

    int ProcessJson();

    int ReadDeviceSetting();

    int WriteDeviceSetting();

    int BeginReadRecords();

    int ReadNextRecord();

    int EndReadRecords();

    int UserMemoryOperation();

    int ContinuePrint();

    int InitMgm();

    int UtilFormTlv();

    int UtilFormNomenclature();

    int UtilMapping();

    int ReadModelFlags();

    int LineFeed();

    int FlashFirmware();

    int SoftLockInit();

    int SoftLockQuerySessionCode();

    int SoftLockValidate();

    int UtilCalcTax();

    int DownloadPicture();

    int BluetoothRemovePairedDevices();

    int UtilTagInfo();

    int UtilContainerVersions();

    int ActivateLicenses();

    int RemoveLicenses();

    int EnterKeys();

    int ValidateKeys();

    int EnterSerialNumber();

    int GetSerialNumberRequest();

    int UploadPixelBuffer();

    int DownloadPixelBuffer();

    int PrintPixelBuffer();

    int UtilConvertTagValue();

    int ParseMarkingCode();

    int CallScript();

    int SetHeaderLines();

    int SetFooterLines();

    int UploadPictureCliche();

    int UploadPictureMemory();

    int UploadPixelBufferCliche();

    int UploadPixelBufferMemory();

    int ExecDriverScript();

    int UploadDriverScript();

    int ExecDriverScriptById();

    int WriteUniversalCountersSettings();

    int ReadUniversalCountersSettings();

    int QueryUniversalCountersState();

    int ResetUniversalCounters();

    int CacheUniversalCounters();

    int ReadUniversalCounterSum();

    int ReadUniversalCounterQuantity();

    int ClearUniversalCountersCache();

    int DisableOfdChannel();

    int EnableOfdChannel();

    int ValidateJson();

    int ReflectionCall();

    int GetRemoteServerInfo();

    int BeginMarkingCodeValidation();

    int CancelMarkingCodeValidation();

    int GetMarkingCodeValidationStatus();

    int AcceptMarkingCode();

    int DeclineMarkingCode();

    int UpdateFnmKeys();

    int WriteSalesNotice();

    int CheckMarkingCodeValidationsReady();

    int ClearMarkingCodeValidationResult();

    int PingMarkingServer();

    int GetMarkingServerStatus();

    int IsDriverLocked();

    int GetLastDocumentJournal();
}