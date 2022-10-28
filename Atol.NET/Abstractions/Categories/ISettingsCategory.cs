using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface ISettingsCategory
{
    KktBaseResponse ShowSettingsWindow(IntPtr descriptor);
}