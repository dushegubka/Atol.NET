using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Atol.NET.Abstractions;
using Microsoft.Win32;

namespace Atol.NET;

public class KktDriver : IKktDriver, IDisposable
{
    private readonly Encoding _encoding;
    private readonly int _symbolSize;
    private IntPtr _mHandle = IntPtr.Zero;

    public KktDriver()
    {
        _symbolSize = GetOsSymbolSize();
        _encoding = GetDefaultEncoding();

        InitializeDriver(null);

        switch (Create(out _mHandle))
        {
            case -2:
                throw new ArgumentException("Invalind [id] format");
            case 0:
                break;
            default:
                throw new Exception("Can't create driver handle");
        }
    }

    public KktDriver(string libraryPath)
    {
        _symbolSize = GetOsSymbolSize();
        _encoding = GetDefaultEncoding();

        InitializeDriver(libraryPath);

        switch (Create(out _mHandle))
        {
            case -2:
                throw new ArgumentException("Invalind [id] format");
            case 0:
                break;
            default:
                throw new Exception("Can't create driver handle");
        }
    }

    public KktDriver(string id, string libraryPath)
    {
        _symbolSize = GetOsSymbolSize();
        _encoding = GetDefaultEncoding();

        InitializeDriver(libraryPath);

        switch (CreateWithId(out _mHandle, _encoding.GetBytes(id)))
        {
            case -2:
                throw new ArgumentException("Invalind [id] format");
            case 0:
                break;
            default:
                throw new Exception("Can't create driver handle");
        }
    }

    public void Dispose()
    {
        Destroy();
    }

    public void Destroy()
    {
        if (!(_mHandle == IntPtr.Zero))
            return;

        Destroy(out _mHandle);
    }

    public string Version()
    {
        return Marshal.PtrToStringAnsi(GetVersionString())!;
    }

    public int LogWrite(string tag, int level, string message)
    {
        return LogWriteEx(_mHandle, GetBytes(tag), level, GetBytes(message));
    }

    public int ChangeLabel(string label)
    {
        throw new NotImplementedException();
    }

    public int ShowProperties(int parentType, IntPtr parent)
    {
        return ShowProperties(_mHandle, parentType, parent);
    }

    public bool IsOpened()
    {
        return IsOpened(_mHandle);
    }

    public int ErrorCode()
    {
        return ErrorCode(_mHandle);
    }

    public string ErrorDescription()
    {
        var bufferSize = 128;
        var buffer = new byte[_symbolSize * bufferSize];

        var result = ErrorDescription(_mHandle, buffer, bufferSize);

        if (result > bufferSize)
        {
            bufferSize = result;
            buffer = new byte[_symbolSize * result];
            ErrorDescription(_mHandle, buffer, bufferSize);
        }

        return GetString(buffer);
    }

    public void ResetError()
    {
        ResetError(_mHandle);
    }

    public int SetSettings(string settings)
    {
        return SetSettings(_mHandle, GetBytes(settings));
    }

    public string GetSettings()
    {
        var bufferSize = 128;
        var buffer = new byte[_symbolSize * bufferSize];

        var settings = GetSettings(_mHandle, buffer, bufferSize);

        if (settings > bufferSize)
        {
            bufferSize = settings;
            buffer = new byte[_symbolSize * settings];
            GetSettings(_mHandle, buffer, bufferSize);
        }

        return _encoding.GetString(buffer, 0, settings * _symbolSize).TrimEnd(new char[1]);
    }

    public void SetSingleSetting(string key, string setting)
    {
        SetSingleSetting(_mHandle, _encoding.GetBytes(key), _encoding.GetBytes(setting));
    }

    public string GetSingleSetting(string key)
    {
        var bufferSize = 128;
        var buffer = new byte[_symbolSize * bufferSize];
        var singleSetting = GetSingleSetting(_mHandle, _encoding.GetBytes(key), buffer, bufferSize);

        if (singleSetting > bufferSize)
        {
            bufferSize = singleSetting;
            buffer = new byte[_symbolSize * singleSetting];
            GetSingleSetting(_mHandle, _encoding.GetBytes(key), buffer, bufferSize);
        }

        return _encoding.GetString(buffer, 0, singleSetting * _symbolSize).TrimEnd(new char[1]);
    }

    public void SetParam(int paramId, uint value)
    {
        SetParamInt(_mHandle, paramId, value);
    }

    public void SetParam(int paramId, bool value)
    {
        SetParamBool(_mHandle, paramId, value);
    }

    public void SetParam(int paramId, double value)
    {
        SetParamDouble(_mHandle, paramId, value);
    }

    public void SetParam(int paramId, byte[] value)
    {
        SetParamByteArray(_mHandle, paramId, value, value.Length);
    }

    public void SetParam(int paramId, DateTime value)
    {
        SetParamDateTime(_mHandle, paramId, value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
    }

    public void SetParam(int paramId, string value)
    {
        SetParamString(_mHandle, paramId, GetBytes(value));
    }

    public void SetNonPrintableParam(int paramId, uint value)
    {
        SetNonPrintableParamInt(_mHandle, paramId, value);
    }

    public void SetNonPrintableParam(int paramId, bool value)
    {
        SetNonPrintableParamBool(_mHandle, paramId, value);
    }

    public void SetNonPrintableParam(int paramId, double value)
    {
        SetNonPrintableParamDouble(_mHandle, paramId, value);
    }

    public void SetNonPrintableParam(int paramId, byte[] value)
    {
        SetNonPrintableParamByteArray(_mHandle, paramId, value, value.Length);
    }

    public void SetNonPrintableParam(int paramId, DateTime value)
    {
        SetNonPrintableParamDateTime(_mHandle, paramId, value.Year, value.Month, value.Day, value.Hour, value.Minute,
            value.Second);
    }

    public void SetNonPrintableParam(int paramId, string value)
    {
        SetNonPrintableParamString(_mHandle, paramId, GetBytes(value));
    }

    public void SetUserParam(int paramId, uint value)
    {
        SetUserParamInt(_mHandle, paramId, value);
    }

    public void SetUserParam(int paramId, bool value)
    {
        SetUserParamBool(_mHandle, paramId, value);
    }

    public void SetUserParam(int paramId, double value)
    {
        SetUserParamDouble(_mHandle, paramId, value);
    }

    public void SetUserParam(int paramId, byte[] value)
    {
        SetUserParamByteArray(_mHandle, paramId, value, value.Length);
    }

    public void SetUserParam(int paramId, DateTime value)
    {
        SetUserParamDateTime(_mHandle, paramId, value.Year, value.Month, value.Day, value.Hour, value.Minute,
            value.Second);
    }

    public void SetUserParam(int paramId, string value)
    {
        SetUserParamString(_mHandle, paramId, GetBytes(value));
    }

    public uint GetParamInt(int paramId)
    {
        return GetParamInt(_mHandle, paramId);
    }

    public bool GetParamBool(int paramId)
    {
        return GetParamBool(_mHandle, paramId);
    }

    public double GetParamDouble(int paramId)
    {
        return GetParamDouble(_mHandle, paramId);
    }

    public byte[] GetParamByteArray(int paramId)
    {
        var bufferSize = 128;
        var buffer = new byte[bufferSize];
        var paramByteArray = GetParamByteArray(_mHandle, paramId, buffer, bufferSize);

        if (paramByteArray > bufferSize)
        {
            bufferSize = paramByteArray;
            buffer = new byte[bufferSize];
            GetParamByteArray(_mHandle, paramId, buffer, bufferSize);
        }

        return buffer;
    }

    public DateTime GetParamDateTime(int paramId)
    {
        GetParamDateTime(
            _mHandle,
            paramId,
            out var year,
            out var month,
            out var day,
            out var hour,
            out var minute,
            out var second);

        return new DateTime(year.ToInt32(), month.ToInt32(), day.ToInt32(), hour.ToInt32(), minute.ToInt32(),
            second.ToInt32());
    }

    public string GetParamString(int paramId)
    {
        var bufferSize = 128;
        var buffer = new byte[_symbolSize * bufferSize];
        var paramString = GetParamString(_mHandle, paramId, buffer, bufferSize);

        if (paramString > bufferSize)
        {
            bufferSize = paramString;
            buffer = new byte[_symbolSize * paramString];
            GetParamString(_mHandle, paramId, buffer, bufferSize);
        }

        return _encoding.GetString(buffer, 0, paramString * _symbolSize).TrimEnd(new char[1]);
    }

    public int ApplySingleSettings()
    {
        return ApplySingleSettings(_mHandle);
    }

    public int Open()
    {
        return Open(_mHandle);
    }

    public int Close()
    {
        return Close(_mHandle);
    }

    public int ResetParams()
    {
        return ResetParams(_mHandle);
    }

    public int RunCommand()
    {
        return RunCommand(_mHandle);
    }

    public int Beep()
    {
        return Beep(_mHandle);
    }

    public int OpenDrawer()
    {
        return OpenDrawer(_mHandle);
    }

    public int Cut()
    {
        return Cut(_mHandle);
    }

    public int DevicePoweroff()
    {
        return DevicePoweroff(_mHandle);
    }

    public int DeviceReboot()
    {
        return DeviceReboot(_mHandle);
    }

    public int OpenShift()
    {
        return OpenShift(_mHandle);
    }

    public int ResetSummary()
    {
        return ResetSummary(_mHandle);
    }

    public int InitDevice()
    {
        return InitDevice(_mHandle);
    }

    public int QueryData()
    {
        return QueryData(_mHandle);
    }

    public int CashIncome()
    {
        return CashIncome(_mHandle);
    }

    public int CashOutcome()
    {
        return CashOutcome(_mHandle);
    }

    public int OpenReceipt()
    {
        return OpenReceipt(_mHandle);
    }

    public int CancelReceipt()
    {
        return CancelReceipt(_mHandle);
    }

    public int CloseReceipt()
    {
        return CloseReceipt(_mHandle);
    }

    public int CheckDocumentClosed()
    {
        return CheckDocumentClosed(_mHandle);
    }

    public int ReceiptTotal()
    {
        return ReceiptTotal(_mHandle);
    }

    public int ReceiptTax()
    {
        return ReceiptTax(_mHandle);
    }

    public int Registration()
    {
        return Registration(_mHandle);
    }

    public int Payment()
    {
        return Payment(_mHandle);
    }

    public int Report()
    {
        return Report(_mHandle);
    }

    public int PrintText()
    {
        return PrintText(_mHandle);
    }

    public int PrintCliche()
    {
        return PrintCliche(_mHandle);
    }

    public int BeginNonfiscalDocument()
    {
        return BeginNonfiscalDocument(_mHandle);
    }

    public int EndNonfiscalDocument()
    {
        return EndNonfiscalDocument(_mHandle);
    }

    public int PrintBarcode()
    {
        return PrintBarcode(_mHandle);
    }

    public int PrintPicture()
    {
        return PrintPicture(_mHandle);
    }

    public int PrintPictureByNumber()
    {
        return PrintPictureByNumber(_mHandle);
    }

    public int UploadPictureFromFile()
    {
        return UploadPictureFromFile(_mHandle);
    }

    public int ClearPictures()
    {
        return ClearPictures(_mHandle);
    }

    public int WriteDeviceSettingRaw()
    {
        return WriteDeviceSettingRaw(_mHandle);
    }

    public int ReadDeviceSettingRaw()
    {
        return ReadDeviceSettingRaw(_mHandle);
    }

    public int CommitSettings()
    {
        return CommitSettings(_mHandle);
    }

    public int InitSettings()
    {
        return InitSettings(_mHandle);
    }

    public int ResetSettings()
    {
        return ResetSettings(_mHandle);
    }

    public int WriteDateTime()
    {
        return WriteDateTime(_mHandle);
    }

    public int WriteLicense()
    {
        return WriteLicense(_mHandle);
    }

    public int FnOperation()
    {
        return FnOperation(_mHandle);
    }

    public int FnQueryData()
    {
        return FnQueryData(_mHandle);
    }

    public int FnWriteAttributes()
    {
        return FnWriteAttributes(_mHandle);
    }

    public int ExternalDevicePowerOn()
    {
        return ExternalDevicePowerOn(_mHandle);
    }

    public int ExternalDevicePowerOff()
    {
        return ExternalDevicePowerOff(_mHandle);
    }

    public int ExternalDeviceWriteData()
    {
        return ExternalDeviceWriteData(_mHandle);
    }

    public int ExternalDeviceReadData()
    {
        return ExternalDeviceReadData(_mHandle);
    }

    public int OperatorLogin()
    {
        return OperatorLogin(_mHandle);
    }

    public int ProcessJson()
    {
        return ProcessJson(_mHandle);
    }

    public int ReadDeviceSetting()
    {
        return ReadDeviceSetting(_mHandle);
    }

    public int WriteDeviceSetting()
    {
        return WriteDeviceSetting(_mHandle);
    }

    public int BeginReadRecords()
    {
        return BeginReadRecords(_mHandle);
    }

    public int ReadNextRecord()
    {
        return ReadNextRecord(_mHandle);
    }

    public int EndReadRecords()
    {
        return EndReadRecords(_mHandle);
    }

    public int UserMemoryOperation()
    {
        return UserMemoryOperation(_mHandle);
    }

    public int ContinuePrint()
    {
        return ContinuePrint(_mHandle);
    }

    public int InitMgm()
    {
        return InitMgm(_mHandle);
    }

    public int UtilFormTlv()
    {
        return UtilFormTlv(_mHandle);
    }

    public int UtilFormNomenclature()
    {
        return UtilFormNomenclature(_mHandle);
    }

    public int UtilMapping()
    {
        return UtilMapping(_mHandle);
    }

    public int ReadModelFlags()
    {
        return ReadModelFlags(_mHandle);
    }

    public int LineFeed()
    {
        return LineFeed(_mHandle);
    }

    public int FlashFirmware()
    {
        return FlashFirmware(_mHandle);
    }

    public int SoftLockInit()
    {
        return SoftLockInit(_mHandle);
    }

    public int SoftLockQuerySessionCode()
    {
        return SoftLockQuerySessionCode(_mHandle);
    }

    public int SoftLockValidate()
    {
        return SoftLockValidate(_mHandle);
    }

    public int UtilCalcTax()
    {
        return UtilCalcTax(_mHandle);
    }

    public int DownloadPicture()
    {
        return DownloadPicture(_mHandle);
    }

    public int BluetoothRemovePairedDevices()
    {
        return BluetoothRemovePairedDevices(_mHandle);
    }

    public int UtilTagInfo()
    {
        return UtilTagInfo(_mHandle);
    }

    public int UtilContainerVersions()
    {
        return UtilContainerVersions(_mHandle);
    }

    public int ActivateLicenses()
    {
        return ActivateLicenses(_mHandle);
    }

    public int RemoveLicenses()
    {
        return RemoveLicenses(_mHandle);
    }

    public int EnterKeys()
    {
        return EnterKeys(_mHandle);
    }

    public int ValidateKeys()
    {
        return ValidateKeys(_mHandle);
    }

    public int EnterSerialNumber()
    {
        return EnterSerialNumber(_mHandle);
    }

    public int GetSerialNumberRequest()
    {
        return GetSerialNumberRequest(_mHandle);
    }

    public int UploadPixelBuffer()
    {
        return UploadPixelBuffer(_mHandle);
    }

    public int DownloadPixelBuffer()
    {
        return DownloadPixelBuffer(_mHandle);
    }

    public int PrintPixelBuffer()
    {
        return PrintPixelBuffer(_mHandle);
    }

    public int UtilConvertTagValue()
    {
        return UtilConvertTagValue(_mHandle);
    }

    public int ParseMarkingCode()
    {
        return ParseMarkingCode(_mHandle);
    }

    public int CallScript()
    {
        return CallScript(_mHandle);
    }

    public int SetHeaderLines()
    {
        return SetHeaderLines(_mHandle);
    }

    public int SetFooterLines()
    {
        return SetFooterLines(_mHandle);
    }

    public int UploadPictureCliche()
    {
        return UploadPictureCliche(_mHandle);
    }

    public int UploadPictureMemory()
    {
        return UploadPictureMemory(_mHandle);
    }

    public int UploadPixelBufferCliche()
    {
        return UploadPixelBufferCliche(_mHandle);
    }

    public int UploadPixelBufferMemory()
    {
        return UploadPixelBufferMemory(_mHandle);
    }

    public int ExecDriverScript()
    {
        return ExecDriverScript(_mHandle);
    }

    public int UploadDriverScript()
    {
        return UploadDriverScript(_mHandle);
    }

    public int ExecDriverScriptById()
    {
        return ExecDriverScriptById(_mHandle);
    }

    public int WriteUniversalCountersSettings()
    {
        return WriteUniversalCountersSettings(_mHandle);
    }

    public int ReadUniversalCountersSettings()
    {
        return ReadUniversalCountersSettings(_mHandle);
    }

    public int QueryUniversalCountersState()
    {
        return QueryUniversalCountersState(_mHandle);
    }

    public int ResetUniversalCounters()
    {
        return ResetUniversalCounters(_mHandle);
    }

    public int CacheUniversalCounters()
    {
        return CacheUniversalCounters(_mHandle);
    }

    public int ReadUniversalCounterSum()
    {
        return ReadUniversalCounterSum(_mHandle);
    }

    public int ReadUniversalCounterQuantity()
    {
        return ReadUniversalCounterQuantity(_mHandle);
    }

    public int ClearUniversalCountersCache()
    {
        return ClearUniversalCountersCache(_mHandle);
    }

    public int DisableOfdChannel()
    {
        return DisableOfdChannel(_mHandle);
    }

    public int EnableOfdChannel()
    {
        return EnableOfdChannel(_mHandle);
    }

    public int ValidateJson()
    {
        return ValidateJson(_mHandle);
    }

    public int ReflectionCall()
    {
        return ReflectionCall(_mHandle);
    }

    public int GetRemoteServerInfo()
    {
        return GetRemoteServerInfo(_mHandle);
    }

    public int BeginMarkingCodeValidation()
    {
        return BeginMarkingCodeValidation(_mHandle);
    }

    public int CancelMarkingCodeValidation()
    {
        return CancelMarkingCodeValidation(_mHandle);
    }

    public int GetMarkingCodeValidationStatus()
    {
        return GetMarkingCodeValidationStatus(_mHandle);
    }

    public int AcceptMarkingCode()
    {
        return AcceptMarkingCode(_mHandle);
    }

    public int DeclineMarkingCode()
    {
        return DeclineMarkingCode(_mHandle);
    }

    public int UpdateFnmKeys()
    {
        return UpdateFnmKeys(_mHandle);
    }

    public int WriteSalesNotice()
    {
        return WriteSalesNotice(_mHandle);
    }

    public int CheckMarkingCodeValidationsReady()
    {
        return CheckMarkingCodeValidationsReady(_mHandle);
    }

    public int ClearMarkingCodeValidationResult()
    {
        return ClearMarkingCodeValidationResult(_mHandle);
    }

    public int PingMarkingServer()
    {
        return PingMarkingServer(_mHandle);
    }

    public int GetMarkingServerStatus()
    {
        return GetMarkingServerStatus(_mHandle);
    }

    public int IsDriverLocked()
    {
        return IsDriverLocked(_mHandle);
    }

    public int GetLastDocumentJournal()
    {
        return GetLastDocumentJournal(_mHandle);
    }

    private static void InitializeDriver(string path)
    {
        try
        {
            GetVersionString();
            return;
        }
        catch (Exception ex)
        {
            // ignored
        }

        path = path ?? string.Empty;

        if (path.Length == 0)
        {
            if (LoadDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!))
                return;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                path = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\ATOL\\Drivers\\10.0\\KKT",
                    "INSTALL_DIR", null)!;

                path = path != null
                    ? Path.Combine(path, "bin")
                    : throw new FileNotFoundException("Driver not installed");
            }
        }

        if (LoadDriver(path))
            return;

        throw new FileNotFoundException("Driver not found");
    }

    private static bool LoadDriver(string path)
    {
        var os = Environment.OSVersion.Platform;
        try
        {
            return os switch
            {
                PlatformID.Win32NT => LoadWindowsLibrary(path),
                PlatformID.Unix => RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                    ? LoadOSXLibrary(path)
                    : LoadLinuxLibrary(path),
                _ => throw new PlatformNotSupportedException()
            };
        }
        catch (FileNotFoundException e)
        {
            //TODO: добавить лог ошибок
            return false;
        }
    }

    private static string GetLibraryPath(string path, OSPlatform os)
    {
        var libraryNames = new Dictionary<OSPlatform, string>
        {
            { OSPlatform.Windows, "fptr10.dll" },
            { OSPlatform.Linux, "libfptr10.so" },
            { OSPlatform.OSX, "libfptr10.dylib" }
        };

        if (path.Length == 0)
            path = libraryNames[os];
        else if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            path = Path.Combine(path, libraryNames[os]);

        return path;
    }

    private static bool LoadWindowsLibrary(string path)
    {
        var libraryPath = GetLibraryPath(path, OSPlatform.Windows);

        var loadResult = LoadLibrary(libraryPath);

        if (loadResult != IntPtr.Zero)
            return loadResult != IntPtr.Zero;

        LoadLibrary(Path.Combine(Path.GetDirectoryName(path), "msvcp140.dll"));
        loadResult = LoadLibrary(libraryPath);

        return loadResult != IntPtr.Zero;
    }

    private static bool LoadLinuxLibrary(string path)
    {
        var libraryPath = GetLibraryPath(path, OSPlatform.Linux);

        var loadResult = LoadLibrary(libraryPath);

        return loadResult != IntPtr.Zero;
    }

    private static bool LoadOSXLibrary(string path)
    {
        var libraryPath = GetLibraryPath(path, OSPlatform.OSX);

        var loadResult = LoadLibrary(libraryPath);

        return loadResult != IntPtr.Zero;
    }

    private byte[] GetBytes(string input)
    {
        return _encoding.GetBytes(input);
    }

    private string GetString(byte[] input)
    {
        return _encoding.GetString(input);
    }

    private Encoding GetDefaultEncoding()
    {
        return Environment.OSVersion.Platform switch
        {
            PlatformID.Win32NT => Encoding.Unicode,
            PlatformID.Unix => Encoding.UTF32,
            _ => throw new PlatformNotSupportedException()
        };
    }

    private int GetOsSymbolSize()
    {
        return Environment.OSVersion.Platform switch
        {
            PlatformID.Win32NT => 2,
            PlatformID.Unix => 4,
            _ => throw new PlatformNotSupportedException()
        };
    }

    #region DLL Imports

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr LoadLibrary(string path);

    [DllImport("libdl.so.2", EntryPoint = "dlopen")]
    private static extern IntPtr DLopenLinux(string lpPathName, int flags);

    [DllImport("libdl", EntryPoint = "dlopen")]
    private static extern IntPtr DLopenOSX(string lpPathName, int flags);

    [DllImport("fptr10", EntryPoint = "libfptr_get_version_string", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr GetVersionString();

    [DllImport("fptr10", EntryPoint = "libfptr_create", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Create(out IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_create_with_id", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CreateWithId(out IntPtr handle, byte[] id);

    [DllImport("fptr10", EntryPoint = "libfptr_destroy", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Destroy(out IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_log_write_ex", CallingConvention = CallingConvention.Cdecl)]
    private static extern int LogWriteEx(
        IntPtr handle,
        byte[] tag,
        int level,
        byte[] message);

    [DllImport("fptr10", EntryPoint = "libfptr_change_label", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ChangeLabel(IntPtr handle, byte[] label);

    [DllImport("fptr10", EntryPoint = "libfptr_show_properties", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ShowProperties(IntPtr handle, int parentType, IntPtr parent);

    [DllImport("fptr10", EntryPoint = "libfptr_is_opened", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool IsOpened(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_error_code", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ErrorCode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_error_description", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ErrorDescription(IntPtr handle, byte[] value, int size);

    [DllImport("fptr10", EntryPoint = "libfptr_reset_error", CallingConvention = CallingConvention.Cdecl)]
    private static extern void ResetError(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_set_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SetSettings(IntPtr handle, byte[] settings);

    [DllImport("fptr10", EntryPoint = "libfptr_get_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetSettings(IntPtr handle, byte[] value, int size);

    [DllImport("fptr10", EntryPoint = "libfptr_set_single_setting", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetSingleSetting(
        IntPtr handle,
        byte[] key,
        byte[] setting);

    [DllImport("fptr10", EntryPoint = "libfptr_get_single_setting", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetSingleSetting(
        IntPtr handle,
        byte[] key,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamInt(IntPtr handle, int paramId, uint value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_bool", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamBool(IntPtr handle, int paramId, bool value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_double", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamDouble(IntPtr handle, int paramId, double value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_bytearray", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamByteArray(
        IntPtr handle,
        int paramId,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_datetime", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamDateTime(
        IntPtr handle,
        int paramId,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second);

    [DllImport("fptr10", EntryPoint = "libfptr_set_param_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetParamString(IntPtr handle, int paramId, byte[] value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_int",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamInt(
        IntPtr handle,
        int paramId,
        uint value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_bool",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamBool(
        IntPtr handle,
        int paramId,
        bool value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_double",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamDouble(
        IntPtr handle,
        int paramId,
        double value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_bytearray",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamByteArray(
        IntPtr handle,
        int paramId,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_datetime",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamDateTime(
        IntPtr handle,
        int paramId,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second);

    [DllImport("fptr10", EntryPoint = "libfptr_set_non_printable_param_str",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetNonPrintableParamString(
        IntPtr handle,
        int paramId,
        byte[] value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamInt(IntPtr handle, int paramId, uint value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_bool", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamBool(IntPtr handle, int paramId, bool value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_double", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamDouble(
        IntPtr handle,
        int paramId,
        double value);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_bytearray", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamByteArray(
        IntPtr handle,
        int paramId,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_datetime", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamDateTime(
        IntPtr handle,
        int paramId,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second);

    [DllImport("fptr10", EntryPoint = "libfptr_set_user_param_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern void SetUserParamString(IntPtr handle, int paramId, byte[] value);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_int", CallingConvention = CallingConvention.Cdecl)]
    private static extern uint GetParamInt(IntPtr handle, int paramId);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_bool", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool GetParamBool(IntPtr handle, int paramId);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_double", CallingConvention = CallingConvention.Cdecl)]
    private static extern double GetParamDouble(IntPtr handle, int paramId);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_bytearray", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetParamByteArray(
        IntPtr handle,
        int paramId,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_datetime", CallingConvention = CallingConvention.Cdecl)]
    private static extern void GetParamDateTime(
        IntPtr handle,
        int paramId,
        out IntPtr year,
        out IntPtr month,
        out IntPtr day,
        out IntPtr hour,
        out IntPtr minute,
        out IntPtr second);

    [DllImport("fptr10", EntryPoint = "libfptr_get_param_str", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetParamString(
        IntPtr handle,
        int paramId,
        byte[] value,
        int size);

    [DllImport("fptr10", EntryPoint = "libfptr_apply_single_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ApplySingleSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_open", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Open(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_close", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Close(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_reset_params", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ResetParams(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_run_command", CallingConvention = CallingConvention.Cdecl)]
    private static extern int RunCommand(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_beep", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Beep(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_open_drawer", CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpenDrawer(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cut", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Cut(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_device_poweroff", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DevicePoweroff(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_device_reboot", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DeviceReboot(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_open_shift", CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpenShift(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_reset_summary", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ResetSummary(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_init_device", CallingConvention = CallingConvention.Cdecl)]
    private static extern int InitDevice(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_query_data", CallingConvention = CallingConvention.Cdecl)]
    private static extern int QueryData(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cash_income", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CashIncome(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cash_outcome", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CashOutcome(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_open_receipt", CallingConvention = CallingConvention.Cdecl)]
    private static extern int OpenReceipt(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cancel_receipt", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CancelReceipt(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_close_receipt", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CloseReceipt(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_check_document_closed", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CheckDocumentClosed(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_receipt_total", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReceiptTotal(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_receipt_tax", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReceiptTax(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_registration", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Registration(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_payment", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Payment(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_report", CallingConvention = CallingConvention.Cdecl)]
    private static extern int Report(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_text", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintText(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_cliche", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintCliche(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_begin_nonfiscal_document", CallingConvention = CallingConvention.Cdecl)]
    private static extern int BeginNonfiscalDocument(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_end_nonfiscal_document", CallingConvention = CallingConvention.Cdecl)]
    private static extern int EndNonfiscalDocument(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_barcode", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintBarcode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_picture", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintPicture(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_picture_by_number", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintPictureByNumber(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_picture_from_file", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPictureFromFile(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_clear_pictures", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ClearPictures(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_device_setting_raw", CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteDeviceSettingRaw(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_device_setting_raw", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadDeviceSettingRaw(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_commit_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CommitSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_init_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int InitSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_reset_settings", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ResetSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_date_time", CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteDateTime(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_license", CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteLicense(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_fn_operation", CallingConvention = CallingConvention.Cdecl)]
    private static extern int FnOperation(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_fn_query_data", CallingConvention = CallingConvention.Cdecl)]
    private static extern int FnQueryData(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_fn_write_attributes", CallingConvention = CallingConvention.Cdecl)]
    private static extern int FnWriteAttributes(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_external_device_power_on", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExternalDevicePowerOn(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_external_device_power_off", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExternalDevicePowerOff(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_external_device_write_data",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExternalDeviceWriteData(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_external_device_read_data", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExternalDeviceReadData(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_operator_login", CallingConvention = CallingConvention.Cdecl)]
    private static extern int OperatorLogin(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_process_json", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ProcessJson(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_device_setting", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadDeviceSetting(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_device_setting", CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteDeviceSetting(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_begin_read_records", CallingConvention = CallingConvention.Cdecl)]
    private static extern int BeginReadRecords(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_next_record", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadNextRecord(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_end_read_records", CallingConvention = CallingConvention.Cdecl)]
    private static extern int EndReadRecords(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_user_memory_operation", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UserMemoryOperation(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_continue_print", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ContinuePrint(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_init_mgm", CallingConvention = CallingConvention.Cdecl)]
    private static extern int InitMgm(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_form_tlv", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilFormTlv(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_form_nomenclature", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilFormNomenclature(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_mapping", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilMapping(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_model_flags", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadModelFlags(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_line_feed", CallingConvention = CallingConvention.Cdecl)]
    private static extern int LineFeed(IntPtr haNdle);

    [DllImport("fptr10", EntryPoint = "libfptr_flash_firmware", CallingConvention = CallingConvention.Cdecl)]
    private static extern int FlashFirmware(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_soft_lock_init", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SoftLockInit(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_soft_lock_query_session_code",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int SoftLockQuerySessionCode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_soft_lock_validate", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SoftLockValidate(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_calc_tax", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilCalcTax(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_download_picture", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DownloadPicture(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_bluetooth_remove_paired_devices",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int BluetoothRemovePairedDevices(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_tag_info", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilTagInfo(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_container_versions", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilContainerVersions(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_activate_licenses", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ActivateLicenses(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_remove_licenses", CallingConvention = CallingConvention.Cdecl)]
    private static extern int RemoveLicenses(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_enter_keys", CallingConvention = CallingConvention.Cdecl)]
    private static extern int EnterKeys(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_validate_keys", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ValidateKeys(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_enter_serial_number", CallingConvention = CallingConvention.Cdecl)]
    private static extern int EnterSerialNumber(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_get_serial_number_request", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetSerialNumberRequest(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_pixel_buffer", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPixelBuffer(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_download_pixel_buffer", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DownloadPixelBuffer(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_print_pixel_buffer", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PrintPixelBuffer(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_util_convert_tag_value", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UtilConvertTagValue(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_parse_marking_code", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ParseMarkingCode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_call_script", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CallScript(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_set_header_lines", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SetHeaderLines(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_set_footer_lines", CallingConvention = CallingConvention.Cdecl)]
    private static extern int SetFooterLines(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_picture_cliche", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPictureCliche(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_picture_memory", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPictureMemory(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_pixel_buffer_cliche",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPixelBufferCliche(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_pixel_buffer_memory",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadPixelBufferMemory(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_exec_driver_script", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExecDriverScript(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_upload_driver_script", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UploadDriverScript(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_exec_driver_script_by_id", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ExecDriverScriptById(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_universal_counters_settings",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteUniversalCountersSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_universal_counters_settings",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadUniversalCountersSettings(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_query_universal_counters_state",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int QueryUniversalCountersState(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_reset_universal_counters", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ResetUniversalCounters(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cache_universal_counters", CallingConvention = CallingConvention.Cdecl)]
    private static extern int CacheUniversalCounters(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_universal_counter_sum",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadUniversalCounterSum(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_read_universal_counter_quantity",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadUniversalCounterQuantity(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_clear_universal_counters_cache",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ClearUniversalCountersCache(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_disable_ofd_channel", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DisableOfdChannel(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_enable_ofd_channel", CallingConvention = CallingConvention.Cdecl)]
    private static extern int EnableOfdChannel(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_validate_json", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ValidateJson(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_reflection_call", CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReflectionCall(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_get_remote_server_info", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetRemoteServerInfo(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_begin_marking_code_validation",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int BeginMarkingCodeValidation(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_cancel_marking_code_validation",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int CancelMarkingCodeValidation(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_get_marking_code_validation_status",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetMarkingCodeValidationStatus(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_accept_marking_code", CallingConvention = CallingConvention.Cdecl)]
    private static extern int AcceptMarkingCode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_decline_marking_code", CallingConvention = CallingConvention.Cdecl)]
    private static extern int DeclineMarkingCode(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_update_fnm_keys", CallingConvention = CallingConvention.Cdecl)]
    private static extern int UpdateFnmKeys(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_write_sales_notice", CallingConvention = CallingConvention.Cdecl)]
    private static extern int WriteSalesNotice(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_check_marking_code_validations_ready",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int CheckMarkingCodeValidationsReady(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_clear_marking_code_validation_result",
        CallingConvention = CallingConvention.Cdecl)]
    private static extern int ClearMarkingCodeValidationResult(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_ping_marking_server", CallingConvention = CallingConvention.Cdecl)]
    private static extern int PingMarkingServer(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_get_marking_server_status", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetMarkingServerStatus(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_is_driver_locked", CallingConvention = CallingConvention.Cdecl)]
    private static extern int IsDriverLocked(IntPtr handle);

    [DllImport("fptr10", EntryPoint = "libfptr_get_last_document_journal", CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetLastDocumentJournal(IntPtr handle);

    #endregion
}