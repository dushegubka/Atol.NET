using Atol.NET.Enums;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IShiftCategory
{
    KktBaseResponse OpenShift(string? operatorName, string? operatorInn);
    KktBaseResponse CloseShift(ReportType reportType, bool printReport);
}